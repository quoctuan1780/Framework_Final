using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace CHAdmin.Areas.Client.Dao
{
    public class IntroductDao
    {
        CoffeeHouseDbContext context = null;
        public IntroductDao()
        {
            context = new CoffeeHouseDbContext();
        }

        public List<gioithieu> getGioithieu()
        {
            var query = context.gioithieux.ToList();
            return query;
        }
    }
}