namespace FiscalInfoApp.Web.ViewModels
{
    using System;

    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public int ItemsCount { get; set; }

        public int PagesCount => (int)Math.Ceiling((double)this.ItemsCount / this.ItemsPerPage); // 25 items * 12 per page = 3 pages (Ceiling(2.083)=3)

        public int ItemsPerPage { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public int PreviousPageNumber => this.PageNumber - 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int NextPageNumber => this.PageNumber + 1;

        public int FirstPage => 1;

        public int LastPage => this.PagesCount;
    }
}