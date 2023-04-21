using Microsoft.EntityFrameworkCore;
using CrudExampleAng.Models;
using CrudExampleAng.Services.Contract;

namespace CrudExampleAng.Services.Implementations
{
    public class OfficeService:IOfficeService // Office Interface
    {
        private DbCrudAngContext _dbContex;

        public OfficeService(DbCrudAngContext dbContex)
        {
            _dbContex=dbContex;
        }

        // To get employee in office list
        public async Task<List<Office>> GetList()
        {
            try
            {
                List<Office> list = new List<Office>();
                list = await _dbContex.Offices.ToListAsync();
                return list;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
