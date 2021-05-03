using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKS.Data
{
      public class Post
      {
            [Key]
            public int PostId { get; set; }
            [Required]
            public string PostTitle { get; set; }
            [Required]
            public string PostText { get; set; }

            public Guid UserId { get; set; }
            [Required]
            public DateTimeOffset CreatedUtc { get; set; }
            public DateTimeOffset? ModifiedUtc { get; set; }

            [ForeignKey(nameof(Comment))]
            public int CommentId { get; set; }
            public virtual List<Comment> Comment { get; set; }

           // public virtual List<Like> Like { get; set; }
      }
}
