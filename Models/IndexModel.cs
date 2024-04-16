using Final.EFW.Database;
using Final.EFW.Entities;
using Final.Static.EntitiesScripts;
using static Final.EFW.Database.Core;

namespace Final.Models
{
    public class IndexModel : BaseModel
    {
        public IndexModel() : base() 
        {
            Core.DB _db = new Core.DB();
        }
        public IndexModel(string _sessionId, DB _db) : base(_sessionId, _db) { }
    }
}
