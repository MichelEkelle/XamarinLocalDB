using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using XamarinLocalDB.Models;

namespace XamarinLocalDB.DataServices
{
    public class ProductDatabaseController
    {
        private SQLiteAsyncConnection connection;
        public string StatusMessage { get; set; }
        public ProductDatabaseController(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<Product>();
        }

        public async Task AddNewProductAsync(string name) 
        {
            int result = 0;
            try
            {
                result = await connection.InsertAsync(new Product { Name = name});
                StatusMessage = $"{result} produit ajouté : {name}";
            }
            catch (Exception e)
            {

                StatusMessage = $"Impossible d'ajouter le produit : {name}.\n Erreur : {e.Message}";
            }
        }

        public async Task UpdateProductAsync(Product newProduct)
        {
            int result = 0;
            try
            {
                result = await connection.UpdateAsync(newProduct);
                StatusMessage = $"{result} produit mise à jours : {newProduct.Name}";
            }
            catch (Exception e)
            {
                StatusMessage = $"Impossible de mettre à jours le produit : {newProduct.Name}.\n Erreur : {e.Message}";
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                return await connection.Table<Product>().ToListAsync();
            }
            catch (Exception e)
            {

                StatusMessage = $"Impossible de récupérer la liste des produits.\n Erreur : {e.Message}";
            }
            return new List<Product>();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            try
            {
                return await connection.Table<Product>().Where(i => i.ID == id).FirstOrDefaultAsync();

            }
            catch (Exception e)
            {

                StatusMessage = $"Impossible de récupérer le produits identifié : {id}.\n Erreur : {e.Message}";
            }
            return null;
        }

        public async Task DeleteProduct(Product deletedProduct)
        {
            try
            {
                var result = await connection.DeleteAsync<Product>(deletedProduct);
                StatusMessage = $"{result} produit  supprimé : {deletedProduct.Name}";
            }
            catch (Exception e)
            {

                StatusMessage = $"Impossible de supprimer  le produit : {deletedProduct.Name}.\n Erreur : {e.Message}";
            }
        }
    }
}
