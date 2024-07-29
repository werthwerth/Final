

using Final.EFW.Entities;
using System.Security.Cryptography;
using static Final.EFW.Database.Core;

namespace Final.EFW.Database.EntityActions
{
    public class CommentEntity
    {
        protected internal static List<Comment> GetByArticle(DB _db, Article _article)
        {
            return _db.context.Comments.Where(x => x.Article == _article).ToList();
        }
        protected internal static void Add(DB _db, Article _article, User _author, string _text)
        {
            _db.context.Comments.Add(new Comment {  Article = _article, Author = _author , Text = _text});
            _db.context.SaveChanges();
        }
    }
}