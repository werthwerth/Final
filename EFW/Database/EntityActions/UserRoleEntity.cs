using Final.EFW.Entities;

namespace Final.EFW.Database.EntityActions
{
    public class UserRoleEntity
    {
        protected internal static List<UserRole>? GetByUser (Core.DB _db, User _user)
        {
            List<UserRole>? _userList = _db.context.UserRoles.Where(x => x.User == _user).ToList();
            return _userList;
        }
        protected internal static void AddRoleToUser(Core.DB _db, User _user, Role _role)
        {
            UserRole _userRole = new UserRole();
            _userRole.Var(_user, _role);
            _db.context.Add(_userRole);
            _db.context.SaveChanges();
        }
    }
}
