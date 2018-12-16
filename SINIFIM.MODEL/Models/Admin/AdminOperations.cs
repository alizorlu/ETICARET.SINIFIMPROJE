using SINIFIM.DATABASE;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity.Migrations;
using System;

namespace SINIFIM.MODEL.Models.Admin
{
    public class AdminOperations
    {
        private SinifimCom_SinifimDB2018DBEntities db { get; set; }
       
        public AdminOperations()
        {
            //Yeni bir veritabanı bağlantı oluştu
            db = new SinifimCom_SinifimDB2018DBEntities();
           
        }
        public async Task<List<AdminTB>> GetAllAdmins()
        {
            return db.AdminTB.ToList();
        }
        public async Task<bool> DeleteAdmin(int id)
        {
            //EKSTRA
            //var allAdmin = await GetAllAdmins();
            //var findedAdmin = allAdmin.Find(asda => asda.id == id);
            //if (findedAdmin == null) return false;
            //db.Entry(findedAdmin).State = System.Data.Entity.EntityState.Deleted;
            //await db.SaveChangesAsync();
            //return true;
            var findedAdmin
                = db.AdminTB.Find(id);
            if (findedAdmin == null) return false;
            db.AdminTB.Remove(findedAdmin);
            db.SaveChanges();
            return true;
            
        }
        public async Task<AdminTB> AddAdmin(AdminTB model)
        {
            db.AdminTB.AddOrUpdate(model);
            await db.SaveChangesAsync();
            return model;
        }
        public async Task<AdminTB> FindedAdmin(int id)
        {
            //var finden = db.AdminTB.ToList().Where(haci => haci.email.Equals(email)).FirstOrDefault();
            //if (finden != null) return finden;
            //else return null;
            return db.AdminTB.Find(id);
        }
        public async Task<AdminTB> UpdateAdmin(AdminTB model)
        {
            db.AdminTB.AddOrUpdate(model);
            await db.SaveChangesAsync();
            return model;
        }
        
    }
}
