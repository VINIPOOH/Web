using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.dto;
using BLL.Intarfaces;
using BLL.mapers;
using ComputerNet.DAL.Interfaces;
using DAL.Entity;

namespace BLL.Servise
{
    public class UserServise: IGenericService<UserDto>
    {
        protected readonly IMapper mp;
        protected readonly IUnitOfWork _db;
        protected readonly IGenericRepository<User> _repo;
        
        public UserServise(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            mp = mapper;
            _repo = unitOfWork.Set<User>();
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Create(UserDto dto)
        {
            if (dto == null)
            {
                return;
            }
            User item = UserCastomMaper.mapDtoToUser(dto, mp);            
            _repo.Create(item);
            _db.Save();
        }

        public UserDto GetById(int id)
        {
            User item = _repo.GetById(id);

            return UserCastomMaper.mapUserToDto(item, mp);
        }

        public IEnumerable<UserDto> GetAll()
        {

            IEnumerable<User> userList = new List<User>();
            string[] includes = { "UserApartments" };
            userList = _repo.Get().ToList();
            List<UserDto> toReturn = new List<UserDto>();
            foreach (var item in userList)
            {
                toReturn.Add(UserCastomMaper.mapUserToDto(item, mp));
            }
            return toReturn;

            //IEnumerable<User> items = _repo.Get();

            //List<UserDto> toReturn = new List<UserDto>();
            //foreach (var item in items)
            //{
            //    foreach (var useraps in item.UserApartments)
            //    {

            //    }

            //    toReturn.Add(UserCastomMaper.mapUserToDto(item, mp));
            //}

            //return toReturn;
        }

        public void Update(UserDto dto)
        {
            if (dto == null)
            {
                return;
            }
            User item = UserCastomMaper.mapDtoToUser(dto, mp);       

            _repo.Update(item);
            _db.Save();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
            _db.Save();
        }
    }
}