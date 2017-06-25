using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using WebMCVWithoutEF.Models;

namespace WebMCVWithoutEF.Controllers
{
    public class ProductController : Controller
    {
       // string connectionString = @"(localdb)\MSSQLLocalDB; Initial Catalog=Studies; integrated security=True ";
        string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = studies; Integrated Security=True";

        // GET: Product
        public ActionResult Index()
        {
            DataTable dtProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT * FROM PRODUCT", sqlCon);
                sqlDA.Fill(dtProduct);
            }
            return View(dtProduct);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        // GET: Product/Create
        public ActionResult Create()
        {
            return View(new ProductModel());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            try
            {
                // TODO: Add insert logic here
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "INSERT PRODUCT VALUES (@ProductName,@Price,@Count)";
                    SqlCommand sqlCom = new SqlCommand(query, sqlCon);
                    sqlCom.Parameters.AddWithValue("@Productname", productModel.ProductName );
                    sqlCom.Parameters.AddWithValue("@Price", productModel.Price);
                    sqlCom.Parameters.AddWithValue("@Count", productModel.Count);
                    sqlCom.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductModel productModel = new ProductModel();
            DataTable dt = new DataTable();
            using (SqlConnection sqlC = new SqlConnection(connectionString))
            {
                sqlC.Open();
                string query = "Select * from Product where productid = @ProductId";
                SqlDataAdapter sqlDA = new SqlDataAdapter(query,sqlC);
                sqlDA.SelectCommand.Parameters.AddWithValue("@ProductId", id);
                sqlDA.Fill(dt);

            }
            if (dt.Rows.Count == 1)
            {
                productModel.ProductId   = Convert.ToInt16(dt.Rows[0][0].ToString());
                productModel.ProductName = Convert.ToString(dt.Rows[0][1].ToString());
                productModel.Price       = Convert.ToDecimal(dt.Rows[0][2].ToString());
                productModel.Count       = Convert.ToInt16(dt.Rows[0][3].ToString());
                return View(productModel);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductModel productModel)
        {
   
                // TODO: Add insert logic here
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE PRODUCT " +
                                   " SET " +
                                   " ProductName = @ProductName, " +
                                   " Price = @Price," +
                                   " Count = @Count " +
                                   " Where ProductId = @ProductId";
                    SqlCommand sqlCom = new SqlCommand(query, sqlCon);
                    sqlCom.Parameters.AddWithValue("@ProductID", productModel.ProductId );
                    sqlCom.Parameters.AddWithValue("@Productname", productModel.ProductName);
                    sqlCom.Parameters.AddWithValue("@Price", productModel.Price);
                    sqlCom.Parameters.AddWithValue("@Count", productModel.Count);
                    sqlCom.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM PRODUCT " +
                               " Where ProductId = @ProductId";
                SqlCommand sqlCom = new SqlCommand(query, sqlCon);
                sqlCom.Parameters.AddWithValue("@ProductID", id );

                //DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    //do something
                //}
                //else if (dialogResult == DialogResult.No)
                //{
                //    //do something else
                //}
                sqlCom.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

    }
}
