using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_VTS_.Models;


namespace Test_VTS_.Controllers
{
    public class Vehicle_DetailsController : Controller
    {
        private const int pageSize = 5;
        private object product;

        // GET: Vehicle_Details
        public ActionResult Index()
        {
            //int pageNumber = ?? {1});
            //var model = product.GetList.ToList().ToPagedList(pageNumber, pageSize);
            VTS_DBHandle dbhandle = new VTS_DBHandle();
            ModelState.Clear();
            return View(dbhandle.GetVehicleDetils());
        }
        // GET: Vehicle_Details/Details/5
            public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vehicle_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicle_Details/Create
        [HttpPost]
        public ActionResult Create(Vehicle vModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VTS_DBHandle sdb = new VTS_DBHandle();
                    if (sdb.AddVehicle(vModel))
                    {
                        ViewBag.Message = "Vechile Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        // GET: Vehicle_Details/Edit/5
        public ActionResult Edit(int id)
        {
            VTS_DBHandle sdb = new VTS_DBHandle();
            return View(sdb.GetVehicleDetils().Find(vModel => vModel.ID == id));
        }

        // POST: Vehicle_Details/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Vehicle vModel)
        {
            try
            {
                VTS_DBHandle sdb = new VTS_DBHandle();
                sdb.UpdateVehicleDetails(vModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehicle_Details/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                VTS_DBHandle sdb = new VTS_DBHandle();
                if (sdb.DeleteVehicle(id))
                {
                    ViewBag.AlertMsg = "Vehicle Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Vehicle_Details/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
