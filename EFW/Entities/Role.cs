using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Final.EFW.Entities
{
    public class Role
    {
        protected internal void Var(string _name)
        {
            Name = _name;
        }
        [Key]
        public string? Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Name { get; set; }
    }
}
