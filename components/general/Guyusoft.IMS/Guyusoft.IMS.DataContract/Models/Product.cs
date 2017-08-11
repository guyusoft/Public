namespace Guyusoft.IMS.DataContract
{
    public class Product : BaseModel
    {
        public string Title { get; set; }

        public string ProductName { get; set; }

        public string ProductDesc { get; set; }

        public int ProductCategoryId { get; set; }
    }
}
