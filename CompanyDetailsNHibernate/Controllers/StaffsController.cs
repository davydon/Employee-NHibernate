using CompanyDetailsNHibernate.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyDetailsNHibernate.Controllers
{
    public class StaffsController : Controller
    {
        // GET: Staffs
        public ActionResult Index()
        {
            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                var staffs = session.Query<Staffs>().ToList();
                return View(staffs);
            }
            
        }

        // GET: Staffs/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                var staff = session.Get<Staffs>(id);
                return View(staff);
            }
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        [HttpPost]
        public ActionResult Create(Staffs staffs)
        {
            try
            {
                using(ISession session = OpenNHibernateSession.OpenSession())
                {
                    using(ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(staffs);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                var staff = session.Get<Staffs>(id);
                return View(staff);
            }
        }

        // POST: Staffs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Staffs staffs)
        {
            try
            {
                using(ISession session = OpenNHibernateSession.OpenSession())
                {
                    var staffsUptodate = session.Get<Staffs>(id);

                    staffsUptodate.Surname = staffs.Surname;
                    staffsUptodate.Firstname = staffs.Firstname;
                    staffsUptodate.Address = staffs.Address;
                    staffsUptodate.Phone = staffs.Phone;
                    staffsUptodate.Email = staffs.Email;
                    staffsUptodate.Salary = staffs.Salary;
                    
                    using(ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(staffsUptodate);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                var staff = session.Get<Staffs>(id);
                return View(staff);
            }
        }

        // POST: Staffs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Staffs staffs)
        {
            try
            {
                using(ISession session = OpenNHibernateSession.OpenSession())
                {
                    using(ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(staffs);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
