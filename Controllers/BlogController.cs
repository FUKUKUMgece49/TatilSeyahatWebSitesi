using System.Linq;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        TravelTripProje.Models.Siniflar.Context c = new TravelTripProje.Models.Siniflar.Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            // var bloglar = c.Blogs.ToList();
            by.Bloglarim = c.Blogs.ToList();
            by.Yorumlarım = c.Yorumlars.Take(3).ToList();
            return View(by);
        }

        //BlogYorum by=new BlogYorum();
        public ActionResult BlogDetay(int? id)
        {

            //var blogbul = c.Blogs.Where(x => x.ID == id)/*.ToList()*/;
            //return View(blogbul);
            if (id.HasValue)
            {
                var blogbul = c.Blogs.FirstOrDefault(x => x.ID == id);
                var yrm = c.Yorumlars.Where(x => x.ID == id).ToList();
                by.Blogum = blogbul;
                by.Yorumlarım = yrm;
                return View(by);
            }
            else
            {
                return View();
            }

        }

        // Resimleri Çekmek İçin ActionResult Metodu
        public ActionResult GetBlogImage(int id)
        {
            var blog = c.Blogs.FirstOrDefault(x => x.ID == id);
            if (blog != null && blog.BlogImage != null)
            {
                return File(blog.BlogImage, "image/jpeg");
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id) 
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}
