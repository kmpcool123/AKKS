using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKS.Data
{
    class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        [ForeignKey(nameof(CommentID))]
        public int CommentID { get; set; }
        //public virtual List<Comment> Comment { get; set; }

        [Required]
        public string ReplyText { get; set; }

        public Guid UserId { get; set; }
    }
}
