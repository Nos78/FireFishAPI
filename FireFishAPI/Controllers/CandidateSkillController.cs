using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using FireFishAPI.Models;
using FireFishAPI.Services;

namespace FireFishAPI.Controllers
{
    public class CandidateSkillController : ApiController
    {
        private CandidateSkillService _candidateSkillService;

        public CandidateSkillController()
        {
            _candidateSkillService = new CandidateSkillService();
        }

        // GET: api/CandidateSkill
        public HttpResponseMessage Get()
        {
            //var candidateSkills = _candidateSkillService.Get();
            //if (candidateSkills != null)
                //return Request.CreateResponse(HttpStatusCode.OK, candidateSkills);
            //else
                return Request.CreateErrorResponse(HttpStatusCode.NotImplemented
                                    , "Not Implemented!  Please use /api/candidateskill/-id-");
        }

        // GET: api/CandidateSkill/5
        public HttpResponseMessage Get(int id)
        {
            // Candidate.Id (not CandidateSkill.Id!)
            var candidateSkill = _candidateSkillService.Get(id);
            if (candidateSkill != null)
                return Request.CreateResponse(HttpStatusCode.OK, candidateSkill);
            else return Request.CreateErrorResponse(HttpStatusCode.NotFound
                                    , "No skills found for Candidate, Id = " + id);
        }

        // POST: api/CandidateSkill
        public HttpResponseMessage Post([FromBody]CandidateSkill skill)
        {
            _candidateSkillService.Add(skill);

            var message = Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(Request.RequestUri + skill.Id.ToString());
            return message;
        }

        // DELETE: api/CandidateSkill/5
        public HttpResponseMessage Delete(int candidateSkillId)
        {
            _candidateSkillService.Delete(candidateSkillId);
            return Request.CreateResponse(HttpStatusCode.OK, string.Empty);
        }
    }
}