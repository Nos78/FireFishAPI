using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using FireFishAPI.Models;

namespace FireFishAPI.Repositories
{
    public class CandidateSkillRepository : Repository<CandidateSkill>
    {
        public override CandidateSkill PopulateRecord(IDataReader reader)
        {
            return new CandidateSkill(reader);
        }

        #region GET methods
        public IEnumerable<CandidateSkill> GET()
        {
            // It makes no sense to get candidate skills without a given candidate
            throw new NotImplementedException("This web service does not allow retrieving items outside of a candidate.");
        }

        /// <summary>
        /// Get candidate skills for a given candidate
        /// </summary>
        /// <param name="candidateId">the candidate for which skills have been requested</param>
        /// <returns></returns>
        public IEnumerable<CandidateSkill> Get(int candidateId)
        {
            var sqlCommand =
                "SELECT CANDIDATESKILL.ID, CandidateID, SkillID, "
                + " CANDIDATESKILL.CreatedDate, CANDIDATESKILL.UpdatedDate"
                + " FROM dbo.CandidateSkill CANDIDATESKILL "
                + " INNER JOIN dbo.Skill SKILL ON CANDIDATESKILL.SkillID = SKILL.ID"
                + " WHERE CandidateID = @CandidateID ";
            var parameters = new SqlParameter[] { new SqlParameter("@CandidateID", candidateId) };

            return base.Get(sqlCommand, parameters);
        }
        #endregion

        #region ADD methods
        public void Add(IEnumerable<CandidateSkill> candidateItems, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            foreach (CandidateSkill item in candidateItems)
                Add(item, sqlConnection, sqlTransaction);
        }

        public void Add(CandidateSkill candidateItem, SqlConnection sqlConnection = null, SqlTransaction sqlTransaction = null)
        {
            var sqlCommand =
                "IF NOT EXISTS(SELECT 1 FROM dbo.CandidateSkill WHERE CandidateID = @CandidateID AND SkillID = @SkillID) "
                + "INSERT INTO dbo.CandidateSkill "
                + "    (CandidateID, SkillID, CreatedDate, UpdatedDate) "
                + "VALUES(@CandidateID, @ProductID, " + DateTime.Now + "," + DateTime.Now + ") ";

            base.ExecuteNonQuery(sqlCommand, candidateItem.ToParameterArray(), CommandType.Text, sqlConnection, sqlTransaction);
        }
        #endregion

        #region UPDATE methods
        public void Update(IEnumerable<CandidateSkill> candidateSkills, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            foreach (var item in candidateSkills)
                Update(item, sqlConnection, sqlTransaction);
        }

        public void Update(CandidateSkill candidateSkill, SqlConnection sqlConnection = null, SqlTransaction sqlTransaction = null)
        {
            // It makes no sense to "update" skills ... you add them to a candidate, or remove them from a candidate...
            throw new NotImplementedException("This web service does not allow updating candidate skills. Use add or delete.");
        }
        #endregion

        #region DELETE methods
        public void Delete(int candidateId, SqlConnection sqlConnection = null, SqlTransaction sqlTransaction = null)
        {
            // This will delete all the skills where candidateId is matched.
            var sqlCommand = "DELETE FROM dbo.CandidateSkill WHERE CandidateID = @CandidateID ";
            var parameters = new SqlParameter[] { new SqlParameter("@CandidateID", candidateId) };

            base.ExecuteNonQuery(sqlCommand, parameters, CommandType.Text, sqlConnection, sqlTransaction);
        }

        public void Delete(int candidateId, int skillId, SqlConnection sqlConnection = null, SqlTransaction sqlTransaction = null)
        {
            // Delete an individual skill from a given candidateId
            var sqlCommand = "DELETE FROM dbo.CandidateSkill "
                            + "WHERE CandidateID = @CandidateID AND SkillID = @SkillID ";
            var parameters = new SqlParameter[] { new SqlParameter("@CandidateID", candidateId)
                                                , new SqlParameter("@SkillID", skillId) };

            base.ExecuteNonQuery(sqlCommand, parameters, CommandType.Text, sqlConnection, sqlTransaction);
        }
        #endregion
    }
}    