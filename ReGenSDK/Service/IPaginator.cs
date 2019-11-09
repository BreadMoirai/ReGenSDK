using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReGenSDK.Service
{
    public interface IPaginator<T, K>
    {
        /// <summary>
        /// Gets the next page. If the next page is empty, then an empty list is returned.
        /// If an empty list is returned, it should be assumed that there are no more results to return.
        /// </summary>
        /// <returns>A List containing the contents of the next page.</returns>
        Task<List<T>> GetNext();

        /// <summary>
        /// Returns true if there might be more results.
        /// Returns false if the last page fetched was empty.
        /// </summary>
        bool HasNext { get; }
        /// <summary>
        /// This is true if the paginator has not yet retrieved any pages.
        /// </summary>
        bool AtBeginning { get; }
    }
}