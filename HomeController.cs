using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using WebApplicationRevisionCRUD.DBConnection;
using WebApplicationRevisionCRUD.Models;

namespace WebApplicationRevisionCRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            employeesEntities obj = new employeesEntities();
           var res = obj.emp_details.ToList();

            List<Class1Model> list = new List<Class1Model>();
            foreach (var item in res)
            {
                list.Add(new Class1Model { 
                    id = item.id , 
                    name = item.name ,
                    email_id = item.email_id ,
                    contact_No = item.contact_No,
                    address = item.address,
                    Gender = item.Gender,
                    salary = item.salary
                });
            }
            return View(list);
        }

        public ActionResult Delete(int id)
        {
            employeesEntities obj = new employeesEntities();
            var res = obj.emp_details.Where(a => a.id == id).FirstOrDefault();
            obj.emp_details.Remove(res);
            obj.SaveChanges();

            return RedirectToAction("Index");   
        }

        [HttpGet]
       
       public ActionResult EmpView(int id)
        {
            employeesEntities obj1 = new employeesEntities();
            var data = obj1.emp_details.Find(id);

             if(data != null)
            {
                return View(data);  
            }



            return View();
        }


        [HttpGet]
        public ActionResult Createdata()
        { 
           return View();
        }

        [HttpPost]
        public ActionResult Createdata(emp_details emp)
        { 


            employeesEntities obj = new employeesEntities();

            emp_details obj1 = new emp_details()
            { 
             name = emp.name,   
             email_id = emp.email_id,   
             address = emp.address,   
             salary = emp.salary,   
             contact_No = emp.contact_No,   
              Gender= emp.Gender,   
            };

            obj.emp_details.Add(obj1);
            obj.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult getCategoryByID(int id)
        {
            List<emp_details> emp1 = new List<emp_details>();    
            emp1.Add(new emp_details { id = 1,name="Visu", });
            emp1.Add(new emp_details { id = 2,name="Visu", });
            var res = emp1.Where(x=>x.id==id).First();

            return View(res);



        }





        [HttpPost]  
        
        public ActionResult EmpView(Class1Model obj)
        {
            employeesEntities obj1 = new employeesEntities();
            emp_details  ab = new emp_details();


            ab.id = obj.id;
            ab.name = obj.name;
            ab.email_id = obj.email_id;
            ab.contact_No = obj.contact_No;
            ab.address = obj.address;
            ab.Gender = obj.Gender;
            ab.salary = obj.salary;

            if(obj.id==0)
            {
                obj1.emp_details.Add(ab);
                obj1.SaveChanges();
            }
            else
            {
                obj1.Entry(ab).State = System.Data.Entity.EntityState.Modified;
                obj1.SaveChanges();

            }
            return RedirectToAction("Index");


        }


       
   
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}