using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKS.Data
{
      public class Comment
      {
            [Required]
            public int CommentId { get; set; }

            [Required]
            public string Text { get; set; }

            [Required]
            public Guid AuthorId { get; set; }

            [Display(Name = "Created")]
            public DateTimeOffset CreatedUtc { get; set; }

            [Display(Name = "Modified")]
            public DateTimeOffset? ModifiedUtc { get; set; }

            //  [ForeignKey(nameof(Post))]
            //public int PostId { get; set; }

            // public virtual List<Post> Post { get; set; }

            // public virtual List<Reply> Replies { get; set; } = new List<Reply>();
      }
}

