using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class DBconnection
    {
        public static SqlConnection con = new SqlConnection("server=DESKTOP-URI6F1G\\SQLEXPRESS;uid=sa;pwd=123;database=qlkhachsan");
    }
}
