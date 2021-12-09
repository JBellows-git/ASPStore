using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GroupProject.Models
{
    public class AdminViewModels
    {

        public class RoleEditModel
        {
            public IdentityRole Role { get; set; }
            public IEnumerable<IdentityUser> Members { get; set; }
            public IEnumerable<IdentityUser> NonMembers { get; set; }
        }

        public class RoleModificationModel
        {
            [Required]
            public string RoleName { get; set; }
            public string RoleId { get; set; }
            public string[] IdsToAdd { get; set; }
            public string[] IdsToDelete { get; set; }
        }

    }
}
