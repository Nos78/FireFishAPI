using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using FireFishAPI.Models;
using FireFishAPI.Services;

namespace FireFishAPI.Controllers
{
    public class CandidateController : ApiController
    {
        private CandidateService _candidateService;

        public CandidateController()
        {
            _candidateService = new CandidateService();
        }

        // GET: api/Candidate
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var candidates = _candidateService.Get();
            if (candidates != null)
                return Request.CreateResponse(HttpStatusCode.OK, candidates);
            else return Request.CreateErrorResponse(HttpStatusCode.NotFound
                                    , "No candidates found");
        }

        // GET: api/Candidate/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var candidate = _candidateService.Get(id);
            if (candidate != null)
                return Request.CreateResponse(HttpStatusCode.OK, candidate);
            else return Request.CreateErrorResponse(HttpStatusCode.NotFound
                                    , "Candidate with Id " + id + " does not exist");
        }

        // POST: api/Candidate
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Candidate candidate)
        {
            _candidateService.Add(candidate);

            var message = Request.CreateResponse(HttpStatusCode.OK);
            message.Headers.Location = new Uri(Request.RequestUri + "/" + candidate.Id.ToString());
            return message;
        }

        // PUT: api/Customer/5
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Candidate candidate)
        {
            _candidateService.Update(candidate);
            return Request.CreateResponse(HttpStatusCode.OK, string.Empty);
        }

        // DELETE: api/Customer/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _candidateService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, string.Empty);
        }
    }
}  