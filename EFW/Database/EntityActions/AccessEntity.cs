using Final.EFW.Entities;

namespace Final.EFW.Database.EntityActions
{
    public class AccessEntity
    {
        protected internal static List<Access> GetByPage(Core.DB _db, Page _page)
        {
            List<Access> _pageAccesses = _db.context.Accesses.Where(x => x.Page == _page).ToList();
            return _pageAccesses;
        }
        protected internal static bool CheckRoleByPageAndRole(Core.DB _db, Page _page, Role _role)
        {
            if (_db.context.Accesses.Where(x => x.Page == _page && x.Role == _role).Count() < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected internal static void Add(Core.DB _db, Page _page, Role _role)
        {
            if (!CheckRoleByPageAndRole(_db, _page, _role))
            {
                Access _access = new Access();
                _access.Var(_page, _role);
                _db.context.Accesses.Add(_access);
                _db.context.SaveChanges();
            }
        }
    }
}
