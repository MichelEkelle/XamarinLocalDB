using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinLocalDB.Models;

namespace XamarinLocalDB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAddButtonClicked(object sender, EventArgs e) 
        {
            statusMessage.Text = "";
            await App.ProductDbController.AddNewProductAsync(newProduct.Text);

            statusMessage.Text = App.ProductDbController.StatusMessage;
        }

        private async void OnGetAllButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            List<Product> products = await App.ProductDbController.GetProductsAsync();
            Console.WriteLine("*********** LISTE DE PRODUITS **************");

            products.ForEach((prod) => {
                Console.WriteLine($"Id: {prod.ID} -  Name: {prod.Name}");
            });
            statusMessage.Text = App.ProductDbController.StatusMessage;
        }
    }
}
