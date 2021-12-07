using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using GroupProject.Models;

namespace GroupProject.Infrastructure
{
    [HtmlTargetElement("td", Attributes = "identity-role")]
    public class RoleUserTagHelper :TagHelper
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> userManager;


        public RoleUserTagHelper(RoleManager<IdentityRole> roleMgr, UserManager<IdentityUser> userMgr)
        {
            roleManager = roleMgr;
            userManager = userMgr;
        }

        [HtmlAttributeName("identity-role")]
        public string Role { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> names = new List<string>();
            IdentityRole role = await roleManager.FindByIdAsync(Role);
            
            
            if(role != null)
            {
                foreach (var user in userManager.Users)
                {
                    if(user != null && await userManager.IsInRoleAsync(user, role.Name))
                    {
                        names.Add(user.UserName);
                    }
                }
            }
            output.Content.SetContent(names.Count == 0 ? "No Users" : string.Join(", ", names));
        }
    }
}
