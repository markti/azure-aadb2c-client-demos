using Microsoft.Identity.Client;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";

            AuthenticationResult authResult = null;
            IEnumerable<IAccount> accounts = await App.PublicClientApp.GetAccountsAsync();
            try
            {
                IAccount currentUserAccount = GetAccountByPolicy(accounts, App.PolicySignUpSignIn);
                authResult = await App.PublicClientApp.AcquireTokenSilent(App.ApiScopes, currentUserAccount)
                    .ExecuteAsync();

                //DisplayBasicTokenInfo(authResult);
                //UpdateSignInState(true);
            }
            catch (MsalUiRequiredException)
            {
                try
                {
                    authResult = await App.PublicClientApp.AcquireTokenInteractive(App.ApiScopes)
                        .WithAccount(GetAccountByPolicy(accounts, App.PolicySignUpSignIn))
                        .WithPrompt(Prompt.SelectAccount)
                        .ExecuteAsync();
                    //DisplayBasicTokenInfo(authResult);
                    //UpdateSignInState(true);
                }
                catch (Exception ex)
                {
                    ResultText.Text = $"Users:{string.Join(",", accounts.Select(u => u.Username))}{Environment.NewLine}Error Acquiring Token:{Environment.NewLine}{ex}";
                }
            }
            catch (Exception ex)
            {
                ResultText.Text = $"Users:{string.Join(",", accounts.Select(u => u.Username))}{Environment.NewLine}Error Acquiring Token:{Environment.NewLine}{ex}";
            }
        }

        private IAccount GetAccountByPolicy(IEnumerable<IAccount> accounts, string policy)
        {
            foreach (var account in accounts)
            {
                string userIdentifier = account.HomeAccountId.ObjectId.Split('.')[0];
                if (userIdentifier.EndsWith(policy.ToLower()))
                    return account;
            }

            return null;
        }

    }
}
