using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReGenSDK.Service.Api;

namespace ReGenSDK.Service.Impl
{
    class FavoriteServiceImpl : FavoriteService
    {
        public FavoriteServiceImpl(IFavoriteApi favoriteApiImplementation) : base(favoriteApiImplementation)
        {
        }

        public override async Task<List<string>> GetList()
        {
            var dictionary = await FavoriteApiImplementation.Get();
            return dictionary.Keys.ToList();
        }
    }
}