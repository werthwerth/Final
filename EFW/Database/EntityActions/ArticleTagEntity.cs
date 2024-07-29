using Final.EFW.Entities;
using Final.EFW.Database;
using static Final.EFW.Database.Core;
using Microsoft.EntityFrameworkCore;

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
        protected internal static List<Tag?>? GetByArticle(DB _db, Article _article)
        {
            List<Tag?>? _return = _db.context.ArticleTags.Where(x => x.Article == _article).Select(x => x.Tag).ToList();
            return _return;
        }
        protected internal static void DeleteAllByAtricle (DB _db, Article _article)
        {
            _db.context.ArticleTags.Where(x => x.Article == _article).ExecuteDelete();
            _db.context.SaveChanges();
        }
        protected internal static int GetCountByTag(DB _db, Tag _tag)
        {
            return _db.context.ArticleTags.Where(x => x.Tag == _tag).Count();
        }
    }
}
