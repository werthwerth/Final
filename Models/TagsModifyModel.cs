using Final.EFW.Database.EntityActions;
using Final.EFW.Database;
using static Final.EFW.Database.Core;
using Final.EFW.Entities;

namespace Final.Models
{
    public class TagsModifyModel : BaseModel
    {
        public TagsModifyModel() : base()
        {
            Core.DB _db = new Core.DB();
        }
        public TagsModifyModel(string _sessionId, DB _db) : base(_sessionId, _db)
        {
            Access = false;
        }
        public TagsModifyModel(string _sessionId, DB _db, RouteData _routes) : base(_sessionId, _db)
        {
            Access = AccessScripts.CheckAccess(_db, base.user, _routes);
            if (_routes.Values["id"].ToString() != null)
            {
                ContextTag = TagEntity.GetById(_db, _routes.Values["id"].ToString());
            }
        }
        public TagsModifyModel(string _sessionId, DB _db, string _tagText, RouteData _routes) : base(_sessionId, _db)
        {
            if (AccessScripts.CheckAccess(_db, base.user, _routes))
            {
                TagEntity.UpdateById(_db, _routes.Values["id"].ToString(), _tagText);
                ContextTag = TagEntity.GetById(_db, _routes.Values["id"].ToString());
            }
            Access = AccessScripts.CheckAccess(_db, base.user, _routes);
        }
        public bool Access { get; set; }
        public Tag? ContextTag { get; set; }
    }
}
