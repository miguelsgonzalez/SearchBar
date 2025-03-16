using SearchBar.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;

namespace SearchBar
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Produto> Produtos { get; set; }
        public ObservableCollection<Produto> FilteredItems { get; set; }

        private string searchText = string.Empty;

        public MainPage()
        {
            InitializeComponent();
            Produtos = new ObservableCollection<Produto>
            {
                new Produto { Nome = "Camisa", Preco = 49.90M },
                new Produto { Nome = "Calça Jeans", Preco = 129.90M },
                new Produto { Nome = "Tênis", Preco = 199.90M },
                new Produto { Nome = "Boné", Preco = 39.90M },
                new Produto { Nome = "Jaqueta", Preco = 299.90M }
            };

            FilteredItems = new ObservableCollection<Produto>(Produtos);

        
            BindingContext = this;
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            searchText = e.NewTextValue?.ToLower() ?? string.Empty;
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (string.IsNullOrEmpty(searchText))
            {
                FilteredItems = new ObservableCollection<Produto>(Produtos);
            }
            else
            {
                var filteredList = Produtos.Where(p => p.Nome.ToLower().Contains(searchText)).ToList();
                FilteredItems = new ObservableCollection<Produto>(filteredList);
            }


            productListView.ItemsSource = FilteredItems;
        }
    }
}
