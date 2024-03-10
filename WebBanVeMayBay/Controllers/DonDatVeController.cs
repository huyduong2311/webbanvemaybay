using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebBanVeMayBay.Controllers
{
    public class DonDatVeController : Controller
    {
        // GET: DonDatVe
        public ActionResult Index()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("SELECT * FROM VEMAYBAY ORDER BY MAVE DESC");
            ViewBag.listKH = db.get("SELECT * FROM KHACHHANG");
            ViewBag.listCB = db.get("SELECT * FROM CHUYENBAY");
            return View();
        }
        [HttpPost]
        public ActionResult ThemVMB(string MaKH, string MaCB, string HTTT)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC THEMVMB1 " + MaKH + ", " + MaCB + ",N'" + HTTT + "';");
            return RedirectToAction("Index", "DonDatVe");
        }
        public ActionResult XoaVe(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC XOAVE " + id);
            return RedirectToAction("Index", "DonDatVe");
        }
        public ActionResult TimVeUpdate(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC TIMKIEMVETHEOID " + id + ";");
            ViewBag.listKH = db.get("SELECT * FROM KHACHHANG");
            ViewBag.listCB = db.get("SELECT * FROM CHUYENBAY");
            return View();
        }
        [HttpPost]
        public ActionResult SUAVE(string MAKH, string MACB, string HTTT, string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC SUAVE " + MAKH + "," + MACB + ", N'"+ HTTT +"', "+id+";");
            ViewBag.listKH = db.get("SELECT * FROM KHACHHANG");
            ViewBag.listCB = db.get("SELECT * FROM CHUYENBAY");
            return RedirectToAction("Index", "DonDatVe");
        }
    }
}