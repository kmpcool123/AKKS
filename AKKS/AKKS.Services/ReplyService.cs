using AKKS.Data;
using AKKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKS.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        //api/post/reply
        public bool CreateReply(PostReply text, Comment comment)
        {
            var entity =
                new Reply()
                {
                    UserId = _userId,
                    ReplyText = text.ReplyText
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Reply> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new Reply
                        {
                            UserId = _userId,
                            ReplyText = e.ReplyText
                        });
                return query.ToArray();
            }
        }
    }
}
