using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReGenSDK.Model;
using ReGenSDK.Service.Api;

namespace ReGenSDK.Service.Impl
{
    class SearchServiceImpl : SearchService
    {
        public SearchServiceImpl(ISearchApi searchApiImplementation) : base(searchApiImplementation)
        {
        }

        public override SearchQueryBuilder Builder()
        {
            return new SearchQueryBuilderImpl(this);
        }

        public override Task<List<RecipeLite>> Search(string query, IEnumerable<string> includeTags,
            IEnumerable<string> excludeTags)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            if (includeTags == null) throw new ArgumentNullException(nameof(includeTags));
            if (excludeTags == null) throw new ArgumentNullException(nameof(excludeTags));
            return Search(query, new TagFilter
            {
                IncludeTags = includeTags.ToList(),
                ExcludeTags = excludeTags.ToList()
            });
        }
    }
}