using Final.EFW.Database.EntityActions;
using Final.EFW.Database;
using static Final.EFW.Database.Core;
using Final.EFW.Entities;
using System.Collections;


namespace Final.Models
{
    public class ArticlesAddModel : BaseModel
    {

        public ArticlesAddModel() : base()
        {
            Core.DB _db = new Core.DB();
        }
        public ArticlesAddModel(string _sessionId, DB _db) : base(_sessionId, _db)
        {
            Access = false;
        }

        public void Exec(string _sessionId, DB _db, RouteData _routes, List<Tag> _tagList, string _subject, string _text)
        {
            var _access = AccessScripts.CheckAccess(_db, base.user, _routes);

            var _newArticle = ArticleEntity.Add(_db, _subject, _text, base.user);
            foreach(var _tag in _tagList)
            {
                ArticleTagEntity.Add(_db, _tag, _newArticle);
            }
            var _tags = TagEntity.GetAllTags(_db);
            if (_tags != null)
            {
                TagList = _tags;
        }

            Access = _access;
        }
        public void Exec(string _sessionId, DB _db, RouteData _routes, string _subject, string _text)
        {
            var _access = AccessScripts.CheckAccess(_db, base.user, _routes);

                ArticleEntity.Add(_db, _subject, _text, base.user);
                var _tags = TagEntity.GetAllTags(_db);
                if (_tags != null)
            {
                    TagList = _tags;
            }
  
            Access = _access;
        }
        public bool Access { get; set; }
        public List<Tag> TagList { get; set; }
        public override void Init(string _sessionId, DB _db, RouteData _routes)
        {
            this.Init(_sessionId, _db);
            var _access = AccessScripts.CheckAccess(_db, base.user, _routes);

            var _tags = TagEntity.GetAllTags(_db);
            if (_tags != null)
            {
                TagList = _tags;
            }

            Access = _access;
        }
        public override void Exec(string _sessionId, DB _db, RouteData _routes, Hashtable _HashTable)
        {
            Init(_sessionId, _db, _routes);
            var _access = AccessScripts.CheckAccess(_db, base.user, _routes);

            var _tags = TagEntity.GetAllTags(_db);
            if (_tags != null)
            {
                TagList = _tags;
            }

            Access = _access;
            if (isLogged)
            {
                List<Tag> _tagList = new List<Tag>();
                foreach (var _tag in (IFormCollection)_HashTable["form"])
                {
                    if (Guid.TryParse(_tag.Key, out var _out) && _tag.Value[0] == "true")
                    {
                        var _tempTag = TagEntity.GetById(_db, _tag.Key);
                        if (_tempTag != null)
                        {
                            _tagList.Add(_tempTag);
                        }
                    }
                }
                string? ArticleSubject = (string)_HashTable["ArticleSubject"];
                string? ArticleText = (string)_HashTable["ArticleSubject"];
                if (ArticleSubject != null && ArticleText != null)
                {
                    if (_tagList.Count > 0)
                    {
                        Exec(_sessionId, _db, _routes, _tagList, ArticleSubject, ArticleText);
                    }
                    else
                    {
                        Exec(_sessionId, _db, _routes, ArticleSubject, ArticleText);
                    }
                }
                else
                {
                    Init(_sessionId, _db, _routes);
                }
            }
        }
    }
}

