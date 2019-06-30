using System.Collections.Generic;
using System.Linq;

using FireFishAPI.Models;
using FireFishAPI.Repositories;

namespace FireFishAPI.Services
{
    public class CandidateSkillService
    {
        private CandidateSkillRepository _candidateSkillRepository;
        private CandidateRepository _candidateRepository;
        private SkillRepository _skillRepository;

        private static List<CandidateSkill> _candidateSkillList;  //complete list of candidate skills
        private static bool _candidateSkillListStale = true;

        private static List<Candidate> _candidateList;  //complete list of candidates
        private static bool _candidateListStale = true;

        private static List<Skill> _skillList;  //complete list of skills
        private static bool _skillListStale = true;

        public CandidateSkillService()
        {
            _candidateSkillRepository = new CandidateSkillRepository();
            _candidateRepository = new CandidateRepository();
            _skillRepository = new SkillRepository();
        }

        /// <summary>
        /// Get an candidate skill set for given candidate Id
        /// </summary>
        /// <param name="candidateId"></param>
        /// <returns></returns>
        public IEnumerable<CandidateSkill> Get(int candidateId)
        {
            List<CandidateSkill> candidateSkillList = null;

            if (_candidateSkillList != null && !_candidateListStale)
            {
                ///look for candidate skill within cached candiate list
                candidateSkillList = _candidateSkillList.Where(cs => cs.CandidateId == candidateId).ToList();
            }

            if (candidateSkillList == null)
            {
                candidateSkillList = _candidateSkillRepository.Get(candidateId).ToList();
                if (candidateSkillList == null)
                    return candidateSkillList;
            }

            return candidateSkillList;
        }

        /// <summary>
        /// Adds a new skill.
        /// New candidates, new skills, are NOT added. Assume all references to
        /// refer to existing instances.
        /// </summary>
        /// <param name="order"></param>
        public void Add(CandidateSkill cs)
        {
            _candidateSkillRepository.Add(cs);
        }

        public void Delete(int csId)
        {
            _candidateSkillRepository.Delete(csId);
        }

        public void Delete(CandidateSkill cs)
        {
            _candidateSkillRepository.Delete(cs);
        }
    }
}
