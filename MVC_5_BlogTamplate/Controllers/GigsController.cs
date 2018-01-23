using System.Linq;
using System.Web.Mvc;
using MVC_5_BlogTamplate.Models;
using MVC_5_BlogTamplate.ViewModel;

namespace MVC_5_BlogTamplate.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GigsController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var viewModel = new GigsFormViewModel
            {
                Genres = _applicationDbContext.Genres.ToList()
            };

            return View(viewModel);
        }
    }
}