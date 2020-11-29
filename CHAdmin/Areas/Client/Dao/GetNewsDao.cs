using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace CHAdmin.Areas.Client.Dao
{
    public class GetNewsDao
    {
        public bool getDangkinhantin(string mail)
        {
            using(var db=new CoffeeHouseDbContext())
            {
                dknt dk = new dknt();
                dk.email = mail;
                dk.ngaydk = DateTime.Today;
                db.dknts.Add(dk);
                db.SaveChanges();
                //try
                //{
                //    db.dknts.Add(dk);
                //    db.SaveChanges();
                //}
                //catch (DbEntityValidationException dbEx)
                //{
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                //        }
                //    }
                //}
                return true;
            }
        }
    }
}