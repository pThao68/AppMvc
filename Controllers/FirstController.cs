using AppMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;

        public FirstController (ILogger<FirstController> logger, ProductService productService){
            _productService = productService;
            _logger = logger;
        }
        public string Index(){
            // this.HttpContext
            // this.Request
            // this.Réponse
            // this. RouteData

            // this.User
            //this.ModelState
            //this.ViewData
            //this.ViewBag
            //this.Url
            //this.TempData
            _logger.LogWarning("Thongbao");
            _logger.LogError("Thongbao");
            _logger.LogDebug("Thongbao");
            _logger.LogCritical("Thongbao");
            _logger.LogInformation ("Index Action");

            //SeriLog


            //Console.Write
            return " Toi la Index cua first";
        }

        public void Nothing (){
            _logger.LogInformation("Nothing action");
            Response.Headers.Add("hi","xin chao cac ban");
        }
        public object Anything() => DateTime.Now;

        //IActionResult
        public IActionResult Readme()
        {
            var content = @"
            Xin chao cac ban,
            cac ban dang hoc ASP.NET";
            return Content(content,"text/plain");
        }

        // 
        public IActionResult Bird()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "First","1.jpg" );
            var bytes = System.IO.File.ReadAllBytes("D:\\LTWebNc\\AppMvc\\Files\\1.jpg");
            return File(bytes,"image/jpg");
        }

        // JsonResult
        public IActionResult IphonePrice()
        {
            return Json(
                new {
                    productName = "Iphone X",
                    Price = 1000
                }
            );
        }
        public IActionResult Privacy(){
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyen huong den" + url);
            return LocalRedirect(url);
        }
        public IActionResult Google(){
            var url = "https://google.com" ;
            _logger.LogInformation("Chuyen huong den" + url);
            return Redirect(url);
        }

        // View Result 
        public IActionResult HelloView(string username){
            if(string.IsNullOrEmpty(username))
            username = "Khach";
            // View () => Razor Engine 
            // return View("/MyView/xinchao1.cshtml", username);
            // return View("xinchao2", username);
            // return View((object)username);
            return View("xinchao3",username);
        }
        [TempData]
        public string StatusMessage {get; set;}
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if(product == null){
                // TempData["StatusMessage"] = "san pham khong co";
                StatusMessage = "san pham khong co";
                return Redirect(Url.Action ("Index", "Home"));
            }
                // return NotFound();
            // View/First/ViewProduct
            // return Content($"San pham ID = {id}");
            // return View(product);

            // this.ViewData["product"] = product;
            // this.ViewData["Title"] = product.Name;
            // return View();

            ViewBag.product = product;
            return View();
        }
    }
}