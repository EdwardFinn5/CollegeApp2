namespace API.Helpers
{
    public class ColUserParams : ColPaginationParams
    {
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