﻿using System;
namespace App3.Features.LogOn
{
    public static class B2CConstants
    {
        // Azure AD B2C Coordinates
        public static string Tenant = "foo.onmicrosoft.com";
        public static string AzureADB2CHostname = "foo.b2clogin.com";
        public static string ClientID = "xxx";
        public static string PolicySignUpSignIn = "b2c_1_susi";
        public static string PolicyEditProfile = "b2c_1_edit_profile";
        public static string PolicyResetPassword = "b2c_1_reset";

        public static string[] Scopes = { "https://foo.onmicrosoft.com/helloapi/demo.read" };

        public static string AuthorityBase = $"https://{AzureADB2CHostname}/tfp/{Tenant}/";
        public static string AuthoritySignInSignUp = $"{AuthorityBase}{PolicySignUpSignIn}";
        public static string AuthorityEditProfile = $"{AuthorityBase}{PolicyEditProfile}";
        public static string AuthorityPasswordReset = $"{AuthorityBase}{PolicyResetPassword}";
        public static string IOSKeyChainGroup = "com.microsoft.adalcache";
    }
}

