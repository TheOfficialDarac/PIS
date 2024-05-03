using PIS.DAL.DataModel;
using PIS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Repository.Common
{
    public interface IService
    {
        List<PisUsersDrupcic> GetAllUsers();
        string Test();
        List<UsersDTO> GetAllUsersDTOs();
        Task<bool> AddUserAsync(UsersDTO usersDTO);
        UsersDTO GetUserDTOById(int id);
    }
}
