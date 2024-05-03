using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIS.Common;
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

        //public List<PisUsersDrupcic> GetAllUsers()
        //{
        //    List<PisUsersDrupcic> users = _repository.GetAllUsers().ToList();

        //    string error = "Users List is empty.";
        //    if (users == null)
        //    {
        //        throw new Exception($@"{400} :{error}");
        //    }
        //    else return users;
        //}

        public Tuple<List<UsersDTO>, List<ErrorMessage>> GetAllUsersDTOs()
        {
            List<UsersDTO> users = _repository.GetAllUsersDTOs().ToList();
            List<ErrorMessage> errors = new List<ErrorMessage>();

            if (users == null)
            {
                errors.Add(new ErrorMessage($@"{400} : Users List is empty."));
            }
            else errors.Add(new ErrorMessage("Sve je OK."));

            return new Tuple<List<UsersDTO>, List<ErrorMessage>>(users, errors);
        }

        public UsersDTO GetUserDTOById(int id)
        {
            return _repository.GetUsersDTObyId(id);
        }

        public async Task<bool> IsValidUser(int userId)
        {
            UsersDTO user = await _repository.FindUserAsync(userId);

            if (user == null) return false;
            else return true;
        }

        public string Test()
        {
            return _repository.Test();
        }

        public async Task<Tuple<List<PisUsersDrupcic>, List<ErrorMessage>>> GetAllUsers()
        {
            List<PisUsersDrupcic> users = _repository.GetAllUsers().ToList();
            List<ErrorMessage> errors = new List<ErrorMessage>();

            if (users == null)
            {
                errors.Add(new ErrorMessage($@"{400} : Users List is empty."));
            }
            else errors.Add(new ErrorMessage("Sve je OK."));
            
            return Tuple.Create(users, errors);
        }

        Tuple<UsersDTO, List<ErrorMessage>> IService.GetUserDTOById(int id)
        {
            UsersDTO user = _repository.GetUsersDTObyId(id);
            List<ErrorMessage> errors = new List<ErrorMessage>();

            if (user == null)
            {
                errors.Add(new ErrorMessage($@"{400} : No users with id {id} found."));
            }
            else errors.Add(new ErrorMessage("Sve je OK."));

            return new Tuple<UsersDTO, List<ErrorMessage>>(user, errors);
        }
    }
}
