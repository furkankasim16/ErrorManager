using ErrorAPI.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ErrorAPI.Repositories
{
    public interface IErrorRepository
    {
        Task<List<ErrorDto>> GetErrorsByCodeAsync(string errorCode);
        Task<List<ErrorDto>> GetErrorsByDescriptionAsync(string description);
        Task<IEnumerable<ErrorDto>> GetErrorsAsync(string code = null, string description = null);
        Task<ErrorDto> GetErrorByIdAsync(int id);
        Task<IEnumerable<ErrorDto>> GetErrorsByCategoryAsync(string category);
        Task AddErrorAsync(ErrorDto error);
        Task<bool> UpdateErrorAsync(ErrorDto error);
        Task<bool> DeleteErrorAsync(int id);
        Task<IEnumerable<ErrorDto>> GetAllErrorsAsync();
    }
}
