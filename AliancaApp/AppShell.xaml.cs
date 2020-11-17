using AliancaApp.ViewModels;
using AliancaApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AliancaApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ActivityDetailPage), typeof(ActivityDetailPage));
            Routing.RegisterRoute(nameof(NewsDetailPage), typeof(NewsDetailPage));
        }

    }
}
