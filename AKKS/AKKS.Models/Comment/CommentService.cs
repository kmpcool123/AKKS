using AKKS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKS.Models
{
      public class CommentService
      {
            private Guid _userId;

            public CommentService(Guid userId)
            {
                  _userId = userId;
            }

            public bool CreateComment(CommentCreate model)
            {
                  var entity =

                        new Comment
                        {

                              Text = model.Text
                        };
                  using (var ctx = new ApplicationDbContext())
                  {
                        ctx.Comments.Add(entity);
                        return ctx.SaveChanges() == 1;
                  }
            }

            public CommentDetails GetComment(int postId)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =

                              ctx
                              .Comments
                              .Single(e => e.CommentId == postId);
                        return
                        new CommentDetails
                        {

                              Text = entity.Text,
                              CreatedUtc = entity.CreatedUtc,
                              ModifiedUtc = (DateTimeOffset)entity.ModifiedUtc

                        };
                  }
            }

      }
}
