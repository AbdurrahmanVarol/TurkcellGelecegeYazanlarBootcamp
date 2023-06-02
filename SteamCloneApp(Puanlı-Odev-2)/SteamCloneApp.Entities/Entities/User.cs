using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Entities.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
