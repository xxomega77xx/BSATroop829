using Microsoft.AspNetCore.Mvc;
using BSATroop829.Services;

namespace BSATroop829.Controllers
{
    public class BandFeedController : Controller
    {
        public IActionResult Index()
        {
            var posts = BandApi.GetPosts();
            return View(posts);
        }
    }
}
