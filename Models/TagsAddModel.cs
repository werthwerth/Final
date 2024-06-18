using Final.EFW.Database;
using Final.EFW.Database.EntityActions;
using System.Collections;
using static Final.EFW.Database.Core;

namespace Final.Models
{
    public class TagsAddModel : BaseModel
    {
        public TagsAddModel() : base()
        {
            Core.DB _db = new Core.DB();
        }
        public TagsAddModel(string _sessionId, DB _db) : base(_sessionId, _db) 
        {
            Access = false;
        }
        public TagsAddModel(string _sessionId, DB _db, RouteData _routes) : base(_sessionId, _db)
        {
            Access = AccessScripts.CheckAccess(_db, base.user, _routes);
        }
        public TagsAddModel(string _sessionId, DB _db, string _tagName, RouteData _routes) : base(_sessionId, _db) 
        {
            if (AccessScripts.CheckAccess(_db, base.user, _routes))
            {
                TagEntity.Add(base.user, _db, _tagName);
            }
            Access = AccessScripts.CheckAccess(_db, base.user, _routes);
        }
        public override void Exec(string _sessionId, DB _db, RouteData _routes, Hashtable _HashTable)
        {
            Init(_sessionId, _db);
            if (AccessScripts.CheckAccess(_db, base.user, _routes))
            {
                RoleEntity.Add(_HashTable["tagName"].ToString(), _db);
            }
            Access = AccessScripts.CheckAccess(_db, user, _routes);
        }
    }
}