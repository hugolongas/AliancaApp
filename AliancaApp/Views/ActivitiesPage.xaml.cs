using AliancaApp.Models;
using AliancaApp.ViewModels;
using AliancaApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AliancaApp.Views
{
    public partial class ActivitiesPage : ContentPage
    {
        ActivitiesViewModel _viewModel;

        public ActivitiesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ActivitiesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}