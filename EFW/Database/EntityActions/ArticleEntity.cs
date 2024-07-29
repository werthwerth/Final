using Final.EFW.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final.EFW.Database.EntityActions
{
    public class ArticleEntity
    {
        protected internal static Article Add(Core.DB _db, string _subject, string _text, User _user)
        {
            Article _article = new Article();
            _article.Var(_subject, _text, _user);
            _db.context.Articles.Add(_article);
            _db.context.SaveChanges();
            return _article;
        }
        protected internal static Article? GetByid(Core.DB _db, string? _id)
        {
            if (_id == null)
            {
                return null;
            }
            else
            {
                Article? _article = _db.context.Articles.FirstOrDefault(a => a.Id == _id);
                return _article;
            }
        }
        protected internal static void Update(Core.DB _db, Article? _article, string _subject, string _text)
        {
            if (_article != null)
            {
                _article.Text = _text;
                _article.Subject = _subject;
                _db.context.Articles.Update(_article);
                _db.context.SaveChanges();
            }

        }
        protected internal static List<Article> GetAll(Core.DB _db)
        {
            return _db.context.Articles.ToList();
        }
        protected internal static void DeleteById(Core.DB _db, string? _id)
        {
            if (_id != null)
            {
                _db.context.Articles.Where(x => x.Id == _id).ExecuteDelete();
                _db.context.SaveChanges();
            }
        }
    }
}