using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using ReGenSDK.Model;
using ReGenSDK.Service.Api;

namespace ReGenSDK.Service
{
    public abstract partial class SearchService
    {
        protected readonly ISearchApi SearchApiImplementation;

        protected SearchService([NotNull] ISearchApi searchApiImplementation)
        {
            SearchApiImplementation = searchApiImplementation ?? throw new ArgumentNullException(nameof(searchApiImplementation));
        }

        public Task<List<RecipeLite>> Search(string query, TagFilter tags)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            return SearchApiImplementation.Search(query, tags);
        }
    }
}