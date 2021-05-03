using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKS.Models.Post_Models
{
    public class PostListItem
    {
        public int PostId { get; set; }

        [Display(Name="Title")]
        public string PostTitle { get; set; }

        [Display(Name ="Text")]
        public string PostText { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
