using Final.EFW.Database;
using Final.EFW.Database.EntityActions;
using Microsoft.AspNetCore.Identity;
using Final.EFW.Entities;
using System.Runtime.CompilerServices;

namespace Final.Static.EntitiesScripts
{
    public class UserScripts
    {
        public static RegistrationResult Register(string _login, Core.DB _db, string _password, string? _salt, string _firstName, string _lastName, string _email, string? _sessionId)
        {
            if (!UserEntity.Check(_login, _db) && _salt != null)
            {
                UserEntity.Register(_login, _db, _password, _salt, _firstName, _lastName, _email);
                RegistrationResult _RegistrationResult = new RegistrationResult(_firstName, _lastName);
                User? _user = UserEntity.GetByLogin(_login, _db);
                if (_sessionId == null)
                {
                    _sessionId = RandomString.Generate();
                }
                if (!SessionScripts.Check(_sessionId, _db, _user))
                {
                    
                    string _newSessionId = SessionScripts.Start(_db, _user);
                    _RegistrationResult.newSessionId = _newSessionId;
                }
                return _RegistrationResult;
            }
            else
            {
                RegistrationResult _RegistrationResult = new RegistrationResult();
                return _RegistrationResult;
            }
        }
    }
    public class RegistrationResult
    {
        public RegistrationResult()
        {
            success = false;
            firstName = "";
            lastName = "";
        }
        public RegistrationResult(string _firstName, string _lastName)
        {
            success = true;
            firstName = _firstName;
            lastName = _lastName;
        }
        public bool success { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string? newSessionId { get; set; }
    }
}
