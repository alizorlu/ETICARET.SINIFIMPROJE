using SINIFIM.DATABASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace SINIFIM.MODEL.Models.Admin
{
  
        public class HocalarOperations
        {
            private SinifimCom_SinifimDB2018DBEntities db { get; set; }
            public HocalarOperations() => db = new SinifimCom_SinifimDB2018DBEntities();

            public async Task<List<ArgorTB>> GetAllArGorAsync()
            {
                return db.ArgorTB.ToList();
            }

            public async Task<bool> AddArGorAsync(ArgorTB model)
            {
                try
                {
                    db.ArgorTB.Add(model);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch (System.Exception)
                {

                    return false;
                }
            }

            public async Task<bool> DeleteArGorAsync(int id)
            {
                try
                {
                    var finded = await db.ArgorTB.FindAsync(id);
                    db.ArgorTB.Remove(finded);
                    db.Entry(finded).State = System.Data.Entity.EntityState.Deleted;
                    await db.SaveChangesAsync();
                    return true;


                }
                catch (System.Exception)
                {

                    return false;
                }

            }
            public async Task<ArgorTB> UpdateArGorAsync(ArgorTB model)
            {
                db.ArgorTB.AddOrUpdate(model);
                db.SaveChangesAsync();
                return model;
            }

            public async Task<ArgorTB> ReadArGorAsync(int id)
            {
                return db.ArgorTB.Find(id);

            }

        }
    }

