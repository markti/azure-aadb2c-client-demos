using Microsoft.Identity.Client;
using Microsoft.UI.Xaml;
using System;
using System.IO;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App2
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private static string DomainName = "";
        private static string ClientId = "";

        private static string Tenant = $"{DomainName}.onmicrosoft.com";
        private static string AzureADB2CHostname = $"{DomainName}.b2clogin.com";
        public static string PolicySignUpSignIn = "b2c_1_susi";
        private static string PolicyEditProfile = "b2c_1_edit_profile";
        private static string PolicyResetPassword = "b2c_1_reset";
        private static string RedirectUri = $"https://{AzureADB2CHostname}/oauth2/nativeclient";

        public static string[] ApiScopes = { $"https://{DomainName}.onmicrosoft.com/{ClientId}/demo.read" };
        public static string ApiEndpoint = $"https://{DomainName}.azurewebsites.net/hello";

        private static string AuthorityBase = "https://{hostname}/tfp/{tenant}/{policy}/".Replace("{hostname}", AzureADB2CHostname).Replace("{tenant}", Tenant);
        public static string AuthoritySignInSignUp = AuthorityBase.Replace("{policy}", PolicySignUpSignIn);
        public static string AuthorityEditProfile = AuthorityBase.Replace("{policy}", PolicyEditProfile);
        public static string AuthorityResetPassword = AuthorityBase.Replace("{policy}", PolicyResetPassword);

        public static IPublicClientApplication PublicClientApp { get; private set; }

        static App()
        {
            PublicClientApp = PublicClientApplicationBuilder.Create(ClientId)
                .WithB2CAuthority(AuthoritySignInSignUp)
                .WithRedirectUri(RedirectUri)
                .Build();
        }
        private static void Log(LogLevel level, string message, bool containsPii)
        {
            string logs = $"{level} {message}{Environment.NewLine}";
            File.AppendAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + ".msalLogs.txt", logs);
        }


        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window m_window;
    }
}
