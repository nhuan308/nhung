using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cau1_lan3.Models;

namespace cau1_lan3.Controllers
{
    public class ThucHanhController : ApiController
    {
        NhanVienEntities db = new NhanVienEntities();
        //all
        [HttpGet]
        public IEnumerable<NV> DanhSach()
        {
            return db.NVs;
        }
        // thêm
        [HttpPost]
        public bool ThemNV(int manv, string tenvn, int hsluong)
        {
            NV nv = db.NVs.FirstOrDefault(x => x.manv == manv);
            if (nv == null)
            {
                NV nv1 = new NV();
                nv1.manv = manv;
                nv1.tenvn = tenvn;
                nv1.hsluong = hsluong;
                db.NVs.Add(nv1);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpPut]
        public bool SuaNV(int manv, string tenvn, int hsluong)
        {
            NV nv = db.NVs.FirstOrDefault(x => x.manv == manv);
            if (nv != null)
            {
                nv.manv = manv;
                nv.tenvn = tenvn;
                nv.hsluong = hsluong;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpDelete]
        public bool XoaNV(int manv)
        {
            NV nv = db.NVs.FirstOrDefault(x => x.manv == manv);
            if (nv != null)
            {
                db.NVs.Remove(nv);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
