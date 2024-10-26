using AutoMapper;
using EventManagement.BLL.Services.Contracts;
using EventManagement.DAL.Repositories.Contracts;
using EventManagement.DTO;
using EventManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.BLL.Services
{
    public class UserService(IGenericRepository<User> userRepository, IMapper mapper) : IUserService
    {
        public async Task<List<UserDto>> ListUsers()
        {
            var queryUser = await userRepository.Consult();
            var userList = queryUser.Include(rol => rol.Role).ToList();

            return mapper.Map<List<UserDto>>(userList);
        }

        public async Task<UserDto> CreateUser(UserDto model)
        {
            try
            {
                var userCreated = await userRepository.Create(mapper.Map<User>(model));
                if (userCreated == null || userCreated.Id == 0)
                {
                    throw new Exception("No se pudo crear el usuario");
                }
                
                var query = await userRepository.Consult(u => u.Id == userCreated.Id);

                userCreated = query.Include(rol => rol.Role).First();

                return mapper.Map<UserDto>(userCreated);

            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No hay detalles adicionales.";
                throw new Exception($"Error al crear el usuario: {ex.Message}. Detalles: {innerException}");
            }
            
        }
             
    }
}
