using MVCStartApp.Models.DB;
using System.Threading.Tasks;

namespace MVCStartApp.Repositories
{
    public interface ILogRepository
    {
        Task AddLog(Request request);

        Task<Request[]> GetLogs();
    }
}
