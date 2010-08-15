using System;
using System.Linq;
using System.Web.Mvc;
using MvcTurbine.NoRM;

namespace SampleApplication.Controllers
{
    public class WebsiteVisit
    {

        public WebsiteVisit()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }

    [HandleError]
    public class HomeController : Controller
    {
        private readonly IMongoRepository mongoRepository;

        public HomeController(IMongoRepository mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public ActionResult Index()
        {
            mongoRepository.Add(new WebsiteVisit());

            var hits = mongoRepository.Retrieve<WebsiteVisit>().Count();

            var testMessage = "Hits: {0}";

            ViewData["Message"] = string.Format(testMessage, hits);

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}