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
        public async Task<ActionResult> delete(int id)
        {
            bool result = await hocaOps.DeleteArGorAsync(id);


            return View();
        }
        public async Task<ActionResult> passreset(int id)
        {
            ArgorTB result = await hocaOps.ReadArGorAsync(id);
            Random ikiliUretec = new Random();
            Random ucluUretec = new Random();
            string sifre = $"hoca{ikiliUretec.Next(10, 99)}{ucluUretec.Next(100, 999)}";
            result.sifre = sifre;
            ArgorTB yeniResult
                = await hocaOps.UpdateArGorAsync(result);
           
            bool emailResult
                = await new Models.GeneralFunctions().SendEmail(result.email, sifre);
            return View();
        }
      
        
        
    }
}