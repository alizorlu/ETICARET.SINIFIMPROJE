using SINIFIM.DATABASE;
using SINIFIM.MODEL.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SINIFIM.SISTEM.Areas._admin.Controllers
{
    public class teachersController : Controller
    {
        private HocalarOperations hocaOps { get; set; } = null;
        public teachersController() => hocaOps = new HocalarOperations();
        // GET: _admin/teachers
        public async Task<ActionResult> operations()
        {
            //Tüm hocalar burada listelenecek
            List<ArgorTB> allList = await hocaOps.GetAllArGorAsync();
            return View(allList);
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
        public ActionResult passreset()
        {
            return View();
        }
      
        
        
    }
}