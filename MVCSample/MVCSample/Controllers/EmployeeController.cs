using MVCSample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Datatables;

namespace MVCSample.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        public ActionResult Validate(FormCollection f)
        {

            string userName = f["txtUserName"];
            string password = f["txtPassword"];
            if (userName == "praveen" && password == "praveen")
            {
                TempData["Status"] = "You have logged in successfully";
                return RedirectToAction("Welcome");
            }
            else
            {
                ViewBag.Status = "Invalid credentials";
                return View("Login");
            }
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult AddEmployee()
        {

            return View();
        }

        MvcDemoEntities3 mvcDemoEntities = new MvcDemoEntities3();

        EmployeeContext employeeContext = new EmployeeContext();
        [HttpPost]
        public ActionResult AddEmployee(EmpDetails empDetails)
        {
            employeeContext.EmpDetailss.Add(empDetails);
            employeeContext.SaveChanges();
            return RedirectToAction("EmpDetailsList");
        }

        public ActionResult EmpDetailsList()
        {

            return View(employeeContext.EmpDetailss.ToList());
        }

        public ActionResult Edit(string id)
        {
            var empDetails = employeeContext.EmpDetailss.Find(Convert.ToInt32(id));
            return View(empDetails);
        }
        [HttpPost]
        public ActionResult Edit(EmpDetails empDetail)
        {
            var empDetails = employeeContext.EmpDetailss.Find(empDetail.EmployeeId);
            empDetails.Name = empDetail.Name;
            empDetails.MobileNo = empDetail.MobileNo;
            empDetails.Email = empDetail.Email;
            empDetails.Address = empDetail.Address;
            employeeContext.SaveChanges();

            return RedirectToAction("EmpDetailsList");
        }

        public ActionResult DeleteEmployee(string id)
        {
            employeeContext.EmpDetailss.Remove(employeeContext.EmpDetailss.Find(Convert.ToInt32(id)));
            employeeContext.SaveChanges();
            return RedirectToAction("EmpDetailsList");
        }

        public ActionResult EmpDetails(string id)
        {
            return View(employeeContext.EmpDetailss.Find(Convert.ToInt32(id)));
        }

        public ActionResult jqEmpList()
        {
            return View();
        }

        public JsonResult jqEmpList1()
        {
            employeeContext = new EmployeeContext();

            int count = mvcDemoEntities.EmpDetails.Count();
            int records = employeeContext.EmpDetailss.ToList().Count;
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = mvcDemoEntities.EmpDetails.ToList().Count,
                //records = employeeContext.EmpDetailss.ToList().Count,
                rows = (from emp in mvcDemoEntities.EmpDetails.ToList()
                        select new
                        {
                            cell = new string[]{
                                  emp.EmployeeId.ToString(),emp.Name,emp.MobileNo,emp.Email,emp.Address
                              }
                        }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
            //return View();
        }

        [HttpPost]
        public String Create([Bind(Exclude = "EmployeeId")] EmpDetail empDetail)
        {
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    mvcDemoEntities.EmpDetails.Add(empDetail);
                    mvcDemoEntities.SaveChanges();
                    msg = "Record added successfully";
                }
                else
                {
                    msg = "Enter valid data";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        [HttpPost]
        public string EditEmp(EmpDetail empDetail)
        {
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    mvcDemoEntities.Entry(empDetail).State = EntityState.Modified;
                    mvcDemoEntities.SaveChanges();
                    msg = "Record updated successfully";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        [HttpPost]
        public string DeleteEmp(int id)
        {
            string msg = string.Empty;
            try
            {
                EmpDetail empDetails = mvcDemoEntities.EmpDetails.Find(id);
                mvcDemoEntities.EmpDetails.Remove(empDetails);
                mvcDemoEntities.SaveChanges();
                msg = "Record deleted successfully";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public ActionResult JqPageList()
        {
            return View();
        }

        public JsonResult JqPageList1(string sort = "desc", int page = 1, int rows = 10)
        {

            int totRecords = mvcDemoEntities.EmpDetails.ToList().Count;
            int pageIndex = page - 1;
            var lstEmpDetails = mvcDemoEntities.EmpDetails.OrderBy(o => o.EmployeeId).Skip(pageIndex * rows).Take(rows);
            // int total = (int)Math.Ceiling((float)totRecords / (float)rows);
            int total = (int)Math.Ceiling((float)totRecords / (float)rows);
            var jsonData = new
            {
                total = (int)Math.Ceiling((float)totRecords / (float)rows),
                totalpages = (int)Math.Ceiling((float)totRecords / (float)rows),
                page = page,
                records = mvcDemoEntities.EmpDetails.ToList().Count,
                rows = (from emp in lstEmpDetails.ToList()
                        select new
                        {
                            cell = new string[]{
                                  emp.EmployeeId.ToString(),
                                  emp.Name,
                                  emp.MobileNo,
                                  emp.Email,
                                  emp.Address
                            }
                        }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        public ActionResult AddEmployees()
        {
            UIEmployee uiEmployee = new UIEmployee();
            uiEmployee.lstCountry = mvcDemoEntities.Countries.ToList();
            uiEmployee.lstGender = mvcDemoEntities.Genders.ToList();
            uiEmployee.lstState = mvcDemoEntities.States.ToList();
            return View(uiEmployee);
        }

        public JsonResult GetState(string id)
        {
            int countryId = Convert.ToInt32(id);
            var lstStates = (from item in mvcDemoEntities.States where (item.CountryId == countryId) select new { item.StateId, item.Name }).ToList();
            return Json(lstStates.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddEmployees(UIEmployee uiEmployee)
        {
            mvcDemoEntities.Employees.Add(uiEmployee.Employee);
            mvcDemoEntities.SaveChanges();
            return RedirectToAction("AddEmployees");
        }

        public ActionResult AddEmp()
        {
            UIEmp uiEmp = new UIEmp();
            // List<UICountry> lstc = new List<UICountry>();
            // mvcDemoEntities.Countries.ToList().ForEach(o => lstc.Add(new UICountry { Name = o.Name, CountryId = o.CountryId }));
            uiEmp.lstCountry = (from c in mvcDemoEntities.Countries select new UICountry { Name = c.Name, CountryId = c.CountryId }).ToList();
            uiEmp.lstGender = (from g in mvcDemoEntities.Genders select new UIGender { Name = g.Name, GenderId = g.GenderId }).ToList();
            uiEmp.lstState = new List<UIState>();

            uiEmp.lstState.Add(new UIState()
            {
                StateId = 0,
                Name = ""
            });
            return View(uiEmp);
        }

        public ActionResult LoadImage()
        {
            return View();
        }

        public ActionResult AddEmp1(UIEmp uiEmp)
        {
            string statusMsg = string.Empty;
            try
            {
                int empId = uiEmp.EmployeeId;
                int status = 0;
                HttpPostedFileBase imgFile = Request.Files["ProfilePic"];
                BinaryReader br = new BinaryReader(imgFile.InputStream);
                byte[] bytes = br.ReadBytes(Convert.ToInt32(imgFile.ContentLength));
                uiEmp.ProfilePic = new UIProfilePic();
                uiEmp.ProfilePic.ProfileImage = bytes;

                if (empId == 0)
                {
                    Employee employee = new Employee();
                    employee.FirstName = uiEmp.FirstName;
                    employee.LastName = uiEmp.LastName; 
                    employee.MobileNo = uiEmp.MobileNo;
                    employee.EmailId = uiEmp.EmailId;
                    employee.Address = uiEmp.Address;
                    employee.ZipCode = uiEmp.ZipCode;
                    employee.GenderId = uiEmp.Gender.GenderId;
                    employee.CountryId = uiEmp.Country.CountryId;
                    employee.StateId = uiEmp.State.StateId;
                    employee.StatusTypeId = 1;
                    mvcDemoEntities.Employees.Add(employee);
                    status = mvcDemoEntities.SaveChanges();
                    int id = employee.EmployeeId;
                    if (status > 0)
                    {
                        if (imgFile.ContentLength != 0)
                        {
                            ProfilePic profilePic = new ProfilePic();
                            profilePic.ProfileImage = uiEmp.ProfilePic.ProfileImage;
                            profilePic.EmployeeId = id;
                            mvcDemoEntities.ProfilePics.Add(profilePic);
                            int res = mvcDemoEntities.SaveChanges();
                        }
                        statusMsg = "Add";
                    }
                }
                else
                {
                    var lstEmp = mvcDemoEntities.Employees.Find(empId);
                    lstEmp.FirstName = uiEmp.FirstName;
                    lstEmp.LastName = uiEmp.LastName;
                    lstEmp.MobileNo = uiEmp.MobileNo;
                    lstEmp.EmailId = uiEmp.EmailId;
                    lstEmp.Address = uiEmp.Address;
                    lstEmp.ZipCode = uiEmp.ZipCode;
                    lstEmp.GenderId = uiEmp.Gender.GenderId;
                    lstEmp.CountryId = uiEmp.Country.CountryId;
                    lstEmp.StateId = uiEmp.State.StateId;
                    mvcDemoEntities.Entry(lstEmp).State = EntityState.Modified;
                    status = mvcDemoEntities.SaveChanges();
                    if (status > 0)
                    {
                        if (mvcDemoEntities.ProfilePics.Any(o => o.EmployeeId == empId))
                        {
                            if (imgFile.ContentLength != 0)
                            {
                                var obj = mvcDemoEntities.ProfilePics.FirstOrDefault(o => o.EmployeeId == empId);
                                mvcDemoEntities.ProfilePics.Remove(obj);
                                mvcDemoEntities.Entry(obj).State = EntityState.Deleted;
                                int i = mvcDemoEntities.SaveChanges();

                                ProfilePic profilePic = new ProfilePic();
                                profilePic.ProfileImage = uiEmp.ProfilePic.ProfileImage;
                                profilePic.EmployeeId = empId;
                                mvcDemoEntities.ProfilePics.Add(profilePic);
                                int res = mvcDemoEntities.SaveChanges();
                                obj.ProfileImage = uiEmp.ProfilePic.ProfileImage;
                                status = mvcDemoEntities.SaveChanges();
                            }
                        }
                        else
                        {
                            ProfilePic profilePic = new ProfilePic();
                            profilePic.ProfileImage = uiEmp.ProfilePic.ProfileImage;
                            profilePic.EmployeeId = empId;
                            mvcDemoEntities.ProfilePics.Add(profilePic);
                            int res = mvcDemoEntities.SaveChanges();
                        }
                        statusMsg = "Update";
                    }
                }
            }
            catch (Exception ex)
            {
                statusMsg = "Error";
            }

            //return RedirectToAction("jqEmpsList");
            return Redirect("jqEmpsList?status=" + statusMsg);
        }

        public ActionResult jqEmpsList()
        {
            return View();
        }

        public JsonResult jqEmpsList1(string sort = "desc", int page = 1, int rows = 15)
        {
            List<UIEmp> lstUiEmp = new List<UIEmp>();
            int pageIndex = page - 1;
            int totalRecords = mvcDemoEntities.Employees.ToList().Count;
            lstUiEmp = (from e in mvcDemoEntities.Employees.Where(o => o.StatusTypeId == 1).OrderByDescending(o => o.EmployeeId).Skip(pageIndex * rows).Take(rows)
                        select new UIEmp
                        {
                            EmployeeId = e.EmployeeId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Gender = new UIGender { GenderId = e.GenderId, Name = e.Gender.Name },
                            Country = new UICountry { CountryId = e.CountryId, Name = e.Country.Name },
                            State = new UIState { StateId = e.StateId, Name = e.State.Name },
                            MobileNo = e.MobileNo,
                            EmailId = e.EmailId,
                            ZipCode = e.ZipCode,
                            Address = e.Address
                        }).ToList();
            var lstEmp = lstUiEmp;
            //var lstEmp = mvcDemoEntities.Employees.OrderBy(o => o.EmployeeId).Skip(pageIndex * rows).Take(rows);
            int total = (int)Math.Ceiling((float)totalRecords / (float)rows);
            var jsonData = new
            {
                total = total,
                page = page,
                records = totalRecords,
                rows = (from employee in lstEmp
                        select new
                        {
                            cell = new string[]{
                                employee.EmployeeId.ToString(),
                                employee.FirstName,
                                employee.LastName,
                                employee.Gender.Name,
                                employee.Country.Name,
                                employee.State.Name,
                                employee.MobileNo,
                                employee.EmailId,
                                employee.ZipCode,
                                employee.Address                                
                              }
                        }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        
        public string DeleEmp(int empId)
        {
            string msg = string.Empty;

            try
            {
                //mvcDemoEntities.Employees.Remove(mvcDemoEntities.Employees.Find(empId));
                var lstEmp = mvcDemoEntities.Employees.Find(empId);
                lstEmp.StatusTypeId = 2;
                mvcDemoEntities.SaveChanges();
                msg = "Record deleted success fully";
            }
            catch (Exception ex)
            {
                msg = ex.Message;

            }
            return msg;
        }

        public ActionResult EditEmps(string empId)
        {
            UIEmp uiEmp = new UIEmp();

            int id = Convert.ToInt32(empId);
            uiEmp = (from e in mvcDemoEntities.Employees.Where(o => o.EmployeeId == id)
                     select new UIEmp
                       {
                           EmployeeId = e.EmployeeId,
                           FirstName = e.FirstName,
                           LastName = e.LastName,
                           Gender = new UIGender { GenderId = e.GenderId },
                           Country = new UICountry { CountryId = e.CountryId },
                           State = new UIState { StateId = e.StateId },
                           MobileNo = e.MobileNo,
                           EmailId = e.EmailId,
                           Address = e.Address,
                           ZipCode = e.ZipCode,
                       }).FirstOrDefault();
            uiEmp.lstCountry = (from c in mvcDemoEntities.Countries select new UICountry { Name = c.Name, CountryId = c.CountryId }).ToList();
            uiEmp.lstGender = (from g in mvcDemoEntities.Genders select new UIGender { Name = g.Name, GenderId = g.GenderId }).ToList();
            uiEmp.lstState = (from s in mvcDemoEntities.States
                              join e in mvcDemoEntities.Employees.Where(o => o.EmployeeId == id) on s.CountryId equals e.CountryId
                              select new UIState { Name = s.Name, StateId = s.StateId }).ToList();
            return View("AddEmp", uiEmp);
        }

        public ActionResult GetImage(int id)
        {
            if (id != 0)
            {
                if (mvcDemoEntities.ProfilePics.Any(o => o.EmployeeId == id))
                {
                    var image = from img in mvcDemoEntities.ProfilePics where img.EmployeeId == id select img.ProfileImage;
                    byte[] profilePic = image.First();
                    return File(profilePic, "image/jpg");
                    
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
        public ActionResult _BindMenu()
        {
            List<UIMenu> lstMenu = new List<UIMenu>();
            UiMenuModel menuModel = new UiMenuModel();
            menuModel.lstUiMenu = (from m in mvcDemoEntities.Menus select new UIMenu { ID = m.ID, Name = m.Name, ControllerName = m.ControllerName, ActionName = m.ActionName, ParentId = m.ParentId }).ToList();
            return PartialView("~/Views/Shared/_MenuView.cshtml", menuModel);
        }

        public ActionResult DatatableDemo()
        {
            return View();
        }

        public JsonResult DatatableDemo1(ControllerContext cContext)
        {
            string sort = "desc";
            int pageIndex = 0;
            int rows = 12;
            int totalRecords = mvcDemoEntities.Employees.ToList().Count;
            List<UIEmp> lstUiEmp = new List<UIEmp>();
            lstUiEmp = (from e in mvcDemoEntities.Employees.Where(o => o.StatusTypeId == 1).OrderByDescending(o => o.EmployeeId).Skip(pageIndex * rows).Take(rows)
                        select new UIEmp
                        {
                            EmployeeId = e.EmployeeId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Gender = new UIGender { GenderId = e.GenderId, Name = e.Gender.Name },
                            Country = new UICountry { CountryId = e.CountryId, Name = e.Country.Name },
                            State = new UIState { StateId = e.StateId, Name = e.State.Name },
                            MobileNo = e.MobileNo,
                            EmailId = e.EmailId,
                            ZipCode = e.ZipCode,
                            Address = e.Address
                        }
                      ).ToList();

            var lst = from emp in lstUiEmp
                      select new[] {
                emp.EmployeeId.ToString(),
                emp.FirstName,
                emp.LastName,
                emp.Gender.Name, 
                emp.Country.Name, 
                emp.State.Name,
                emp.MobileNo,
                emp.EmailId,
                emp.ZipCode,
                emp.Address
            };
            return Json(new
            {
                sEcho = "1",
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = rows,
                aaData = lst,
            }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult Test()
        {
            return View();
        }

        public ActionResult AjaxHandler()
        {
            return Json(new
            {
                // sEcho = param.sEcho, 
                iTotalRecords = 97,
                iTotalDisplayRecords = 3,
                aaData = new List<string[]>() {
                    new string[] {"1", "Microsoft", "Redmond", "USA"},
                    new string[] {"2", "Google", "Mountain View", "USA"},
                    new string[] {"3", "Gowi", "Pancevo", "Serbia"}
                    }
            },
            JsonRequestBehavior.AllowGet);
        }

    }


}