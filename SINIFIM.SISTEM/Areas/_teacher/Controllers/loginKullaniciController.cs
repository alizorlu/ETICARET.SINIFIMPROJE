using SINIFIM.DATABASE;
using SINIFIM.MODEL.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SINIFIM.SISTEM.Areas._teacher.Controllers
{
    public class loginKullaniciController: Controller
    {
        private readonly HocalarOperations hocaactions;
       public loginKullaniciController()
        {
            hocaactions = new HocalarOperations();
        }

        public ActionResult singin()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> singinserver(string email,string password)
        {
            List<ArgorTB> tumhocalar = await hocaactions.GetAllArGorAsync();
            tumhocalar = tumhocalar.Where(sa => sa.email.Equals(email)).ToList();
            tumhocalar = tumhocalar.Where(sa => sa.sifre.Equals(password)).ToList();
            if (tumhocalar == null) return RedirectToAction("", "");
            if(tumhocalar.Count==1)
            {
                var girisYapan = tumhocalar.First();
                girisYapan.songiris = DateTime.Now;
                await hocaactions.UpdateArGorAsync(girisYapan);
                return RedirectToAction("dashboard", "operations");
            }
            return View();
        }
    }
}