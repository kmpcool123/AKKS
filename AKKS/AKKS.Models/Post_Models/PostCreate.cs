using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKS.Models.Post_Models
{
    public class PostCreate
    {
       
        [Required]
        
        [MaxLength(100, ErrorMessage = "Maximum Post Title length is 100 characters.")]
        [MinLength(1, ErrorMessage = "Please enter at least one character.")]
        [Display(Name = "Post Title")]
        public string PostTitle { get; set; }

        
        [MaxLength(240, ErrorMessage = "Post text is too long; please keep text to less than 240 characters.")]
        [MinLength(1, ErrorMessage = "Please enter at least one character.")]
        [Display(Name = "Text")]
        public string PostText { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
