using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace SCNMonitor
{
    class SCNClient
    {
        private decimal download, upload, total;
        private int percentage;

        public decimal Download {
            get
            {
                return download;
            }
        }
        public decimal Upload
        {
            get
            {
                return upload;
            }
        }
        public decimal Total
        {
            get
            {
                return total;
            }
        }
        public int Percentage
        {
            get
            {
                return percentage;
            }
        }

        private readonly string URL;

        public SCNClient(string url)
        {
            URL = url;
        }

        async public Task Transfer()
        {
            string responseStr;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                try
                {
                    HttpResponseMessage response = await client.GetAsync(URL + "?view=transfer");
                    responseStr = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    throw new TransferCheckException("HTTP request failed!", e);
                }

                ParseUsage(responseStr);
            }
        }

        private decimal ExtractDecimal(string data)
        {
            decimal num;
            Match match = Regex.Match(data, @"\d+,\d+");
            if (!match.Success || !decimal.TryParse(match.Value, out num))
            {
                throw new TransferCheckException("Failed to match a decimal number!");
            }
            return num;
        }

        private int ExtractInt(string data)
        {
            int num;
            Match match = Regex.Match(data, @"\d+");
            if (!match.Success || !int.TryParse(match.Value, out num))
            {
                throw new TransferCheckException("Failed to match a number!");
            }
            return num;
        }

        private void ParseUsage(string htmlString)
        {
            HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.OptionFixNestedTags = true;
            html.LoadHtml(htmlString);
            if (html.ParseErrors != null && html.ParseErrors.Count() > 0 || html.DocumentNode == null)
            {
                throw new TransferCheckException("The HTML document is invalid!");
            }

            HtmlNodeCollection cells = html.DocumentNode.SelectNodes("//fieldset[position() = last() - 1]//table//td[@class='form_values']");
            HtmlNode span;
            if (cells == null || cells.Count < 3 || (span = cells[2].FirstChild) == null)
            {
                throw new TransferCheckException("The table could not be found!");
            }

            download = ExtractDecimal(cells[0].InnerHtml);
            upload = ExtractDecimal(cells[1].InnerHtml);
            total = ExtractDecimal(cells[2].InnerHtml);
            percentage = ExtractInt(span.InnerHtml);
        }
    }
}
