using System.Collections.Generic;
using System.Threading.Tasks;
using ReGenSDK.Service.Api;

namespace ReGenSDK.Service
{
    public abstract partial class FavoriteService : IFavoriteApi
    {
        public abstract Task<List<string>> GetList();
    }

}