﻿using Final.EFW.Entities;

namespace Final.EFW.Database.EntityActions
{
    public class UserRoleEntity
    {
        protected internal static List<UserRole>? GetByUser (Core.DB _db, User _user)
        {
            List<UserRole>? _userList = _db.context.UserRoles.Where(x => x.User == _user).ToList();
            return _userList;
        }
        protected internal static void AddRoleToUser(Core.DB _db, User _user, Role _role)
        {
            UserRole _userRole = new UserRole();
            _userRole.Var(_user, _role);
            _db.context.Add(_userRole);
            _db.context.SaveChanges();
        }
        protected internal static List<Role?>? GetRolesByUserId(Core.DB _db, string? _userId)
        {
            if (_userId != null)
            {
                User? _user = new User();
                _user = _db.context.Users.FirstOrDefault(x => x.Id == _userId);
                if (_user != null)
                {
                    List<Role?>? _userRoles = _db.context.UserRoles.Where(x => x.User == _user).Select(x => x.Role).ToList();
                    if (_userRoles != null && _userRoles.Count > 0)
                    {
                        return _userRoles;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
