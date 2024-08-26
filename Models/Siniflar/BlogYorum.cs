using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Siniflar
{
    public class BlogYorum
    {
        public IEnumerable<Blog> Bloglarim { get; set; }
        public IEnumerable<Yorumlar> Yorumlarım { get; set; }
        public  Blog Blogum { get; set; }
    }
}