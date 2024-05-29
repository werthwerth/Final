using Final.EFW.Database;
using Final.EFW.Database.EntityActions;
using static Final.EFW.Database.Core;

namespace Final.Models
{
    public class RolesAddModel : BaseModel
    {
        public RolesAddModel() : base()
        {
            Core.DB _db = new Core.DB();
        }
        public RolesAddModel(string _sessionId, DB _db) : base(_sessionId, _db)
        {
            Access = false;
        }
        public RolesAddModel(string _sessionId, DB _db, RouteData _routes) : base(_sessionId, _db)
        {
            Access = AccessScripts.CheckAccess(_db, base.user, _routes);
        }
        public RolesAddModel(string _sessionId, DB _db, string _tagName, RouteData _routes) : base(_sessionId, _db)
        {
            if (AccessScripts.CheckAccess(_db, base.user, _routes))
            {
                RoleEntity.Add(_tagName, _db);
            }
            Access = AccessScripts.CheckAccess(_db, base.user, _routes);
        }
        public bool Access { get; set; }
    }
}