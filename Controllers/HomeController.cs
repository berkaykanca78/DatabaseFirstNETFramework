using System.Linq;
using System.Web.Mvc;
using DatabaseFirstNETFramework.Models;

namespace DatabaseFirstNETFramework.Controllers
{
    public class HomeController : Controller
    {
        DatabaseFirstNETEntities DFE = new DatabaseFirstNETEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Listele()
        {
            return View(DFE.Oyuncus.ToList());
        }
    }
}