using Library.Data;
using Library.Models;
using Library.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryContext _DBContext;

        public HomeController(LibraryContext libraryContext)
        {
            _DBContext = libraryContext;
        }

        public IActionResult Main()
        {
            List<Categories> categories = _DBContext.Categories.ToList();
            categories.Insert(0, new Categories { CategoryId = 0, CategoryName = "Select" });
            ViewBag.Categories = categories;
            return View();
        }

        public List<SubCategories> GetSubCategories(int categoryId)
        {
            DataTable dtResult = new DataTable();
            List<SubCategories> subCategories = new List<SubCategories>();
            using (SqlConnection sqlCon = new SqlConnection(DBConfig.ConnectionString))
            {
                sqlCon.Open();
                string query = $"EXEC proc_get_subcategories '{categoryId}'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                dtResult = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dtResult);
            }
            subCategories = JsonConvert.DeserializeObject<List<SubCategories>>(JsonConvert.SerializeObject(dtResult));
            return subCategories;
        }

        public List<BookDetails> GetBookDetail(int subCatId)
        {
            List<BookDetails> bookDetail = new List<BookDetails>();
            bookDetail = _DBContext.BookDetails.Where(b => b.SubCategoryId == subCatId).ToList();
            return bookDetail;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}