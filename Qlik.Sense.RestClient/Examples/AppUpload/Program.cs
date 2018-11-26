﻿using System;
using System.IO;
using System.Linq;
using Qlik.Sense.RestClient;

namespace AppUpload
{
    class Program
    {
        static void Main(string[] args)
        {
            var senseServerUrl = args.Any() ? args[0] : "https://my.server.url";
            var restClient = new RestClient(senseServerUrl);
            restClient.AsNtlmUserViaProxy();

            var data = File.ReadAllBytes(@"\path\to\app.qvf");
            const string nameOfApp = "MyUploadedApp";
            Console.WriteLine(restClient.WithContentType("application/vnd.qlik.sense.app").Post("/qrs/app/upload?keepData=true&name=" + nameOfApp, data));
        }
    }
}
