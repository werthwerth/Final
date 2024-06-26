using Final.EFW.Database.EntityActions;
using Final.EFW.Database;
using static Final.EFW.Database.Core;
using Final.EFW.Entities;

namespace Final.Models
{
    public class ArticlesAddModel : BaseModel
    {

        public ArticlesAddModel() : base()
        {
            Core.DB _db = new Core.DB();
        }
        public ArticlesAddModel(string _sessionId, DB _db) : base(_sessionId, _db)
        {
            Access = false;
        }
        public ArticlesAddModel(string _sessionId, DB _db, RouteData _routes) : base(_sessionId, _db)
        {
            Access = AccessScripts.CheckAccess(_db, base.user, _routes);
            var _tags = TagEntity.GetAllTags(_db);
            if (_tags != null)
            {
                TagList = _tags;
            }
        }
        public ArticlesAddModel(string _sessionId, DB _db, string _tagName, RouteData _routes) : base(_sessionId, _db)
        {
            if (AccessScripts.CheckAccess(_db, base.user, _routes))
            {
                TagEntity.Add(base.user, _db, _tagName);
            }
            Access = AccessScripts.CheckAccess(_db, base.user, _routes);
        }
        public bool Access { get; set; }
        public List<Tag> TagList { get; set; }
    }
}

