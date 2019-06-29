using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FireFishAPI.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address1 { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneWork { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Candidate() { }  // Empty constructor - aids serialisation

        public Candidate(IDataReader reader)
        {
            this.Id = Convert.ToInt32(reader["ID"]);
            this.FirstName = reader["FirstName"].ToString();
            this.Surname = reader["Surname"].ToString();
            this.DateOfBirth = reader["DateOfBirth"] as DateTime?;
            this.Address1 = reader["Address1"].ToString();
            this.Town = reader["Town"].ToString();
            this.Country = reader["Country"].ToString();
            this.PostCode = reader["PostCode"].ToString();
            this.PhoneHome = reader["PhoneHome"].ToString();
            this.PhoneMobile = reader["PhoneMobile"].ToString();
            this.PhoneWork = reader["PhoneWork"].ToString();
            this.CreatedDate = reader["CreatedDate"] as DateTime?;
            this.UpdatedDate = reader["UpdatedDate"] as DateTime?;
        }
    }
}
