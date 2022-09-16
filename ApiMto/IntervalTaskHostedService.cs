using ApiMto.Application.UnitOfWork;
using ApiMto.Dto;
using ApiMto.Helper;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml;

namespace ApiMto
{
    public class IntervalTaskHostedService : IHostedService, IDisposable
    {
        private Timer? _timer;
       
        private readonly IServiceProvider serviceProvider;

        public IntervalTaskHostedService(IServiceProvider serviceProvider)
        {          
            this.serviceProvider = serviceProvider;
        }     
        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Check(null);
           _timer = new Timer(Check, null, TimeSpan.Zero, TimeSpan.FromSeconds(300));
            

            return Task.CompletedTask;
        }
        public async void ChangePass(Object? state)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopeService= scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                IEnumerable<Camera>? item = await scopeService.CameraApplication.Get();
                foreach(Camera val in item)
                {
                    var newPass = EncodingPass.EncryptPass(val.SerialNumber + "|" + val.Password);
                    val.Password = newPass;
                    await scopeService.CameraApplication.Update(val.Id, val);                   
                }
                Console.WriteLine("End");
            }
        }
        public async void Check(Object? state)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedService = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                IEnumerable<Server>? srv =await scopedService.ServerApplication.Get();
                bool deviceOn = true;
               foreach(Server sr in srv)
                {
                   
                        if (sr.BrandId == 1)
                        {
                            if (sr.PortAnalogo == 0)
                            {
                                var uri = "http://" + sr.IpAddress + "/ISAPI/ContentMgmt/InputProxy/channels/status";
                                var node = "InputProxyChannelStatus";
                                var tagName = "online";
                                var tagValue = "false";
                                await checkDeviceHik(sr, uri, node, tagName, tagValue);
                            }
                            if (sr.PortAnalogo > 0)
                            {
                                var uri = "http://" + sr.IpAddress + "/ISAPI/System/Video/inputs/channels";
                                var node = "VideoInputChannel";
                                var tagName = "resDesc";
                                var tagValue = "NO VIDEO";
                                var result=await checkDeviceHik(sr, uri, node, tagName, tagValue);
                                deviceOn = result;

                            }
                            if (sr.PortAnalogo > 0 && sr.CanalesIP > 0 && deviceOn)
                            {
                                var uri = "http://" + sr.IpAddress + "/ISAPI/ContentMgmt/InputProxy/channels/status";
                                var node = "InputProxyChannelStatus";
                                var tagName = "online";
                                var tagValue = "false";
                                await checkDeviceHik(sr, uri, node, tagName, tagValue);
                            }

                        }
                        if (sr.BrandId == 2)
                        {

                            foreach (var cam in sr.Cameras)
                            {
                                var uri = "";
                                if (cam.BrandId == 2)
                                {
                                    uri = "http://" + cam.IpAddress + "/cgi-bin/viewer/getparam.cgi?system_hostname&system_info";
                                }
                                if (cam.BrandId == 6)
                                {
                                    uri = "http://" + cam.IpAddress + "/VideoServerSPN.xml";
                                }
                                var passUncryp = EncodingPass.DecryptPass(cam.Password).Split("|");
                                var response = await conDevice(uri, cam.User, passUncryp[1]);
                                if (response == null || !response.IsSuccessStatusCode)
                                {
                                    updateDevice(cam, false);
                                    addLog(cam, "OffLine", false);
                                    addEvent(cam, "OffLine");
                                }
                                else if (response.IsSuccessStatusCode)
                                {
                                    if (cam.Online == false)
                                    {
                                        updateDevice(cam, true);
                                        addLog(cam, "OnLine", true);
                                        deleteEvent(cam);
                                    }
                                }



                            }

                        }
                    
                   
                }
            }
            Console.WriteLine("End");              
        }

        private async Task<bool> checkDeviceHik(Server sr,string uri,string node, string tagName, string tagValue)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedService = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var passUncryp = EncodingPass.DecryptPass(sr.Password).Split("|");
                var response = await conDevice(uri, sr.User,passUncryp[1]);
                if (response == null)
                {
                   
                    foreach (var cam in sr.Cameras)
                    {
                        Console.WriteLine("Error NVR "+ cam.Id);
                        updateDevice(cam, false);
                        addLog(cam, "Error NVR", false);
                        addEvent(cam, "Error NVR");
                    }
                    return false;
                }
                else
                {
                   
                   var content = new ContentResult
                    {
                        ContentType = "application/xml",
                        Content = await response.Content.ReadAsStringAsync(),
                        StatusCode = 200
                    };
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(content.Content);
                    XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName(node);
                    foreach (XmlNode xmlNode in xmlNodeList)
                    {
                        var channel = "";
                        foreach (XmlNode item in xmlNode)
                        {
                            if (item.Name.Equals("id")) channel = item.InnerText;
                            if (item.Name.Equals(tagName) && item.InnerText.Equals(tagValue))
                            {
                                foreach (var cam in sr.Cameras)
                                {
                                    if (cam.PortChannel == Convert.ToInt32(channel))
                                    {
                                        Console.WriteLine("Cam Offline " + cam.Id);
                                        updateDevice(cam, false);
                                        addLog(cam, "OffLine", false);
                                        addEvent(cam, "OffLine");
                                    }
                                }
                            }
                            if (item.Name.Equals(tagName) && !item.InnerText.Equals(tagValue))
                            {
                                foreach (var cam in sr.Cameras)
                                {
                                    if (cam.PortChannel == Convert.ToInt32(channel))
                                    {
                                        if (cam.Online == false)
                                        {
                                            updateDevice(cam, true);
                                            addLog(cam, "OnLine", true);
                                            deleteEvent(cam);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return true;
                }
            }
        }
        private static async Task<HttpResponseMessage> conDevice(string uri,string user, string pass)
        {
            var response = new HttpResponseMessage();
            var credCache = new CredentialCache();            
            credCache.Add(new Uri(uri),"Digest", new NetworkCredential(user,pass));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            try
            {
                response = await client.GetAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                    credCache.Add(new Uri(uri), "Basic", new NetworkCredential(user, pass));
                    client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                    response = await client.GetAsync(uri);
                }
                //response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                response = null;
            }
            return response;
        }
        private async void updateDevice(Camera cam, bool online)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedService = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                cam.Online = online;
                await scopedService.CameraApplication.Update(cam.Id, cam);
            }
        }
        private async void addLog(Camera cam, string msg, bool type)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedService = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                Log log = new Log { CameraId = cam.Id, Evento = msg, UsuarioId = 1, Type = type };
                var logCamera = await scopedService.LogApplication.FindByCameraId(cam.Id);
                if (logCamera == null) await scopedService.LogApplication.Add(log);
                if (logCamera != null)
                {
                    if (logCamera.Type != false) await scopedService.LogApplication.Add(log);
                }
            }

        }
        private async void addEvent(Camera cam,string msg)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedService = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                Evento evento = new Evento { CameraId = cam.Id, Comment = msg };
                var eventCam = await scopedService.EventoApplication.FindByCam(cam.Id);
                if (eventCam == null)
                {

                    await scopedService.EventoApplication.Add(evento);
                }
            }

        }
        private async void deleteEvent(Camera cam)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedService = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var evento = await scopedService.EventoApplication.FindByCam(cam.Id);
                if(evento != null) await scopedService.EventoApplication.Delete(evento);
            }

        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();            
        }
    }
}
