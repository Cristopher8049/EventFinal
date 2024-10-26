using EventManagement.DTO;
namespace EventManagement.BLL.Services.Contracts
{
    public interface IUserService
    {
        Task<List<UserDto>> ListUsers();
        Task<UserDto> CreateUser(UserDto model);
    }
}
