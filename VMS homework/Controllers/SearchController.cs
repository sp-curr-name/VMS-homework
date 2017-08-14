﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMS_homework.Models;

namespace VMS_homework.Controllers
{
    public class SearchController : Controller
    {
        VMSEntities db = new VMSEntities();
        // GET: Search

        //for future use to search any other addition status that would be used under approval status
        public ActionResult Index(String searching)
        {
            var status = from s in db.volunteers
                         select s;
            if (!String.IsNullOrEmpty(searching))
            {
                status = status.Where(s => s.ApprovalStatus.Contains(searching));
            }
            return View(status.ToList());

        }
        //returns all users that have an Approved or pending status
        public ActionResult FilterA()
        {
            var status = from s in db.volunteers
                         select s;
           
                status = status.Where(s => s.ApprovalStatus.Equals("Approved") || s.ApprovalStatus.Equals("Pending"));
            
            return View(status.ToList());
        }

        //returns all users that have an Approved status
        public ActionResult FilterB()
        {
            var status = from s in db.volunteers
                         select s;

            status = status.Where(s => s.ApprovalStatus.Equals("Approved"));

            return View(status.ToList());
        }

        //returns all users that have a Pending Status
        public ActionResult FilterC()
        {
            var status = from s in db.volunteers
                         select s;

            status = status.Where(s => s.ApprovalStatus.Contains("Pending"));

            return View(status.ToList());
        }

        //returns all users that have a Disaprroved Status
        public ActionResult FilterD()
        {
            var status = from s in db.volunteers
                         select s;

            status = status.Where(s => s.ApprovalStatus.Contains("Disapproved"));

            return View(status.ToList());
        }

        //returns all users that have an inactive status
        public ActionResult FilterE()
        {
            var status = from s in db.volunteers
                         select s;

            status = status.Where(s => s.ApprovalStatus.Contains("Inactive"));

            return View(status.ToList());
        }

        //returns all users in the system
        public ActionResult FilterF()
        {
            var status = from s in db.volunteers
                         select s;

            status = status.Where(s => s.ApprovalStatus.Contains(""));

            return View(status.ToList());
        }
    }
}