using statejitsss.BAL.Interfaces;
using statejitsss.DAL;
using statejitsss.DAL.Entities;
using statejitsss.DAL.Interfaces;
using statejitsss.Helpers;

namespace statejitsss.BAL.Services
{
    public class MasterService : IMasterService
    {
        private readonly IMasterRepository _masterRepository;

        public MasterService(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        public async Task<ServiceResponse<PagedResult<MmGenDdo>>> GetAllDdos(DapperQueryParameter parameters)
        {
            return await _masterRepository.GetAllDdos(parameters);
        }
        public async Task<ServiceResponse<IEnumerable<MmGenDdo>>> GetDdoDetails()
        {
            return await _masterRepository.GetDdoDetails();
        }
    }
}
