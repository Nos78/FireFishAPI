using System.Collections.Generic;
using System.Linq;

using FireFishAPI.Models;
using FireFishAPI.Repositories;

namespace FireFishAPI.Services
{
    public class SkillService
    {
        private SkillRepository _skillRepository;

        /// <summary>
        /// skillList stores in-memory copy of repository (cached).
        /// </summary>
        private static List<Skill> _skillList;

        //this boolean determines if cached employee list is up to date
        private static bool _skillListStale = true;

        public SkillService()
        {
            _skillRepository = new SkillRepository();
        }

        public IEnumerable<Skill> Get()
        {

            if (_skillList == null || _skillListStale)
            {
                _skillList = _skillRepository.Get().ToList();
            }
            return _skillList;
        }

        public IEnumerable<Skill> Get(int skillId)
        {
            if (_skillList != null && _skillListStale == false)
                return _skillList.Where(c => c.Id == skillId);
            else return _skillRepository.Get(skillId);
        }

        public void Add(Skill skill)
        {
            _skillRepository.Add(skill);
            _skillListStale = true;
        }

        public void Update(Skill skill)
        {
            _skillRepository.Update(skill);
            _skillListStale = true;
        }

        public void Delete(int skillId)
        {
            _skillRepository.Delete(skillId);
            _skillListStale = true;
        }
    }
}