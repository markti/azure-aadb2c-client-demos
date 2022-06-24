using System;
using App3.Features.LogOn;
using Microsoft.Identity.Client;
using Plugin.CurrentActivity;

namespace App3.Droid
{
    class AndroidParentWindowLocatorService : IParentWindowLocatorService
    {
        public object GetCurrentParentWindow()
        {
            return CrossCurrentActivity.Current.Activity;
        }
    }
}

