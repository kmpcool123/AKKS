using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKS.Models
{
    class PostReply
    {
        public int NoteId { get; set; }
        [Required]
        public string ReplyText { get; set; }
    }
}
