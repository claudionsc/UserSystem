using UsersSystem.DTOs.User;
using UsersSystem.Models;

namespace UsersSystem.Interfaces
{
    public interface IUser
    {
        Task<ResponseModel<UserModel>> UpdateUser(int id, UserModel updatedUser);
        Task<ResponseModel<UserModel>> SearchUser(string email);
        Task<ResponseModel<UserModel>> CreateUser(UserDTO userDTO);
    }
}
