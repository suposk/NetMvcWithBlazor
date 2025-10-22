using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetMvcWithBlazor.Controllers;
public class PersonController : Controller
{
    // GET: PersonController1cs
    public ActionResult Index()
    {
        return View();
    }

    // GET: PersonController1cs/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: PersonController1cs/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PersonController1cs/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PersonController1cs/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: PersonController1cs/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PersonController1cs/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: PersonController1cs/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
