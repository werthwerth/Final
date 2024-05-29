using Final.EFW.Entities;
using static Final.EFW.Database.Core;
namespace Final.EFW.Database.EntityActions
{
    internal class PageEntity
    {
        protected internal static Page? Get(DB _db, string _controllerName, string _actionName)
        {
            Page? _page = _db.context.Pages.FirstOrDefault(x => x.Controller == _controllerName && x.Action == _actionName);
            return _page;
        }
        protected internal static bool Check(DB _db, string _controllerName, string _actionName)
        {
            if (_db.context.Pages.Where(x => x.Controller == _controllerName && x.Action == _actionName).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected internal static void Add(DB _db, string _controllerName, string _actionName)
        {
            if (!Check(_db, _controllerName, _actionName))
            {
                Page _page = new Page();
                _page.Var(_controllerName, _actionName);
                _db.context.Pages.Add(_page);
                _db.context.SaveChanges();
            }
        }
    }
}