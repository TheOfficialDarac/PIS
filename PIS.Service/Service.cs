using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;
using PIS.Service;


namespace PIS.Service
{
    public class Service:IService
    {
        private readonly IRepository _repository;
        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddUserAsync(UsersDTO usersDTO)
        {
            return await _repository.AddUserAsync(usersDTO);
        }

        public List<PisUsersDrupcic> GetAllUsers()
        {
            List<PisUsersDrupcic> users = _repository.GetAllUsers().ToList();

            string error = "Users List is empty.";
            if (users == null)
            {
                throw new Exception($@"{error}");
            }
            else return users;
        }

        public List<UsersDTO> GetAllUsersDTOs()
        {
            return (List<UsersDTO>)_repository.GetAllUsersDTOs();
        }

        public UsersDTO GetUserDTOById(int id)
        {
            return _repository.GetUsersDTObyId(id);
        }

        public string Test()
        {
            return _repository.Test();
        }
    }
}
