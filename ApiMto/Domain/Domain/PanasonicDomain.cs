using ApiMto.Domain.Interfaces;
using ApiMto.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiMto.Domain.Domain
{
    public class PanasonicDomain: IPanasonicDomain
    {
        public PanasonicDomain()
        {

        }

        public Camera InfoDeviceOne(ContentResult response)
        {
            var pageContent = response.Content;
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(pageContent);
            var nodes = html.DocumentNode.SelectSingleNode("//html");
            var result = new Camera();
            foreach (var node in nodes.SelectNodes(".//script"))
            {
                if (node.OuterHtml.Contains("InitThisPage"))
                {
                    var readNode = node.OuterHtml.Split("InitThisPage");
                    foreach (var item in readNode)
                    {
                        var contentVar = item.Split(";");
                        foreach (var item2 in contentVar)
                        {
                            if (item2.Contains("var sMacInfo"))
                            {
                                var titleArr = item2.Split("=");
                                var title = titleArr[1].Replace('"', ' ');
                                var macIfoArr = title.Trim().Split(" ");
                                var macIfoLine = macIfoArr[2].Split("&");
                                result.Mac = macIfoLine[0];
                                result.SerialNumber = macIfoLine[2];
                            }
                            if (item2.Contains("sTitle"))
                            {
                                var titleArr = item2.Split("=");
                                var title = titleArr[1].Replace('"', ' ');
                                result.Model = title.Trim();
                            }
                            if (item2.Contains("sCamname"))
                            {
                                var titleArr = item2.Split("=");
                                var title = titleArr[1].Replace('"', ' ');
                                result.Name = title.Trim();
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }
        public Camera InfoDeviceTwo(ContentResult response, int count, Camera result)
        {
            var pageContent = response.Content;
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(pageContent);
            if(count==1)result = CamModel(html, result);
            if (count == 2) result = CamName(html, result);
            if (count == 3) result = CamMac(html, result);
            return result;
        }
        private Camera CamModel(HtmlDocument html, Camera cam)
        {
            var nodes = html.DocumentNode.SelectSingleNode("//table");
            foreach (var node in nodes.SelectNodes(".//tr/td/font"))
            {
                var nod = node.SelectSingleNode(".//b");
                if (nod != null)
                {
                    if(nod.InnerText.Contains("BL"))cam.Model = nod.InnerText;
                    if (nod.InnerText.Contains("Version")) cam.FirmwareVersion = nod.InnerText;
                }
            }
            return cam;
        }
        private Camera CamName(HtmlDocument html, Camera cam)
        {

            var nodes = html.DocumentNode.SelectSingleNode("//div");
            foreach (var node in nodes.SelectNodes(".//table"))
            {
                Console.WriteLine(node.OuterHtml);

                var nod = node.SelectSingleNode(".//tr/td/table/tr/td/input");
                if (nod != null)
                {
                Console.WriteLine(nod.OuterHtml);
                    if (nod.Attributes["name"].Value == "CameraName")
                    {
                        cam.Name = nod.Attributes["value"].Value;
                    }
                }
            }
            return cam;
        }
        private Camera CamMac(HtmlDocument html, Camera cam)
        {

            var nodes = html.DocumentNode.SelectSingleNode("//body");
            var value = "";
            foreach (var node in nodes.SelectNodes(".//table/tr/td"))
            {
                Console.WriteLine(node.OuterHtml);

                var nod = node.SelectSingleNode(".//font");
                if (nod != null)
                {
                    Console.WriteLine(nod.OuterHtml);
                    if (value.Contains("MAC"))
                    {
                        cam.Mac = nod.InnerText;
                    }
                    if (nod.InnerText.Contains("MAC"))
                    {
                        value = nod.InnerText;
                    }
                    else { value = ""; }
                }
            }
            return cam;
        }
    }
}
