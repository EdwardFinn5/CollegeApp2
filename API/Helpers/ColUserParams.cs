namespace API.Helpers
{
    public class ColUserParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string CurrentColUsername { get; set; }
        public string ColUserType { get; set; }
        public int MinEnrollment { get; set; } = 300;
        public int MaxEnrollment { get; set; } = 6000;
        public string CollegeLocation { get; set; }
        public string ClassYear { get; set; } = "Junior";
        public string ProposedMajor { get; set; } = "Accounting";
        public string CollegeName { get; set; }
        public string FirstName { get; set; }
        public string OrderBy { get; set; } = "LastActive";
    }
}