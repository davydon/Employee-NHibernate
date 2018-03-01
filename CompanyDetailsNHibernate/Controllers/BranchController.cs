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
    public class BranchController : Controller
    {
        // GET: Branch
        public ActionResult Index()
        {
            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                var branchs = session.Query<Branch>().ToList();
                return View(branchs);
            }
        }

        // GET: Branch/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                var branch = session.Get<Branch>(id);
                return View(branch);
            }
        }

        // GET: Branch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Branch/Create
        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            try
            {
                using (ISession session = OpenNHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(branch);
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

        // GET: Branch/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                var branch = session.Get<Branch>(id);
                return View(branch);
            }
        }

        // POST: Branch/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Branch branch)
        {
            try
            {
                using (ISession session = OpenNHibernateSession.OpenSession())
                {
                    var branchsUptodate = session.Get<Branch>(id);

                    branchsUptodate.BranchId = branch.BranchId;
                    branchsUptodate.Address = branch.Address;
                    branchsUptodate.Manager = branch.Manager;
                    branchsUptodate.Phone = branch.Phone;
                    branchsUptodate.Email = branch.Email;
                    

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(branchsUptodate);
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

        // GET: Branch/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                var branch = session.Get<Branch>(id);
                return View(branch);
            }
        }

        // POST: Branch/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Branch branch)
        {
            try
            {
                using (ISession session = OpenNHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(branch);
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
