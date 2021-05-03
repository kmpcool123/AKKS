using AKKS.Data;
using AKKS.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AKKS.Controllers
{
      [Authorize]
      public class CommentController : ApiController
      {
            private CommentService CreateComment()
            {
                  var userId = Guid.Parse(User.Identity.GetUserId());

                  var categoryService = new CommentService(userId);

                  return categoryService;
            }

            public IHttpActionResult Post(CommentCreate comment)
            {
                  if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                  var pComment = CreateComment();

                  if (!pComment.CreateComment(comment))
                  {
                        return InternalServerError();
                  }

                  return Ok("comment added");
            }

            public CommentDetails Get(int inputId)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =

                              ctx
                              .Comments
                              .Single(e => e.PostId == inputId);
                        return
                              new CommentDetails
                              {
                                    Text = entity.Text,
                                    CreatedUtc = entity.CreatedUtc,
                                    ModifiedUtc = DateTimeOffset.UtcNow
                              };

                  }
            }
      }
}

