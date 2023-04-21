using CrudExampleAng.Models;
namespace CrudExampleAng.Services.Contract
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetList();
        Task<Employee> Get(int idEmployee); // Generating Id
        Task<Employee>Add(Employee model); // Adding employee
        Task<bool> Update(Employee model); // Update employee
        Task<bool>Delete(Employee model); // Delete employee
    }
}
