namespace BusinessContact.Domain.Configurations
{
    public class PaginationParams
    {
        private int pageSize;
        private int pageIndex;

        public int PageSize
        {
            get => pageSize;
            set => pageSize = value <= 0 ? 20 : value;
        }

        public int PageIndex
        {
            get => pageIndex;
            set => pageIndex = value <= 0 ? 1 : value;
        }
    }
}
