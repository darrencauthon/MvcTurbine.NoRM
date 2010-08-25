using System;
using System.Linq;
using System.Web.Mvc;
using MvcTurbine.NoRM;
using MvcTurbine.NoRM.Db;

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
        private readonly IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            repository.Add(new WebsiteVisit());

            var hits = repository.Retrieve<WebsiteVisit>().Count();

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