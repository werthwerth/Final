using Final.EFW.Database;
using Final.EFW.Database.EntityActions;
using Final.EFW.Entities;
using Final.Static.EntitiesScripts;
using Microsoft.Extensions.Logging;
using static Final.EFW.Database.Core;

namespace Final.Models
{
    public class TagsAddModel : BaseModel
    {
        public TagsAddModel() : base()
        {
            Core.DB _db = new Core.DB();
        }
        public TagsAddModel(string _sessionId, DB _db) : base(_sessionId, _db) { }
        public TagsAddModel(string _sessionId, DB _db, string _tagName) : base(_sessionId, _db) 
        {
            TagEntity.Add(base.user, _db, _tagName);
        }
    }
}