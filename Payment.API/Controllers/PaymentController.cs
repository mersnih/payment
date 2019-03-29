using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
 

       // [EnableCors("MyPolicy")]
        [HttpPost]
        public IActionResult Post(string storeName,string txndatetime, string chargetotal, string currency)
        {
            if(!string.IsNullOrEmpty(storeName) 
               && !string.IsNullOrEmpty(txndatetime)
               && !string.IsNullOrEmpty(chargetotal)
               && !string.IsNullOrEmpty(currency)){

                    string input = storeName + txndatetime + chargetotal + currency + "20192019";
                    string output = Billing.sha256(input);
                    return Json(output);
               }
               else{
                    return BadRequest();
               }

        }

         public class Billing
         {
            public  string txntype {get; set;}
            public string timezone {get; set;}
            public string txndatetime {get; set;}
            public string hash_algorithm {get; set;}
            public string hash {get; set;}
            public int storename {get; set;} // Store id
            public string mode {get; set;}
            public int  chargetotal {get; set;}
            public int  currency {get; set;} // numeric ISO value

            internal static string sha256(string s)
            {
                string ascii = stringToAscii(s);
                var crypt = new System.Security.Cryptography.SHA256Managed();
                var hash = new System.Text.StringBuilder();
                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(ascii));
                foreach (byte theByte in crypto)
                {
                    hash.Append(theByte.ToString("x2"));
                }
                return hash.ToString();
            }

            internal static string stringToAscii(string s)
            {
                StringBuilder sb = new StringBuilder();
                foreach( char c in s)
                {
                    sb.Append(System.Convert.ToInt32(c));
                }
                Console.WriteLine("INPUT : " + s + "OUTPUT : " + sb.ToString());
                return sb.ToString();
            }
         }   
    }
}