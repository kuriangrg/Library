namespace Model.BookModels
{
    /// <summary>
    /// The request class for how many books to be requested and is used for pagination
    /// </summary>
    public class BookListRequestFilter
    {
        /// <summary>
        /// Index of the page to be served.
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// Total pages to be served for the request.
        /// </summary>
        public int PageSize { get; set; }
    }
}
