using Microsoft.AspNetCore.Mvc;
using Proxy.Models;
using System.Diagnostics;
using System.Net;
using QRCoder;


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

        private string GenerateQrCode(string content)
        {
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);

                using (var pngQRCode = new PngByteQRCode(qrCodeData))
                {
                    byte[] qrCodeBytes = pngQRCode.GetGraphic(20);
                    return "data:image/png;base64," + Convert.ToBase64String(qrCodeBytes);
                }
            }
        }


        public IActionResult Index()
        {
            string localIp = GetLocalIpAddress() + ":5087";
            ViewData["LocalIPAddress"] = localIp;
            ViewData["QrCodeImage"] = GenerateQrCode("http://" + localIp);
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
