using PIS.DAL.DataModel;
using PIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Repository.Common
{
    public interface IRepository
    {
        IQueryable<PisUsersDrupcic> GetAllUsers();
        IEnumerable<UsersDTO> GetAllUsersDTOs();
        UsersDTO GetUsersDTObyId(int id);

        Task<bool> AddUserAsync(UsersDTO usersDTO);
        string Test();
    }
}
