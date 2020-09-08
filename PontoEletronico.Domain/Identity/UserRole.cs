using Microsoft.AspNetCore.Identity;

namespace PontoEletronico.Domain.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set; }
        public Role Role { get; set; }

    }
}