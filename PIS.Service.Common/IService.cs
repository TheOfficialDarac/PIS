using PIS.Common;
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
        Task<Tuple<List<PisUsersDrupcic>, List<ErrorMessage>>> GetAllUsers();
        //List<PisUsersDrupcic> GetAllUsers();
        string Test();
        //List<UsersDTO> GetAllUsersDTOs();
        Tuple<List<UsersDTO>, List<ErrorMessage>> GetAllUsersDTOs();
        Task<bool> AddUserAsync(UsersDTO usersDTO);
        //UsersDTO GetUserDTOById(int id);
        Tuple<UsersDTO, List<ErrorMessage>> GetUserDTOById(int id);
        Task<bool> IsValidUser(int userId);
    }
}
