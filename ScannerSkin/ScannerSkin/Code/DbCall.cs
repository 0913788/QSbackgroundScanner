using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ScannerSkin.Code
{
    class DbCall
    {
        public void Query()
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection("Data Source=145.24.222.155,8080;Database=KickstartRotterdam;Persist Security Info=True;User ID=KickstartRotterdam;Password=Pr0ject3");
            Connection.Open();

            SqlCommand Command = new SqlCommand("SELECT month(cast(TheftDate as DATE)), convert(char(3), TheftDate, 0) as Months, count(TheftID) as total from BicycleTheft group by month(cast(TheftDate as DATE)),convert(char(3), TheftDate, 0)order by month(cast(TheftDate as DATE))", Connection);
            using (SqlDataAdapter Data = new SqlDataAdapter(Command)) { Data.Fill(table); }
            foreach (DataRow row in table.Rows)
            {

                Main_Chart.Series["Bicycle thefts"].Points.AddXY(row["Months"], row["total"]);
            }
            Connection.Close();
        }
    }
}
