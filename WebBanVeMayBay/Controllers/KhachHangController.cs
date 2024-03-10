using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebBanVeMayBay.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult Index()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("SELECT * FROM KHACHHANG ORDER BY MAKHACHHANG DESC");
            return View();
        }
        [HttpPost]
        public ActionResult ThemKH(string ten, string email, string sdt, string qt, string gt, DateTime ngaysinh)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC THEMKHACH1 N'" + ten + "','" + email + "'," + sdt + ",'" + qt + "',N'" + gt + "','" + ngaysinh.ToString("yyyy-MM-dd") + "';");
            return RedirectToAction("Index","KhachHang");
        }
        public ActionResult XoaKH(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC XOAKH " + id);
            return RedirectToAction("Index", "KhachHang");
        }
    }
}