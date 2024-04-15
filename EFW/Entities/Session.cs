using System.ComponentModel.DataAnnotations;

namespace Final.EFW.Entities
{
    public class Session
    {
        protected internal void Var(DateTime _ExpirationDate, string _Hash, User _User)
        {
            ExpirationDate = _ExpirationDate;
            Hash = _Hash;
            User = _User;
        }
        [Key]
        public string? Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? Hash { get; set; }
        public User? User { get; set; }
    }
}
