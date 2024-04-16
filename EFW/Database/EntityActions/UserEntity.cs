using Final.EFW.Database;
using System.Xml.Linq;
using Final;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Identity;
using Final.EFW.Entities;
namespace Final.EFW.Database.EntityActions
{
    internal class UserEntity
    {      
        protected internal static bool Check(string _login, Core.DB _db)
        {
            User? _user = _db.context.Users.FirstOrDefault(x => x.Login == _login);
            if (_user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected internal static void Register(string _login, Core.DB _db, string _password, string? _salt, string _firstName, string _lastName, string _email)
        {
            User _user = new User();
            _user.Var(_login, _email, _password, _salt, _firstName, _lastName);
            _db.context.Users.Add(_user);
            _db.context.SaveChanges();
        }
        protected internal static User? GetByLogin(string _login, Core.DB _db)
        {
            User? _user = _db.context.Users.FirstOrDefault(x => x.Login == _login);
            return _user;
        }
    }
}
