using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MercadoPago;
using MercadoPago.Resources;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Common;

namespace PruebaMercadoPago.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            MercadoPago.SDK.SetAccessToken("ENV_ACCESS_TOKEN");

            //MercadoPago.SDK.SetAccessToken = "ENV_ACCESS_TOKEN";

            Payment payment = new Payment
            {
                TransactionAmount = (float)100.0,
                Token = "YOUR_CARD_TOKEN",
                Description = "Ergonomic Silk Shirt",
                PaymentMethodId = "visa",
                Installments = 1,
                Payer = new Payer
                {
                    Email = "larue.nienow@hotmail.com"
                }
            };

            payment.Save();

            Console.Out.WriteLine(payment.Status);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}