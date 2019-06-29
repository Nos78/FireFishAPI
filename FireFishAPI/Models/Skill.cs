using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FireFishAPI.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Skill() { } // Empty constructor to aid serialisation

        public Skill(IDataReader reader)
        {
            this.Id = Convert.ToInt32(reader["ID"]);
            this.Name = reader["Name"].ToString();
            this.CreatedDate = reader["CreatedDate"] as DateTime?;
            this.UpdatedDate = reader["UpdatedDate"] as DateTime?;
        }
    }
}
