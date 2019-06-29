using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using FireFishAPI.Models;

namespace FireFishAPI.Repositories
{
    public class CandidateRepository : Repository<Candidate>
    {
        public override Candidate PopulateRecord(IDataReader reader)
        {
            return new Candidate(reader);
        }

        public IEnumerable<Candidate> Get()
        {
            var sqlCommand = "SELECT ID, FirstName, Surname, DateOfBirth "
                            + ", Address1, Town, Country, PostCode, PhoneHome, PhoneMobile, PhoneWork "
                            + ", CreatedDate, UpdatedDate "
                            + " FROM dbo.Candidate";

            return base.Get(sqlCommand);
        }

        public IEnumerable<Candidate> Get(int candidateId)
        {
            var sqlCommand = "SELECT ID, FirstName, Surname, DateOfBirth "
                            + ", Address1, Town, Country, PostCode, PhoneHome, PhoneMobile, PhoneWork "
                            + ", CreatedDate, UpdatedDate "
                            + " FROM dbo.Candidate WHERE ID = @CandidateID";
            var parameters = new SqlParameter[] { new SqlParameter("@CandidateID", candidateId) };

            return base.Get(sqlCommand, parameters);
        }

        public void Add(Candidate candidate)
        {
            var sqlCommand = "IF NOT EXISTS(SELECT 1 FROM dbo.Candidates WHERE CandidateID = @ID)"
                            + "INSERT INTO dbo.Candidate "
                            + " (ID, FirstName, Surname, DateOfBirth "
                            + ", Address1, Town, Country, PostCode, PhoneHome, PhoneMobile, PhoneWork "
                            + ", CreatedDate, UpdatedDate) "
                            + "VALUES(@Id, @FirstName, @Surname, @DateOfBirth "
                            + ", @Address1, @Town, @Country, @PostCode, @PhoneHome, @PhoneMobile, @PhoneWork "
                            + ", " + DateTime.Now + ", " + DateTime.Now + ") ";

            base.ExecuteNonQuery(sqlCommand, candidate.ToParameterArray());
        }

        public void Update(Candidate candidate)
        {
            DateTime now = DateTime.Now;

            string strNow = now.ToShortDateString();

            candidate.UpdatedDate = DateTime.Now;

            var sqlCommand = "UPDATE dbo.Candidate "
                            + " SET FirstName = @FirstName, Surname = @Surname"
                            + ", DateOfBirth = @DateOfBirth, Address1 = @Address1"
                            + ", Town = @Town, Country = @Country, PostCode = @PostCode"
                            + ", PhoneHome = @PhoneHome, PhoneMobile = @PhoneMobile, PhoneWork = @PhoneWork"
                            + ", UpdatedDate = @UpdatedDate"
                            + " WHERE ID = @Id ";

            base.ExecuteNonQuery(sqlCommand, candidate.ToParameterArray());
        }

        public void Delete(int candidateId)
        {
            var sqlCommand = "DELETE FROM dbo.Candidate WHERE ID = @CandidateID ";
            var parameters = new SqlParameter[] { new SqlParameter("@CandidateID", candidateId) };

            base.ExecuteNonQuery(sqlCommand, parameters);
        }
    }
}
