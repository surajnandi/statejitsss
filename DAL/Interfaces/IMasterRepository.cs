using statejitsss.DAL.Entities;
using statejitsss.Helpers;

namespace statejitsss.DAL.Interfaces
{
    public interface IMasterRepository
    {
        Task<ServiceResponse<PagedResult<MmGenDdo>>> GetAllDdos(DapperQueryParameter parameters);
        Task<ServiceResponse<IEnumerable<MmGenDdo>>> GetDdoDetails();
    }
}
