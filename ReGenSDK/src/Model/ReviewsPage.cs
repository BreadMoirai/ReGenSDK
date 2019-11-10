using System.Collections.Generic;
using Newtonsoft.Json;

namespace ReGenSDK.Model
{
    public class ReviewsPage
    {
        public IEnumerable<Review> Reviews
        { get; set; }

        public string NextKey
        { get; set; }

        [JsonIgnore]
        public string RecipeId;
    }
}
