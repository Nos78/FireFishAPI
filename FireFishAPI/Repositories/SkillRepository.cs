using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using FireFishAPI.Models;

namespace FireFishAPI.Repositories
{
    public class SkillRepository : Repository<Skill>
    {
        public override Skill PopulateRecord(IDataReader reader)
        {
            return new Skill(reader);
        }

        public IEnumerable<Skill> Get()
        {
            var sqlCommand = "SELECT ID, Name, CreatedDate, UpdatedDate "
                            + " FROM dbo.Skill";

            return base.Get(sqlCommand);
        }

        public IEnumerable<Skill> Get(int skillId)
        {
            var sqlCommand = "SELECT ID, Name, CreatedDate, UpdatedDate "
                            + " FROM dbo.Skill WHERE ID = @SkillId";
            var parameters = new SqlParameter[] { new SqlParameter("@SkillID", skillId) };

            return base.Get(sqlCommand, parameters);
        }

        public void Add(Skill skill)
        {
            skill.CreatedDate = DateTime.Now;
            skill.UpdatedDate = skill.CreatedDate;

            var sqlCommand = "IF NOT EXISTS(SELECT 1 FROM dbo.Skill WHERE ID = @Id)"
                            + "INSERT INTO dbo.Skill "
                            + " (ID, Name, CreatedDate, UpdatedDate) "
                            + "VALUES(@Id, @Name, @CreatedDate, @UpdatedDate)";

            base.ExecuteNonQuery(sqlCommand, skill.ToParameterArray());
        }

        public void Update(Skill skill)
        {
            skill.CreatedDate = DateTime.Now;

            var sqlCommand = "UPDATE dbo.Skill "
                            + " SET Name = @Name, UpdatedDate = @UpdatedDate"
                            + " WHERE ID = @Id ";

            base.ExecuteNonQuery(sqlCommand, skill.ToParameterArray());
        }

        public void Delete(int skillId)
        {
            var sqlCommand = "DELETE FROM dbo.Skill WHERE ID = @SkillID ";
            var parameters = new SqlParameter[] { new SqlParameter("@SkillID", skillId) };

            base.ExecuteNonQuery(sqlCommand, parameters);
        }
    }

}
