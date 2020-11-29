using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace CHAdmin.Areas.Client.Dao
{
    public class ContactDao
    {
        CoffeeHouseDbContext context = null;
        public ContactDao()
        {
            context = new CoffeeHouseDbContext();
        }

        public int postPhanHoi(phanhoi ph)
        {
            context.phanhois.Add(ph);
            return context.SaveChanges();
        }
    }
}