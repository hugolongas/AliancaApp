using AliancaApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AliancaApp.Views
{
    public partial class NewsDetailPage : ContentPage
    {
        public NewsDetailPage()
        {
            InitializeComponent();
            BindingContext = new NewsDetailViewModel();
        }
    }
}