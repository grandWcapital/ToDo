namespace ToDoApp.Utilities
{
    public class PagedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalNuberOfPages { get; private set; }
        public bool HasPreviousPage=> PageIndex >1;
        public bool HasNextPage => PageIndex < TotalNuberOfPages;
        public PagedList(List<T> items,int pageIndex, int totalNumberOfPuges)
        {
            PageIndex = pageIndex;
            TotalNuberOfPages = totalNumberOfPuges;
            AddRange(items);
        }
    }
}
