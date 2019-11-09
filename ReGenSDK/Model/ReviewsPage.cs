using System.Collections.Generic;

namespace ReGenSDK.Model
{
    public class ReviewsPage
    {
//        [Required]
        public IEnumerable<Review> Reviews
        { get; set; }

//        [Required]
        public string NextKey
        { get; set; }
    }
}
