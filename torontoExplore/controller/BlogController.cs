using Microsoft.AspNetCore.Mvc;

namespace torontoExplore.controller
{
    [Route("blog")]
    public class BlogController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return new ContentResult { Content = "Blog posts" };
        }

        [Route(@"{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            return new ContentResult
            {
                Content = string.Format("Year: {0}; Month: {1}; Key: {2}",
                            year, month, key)
            };
        }
    }
}
