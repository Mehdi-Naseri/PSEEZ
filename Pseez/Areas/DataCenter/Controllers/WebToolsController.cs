using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net;

namespace Pseez.Areas.DataCenter.Controllers
{
    public class WebToolsController : Controller
    {
        //
        // GET: /DataCenter/WebTools/
        public ActionResult Index()
        {

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string test = host.AddressList[0].ToString();
            string test2 = host.AddressList[1].ToString();
            //IEnumerable<string> IPs = host.AddressList.Select(a => a.ToString());
            //IEnumerable<string> IPs = from Ip in host.AddressList
            //                          select Ip.ToString();
            //List<string> IPs2 = new List<string>();
            //foreach (IPAddress s in host.AddressList)
            //{

            //    IPs2.Add(s.ToString());
            //}
            string IPs3 = null;
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    IPs3 = IPs3 +"<label>IP شبکه داخلی: </label>"+ ip.ToString() + "<br/>";
                else
                    IPs3 = ip.ToString() + "<br/>" + IPs3 ;
            }
            ViewBag.IP = IPs3;
            return View();
        }

        [HttpPost]
        public JsonResult DNS(string Text2DNS)
        {
            string stringResult = null;
            if (Text2DNS != null)
            {
                try
                {
                    System.Text.StringBuilder StringBuilder1 = new System.Text.StringBuilder(string.Empty);
                    //System.Net.IPHostEntry hostInfo = System.Net.Dns.Resolve(Text2DNS);
                    //This line replaces by next line (recomended by compiler).
                    System.Net.IPHostEntry hostInfo = System.Net.Dns.GetHostEntry(Text2DNS);
                    // Get the IP address list that resolves to the host names contained in the 
                    // Alias property.
                    System.Net.IPAddress[] address = hostInfo.AddressList;
                    // Get the alias names of the addresses in the IP address list.
                    String[] alias = hostInfo.Aliases;

                    StringBuilder1.Append("Host Name: " + hostInfo.HostName + "<br/>");
                    StringBuilder1.Append("<br/>Aliases:<br/>");
                    for (int index = 0; index < alias.Length; index++)
                    {
                        StringBuilder1.AppendLine(alias[index] + "<br/>");
                    }
                    StringBuilder1.Append("<br/>IP Address list :<br/>");
                    for (int index = 0; index < address.Length; index++)
                    {
                        StringBuilder1.Append(address[index] + "<br/>");
                    }
                    stringResult = StringBuilder1.ToString();
                }
                catch (Exception ex)
                {
                    stringResult = string.Format("DNS Failed: {0}", ex.Message);
                }
            }
            return Json(stringResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Ping(string Text2Ping)
        {
            string stringPingResult = null;
            if (Text2Ping != null)
            {
                try
                {
                    System.Text.StringBuilder StringBuilder1 = new System.Text.StringBuilder();
                    System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
                    System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();

                    // Use the default Ttl value which is 128,
                    // but change the fragmentation behavior.
                    options.DontFragment = true;

                    // Create a buffer of 32 bytes of data to be transmitted.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = System.Text.Encoding.ASCII.GetBytes(data);
                    int timeout = 999;
                    //TextBox 2 hold Address to be pinged 
                    System.Net.NetworkInformation.PingReply reply = pingSender.Send(Text2Ping, timeout, buffer, options);

                    if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        StringBuilder1.AppendFormat("Address: {0}<br/>", reply.Address.ToString());
                        StringBuilder1.AppendFormat("RoundTrip time: {0}<br/>", reply.RoundtripTime);
                        StringBuilder1.AppendFormat("Time to live: {0}<br/>", reply.Options.Ttl);
                        StringBuilder1.AppendFormat("Don't fragment: {0}<br/>", reply.Options.DontFragment);
                        StringBuilder1.AppendFormat("Buffer size: {0}<br/>", reply.Buffer.Length);
                    }
                    else
                    {
                        StringBuilder1.AppendLine(reply.Status.ToString());
                    }
                    stringPingResult = StringBuilder1.ToString();
                }
                catch (Exception ex)
                {
                    stringPingResult = string.Format("<i>Ping Failed:</i> {0}", ex.Message);
                }
            }
            return Json(stringPingResult, JsonRequestBehavior.AllowGet);
        }
    }
}