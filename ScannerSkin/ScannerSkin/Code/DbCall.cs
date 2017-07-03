using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace ScannerSkin.Code
{
    class DbCall
    {
        public async void PostLocation(int empID, float x, float y)
        {
            using (var client = new HttpClient())
            {
                var response =
                    await client.GetStringAsync(string.Format("http://145.24.222.153/Webserver/NewPosition/?empId={}&X={}&Y={}",empID, x, y));
            }
        }
    }
}
