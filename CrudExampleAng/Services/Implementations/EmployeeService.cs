using Microsoft.EntityFrameworkCore;
using CrudExampleAng.Models;
using CrudExampleAng.Services.Contract;

namespace CrudExampleAng.Services.Implementations
{
    public class EmployeeService: IEmployeeService
    {
        private DbCrudAngContext _dbContex;
        
        public EmployeeService(DbCrudAngContext dbContex)
        {
            _dbContex=dbContex;
        }

        public async Task<List<Employee>> GetList()
        {
            try
            {
                List<Employee> list = new List<Employee>();
                list= await _dbContex.Employees.Include(ofc => ofc.IdOfficeNavigation).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // To get employee id
        public async Task<Employee> Get(int idEmployee)
        {
            try
            {
                Employee? findit = new Employee();
                findit = await _dbContex.Employees.Include(ofc => ofc.IdOfficeNavigation).Where(e => e.IdPerson == idEmployee).FirstOrDefaultAsync();
                return findit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // To add employee
        public async Task<Employee> Add(Employee model)
        {
            try
            {
                _dbContex.Employees.Add(model);
                await _dbContex.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // To Update employee
        public async Task<bool> Update(Employee model)
        {
            try
            {
                _dbContex.Employees.Update(model);
                await _dbContex.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // To Delete employee
        public async Task<bool> Delete(Employee model)
        {
            try
            {
                _dbContex.Employees.Remove(model);
                await _dbContex.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
