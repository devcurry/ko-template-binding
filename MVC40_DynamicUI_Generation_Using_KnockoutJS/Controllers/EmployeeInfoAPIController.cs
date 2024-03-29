﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MVC40_DynamicUI_Generation_Using_KnockoutJS.Models;

namespace MVC40_DynamicUI_Generation_Using_KnockoutJS.Controllers
{
    public class EmployeeInfoAPIController : ApiController
    {
        private CompanyEntities db = new CompanyEntities();

        // GET api/EmployeeInfoAP
        public IEnumerable<EmployeeInfo> GetEmployeeInfoes()
        {
            return db.EmployeeInfoes.AsEnumerable();
        }

        // GET api/EmployeeInfoAP/5
        public EmployeeInfo GetEmployeeInfo(int id)
        {
            EmployeeInfo employeeinfo = db.EmployeeInfoes.Find(id);
            if (employeeinfo == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return employeeinfo;
        }

        // PUT api/EmployeeInfoAP/5
        public HttpResponseMessage PutEmployeeInfo(int id, EmployeeInfo employeeinfo)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != employeeinfo.EmpNo)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(employeeinfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/EmployeeInfoAP
        public HttpResponseMessage PostEmployeeInfo(EmployeeInfo employeeinfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeInfoes.Add(employeeinfo);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, employeeinfo);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = employeeinfo.EmpNo }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/EmployeeInfoAP/5
        public HttpResponseMessage DeleteEmployeeInfo(int id)
        {
            EmployeeInfo employeeinfo = db.EmployeeInfoes.Find(id);
            if (employeeinfo == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.EmployeeInfoes.Remove(employeeinfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, employeeinfo);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}