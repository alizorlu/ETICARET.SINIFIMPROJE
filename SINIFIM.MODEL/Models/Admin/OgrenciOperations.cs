using SINIFIM.DATABASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace SINIFIM.MODEL.Models.Admin
{
    public class OgrenciOperations
    {
        private SinifimCom_SinifimDB2018DBEntities db { get; set; }
        public OgrenciOperations() => db = new SinifimCom_SinifimDB2018DBEntities();
        public async Task<List<OgrenciTB>> GetAllOgrenciAsync()
        {
            return db.OgrenciTB.ToList();
        }
        public async Task<bool> AddOgrenciAsync(OgrenciTB model)
        {
            try
            {
                db.OgrenciTB.Add(model);
                await db.SaveChangesAsync();
                return true;

            }
            catch (System.Exception)
            {

                return false;
            }

        }
        public async Task<bool> DeleteOgrenciAsync(int id)
        {
            try
            {
                var finded = await db.OgrenciTB.FindAsync(id);
                db.OgrenciTB.Remove(finded);
                db.Entry(finded).State = System.Data.Entity.EntityState.Deleted;
                await db.SaveChangesAsync();
                return true;


            }
            catch (System.Exception)
            {

                return false;
            }

        }
        public async Task<OgrenciTB> UpdateOgrenciAsync(OgrenciTB model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChangesAsync();
            return model;

        }
        public async Task<OgrenciTB> ReadOgrenciTB(int id)
        {
            return db.OgrenciTB.Find(id);

        }

    }
}
