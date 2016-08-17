using Newtonsoft.Json;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;

namespace Dusty
{
    public partial class App : Application
    {
        private const string SECRETS_PATH = "Dusty.config.secrets";

        public static RestClient Client { get; private set; }
        public static Secrets Secrets { get; private set; }

        public App()
        {
            InitializeComponent();

            Secrets = ReadSecrets();
            //Client = new RestClient("http://192.168.1.75:8000/");
            Client = new RestClient("http://brock.in:4120/");

            Bootstrap.Run(this);
        }

        private static Secrets ReadSecrets()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            using (var stream = assembly.GetManifestResourceStream(SECRETS_PATH))
            {
                if (stream == null)
                    throw new FileNotFoundException($"Unable to find secrets file at the following resource path: '{SECRETS_PATH}'. " + 
                        "If you haven't yet done so, try copying from config.secrets.example to config.secrets and setting it to an embedded resource.");

                return new JsonSerializer().Deserialize<Secrets>(new JsonTextReader(new StreamReader(stream)));
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
