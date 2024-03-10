using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebBanVeMayBay.Controllers
{
    public class ChuyenBayController : Controller
    {
        // GET: ChuyenBay
        public ActionResult Index()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("SELECT * FROM CHUYENBAY ORDER BY MaChuyenBay DESC");
            return View();
        }
        [HttpPost]
        public ActionResult ThemCB(string sh,
                                        string hmb,
                                        string tpdi,
                                        string tpden,
                                        DateTime tgdi,
                                        DateTime tgden,
                                        int sl,
                                        int gia,
                                        HttpPostedFileBase hinh)
        {
            try
            {
                if (hinh != null && hinh.ContentLength > 0)
                {
                    string filename = Path.GetFileName(hinh.FileName);
                    string path = Path.Combine(Server.MapPath("~/img"), filename);
                    hinh.SaveAs(path);
                    DataModel db = new DataModel();
                    db.get("EXEC THEMCB01 '" + sh + "','" + tgdi.ToString("yyyy-MM-ddTHH:mm:ss") + "', '" + tgden.ToString("yyyy-MM-ddTHH:mm:ss") + "'," + sl + "," + gia + ",'" + hinh.FileName + "',N'" + tpdi + "',N'" + tpden + "','" + hmb + "';");
                }
            }
            catch (Exception) { }
            return RedirectToAction("Index", "ChuyenBay");
        }
        public ActionResult XoaCB(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC XOACB " + id);
            return RedirectToAction("Index", "ChuyenBay");
        }
    }
}