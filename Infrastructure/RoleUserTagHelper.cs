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

        public RoleUserTagHelper(RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
        }
    }
}
