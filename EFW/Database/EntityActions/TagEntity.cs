using Final.EFW.Database;
using System.Xml.Linq;
using Final;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Identity;
using Final.EFW.Entities;
using static Final.EFW.Database.Core;
namespace Final.EFW.Database.EntityActions
{
    internal class TagEntity
    {
        protected internal static void Add(User? _user, DB _db, string _tagName)
        {
            if (_user != null)
            {
                int _count = _db.context.Tags.Where(x => x.Text == _tagName).Count();
                if (_count < 1)
                {
                    Tag _tag = new Tag();
                    _tag.Var(_tagName, _user);
                    _db.context.Tags.Add(_tag);
                    _db.context.SaveChanges();
                }
            }
        }
        protected internal static Tag? GetById(DB _db, string _id)
        {
            return _db.context.Tags.FirstOrDefault(x => x.Id == _id);
        }
        protected internal static List<Tag>? GetAllTags(DB _db)
        {
            return _db.context.Tags.ToList();
        }
        protected internal static void UpdateById(DB _db, string _id, string _tagText)
        {
            Tag? _tempTag = _db.context.Tags.FirstOrDefault(x => x.Id == _id);
            if (_tempTag != null)
            {
                _tempTag.Text = _tagText;
                _db.context.Tags.Update(_tempTag);
                _db.context.SaveChanges();
            }
        }
    }
}