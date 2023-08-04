using BlazorWebAssemblyCleanArchitecture.Domain.Entities;

namespace BlazorWebAssemblyCleanArchitecture.Application.Interfaces.Repositories
{
    public interface IStadiumRepository
    {
        Task<List<Stadium>> GetStadiumByCityAsync(string cityName);
    }
}
