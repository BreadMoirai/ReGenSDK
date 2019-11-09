using System.Collections.Generic;

namespace ReGenSDK.Model
{
    //[ElasticsearchType(RelationName = "recipes")]
    public class RecipeLite
    {
//        [Text(Name = "name")]
        public string Name
        { get; set; }

        //[Nested]
        //[PropertyName("ingredients")]
//        [Object]
        public IEnumerable<Ingredient> Ingredients
        { get; set; }

//        [PropertyName("tags")]
        public IEnumerable<string> Tags
        { get; set; }
    }
}
