using Masc_Model.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
   internal class GenerateContext
    {

       internal MASCContext GetContext()
        {
            DbContextOptionsBuilder<MASCContext> optionsBuilder = new DbContextOptionsBuilder<MASCContext>();
            string connectionString = "Data Source=adrian-desktop;Initial Catalog=MASCManager_Test;Integrated Security=True";
            optionsBuilder.UseSqlServer(connectionString);

            return new MASCContext(optionsBuilder.Options);
        }
    }
}
