using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SINIFIM.SISTEM.Areas._admin.Controllers
{
    public class teachersController : Controller
    {
        // GET: _admin/teachers
        public ActionResult operations()
        {
            //Tüm hocalar burada listelenecek
            return View();
        }
        public ActionResult add()
        {
            //Burada hoca ekleme sayfası açılacak
            return View();
        }
        public ActionResult delete()
        {
            return View();
        }
        
        
    }
}