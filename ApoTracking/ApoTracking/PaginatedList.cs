using System;
using System.Collections.Generic;
using System.Linq;

namespace ApoTracking
{
    public class PaginatedList : List<string>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex <= TotalPages;

        public PaginatedList(List<string> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public static PaginatedList Create(List<string> source, int pageIndex, int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList(items, count, pageIndex, pageSize);
        }
    }
}
