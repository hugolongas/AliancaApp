using AliancaApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AliancaApp.Views
{
    public partial class ActivityDetailPage : ContentPage
    {
        public ActivityDetailPage()
        {
            InitializeComponent();
            BindingContext = new ActivityDetailViewModel();
        }
    }
}