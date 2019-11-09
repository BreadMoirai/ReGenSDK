namespace ReGenSDK.Model
{
    public class Ingredient
    {
        #region Properties

//        [Required]
//        [StringLength(30, MinimumLength = 1)]
        public string IngredientName { get; set; }

//        [Required]
//        [StringLength(30, MinimumLength = 1)]
        public string IngredientAmount { get; set; }

        #endregion

        public override string ToString()
        {
            return $"{IngredientAmount} {IngredientName}";
        }
    }
}