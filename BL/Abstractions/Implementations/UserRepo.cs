using BL.Abstractions.Interfaces;
using BL.DTOs;
using DL.Commons;
using DL.Entities;
using DL.Helpers;
using DL.Repositories;
using Omu.ValueInjecter;

namespace BL.Abstractions.Implementations
{
    public class UserRepo : IUserRepo
    {
        private IGenericRepository<User> _userRepo;

        public UserRepo(IGenericRepository<User> userrepo)
        {
            _userRepo = userrepo;
        }
        public void AddUser(AddUserDTO user)
        {
            if (UserExists(user.Email))
                throw new Exception(ExceptionMessages.USER_ALREADY_EXIST);

            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                RoleId = user.Role,
                PasswordHash = SecurityHelper.GenerateHash(user.Password)
            };

            _userRepo.Insert(newUser);
        }

        public IQueryable<GetUserDTO> GetAllUsers()
        {
            var users = _userRepo.GetAll().Select(_ => new GetUserDTO
            {
                Id = _.Id,
                Name = _.Name,
                Email = _.Email,
                Role = _.RoleId,
                Password = _.PasswordHash
            }).AsQueryable();

            return users;
        }

        public GetUserDTO Get(string email, string password)
        {
            var user = GetUserByEmail(email);
            if (user != null)
            {
                if (SecurityHelper.ValidateHash(password, user.Password))
                    return Mapper.Map<GetUserDTO>(user);

                throw new Exception(ExceptionMessages.INVALID_CREDENTIALS);
            }
            throw new Exception(ExceptionMessages.USER_DOESNOT_EXIST);
        }

        public GetUserDTO? GetUserByEmail(string email) => GetAllUsers().FirstOrDefault(_ => _.Email == email);
        public GetUserDTO? GetUserById(int id) => GetAllUsers().FirstOrDefault(_ => _.Id == id);
        private bool UserExists(string email) => GetAllUsers().Any(_ => _.Email == email);

        public object RoleDetails(int roleId)
        {
            throw new NotImplementedException();
        }
    }
}

