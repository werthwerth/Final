using Final.EFW.Entities;

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
    }
}
