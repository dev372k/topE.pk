using BL.DTOs;

namespace BL.Abstractions.Interfaces
{
    public interface IUserRepo
    {
        IQueryable<GetUserDTO> GetAllUsers();
        GetUserDTO? GetUserById(int id);
        GetUserDTO Get(string email, string password);
        GetUserDTO? GetUserByEmail(string email);
        void AddUser(AddUserDTO user);
    }
}
