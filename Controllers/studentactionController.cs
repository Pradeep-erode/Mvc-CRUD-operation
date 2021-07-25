using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sample_mvc3.Models;
using System.Data.Entity;


namespace sample_mvc3.Controllers
{
    public class studentactionController : Controller
    {

        private student_sampleEntities2 data = new student_sampleEntities2();
        public ActionResult Index()
        {
            ViewBag.alert = "DATA successfully created";
            return View();

        }
        public ActionResult Details()
        {
            return View(data.studentinfoes.Where(model => model.Is_deleted == 0).ToList());
        }
        [HttpPost]
        public ActionResult Creating(studentinformatiom obj)
        {
            if (obj != null)
            {
                using (var entity = new student_sampleEntities2())
                {
                    studentinfo entityclass = new studentinfo();

                    entityclass.First_name = obj.First_name;
                    entityclass.Second_name = obj.Second_name;
                    entityclass.Gender = obj.Gender;
                    entityclass.Department = obj.Department;
                    entityclass.Joining_date = DateTime.Now;
                    entityclass.Is_deleted = 0;
                    entity.studentinfoes.Add(entityclass);
                    entity.SaveChanges();
                }
            }

            return RedirectToAction("Details");
        }
        public ActionResult Edit(int id)
        {
            using (var entity = new student_sampleEntities2())
            {
                return View(entity.studentinfoes.Where(x => x.Student_ID == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Edit(int id, studentinfo objj)
        {

            using (var entity = new student_sampleEntities2())
            {

                entity.Entry(objj).State = EntityState.Modified;
                entity.SaveChanges();
            }
            var studentdelete = data.studentinfoes.Where(model => model.Student_ID == id).FirstOrDefault();
            studentdelete.Is_deleted = 0;
            data.SaveChanges();

            return RedirectToAction("Index");
        }
        #region delete
        public ActionResult Delete(int id)
        {
            using (var dat = new student_sampleEntities2())
            {
                return View(dat.studentinfoes.Where(model => model.Student_ID == id).FirstOrDefault());
            }

        }
        #endregion


        [HttpPost]
        public ActionResult Delete(studentinfo obj)
        {

            var studentdelete = data.studentinfoes.Where(model => model.Student_ID == obj.Student_ID).FirstOrDefault();
            studentdelete.Is_deleted = 1;
            //var studentdelete = data.studentinfoes.Find(id);
            //  data.studentinfoes.Remove(studentdelete);
            data.SaveChanges();
            return RedirectToAction("Details");

        }
        
    }
}