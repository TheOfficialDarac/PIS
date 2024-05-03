using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Automapper;
using PIS.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Repository
{
    public class Repository:IRepository
    {
        #region Properties

        private readonly PIS_DbContext _appDbContext;
        private readonly IRepositoryMappingService _mapper;
        #endregion

        #region Constructor

        public Repository(PIS_DbContext appDbContext, IRepositoryMappingService mapper)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<bool> AddUserAsync(UsersDTO usersDTO)
        {
            try
            {
                EntityEntry<PisUsersDrupcic> user_created = await _appDbContext.PisUsersDrupcic.AddAsync(_mapper.Map<PisUsersDrupcic>(usersDTO));
                await _appDbContext.SaveChangesAsync();
                return true;
            } catch { return false; }
        }
        #endregion

        #region Methods

        public IQueryable<PisUsersDrupcic> GetAllUsers() {
            return _appDbContext.PisUsersDrupcic.AsQueryable();
        }

        public IEnumerable<UsersDTO> GetAllUsersDTOs()
        {
            var usersDb = _appDbContext.PisUsersDrupcic.ToList();
            return _mapper.Map<IEnumerable<UsersDTO>>(usersDb);
        }

        public UsersDTO GetUsersDTObyId(int id)
        {
            var userDb = _appDbContext.PisUsersDrupcic.Find(id);
            return _mapper.Map<UsersDTO>(userDb);
        }

        public string Test()
        {
            return "I am ok - Repository.Test";
        }

        public async Task<UsersDTO> FindUserAsync(int userID)
        {
            try
            {
                var userDb = await _appDbContext.PisUsersDrupcic.FirstAsync(u => u.UserId == userID);
                if (userDb == null) return null;
                return _mapper.Map<UsersDTO>(userID);
            }
            catch 
            {
                return null;
            }
        }

        #endregion
    }
}
