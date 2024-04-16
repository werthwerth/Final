using System.ComponentModel.DataAnnotations;
using Final.Static.EntitiesScripts;

namespace Final.EFW.Entities
{
    public class User
    {
        protected internal void Var(string _Login, string _Email, string _PasswordHash, string _FirstName, string _LastName, Role? _role = null)
        {
            Login = _Login;
            Email = _Email;
            PasswordHash = _PasswordHash;
            FirstName = _FirstName;
            LastName = _LastName;
            if (_role != null)
            {
                Role = _role;
            }
            
        }
        [Key]
        public string? Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Login { get; set; }
        public string? PasswordHash { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? Email { get; set; }
        public Role? Role { get; set; }
    }
}