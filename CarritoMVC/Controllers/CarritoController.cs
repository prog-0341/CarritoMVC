using CarritoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarritoMVC.Controllers
{
    public class CarritoController : Controller
    {
        private static List<Producto> _productos = new();
        private static int _nextId = 1;

        // GET: /Carrito/Index
        public IActionResult Index()
        {
            return View(_productos);
        }

        // GET: /Carrito/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Carrito/Create
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.Id = _nextId++;
                _productos.Add(producto);
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: /Carrito/Delete/1
        public IActionResult Delete(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return RedirectToAction("Index");
            return View(producto);
        }

        // POST: /Carrito/Delete/1
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto != null) _productos.Remove(producto);
            return RedirectToAction("Index");
        }
    }
}