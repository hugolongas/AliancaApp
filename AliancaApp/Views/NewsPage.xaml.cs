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
    public partial class NewsPage : ContentPage
    {
        NewsViewModel _viewModel;

        public NewsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new NewsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}