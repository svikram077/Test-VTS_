using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Test_VTS_.Models;

namespace Test_VTS_.Controllers
{
    public class User_VehicleController : Controller
    {
        
        // GET: User_Vehicle
        public ActionResult Index()
        {


            VTS_DBHandle dbhandle = new VTS_DBHandle();
            ModelState.Clear();
            return View(dbhandle.GetUserDetails());
        }

        

        // GET: User_Vehicle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User_Vehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_Vehicle/Create
        [HttpPost]
        public ActionResult Create(User uModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VTS_DBHandle sdb = new VTS_DBHandle();
                    if (sdb.AddUser(uModel))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: User_Vehicle/Edit/5
        public ActionResult Edit(int id)
        {
            VTS_DBHandle sdb = new VTS_DBHandle();
            return View(sdb.GetUserDetails().Find(smodel => smodel.UserID == id));
        }

        // POST: User_Vehicle/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User uModel)
        {
            try
            {
                VTS_DBHandle sdb = new VTS_DBHandle();
                sdb.UpdateDetails(uModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User_Vehicle/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                VTS_DBHandle sdb = new VTS_DBHandle();
                if (sdb.DeleteUser(id))
                {
                    ViewBag.AlertMsg = "User Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: User_Vehicle/Delete/5
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
