using MVCStartApp.Models.DB;
using System.Threading.Tasks;

namespace MVCStartApp.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);

        Task<User[]> GetUsers();
    }
}
