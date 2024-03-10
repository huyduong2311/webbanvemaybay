using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebBanVeMayBay.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult Index()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("SELECT * FROM TAIKHOAN ORDER BY IDTaikhoan DESC");
            return View();
        }
        [HttpPost]
        public ActionResult ThemTK(string Username, string Password)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC DANGKI '" + Username + "', '" + Password + "'");
            return RedirectToAction("Index","TaiKhoan");
        }
        public ActionResult XoaTK(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC XOATK " + id);
            return RedirectToAction("Index", "TaiKhoan");
        }
    }
}