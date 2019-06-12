using RegisterationForminMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterationForminMVC.Controllers
{
    public class UserRegisterationController : Controller
    {


        clsUserReg clsUser = new clsUserReg();

        public ActionResult GetAllUser()
        {
            clsUserReg obj2 = new clsUserReg();
            List<clsUserReg> lst = obj2.GetUsers();


            return View(lst);
        }



        [HttpGet]
        public ActionResult CreateRegForm()
        {
            clsUserReg obj = new clsUserReg();
            obj.Department = GetDepartment();
            return View(obj);
        }

        private List<SelectListItem> GetDepartment()
        {
            //Get all deprment 
            clsDepartment objclsDepartment = new clsDepartment();
            List<clsDepartment> lstDept = objclsDepartment.GetDept();

            List<SelectListItem> itemslst = new List<SelectListItem>();

            foreach (clsDepartment obj in lstDept)
            {
                SelectListItem item = new SelectListItem();
                item.Value = Convert.ToString(obj.DeptID);
                item.Text = obj.DeptName;
                //  adding object to list 
                itemslst.Add(item);
            }

            return itemslst;
        }

        [HttpPost]
        public ActionResult CreateRegForm (string EmpName, string bday, string DeptID, string EmpAdress, string City, string EmpMob)
        {
            clsUserReg obj = new clsUserReg();

            DateTime dtBday = Convert.ToDateTime(bday);
            int intDeptID = Convert.ToInt32(DeptID);
            double dblMob = Convert.ToDouble(EmpMob);

            obj.AddUser(EmpName, dtBday, intDeptID, EmpAdress, City, dblMob);




            obj.Department = GetDepartment();
            ViewBag.message = "Registeration done successfully";
            return View(obj);

          //  return RedirectToActionPermanent("GetAllUser");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {

            clsUserReg objnew = new clsUserReg();

            objnew = objnew.GetEUserData(id);

            return View("EditUser", objnew);
        }

        [HttpPost]


        public ActionResult Edit(int id, clsUserReg objuser)
        {
            clsUserReg objnew = new clsUserReg();
            objnew.UpdateUser(objuser);

            //List<clsUserReg> lst = objnew.GetUsers();

            //return View("GetUsers", lst);

            return RedirectToActionPermanent("GetAllUser");
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {


            clsUserReg clsUser3 = new clsUserReg();
            clsUser3.DeleteUser(id);
            List<clsUserReg> lst = clsUser3.GetUsers();
            return View("GetAllUser", lst);
        }





    }
}