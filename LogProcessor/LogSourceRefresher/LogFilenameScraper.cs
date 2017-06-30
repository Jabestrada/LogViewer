using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace LogProcessor.LogSourceRefresher
{
    public class LogFilenameScraper
    {
        private List<string> _logFilenames = new List<string>();

        public LogFilenameScraper(string sourceUrl, string rawHtml, DateTime referenceDate, int daysCovered)
        {
            try
            {
                if (!System.Uri.IsWellFormedUriString(sourceUrl, UriKind.Absolute))
                {
                    sourceUrl = System.Uri.EscapeUriString(sourceUrl);
                }

                string _strSitecoreFolder = string.Concat(sourceUrl.Split('/')[3], "/log.");

                if (!string.IsNullOrEmpty(rawHtml))
                {
                    rawHtml = rawHtml.Replace("<br>", string.Empty).Replace("<hr>", string.Empty);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(rawHtml.ToLower());
                    XmlNodeList nodes = xmlDoc.SelectNodes(@"//a");

                    DateTime dateFrom = referenceDate.AddDays(-(daysCovered));
                    while (dateFrom <= referenceDate)
                    {
                        string _strDate = dateFrom.ToString("yyyyMMdd");
                        string _strPattern = string.Concat(_strSitecoreFolder, _strDate);
                        foreach (XmlNode xml in nodes)
                        {
                            if (Regex.IsMatch(xml.OuterXml, _strPattern, RegexOptions.IgnoreCase))
                            {
                                _logFilenames.Add(xml.InnerText);
                            }
                        }
                        dateFrom = dateFrom.AddDays(1);
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }



        public string[] LogFilenames {
            get {
                return _logFilenames.ToArray<string>();
            }
        }


    }
}
