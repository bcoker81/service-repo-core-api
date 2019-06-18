using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using service_repo_api.Domain;

namespace service_repo_api.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceController : ControllerBase
    {
        private ServiceRepositoryContext _context;

        public ServiceController(ServiceRepositoryContext context)
        {
            _context = context;
        }

        [Route("new"), HttpPost]
        public IActionResult NewService(Services service){
            try
            {
                _context.Services.Add(service);
                _context.SaveChanges();
                return Ok("Message received successfully..");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("getdetails/{id}")]
        public IActionResult GetDetails(int id){
            try
            {
                var result = _context.Services.Find(id);
                result.Comments = _context.Comments.Where(p => p.FkServiceId == id).ToList();
                result.ErrorLogs = _context.ErrorLogs.Where(p => p.FkServiceId == id).ToList();

                return Ok(result);                
            }
            catch ( ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("getall"), HttpGet]
        public IActionResult GetAll(){
            try
            {
                return Ok(_context.Services.ToList());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("get/{id}"), HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_context.Services.Find(id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}