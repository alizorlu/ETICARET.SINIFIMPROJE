using SINIFIM.DATABASE;
using SINIFIM.MODEL.Models.Admin;
using SINIFIM.SISTEM.Areas._admin.Models;
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
        public async Task<ActionResult> add()
        {
            var result = await new AddedsModel().getEklemeModel();
            //Burada hoca ekleme sayfası açılacak
            return View(result);
        }
        
        [HttpPost]
        public async Task<ActionResult> add(ArgorTB model)
        {
            model.kayit = DateTime.Now;
            string sifre= new GeneralFunctions().RandomSifreGetir();
            model.sifre = sifre;
            bool result=await hocaOps.AddArGorAsync(model);
            result = await new GeneralFunctions().YeniKayitEmail(model.email, sifre);
            return RedirectToAction("operations", "teachers");
            //return View();
        }
        public async Task<ActionResult> delete(int id)
        {
            bool result = await hocaOps.DeleteArGorAsync(id);


            return View();
        }
        public async Task<ActionResult> passreset(int id)
        {
            ArgorTB result = await hocaOps.ReadArGorAsync(id);

            string sifre= new GeneralFunctions().RandomSifreGetir();
            result.sifre = sifre;
            ArgorTB yeniResult
                = await hocaOps.UpdateArGorAsync(result);
           
            bool emailResult
                = await new Models.GeneralFunctions().SendEmail(result.email, sifre);
            return View();
        }
      
        
        
    }
}