using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
   public  class SqlParameterFactory
    {
        public static SqlParameter GetParameter
        {
            get
            {
                return new SqlParameter();
            }
        }
    }
}
