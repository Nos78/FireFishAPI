using System.Collections.Generic;
using System.Linq;

using FireFishAPI.Models;
using FireFishAPI.Repositories;

namespace FireFishAPI.Services
{
    public class CandidateService
    {
        private CandidateRepository _candidateRepository;

        /// <summary>
        /// candidatelist stores in-memory copy of repository (cached).
        /// </summary>
        private static List<Candidate> _candidateList;

        public CandidateService()
        {
            _candidateRepository = new CandidateRepository();
        }

        public IEnumerable<Candidate> Get()
        {
            if (_candidateList == null)
            {
                _candidateList = _candidateRepository.Get().ToList();
            }
            return _candidateList;
        }

        public IEnumerable<Candidate> Get(int candidateId)
        {
            if (_candidateList != null)
                return _candidateList.Where(c => c.Id == candidateId);
            else return _candidateRepository.Get(candidateId);
        }

        public void Add(Candidate candidate)
        {
            _candidateRepository.Add(candidate);
            if (_candidateList != null)
                _candidateList.Add(candidate);
        }

        public void Update(Candidate candidate)
        {
            _candidateRepository.Update(candidate);
            if (_candidateList != null)
            {
                
                _candidateList.Remove(_candidateList.FirstOrDefault(c => c.Id == candidate.Id));
                _candidateList.Add(candidate);
                
            }
        }

        public void Delete(int candidateId)
        {
            _candidateRepository.Delete(candidateId);
            if (_candidateList != null)
            {
                _candidateList.Remove(_candidateList.Where(c => c.Id == candidateId).FirstOrDefault());
            }
        }
    }
}
