using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using UBCOWeb.Model;
using UBCOWeb.Service.Interfaces;

namespace UBCOWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITranslationService _translationService;

        public HomeController(ILogger<HomeController> logger, ITranslationService translationService)
        {
            _logger = logger;
            _translationService = translationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(TranslationModel model)
        {
            var result = new TranslationModel();
            if (string.IsNullOrEmpty(model.InputString))
            {
                result.Result = "please insert text!!";
                return View("Index", result);
                throw new ArgumentException($"'{nameof(model.InputString)}' cannot be null or empty.", nameof(model.InputString));
            }
            result.Result = _translationService.TranslationText(model.InputString);
            return View("Index", result);
        }
    }
}
