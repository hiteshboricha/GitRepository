using AutoMapper;
using SEG.Azure.Business;
using SEG.Azure.Entities;
using SEG.Azure.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEG.Azure.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<EmployeeViewModel> employeelist = new List<EmployeeViewModel>();

            try
            {
                EmployeeBAL employeebal = new EmployeeBAL();

                List<Employee> employeegenericlist = employeebal.GetEmployees();
                var employeeDto = Mapper.Map<List<EmployeeViewModel>>(employeegenericlist);

                return View(employeeDto);
            }
            catch (Exception ex)
            {
                
            }

            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel employeemodel)
        {
            try
            {
                EmployeeBAL employeebal = new EmployeeBAL();
                var employeeDto = Mapper.Map<Employee>(employeemodel);

                employeebal.InsertEmployee(employeeDto);

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}