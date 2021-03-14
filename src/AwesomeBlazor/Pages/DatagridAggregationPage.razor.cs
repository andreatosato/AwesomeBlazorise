
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomeBlazor.Pages
{
    public partial class DatagridAggregationPage
    {
        protected override void OnInitialized()
        {
            ProductInitialize();
        }

        public List<Product> Products { get; set; } = new();
        private void ProductInitialize()
        {
            Products.AddRange(new[] {
                new Product { Name = "Mela Renetta", Price = 0.15m, AvailableInStock = 142, BuyCount = 56, Year= 2021 },
                new Product { Name = "Mela Golden Delicious", Price = 0.15m, AvailableInStock = 42, BuyCount = 32, Year = 2021 },
                new Product { Name = "Mela Stark Delicious", Price = 0.15m, AvailableInStock = 42, BuyCount = 6, Year = 2021 },
                new Product { Name = "Mela Fuji", Price = 0.10m, AvailableInStock = 2_000, BuyCount = 100, Year = 2021 },              
                new Product { Name = "Mela Royal Gala", Price = 0.12m, AvailableInStock = 80, BuyCount = 2, Year = 2021 },
                new Product { Name = "Mela Annurca", Price = 0.12m, AvailableInStock = 42, BuyCount = 9, Year = 2021 },
                new Product { Name = "Mela Pink Lady", Price = 0.13m, AvailableInStock = 0, BuyCount = 6, Year = 2021 },
                new Product { Name = "Mela Braeburn", Price = 0.16m, AvailableInStock = 42, BuyCount = 6, Year = 2021 },
                new Product { Name = "Mela Morgenduft", Price = 0.162m, AvailableInStock = 48, BuyCount = 2, Year = 2021 },
                new Product { Name = "Mela Imperatore", Price = 0.168m, AvailableInStock = 0, BuyCount = 20, Year = 2021 },

                new Product { Name = "Mela Renetta", Price = 0.15m, AvailableInStock = 2, BuyCount = 560, Year= 2020 },
                new Product { Name = "Mela Golden Delicious", Price = 0.15m, AvailableInStock = 2, BuyCount = 320, Year = 2020 },
                new Product { Name = "Mela Stark Delicious", Price = 0.15m, AvailableInStock = 2, BuyCount = 60, Year = 2020 },
                new Product { Name = "Mela Fuji", Price = 0.10m, AvailableInStock = 0, BuyCount = 10000, Year = 2020 },
                new Product { Name = "Mela Royal Gala", Price = 0.12m, AvailableInStock = 0, BuyCount = 200, Year = 2020 },
                new Product { Name = "Mela Annurca", Price = 0.12m, AvailableInStock = 10, BuyCount = 90, Year = 2020 },
                new Product { Name = "Mela Pink Lady", Price = 0.13m, AvailableInStock = 0, BuyCount = 60, Year = 2020 },
                new Product { Name = "Mela Braeburn", Price = 0.16m, AvailableInStock = 0, BuyCount = 60, Year = 2020 },
                new Product { Name = "Mela Morgenduft", Price = 0.162m, AvailableInStock = 0, BuyCount = 200, Year = 2020 },
                new Product { Name = "Mela Imperatore", Price = 0.168m, AvailableInStock = 0, BuyCount = 200, Year = 2020 },

                new Product { Name = "Mela Renetta", Price = 0.15m, AvailableInStock = 0, BuyCount = 560, Year= 2019 },
                new Product { Name = "Mela Golden Delicious", Price = 0.15m, AvailableInStock = 0, BuyCount = 320, Year = 2019 },
                new Product { Name = "Mela Stark Delicious", Price = 0.15m, AvailableInStock = 0, BuyCount = 60, Year = 2019 },
                new Product { Name = "Mela Fuji", Price = 0.10m, AvailableInStock = 0, BuyCount = 1000, Year = 2019 },
                new Product { Name = "Mela Royal Gala", Price = 0.12m, AvailableInStock = 0, BuyCount = 20, Year = 2019 },
                new Product { Name = "Mela Annurca", Price = 0.12m, AvailableInStock = 0, BuyCount = 90, Year = 2019 },
                new Product { Name = "Mela Pink Lady", Price = 0.13m, AvailableInStock = 0, BuyCount = 60, Year = 2019 },
                new Product { Name = "Mela Braeburn", Price = 0.16m, AvailableInStock = 0, BuyCount = 60, Year = 2019 },
                new Product { Name = "Mela Morgenduft", Price = 0.162m, AvailableInStock = 0, BuyCount = 200, Year = 2019 },
                new Product { Name = "Mela Imperatore", Price = 0.168m, AvailableInStock = 0, BuyCount = 200, Year = 2019 },
            });
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableInStock { get; set; }
        public int BuyCount { get; set; }
        public int Year { get; set; }
    }
}
