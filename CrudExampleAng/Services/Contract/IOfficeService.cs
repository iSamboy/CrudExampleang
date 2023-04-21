using CrudExampleAng.Models;
namespace CrudExampleAng.Services.Contract
{
    public interface IOfficeService
    {
        Task<List<Office>> GetList();
    }
}
