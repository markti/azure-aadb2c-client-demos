using System.ComponentModel;
using Xamarin.Forms;
using App3.ViewModels;

namespace App3.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
