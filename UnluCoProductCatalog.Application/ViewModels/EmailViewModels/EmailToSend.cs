
namespace UnluCoProductCatalog.Application.ViewModels.EmailViewModels
{
    public class EmailToSend
    {
        public string To { get; set; }
        public string From { get;} = "gvnbrs54@gmail.com";
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
