using AssignmnetQHRM.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AssignmnetQHRM.Controllers
{
    public class ProductController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<Product>("ProductViewAll"));
        }
        [HttpGet]
        // ../Employee/AddOrEdit
        // ../Employee/AddOrEdit/id 
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                return View(DapperORM.ReturnList<Product>("ProductViewByID", param).FirstOrDefault<Product>());

            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Product product)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", product.Id);
            param.Add("@ProductName", product.ProductName);
            param.Add("@Description", product.Description);
            param.Add("@Quantity", product.Quantity);
            DapperORM.ExecuteWithoutReturn("ProductAddOrEdit", param);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            DapperORM.ExecuteWithoutReturn("ProductDeleteByID", param);
            return RedirectToAction("Index");
        }
    }
}
