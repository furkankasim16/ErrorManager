using ErrorAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ErrorAPI.Repositories
{
    public interface IErrorRepository
    {
        Task<List<Error>> GetErrorsByCodeAsync(string errorCode);
        Task<List<Error>> GetErrorsByDescriptionAsync(string description);
        Task<IEnumerable<Error>> GetErrorsAsync(string code = null, string description = null);
        Task<Error> GetErrorByIdAsync(int id);
        Task<IEnumerable<Error>> GetErrorsByCategoryAsync(string category);
        Task AddErrorAsync(Error error);
        Task<bool> UpdateErrorAsync(Error error);
        Task<bool> DeleteErrorAsync(int id);
        Task<IEnumerable<Error>> GetAllErrorsAsync();
    }
}
