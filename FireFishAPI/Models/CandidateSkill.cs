using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FireFishAPI.Models
{
    public class CandidateSkill
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int SkillId { get; set; }

        public CandidateSkill() { } // Empty constructor aiding serialisation

        public CandidateSkill(IDataReader reader)
        {
            this.Id = Convert.ToInt32(reader["ID"]);
            this.CandidateId = Convert.ToInt32(reader["CandidateID"]);
            this.CreatedDate = reader["CreatedDate"] as DateTime?;
            this.UpdatedDate = reader["UpdatedDate"] as DateTime?;
            this.SkillId = Convert.ToInt32(reader["SkillID"]);
        }
    }
}

