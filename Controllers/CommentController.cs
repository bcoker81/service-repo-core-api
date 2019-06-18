using System.Linq;
using Microsoft.AspNetCore.Mvc;
using service_repo_api.Domain;

namespace service_repo_api.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private ServiceRepositoryContext _context;

        public CommentController(ServiceRepositoryContext context)
        {
            _context = context;
        }

        [Route("new"), HttpPost]
        public IActionResult New([FromBody] Comments comment){
            try
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
                return Ok("Message received successful..");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("getall/{id}"), HttpGet]
        public IActionResult GetAll(int id){
            try
            {
                return Ok(_context.Comments.Where(p => p.FkServiceId == id).ToList());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("delete/{id}"), HttpGet]
        public IActionResult Delete(int id){
            try
            {
                _context.Remove(_context.Comments.Find(id));
                _context.SaveChanges();
                return Ok("Message received successfully.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}