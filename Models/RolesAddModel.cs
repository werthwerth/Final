using Final.EFW.Database;
using Final.EFW.Database.EntityActions;
using Final.EFW.Entities;
using Final.Static.EntitiesScripts;
using Microsoft.Extensions.Logging;
using static Final.EFW.Database.Core;

namespace Final.Models
{
    public class RolesAddModel : BaseModel
    {
        public RolesAddModel() : base()
        {
            Core.DB _db = new Core.DB();
        }
        public RolesAddModel(string _sessionId, DB _db) : base(_sessionId, _db) { }
        public RolesAddModel(string _sessionId, DB _db, string _roleName) : base(_sessionId, _db)
        {
            RoleEntity.Add(_roleName, _db);
        }
    }
}