using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ApiWrappers.Clients;
using ReturnOnIntelligenceTask.Models;

namespace ReturnOnIntelligenceTask.Controllers
{
    public class CatsController : Controller
    {
        private CatClient CatClient => new CatClient();
        private static int DefaultImageCount => 10;

        public async Task<ViewResult> Index()
        {
            var categories = await GetCategoryListAsync();

            var model = new CatViewModel
            {
                CategoriesNames = categories
            };

            return View(model);
        }

        private async Task<string[]> GetCategoryListAsync()
        {
            var categories = await CatClient.GetCategoriesAsync();

            return categories.Select(x => x.Name).ToArray();
        }

        [HttpPost]
        public async Task<JsonResult> GetImageLinkAsync(string category)
        {
            var images = await CatClient.GetImagesAsync(DefaultImageCount, category);

            var result = new
            {
                images = images.Select(x => x.Url).ToArray()
            };

            return Json(result);
        }
    }
}