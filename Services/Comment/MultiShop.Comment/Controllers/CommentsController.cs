using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _context.userComments.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _context.userComments.Add(userComment);
            _context.SaveChanges();
            return Ok("Yorum Başarıyla Eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _context.userComments.Find(id);
            _context.userComments.Remove(value);
            _context.SaveChanges();
            return Ok("Yorum Başarıyla Silindi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _context.userComments.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _context.userComments.Update(userComment);
            _context.SaveChanges();
            return Ok("Yorum Başarıyla Güncellendi.");
        }
        [HttpGet("CommentListByProductId")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _context.userComments.Where(x => x.ProductId == id).ToList();
            return Ok(value);
        }

    }
}
