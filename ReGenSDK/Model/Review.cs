using System;

namespace ReGenSDK.Model
{
    public class Review
    {
        public string ReviewId { get; set; }

        public string UserId { get; set; }

        public string RecipeId { get; set; }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }

        public int Rating { get; set; }

        public Review(string reviewId = null, string userId = null, string recipeId = null, string content = null, DateTime timestamp = default(DateTime), int rating = 0)
        {
            ReviewId = reviewId;
            UserId = userId;
            RecipeId = recipeId;
            Content = content;
            Timestamp = timestamp;
            Rating = rating;
        }

        public override string ToString()
        {
            return Content;
        }
    }
}