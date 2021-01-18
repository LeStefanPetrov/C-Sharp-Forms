using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT_17621661_Exercise7
{
    class HTTP_Request
    {
        private string htmlContent;
        private string headContent;
        public string HtmlContent
        {
            get { return htmlContent; }
            set { htmlContent = value; }
        }

        public string HeadContent
        {
            get { return headContent; }
            set { headContent = value; }
        }
        public enum HTTP_Method { 
            GET,
            HEAD,
        }

        public HTTP_Request(string url,HTTP_Request.HTTP_Method method)
        {
            if (method == HTTP_Request.HTTP_Method.GET)
            {
                Get(url);
            }
            else
            {
                Head(url);
            }
        }

        private void Get(string url) 
        {
            try
            {

                HttpWebResponse response = (HttpWebResponse)WebRequest.Create(url).GetResponse();

                for (int i = 0; i < response.Headers.Count; i++)
                {
                    headContent = headContent + response.Headers.Keys[i] + ", Value : " + response.Headers[i] + Environment.NewLine;
                }

                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);

                htmlContent = streamReader.ReadToEnd();
                response.Close();
                streamReader.Close();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        MessageBox.Show("HTTP Status Code: " + (int)response.StatusCode + Environment.NewLine
                        + "Status Description: " + ((HttpWebResponse)ex.Response).StatusDescription,
                        "Exception occured !!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void Head(string url) 
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();

                for (int i = 0; i < response.Headers.Count; i++)
                {
                    headContent = this.headContent + response.Headers.Keys[i] + ", Value : " + response.Headers[i] + Environment.NewLine;
                }
                response.Close();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        MessageBox.Show("HTTP Status Code: " + (int)response.StatusCode + Environment.NewLine
                        + "Status Description: " + ((HttpWebResponse)ex.Response).StatusDescription,
                        "Exception occured !!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
