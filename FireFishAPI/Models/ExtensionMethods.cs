using System;
using System.Data.SqlClient;

namespace FireFishAPI.Models
{
    public static class ExtensionMethods
    {
        public static SqlParameter[] ToParameterArray(this Candidate candidate)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@ID", candidate.Id)
                , new SqlParameter("@FirstName", candidate.FirstName ?? (object)DBNull.Value)
                , new SqlParameter("@Surname", candidate.Surname ?? (object)DBNull.Value)
                , new SqlParameter("@DateOfBirth", candidate.DateOfBirth ?? (object)DBNull.Value)
                , new SqlParameter("@Address1", candidate.Address1 ?? (object)DBNull.Value)
                , new SqlParameter("@Town", candidate.Town ?? (object)DBNull.Value)
                , new SqlParameter("@Country", candidate.Country ?? (object)DBNull.Value)
                , new SqlParameter("@PostCode", candidate.PostCode ?? (object)DBNull.Value)
                , new SqlParameter("@PhoneHome", candidate.PhoneHome ?? (object)DBNull.Value)
                , new SqlParameter("@PhoneMobile", candidate.PhoneMobile ?? (object)DBNull.Value)
                , new SqlParameter("@PhoneWork", candidate.PhoneWork ?? (object)DBNull.Value)
                , new SqlParameter("@CreatedDate", candidate.CreatedDate)
                , new SqlParameter("@UpdatedDate", candidate.UpdatedDate)
            };
        }

        public static SqlParameter[] ToParameterArray(this Skill skill)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@ID", skill.Id)
                , new SqlParameter("@Name", skill.Name ?? (object)DBNull.Value)
                , new SqlParameter("@CreatedDate", skill.CreatedDate)
                , new SqlParameter("@UpdatedDate", skill.UpdatedDate)
            };
        }

        public static SqlParameter[] ToParameterArray(this CandidateSkill candidateSkill)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@ID", candidateSkill.Id)
                , new SqlParameter("@CandidateID", candidateSkill.CandidateId)
                , new SqlParameter("@CreatedDate", candidateSkill.CreatedDate)
                , new SqlParameter("@UpdatedDate", candidateSkill.UpdatedDate)
                , new SqlParameter("@SkillID", candidateSkill.SkillId)
            };
        }
    }
}