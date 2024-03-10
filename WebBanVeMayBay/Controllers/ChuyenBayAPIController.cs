using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebBanVeMayBay.Controllers
{
    public class ChuyenBayAPIController : Controller
    {
        // GET: ChuyenBayAPI
        public JsonResult Index(string maxacnhan)
        {
            if(maxacnhan != null && maxacnhan=="123")
            {
                DataModel db = new DataModel();
                ArrayList a = db.get("SELECT * FROM CHUYENBAY");
                return Json(a,JsonRequestBehavior.AllowGet);
            }
            return Json(new ArrayList(), JsonRequestBehavior.AllowGet);
        }
    }
}