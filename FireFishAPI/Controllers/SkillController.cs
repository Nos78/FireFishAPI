using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using FireFishAPI.Models;
using FireFishAPI.Services;

namespace FireFishAPI.Controllers
{
    public class SkillController : ApiController
    {
        private SkillService _skillService;

        public SkillController()
        {
            _skillService = new SkillService();
        }

        // GET: api/Skill
        public HttpResponseMessage Get()
        {
            var skills = _skillService.Get();
            if (skills != null)
                return Request.CreateResponse(HttpStatusCode.OK, skills);
            else return Request.CreateErrorResponse(HttpStatusCode.NotFound
                                    , "No skills found");
        }

        // GET: api/Skill/5
        public HttpResponseMessage Get(int id)
        {
            var skill = _skillService.Get(id);
            if (skill != null)
                return Request.CreateResponse(HttpStatusCode.OK, skill);
            else return Request.CreateErrorResponse(HttpStatusCode.NotFound
                                    , "Skill with Id " + id + " does not exist");
        }

        // POST: api/Skill
        public HttpResponseMessage Post([FromBody]Skill skill)
        {
            _skillService.Add(skill);

            var message = Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(Request.RequestUri + skill.Id.ToString());
            return message;
        }

        // PUT: api/Skill/5
        public HttpResponseMessage Put([FromBody]Skill skill)
        {
            _skillService.Update(skill);
            return Request.CreateResponse(HttpStatusCode.OK, string.Empty);
        }

        // DELETE: api/Skill/5
        public HttpResponseMessage Delete(int id)
        {
            _skillService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, string.Empty);
        }
    }
}