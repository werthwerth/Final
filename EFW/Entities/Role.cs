using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Final.EFW.Entities
{
    public class Role
    {
        protected internal void Var(string _name, int? _acessLevel)
        {
            Name = _name;
            AcessLevel = _acessLevel;
        }
        [Key]
        public string? Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Name { get; set; }
        public int? AcessLevel { get; set; }
    }
}
