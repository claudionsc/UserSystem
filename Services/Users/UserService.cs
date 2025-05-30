using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersSystem.Data;
using UsersSystem.DTOs.User;
using UsersSystem.Interfaces;
using UsersSystem.Models;

namespace UsersSystem.Services.Users
{
    public class UserService : IUser
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        //[HttpGet()]
        public async Task<ResponseModel<UserModel>> UpdateUser(int id, UserModel updatedUser)
        {
            ResponseModel<UserModel> resposta = new ResponseModel<UserModel>();
            try
            {
                var user = await _context.User.FindAsync(id);
                if (user == null)
                {
                    resposta.Message = "Usuário não encontrado.";
                    resposta.HttpStatusCode = false;
                    return resposta;
                }

                // Atualize as propriedades do usuário
                user.Nome = updatedUser.Nome;
                user.Email = updatedUser.Email;
                user.Senha = updatedUser.Senha;
                // Adicione outras propriedades conforme necessário

                _context.User.Update(user);
                await _context.SaveChangesAsync();

                resposta.Dado = updatedUser;
                resposta.Message = "Usuário atualizado com sucesso.";
                resposta.HttpStatusCode = true;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.HttpStatusCode = false;
            }

            return resposta;
        }


        public async Task<ResponseModel<UserModel>> SearchUser(string email)
        {
            ResponseModel<UserModel> resposta = new ResponseModel<UserModel>();
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(x => x.Email == email);

                if (user == null) {
                    resposta.Message = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dado = user;
                resposta.Message = "Usuario exibido com sucesso";

                return resposta;

            }catch(Exception e)
            {
                resposta.Message = e.Message;
                resposta.HttpStatusCode = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<UserModel>> CreateUser(UserDTO userDTO)
        {
            ResponseModel<UserModel> resposta = new ResponseModel<UserModel>();

            try
            {
                var user = new UserModel()
                {
                    Nome = userDTO.Nome,
                    Email = userDTO.Email,
                    Senha = userDTO.Senha,
                };

                _context.Add(user);
                await _context.SaveChangesAsync();

                resposta.Dado = user;
                resposta.Message = "Usuario exibido com sucesso";

                return resposta;
            }
            catch (Exception e) {
                resposta.Message = e.Message;
                resposta.HttpStatusCode = false;
                return resposta;
            }
        }
    }
}
