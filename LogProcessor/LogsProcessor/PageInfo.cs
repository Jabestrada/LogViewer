using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProcessor
{
    public class PageInfo
    {
        public readonly string PageName;
        public readonly string FullPath;
        public readonly int Version;
        public readonly string Language;

        public PageInfo(string pagePath) {
            if (string.IsNullOrEmpty(pagePath)) {
                throw new InvalidOperationException("pagePath cannot be empty");
            }

            // /sitecore/content/Page01|en|1
            string[] parts = pagePath.Split('|');
            FullPath = parts[0];
            int slashPos = FullPath.LastIndexOf('/');
            PageName = slashPos < 0 ? FullPath : FullPath.Substring(slashPos + 1);
            if (parts.Length >= 2)
            {
                Language = string.IsNullOrEmpty(parts[1]) ? "en" : parts[1];
            }
            else {
                Language = "en";
            }
            if (parts.Length >= 3)
            {
                int version;
                if (int.TryParse(parts[2], out version))
                {
                    Version = version;
                }
                else {
                    Version = 1;
                }
            }
            else {
                Version = 1;
            }
            
        }
    }
}
