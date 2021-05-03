using AKKS.Data;
using AKKS.Models.Post_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKS.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool PostTitleValidator(string postTitle)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts.Where(e => e.PostTitle == postTitle && e.UserId == _userId);
                if (query.Any())
                {
                    return true;
                }
                return false;
            }
        }

        public bool CreatePost(PostCreate model)
        {
            var titleValidatorResult = PostTitleValidator(model.PostTitle);
            if (titleValidatorResult)
            {
                return false;
            }

            else
            {
                var entity = new Post()
                {
                    UserId = _userId,
                    PostTitle = model.PostTitle,
                    PostText = model.PostText,
                };
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Posts.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts.Where(e => e.UserId == _userId).Select(e => new PostListItem
                {
                    PostId = e.PostId,
                    PostTitle = e.PostTitle,
                    PostText = e.PostText,
                    CreatedUtc = e.CreatedUtc
                });
                return query.ToArray();
                                
                               
            }
        }
    }
}
