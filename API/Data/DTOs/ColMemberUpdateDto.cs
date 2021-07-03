using System;

namespace API.DTOs
{
    public class ColMemberUpdateDto
    {
        // [DataType(DataType.EmailAddress)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdminContact { get; set; }
        public string AdminTitle { get; set; }
        public string HsName { get; set; }
        public string HsLocation { get; set; }
        public string ClassYear { get; set; }
        public string ProposedMajor { get; set; }
        public string ExtraCurricular { get; set; }
        public string DreamJob { get; set; }
        public string GPA { get; set; }
        public DateTime HsGradDate { get; set; }
        public string CollegeName { get; set; }
        public string CollegeLocation { get; set; }
        public string CollegeEnrollment { get; set; }
        public string CollegeDescription { get; set; }
        public string CollegeStreet { get; set; }
        public string CollegeCity { get; set; }
        public string CollegeState { get; set; }
        public string CollegeZip { get; set; }
        public string CollegeEmail { get; set; }
        public string CollegeWebsite { get; set; }
        public string CollegeVirtual { get; set; }
        public int Tuition { get; set; }
        public int RoomAndBoard { get; set; }
        public int AverageAid { get; set; }
        public int NetPay { get; set; }
        public string ColUserType { get; set; }
        public bool Active { get; set; } = true;
    }
}