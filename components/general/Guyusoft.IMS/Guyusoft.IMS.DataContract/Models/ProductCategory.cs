namespace Guyusoft.IMS.DataContract
{
    public class ProductCategory : BaseModel
    {
        public int ParentId { get; set; }

        public string CategoryName { get; set; }
    }
}
