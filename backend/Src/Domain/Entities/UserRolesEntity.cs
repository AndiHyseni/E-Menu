using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRolesEntity : IdentityUserRole<Guid>
    {
        public override Guid UserId { get; set; } = default;

        public override Guid RoleId { get; set; } = default!;
        public UserEntity User { get; set; }= default!;
        public RoleEntity Role { get; set; } = default!;
    }
}
