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
    public class loginController : Controller
    {
        private readonly AdminOperations adminactionst;
        public loginController()
        {
            adminactionst = new AdminOperations();
        }
        // GET: _admin/login
        public ActionResult signin()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> signinserver(string email,string password)
        {
            List<AdminTB> tumadmins = await adminactionst.GetAllAdmins();//100 admin olabilir
            tumadmins = tumadmins.Where(sa => sa.email.Equals(email)).ToList();//3 düşürdüm
            tumadmins = tumadmins.Where(sa => sa.sifre.Equals(password)).ToList();//1'e düşmesi gerekir.
            if (tumadmins == null) return RedirectToAction("", "");
            if (tumadmins.Count == 1)
            {
                var girisYapan = tumadmins.First();//Giriş yapanı al
                girisYapan.sonaktivite = DateTime.Now;//Son giriş tarihine ekle
                await adminactionst.UpdateAdmin(girisYapan);//Güncelle
                return RedirectToAction("dashboard", "operations");

            }


            return View();
        }
        //[HttpPost]
        //public ActionResult signinserver(bool aktifmi)
        //{
        //    return View();
        //}
        public ActionResult signout()
        {
            return View();
        }
    }
}