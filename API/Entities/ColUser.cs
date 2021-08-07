using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class ColUser
    {
        [Key]
        public int ColUserId { get; set; }
        [DataType(DataType.EmailAddress)]
        public string ColUserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HsName { get; set; }
        public string HsLocation { get; set; }
        public string ClassYear { get; set; }
        public DateTime HsGradDate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime GradDate { get; set; }
        public string GPA { get; set; }
        public string ProposedMajor { get; set; }
        public string ExtraCurricular { get; set; }
        public string DreamJob { get; set; }
        public int CollegeNum { get; set; }
        public string CollegeName { get; set; }
        public string CollegeNickname { get; set; }
        public string CollegeLocation { get; set; }
        public int CollegeEnrollment { get; set; }
        public int Tuition { get; set; }
        public int RoomAndBoard { get; set; }
        public int AverageAid { get; set; }
        public int NetPay { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string ColUserType { get; set; }
        public bool Active { get; set; } = true;
        public string CollegeDescription { get; set; }
        public string CollegeStreet { get; set; }
        public string CollegeCity { get; set; }
        public string CollegeState { get; set; }
        public string CollegeZip { get; set; }
        public string CollegePhone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string CollegeEmail { get; set; }
        public string CollegeWebsite { get; set; }
        public string CollegeVirtual { get; set; }
        public string CollegeYearFounded { get; set; }
        public string CollegePresident { get; set; }
        public string AdminContact { get; set; }
        public string AdminTitle { get; set; }
        public ICollection<ColPhoto> ColPhotos { get; set; }
        public ICollection<CollegeMajor> CollegeMajors { get; set; }
        public ICollection<FactFeature> FactFeatures { get; set; }

    }
}