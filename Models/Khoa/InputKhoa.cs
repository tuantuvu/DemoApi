namespace DemoApi.Models.Khoa
{
    public class InputKhoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string SDT { get; set; }
        //public IFormFile hinhanh { get; set; }
        public IFormFileCollection Images { get; set; }
    }
}
