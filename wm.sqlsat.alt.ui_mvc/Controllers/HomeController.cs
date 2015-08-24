// General 
using System;
using System.Collections.Generic;
using System.Linq;

// Web Related
using System.Web;
using System.Web.Mvc;

// Web Services
using wm.sqlsat.alt.entity;
using wm.sqlsat.alt.svc;

namespace wm.sqlsat.alt.ui_mvc.Controllers
{
    /// <summary>
    /// Se comunica con la fachada sin saber que origines de datos existen 
    /// atrás
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Facade proxy = new Facade();

            var items = proxy.GetStudentsDistribution().ToList();

            ViewBag.ClassRooms = proxy.GetClassRooms();
            return View(items);
        }

        [HttpPost]
        public ActionResult PostClassRoom(ClassRoomEntity foo)
        {
            Facade proxy = new Facade();
            ViewBag.ClassRooms = proxy.GetClassRooms();
            proxy.InsertClassRoom(foo.Number, foo.Building, foo.Floor, foo.Capacity, foo.Description);

            return RedirectToAction("Index");
        }

    }
}