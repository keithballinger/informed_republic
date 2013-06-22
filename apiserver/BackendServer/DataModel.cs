using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace BackendServer.Controllers
{
    public partial class DataModel
    {
        private CloudBlobContainer Container()
        {
            CloudStorageAccount c = new CloudStorageAccount(
                new StorageCredentials(_accountName, _accountKey), useHttps: false);

            var client = c.CreateCloudBlobClient();
            return client.GetContainerReference("data");
        }

        public int GetRating(string issue)
        {
            string name = string.Format("ratings/{0}.txt", issue.ToLower());
            var c = Container();
            var blob = c.GetBlobReferenceFromServer(name);
            string val = Download(blob).Trim();

            return int.Parse(val);
        }

        public IEnumerable<Alert> GetAlerts(IEnumerable<string> issues)
        {
            foreach (var issue in issues)
            {
                foreach (var x in GetAlerts(issue))
                {
                    yield return x;
                }
            }
        }

        // data/alerts/{issue}/{file}
        public IEnumerable<Alert> GetAlerts(string issue)
        {
            string prefix = string.Format("alerts/{0}", issue.ToLower());
            return GetList<Alert>(prefix);
        }

        public IEnumerable<Alert> GetActions(IEnumerable<string> issues)
        {
            foreach (var issue in issues)
            {
                foreach (var x in GetAction(issue))
                {
                    yield return x;
                }
            }
        }


        public IEnumerable<Alert> GetAction(string issue)
        {
            string prefix = string.Format("actions/{0}", issue.ToLower());
            return GetList<Alert>(prefix);
        }

        public IEnumerable<TimelineData> GetEvents(IEnumerable<string> issues)
        {
            foreach (var issue in issues)
            {
                foreach (var x in GetEvents(issue))
                {
                    yield return x;
                }
            }
        }


        public IEnumerable<TimelineData> GetEvents(string issue)
        {
            string prefix = string.Format("events/{0}", issue.ToLower());
            return GetList<TimelineData>(prefix);
        }

        public IEnumerable<T> GetList<T>(string prefix)
        {
            CloudBlobContainer c = Container();
            foreach (var blob in c.ListBlobs(prefix: prefix, useFlatBlobListing: true))
            {
                string val = Download((ICloudBlob)blob);
                T a = JsonConvert.DeserializeObject<T>(val);
                yield return a;
            }

            yield break;
        }

        static string Download(ICloudBlob blob)
        {
            var b = ((CloudBlockBlob)blob);

            MemoryStream ms = new MemoryStream();
            b.DownloadToStream(ms);
            b.FetchAttributes();
            var props = b.Properties;

            string result = System.Text.Encoding.UTF8.GetString(ms.ToArray());
            return result;
        }
    }
}