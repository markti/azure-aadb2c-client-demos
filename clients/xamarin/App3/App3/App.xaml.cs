using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App3.Services;
using App3.Views;
using Microsoft.Identity.Client;
using Xamarin.Essentials;
using System.Text;
using System.Net;
using App3.Features.LogOn;

namespace App3
{
    public partial class App : Application
    {
        private static string DomainName = "";
        public static string ApiEndpoint = $"https://{DomainName}.azurewebsites.net/hello";

        public App ()
        {
            InitializeComponent();

            /* NOTE on Dependency Injection in Xamarin:
             * 
             * 'B2CAuthenticationService' implements the 'IAuthenticationService' interface. 
             * Using the DependencyService we can register the 'B2CAuthenticationService' such 
             * that when we ask for an instance of the 'IAuthenticationService' like this:
             * 
             *      var authenticationService = DependencyService.Get<IAuthenticationService>();
             * 
             * it allows us to grab the instance of the B2CAuthenticationService that we register in the line below:
             * 
             * */
            DependencyService.Register<B2CAuthenticationService>();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}