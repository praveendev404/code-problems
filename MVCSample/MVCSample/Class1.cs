using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSample
{
//    public class Class1
//    {
//        [AuthorizeRedirect]
//        public JsonResult GetFanReviewsList(string sord, int rows = 10, int page = 1, string sidx = "Name", string name =

//"", string startdate = "", string enddate = "", string rating = "", string IsNotification = "")
//        {
//            var reviewslst = (from rv in QuizviaEntities.BusinessReviews.Where(r => r.BusinessUserId ==

//CurrentUser.UserId)
//                              join up in QuizviaEntities.UserProfiles on rv.UserId equals up.UserID
//                              select new
//                              {
//                                  rv.ReviewId,
//                                  rv.UserId,
//                                  rv.Review,
//                                  rv.Rating,
//                                  rv.CreatedDate,
//                                  rv.StatusTypeId,

//                                  rv.Notification,
//                                  up.FirstName,
//                                  up.LastName
//                              });

//            int pageIndex = Convert.ToInt32(page) - 1;
//            int pageSize = rows;

//            Quizvia.Helpers.PagerHelper.PageSet ps = new Quizvia.Helpers.PagerHelper.PageSet()
//            {
//                PageCount = rows,

//                PageIndex = page - 1
//            };

          
//            ps.TotalRecords = reviewslst.Count();

//            bool ascending = sord == "asc";

//            if (ascending)
//            {
//                reviewslst = reviewslst.OrderBy(o => o.CreatedDate).Skip(pageIndex * rows).Take(rows);

//            }
//            else
//            {
//                reviewslst = reviewslst.OrderByDescending(o => o.CreatedDate).Skip(pageIndex * rows).Take(rows);

//            }

//            var jsonData = new
//            {
//                total = (int)Math.Ceiling((float)ps.TotalRecords / (float)rows),
//                page = page,
//                records = ps.TotalRecords, //page size
//                rows = (
//                   from a in reviewslst.ToList()
//                   select new
//                   {
//                       ReviewId = a.ReviewId,
//                       cell = new string[] {
//                           a.ReviewId.ToString(),
//                           a.UserId.ToString(),
//                           a.LastName +", "+ a.FirstName,
//                           a.Review,
//                           a.Rating,
//                           a.StatusTypeId == 1? "Active" : "Inactive",
//                           FormateDate(a.CreatedDate)                         
//                       }
//                   }).ToArray()
//            };

           

//            return Json(jsonData, JsonRequestBehavior.AllowGet);
//        }
//    }
}