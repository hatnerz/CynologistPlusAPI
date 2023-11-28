using WebAPI.DataBase;
using WebAPI.DI;

namespace WebAPI.Services
{
    public class ServiceBase
    {
        protected readonly CynologistPlusContext _context;

        public ServiceBase(CynologistPlusContext context)
        {
            _context = context;
        }
    }
}
