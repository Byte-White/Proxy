using Microsoft.AspNetCore.Mvc;
using Proxy.Models;
using System.Diagnostics;
using System.Net;


namespace Proxy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        private string GetLocalIpAddress()
        {
            string localIpAddress = "";

            foreach (var networkInterface in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                var ipProperties = networkInterface.GetIPProperties();
                foreach (var unicastIPAddressInformation in ipProperties.UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        string ipAddress = unicastIPAddressInformation.Address.ToString();
                        if (ipAddress.StartsWith("192.168"))
                        {
                            localIpAddress = ipAddress;
                            break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(localIpAddress))
                    break;
            }

            return localIpAddress;
        }



        public IActionResult Index()
        {
            string localIp = GetLocalIpAddress();
            ViewData["LocalIPAddress"] = localIp;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
