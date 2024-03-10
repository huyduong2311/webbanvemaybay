using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebBanVeMayBay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DataModel db = new DataModel();
            ViewBag.list4 = db.get("SELECT * FROM ChuyenBay");
            if (Session["Username"] != null)
            {
                string username = Session["Username"].ToString();
                // Trả về trang chủ và hiển thị thông tin tài khoản
                ViewBag.Username = username;
                return View();
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            DataModel dataModel = new DataModel();

            string sql = $"SELECT * FROM Taikhoan WHERE Username = '{username}' AND Password = '{password}'";
            ArrayList result = dataModel.get(sql);
            if (username == "admin" && password == "123")
            {
                // If credentials are valid, redirect to the management page
                return RedirectToAction("Index","TaiKHoan");
            }
            if (result.Count > 0)
            {
                Session["Username"] = username;

                return RedirectToAction("Index");
            }
            else
            {
                // Đăng nhập không thành công, hiển thị thông báo lỗi hoặc thực hiện các hành động khác
                ViewBag.ErrorMessage = "Tài khoản hoặc mật khẩu không đúng. Vui lòng thử lại.";
                return View();
            }
        }
        public ActionResult Management()
        {
            // Logic for the management page
            return View();
        }
        public ActionResult Dangki()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangki(string Username, string Password)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC DANGKI '" + Username + "', '" + Password + "'");
            return RedirectToAction("Login");
        }

        public ActionResult TimKiemChuyenBayTheoTPDEN(string tpden)
        {
            DataModel db = new DataModel();
            ViewBag.list4 = db.get("SELECT * FROM ChuyenBay");
            ViewBag.list5 = db.get("EXEC TIMKIEMCHUYENBAYTHEOTENTP N'"+ tpden + "';");
            if (Session["Username"] != null)
            {
                string username = Session["Username"].ToString();
                // Trả về trang chủ và hiển thị thông tin tài khoản
                ViewBag.Username = username;
                return View();
            }
            return View();
        }

        public ActionResult ChiTietChuyenBay(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list4 = db.get("SELECT * FROM ChuyenBay");
            ViewBag.list6 = db.get("EXEC TIMKIEMCHUYENBAYTHEOID " + id + ";");
            if (Session["Username"] != null)
            {
                string username = Session["Username"].ToString();
                // Trả về trang chủ và hiển thị thông tin tài khoản
                ViewBag.Username = username;
                return View();
            }
            return View();
        }
        public ActionResult ThanhToan(string id)
        {
            // Lưu idChuyenBay vào Session để sử dụng ở bước tiếp theo
            Session["IdChuyenBay"] = id;
            // Hiển thị trang điền thông tin khách hàng
            return View();
        }
        [HttpPost]
        public ActionResult ThemKH(string ten, string email,string sdt, string qt, string gt, DateTime ngaysinh)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC THEMKHACH1 N'" + ten + "','" + email + "'," + sdt + ",'" + qt + "',N'" + gt + "','" + ngaysinh.ToString("yyyy-MM-dd") + "';");
            return RedirectToAction("ThanhToan2");
        }
        [HttpPost]
        public ActionResult ThemVMB(string MaKH, string MaCB, string HTTT,string h2)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC THEMVMB1 " + MaKH + ", " + MaCB + ",N'" + HTTT + "';");
            if (h2 == "1") 
            {
                return RedirectToAction("ThanhToan3", "Home");
            }
            else if (h2 == "2")
            {
                return RedirectToAction("ThanhToan3_2", "Home");
            }
            else
            {
                // Trả về một ActionResult nếu không có điều kiện nào thỏa mãn
                return RedirectToAction("ThanhToan2");
            }
        }
        public ActionResult ThanhToan2()
        {
            // Kiểm tra xem Session["IdChuyenBay"] có tồn tại hay không
            if (Session["IdChuyenBay"] != null)
            {
                // Kiểm tra xem giá trị trong Session có phải là một số nguyên hay không
                if (int.TryParse(Session["IdChuyenBay"].ToString(), out int id))
                {
                    // Đoạn mã ở đây sử dụng id
                    DataModel db = new DataModel();
                    ViewBag.list = db.get("EXEC LayKHMoiNhat");
                    ViewBag.list2 = db.get("SELECT * FROM ChuyenBay");
                    ViewBag.list3 = db.get("EXEC TIMKIEMCHUYENBAYTHEOID " + id + ";");

                    return View();
                }
                else
                {
                    // Xử lý khi giá trị không phải là số nguyên
                    return RedirectToAction("Index"); // Chẳng hạn chuyển hướng về trang chính
                }
            }
            else
            {
                // Xử lý khi Session không tồn tại
                return RedirectToAction("Index"); // Chẳng hạn chuyển hướng về trang chính
            }
        }
        public ActionResult ThanhToan3() 
        {
            return View();
        }
        public ActionResult ThanhToan3_2()
        {
            // Kiểm tra xem Session["IdChuyenBay"] có tồn tại hay không
            if (Session["IdChuyenBay"] != null)
            {
                // Kiểm tra xem giá trị trong Session có phải là một số nguyên hay không
                if (int.TryParse(Session["IdChuyenBay"].ToString(), out int id))
                {
                    // Đoạn mã ở đây sử dụng id
                    DataModel db = new DataModel();
                    ViewBag.list = db.get("EXEC LayKHMoiNhat");
                    ViewBag.list2 = db.get("SELECT * FROM ChuyenBay");
                    ViewBag.list3 = db.get("EXEC TIMKIEMCHUYENBAYTHEOID " + id + ";");

                    return View();
                }
                else
                {
                    // Xử lý khi giá trị không phải là số nguyên
                    return RedirectToAction("Index"); // Chẳng hạn chuyển hướng về trang chính
                }
            }
            else
            {
                // Xử lý khi Session không tồn tại
                return RedirectToAction("Index"); // Chẳng hạn chuyển hướng về trang chính
            }
        }
        public ActionResult XemlaiVeBay()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("SELECT * FROM VEMAYBAY");
            return View();
        }
        public ActionResult ChiTietKhachHang(string idkh)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC TIMKIEMKHACHHANGTHEOID " + idkh + ";");
            return View();
        }
    }
}