using System.Collections.Generic;

namespace ReGenSDK.Model
{
    public class RecipeLite
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}