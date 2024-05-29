using Final.EFW.Entities;
using Final.EFW.Database;

namespace Final.EFW.Database.EntityActions
{
    public class ArticleTagEntity
    {
        protected internal static void Add(Core.DB _db, Tag _tag, Article _article)
        {
            ArticleTag articleTag = new ArticleTag();
            articleTag.Var(_article, _tag);
            _db.context.ArticleTags.Add(articleTag);
            _db.context.SaveChanges();
        }
    }
}
