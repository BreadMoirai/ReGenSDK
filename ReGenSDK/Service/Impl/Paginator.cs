using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ReGenSDK.Service.Impl
{
    internal class Paginator<T, K> : IPaginator<T, K>
    {
        public bool HasNext { get; protected set; } = true;
        public bool AtBeginning { get; protected set; } = true;
        private Task<List<T>> _lastFetch;
        private readonly Func<List<T>, K> _nextIndex;
        private readonly Func<K, Task<List<T>>> _nextPage;

        public Paginator([NotNull] Func<List<T>, K> nextIndex, [NotNull] Func<K, Task<List<T>>> nextPage)
        {
            _nextIndex = nextIndex ?? throw new ArgumentNullException(nameof(nextIndex));
            _nextPage = nextPage ?? throw new ArgumentNullException(nameof(nextPage));
        }

        /// <summary>
        /// Gets the next page. If the next page is empty, then an empty list is returned.
        /// If an empty list is returned, it should be assumed that there are no more results to return.
        /// </summary>
        /// <returns>A List containing the contents of the next page.</returns>
        [NotNull]
        public async Task<List<T>> GetNext()
        {
            List<T> result;
            if (AtBeginning)
            {
                AtBeginning = false;
                _lastFetch = _nextPage(default(K));
                result = await _lastFetch ?? new List<T>();
                if (result.Count == 0) HasNext = false;
            }
            else
            {
                var lastFetch = _lastFetch;
                var thisFetch = new TaskCompletionSource<List<T>>();
                _lastFetch = thisFetch.Task;
                var last = await lastFetch;
                result = await _nextPage(_nextIndex(last)) ?? new List<T>();
                if (result.Count == 0) HasNext = false;
                thisFetch.SetResult(result);
            }

            return result;
        }
    }
}