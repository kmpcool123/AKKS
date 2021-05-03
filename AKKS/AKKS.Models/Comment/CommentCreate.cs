using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKS.Models
{
      public class CommentCreate
      {
            [Required]
            [MaxLength(8000)]
            [Display(Name = "Comment Test")]
            public string Text { get; set; }
      }

}

