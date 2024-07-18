using Final.EFW.Entities;
using static Final.EFW.Database.Core;

namespace Final.EFW.Database.EntityActions
{
    public class RoleEntity
    {
        protected internal static void Add(string _name, DB _db)
        {
            Add(_name, _db.context, null);
        }
        protected internal static void Add(string _name, DB _db, string? _description)
        {
            Add(_name, _db.context, _description);
        }
        protected internal static void Add(string _name, ApplicationContext _context, string? _description)
        {
            Role? _role = _context.Roles.FirstOrDefault(x => x.Name == _name) ?? null;
            if (_role == null)
            {
                int? _maxAccessLevel = _context.Roles.Select(x => x.AcessLevel).Max().GetValueOrDefault(0);

                _role = new Role();
                _role.Var(_name, _maxAccessLevel+1, _description);
                _context.Roles.Add(_role);
                _context.SaveChanges();
            }
        }
        protected internal static Role? GetByName(DB _db, string _roleName)
        {
            return _db.context.Roles.FirstOrDefault(x => x.Name == _roleName);
        }
        protected internal static List<Role> GetAll(DB _db)
        {
            return _db.context.Roles.ToList();
        }
    }
}
