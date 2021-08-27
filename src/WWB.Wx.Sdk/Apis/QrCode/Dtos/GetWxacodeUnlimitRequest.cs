namespace WWB.Wx.Sdk.Apis.QrCode.Dtos
{
    public class GetWxacodeUnlimitRequest
    {
        public string scene { get; set; }
        public string page { get; set; }
        public int? width { get; set; }
        public bool auto_color { get; set; }
        public object line_color { get; set; }
        public bool is_hyaline { get; set; }
    }
}
