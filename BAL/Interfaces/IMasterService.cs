using statejitsss.DAL.Entities;
using statejitsss.Helpers;

namespace statejitsss.BAL.Interfaces
{
    public interface IMasterService
    {
        Task<ServiceResponse<PagedResult<MmGenDdo>>> GetAllDdos(DapperQueryParameter parameters);
        Task<ServiceResponse<IEnumerable<MmGenDdo>>> GetDdoDetails();
    }
}
