using Final.EFW.Entities;
using static Final.EFW.Database.Core;

namespace Final.EFW.Database.EntityActions
{
    public class RoleEntity
    {
        protected internal static void Add(string _name, DB _db)
        {
            Add(_name, _db.context);
        }
        protected internal static void Add(string _name, ApplicationContext _context)
        {
            Role? _role = _context.Roles.FirstOrDefault(x => x.Name == _name) ?? null;
            if (_role == null)
            {
                _role = new Role();
                _role.Var(_name);
                _context.Roles.Add(_role);
                _context.SaveChanges();
            }
        }
    }
}
