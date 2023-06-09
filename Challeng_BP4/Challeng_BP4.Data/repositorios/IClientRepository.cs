using Challeng_BP4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challeng_BP4.Data.repositorios
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> GetClient(int id);
        Task<IEnumerable<Client>> GetByName(string name); 
        Task<bool> DeleteClient(Client client);
        Task<bool> CreateClient(Client client);
        Task<bool> UpdateClient(Client client);

    }
}
