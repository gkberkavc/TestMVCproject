using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TESTPROJE_1_MVC.DataAccess.Concrete;
using TESTPROJE_1_MVC.Entities.Concrete;
using TESTPROJE_1_MVC.Models;

namespace TESTPROJE_1_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Context db = new Context();
            List<Words> words = db.Kelime.ToList();

            Random random= new Random();
            Random randomcolor = new Random();
            int sayi = random.Next(1, 4);

            int color = randomcolor.Next(1, 6);

            string renk = "";

            switch (color)
                
            {
                case 1: renk = "blue";
                        break;
                case 2:
                    renk = "white";
                    break;
                case 3:
                    renk = "yellow";
                    break;
                case 4:
                    renk = "brown";
                    break;
                case 5:
                    renk = "pink";
                    break;

                default:
                
                    break;
            }
          
            WordViewModel wvm = new WordViewModel();

            var soz = words.FirstOrDefault(a => a.Id == sayi);
            wvm.Id = soz.Id;
            wvm.desc = soz.Word;
            wvm.Color = renk;
            return View(wvm);
        }

        [HttpGet]
        public IActionResult Addword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Addword(string txtSoz)
        {
            Context _context=new Context();
            Words word = new Words();
            word.Word = txtSoz;

            _context.Add(word);
            _context.SaveChanges();

            ViewBag.Message = "Kayıt Başarılı bir şekilde eklendi";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}