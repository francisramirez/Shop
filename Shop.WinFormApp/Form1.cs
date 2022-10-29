using System.Windows.Forms;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Net;
namespace Shop.WinFormApp
{
    public partial class Form1 : Form
    {
        string baseUrl = ConfigurationManager.AppSettings["baseUrl"].ToString();
       
        public Form1()
        {
             InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var result = loadCategories();


        }
        async Task<CategoryResult> loadCategories()
        {
            var category = new CategoryResult();
             
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(this.baseUrl);


                   //client.GetType
                    var resp = await client.GetAsync("api/Categories");

                    if (resp.IsSuccessStatusCode)
                    {
                        string apiResponse = await resp.Content.ReadAsStringAsync();
                        category = JsonConvert.DeserializeObject<CategoryResult>(apiResponse);
                    }
                    else
                    {
                        MessageBox.Show("Error obteniendo las categorias..");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error obteniendo las categorias..", ex.Message);
            }

            return category;
        }

        private void btnCargaCategorias_Click(object sender, EventArgs e)
        {
            var result = loadCategoriesNoAsync();

            dataGridView1.DataSource = result.data;
            dataGridView1.Refresh();
        }

        CategoryResult loadCategoriesNoAsync()
        {
            var category = new CategoryResult();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(this.baseUrl);


                    //client.GetType
                    var resp = client.GetAsync("api/Categories");

                    if (resp.Result.IsSuccessStatusCode)
                    {
                        string apiResponse = resp.Result.Content.ReadAsStringAsync().Result;
                        category = JsonConvert.DeserializeObject<CategoryResult>(apiResponse);
                    }
                    else
                    {
                        MessageBox.Show("Error obteniendo las categorias..");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error obteniendo las categorias..", ex.Message);
            }

            return category;
        }

    }
    public class ServiceResult
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
    public class CategoryDetailResult : ServiceResult
    {
        public CategoryList data { get; set; }
    }
    public class CategoryList
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
    }
}
