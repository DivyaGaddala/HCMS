using PRJ2.API.Models;

namespace PRJ2.API.Repositories
{
    public interface IDoctoRRepository 
    {
        Task<List<DoctoR>> GetAllAsync();
        Task<DoctoR> GetByIdAsync(Guid id);
        Task<DoctoR>CreateAsync (DoctoR doctor);
        Task<DoctoR>UpdateAsync(DoctoR doctor);
        Task<DoctoR>DeleteAsync(Guid id);



    }
}
