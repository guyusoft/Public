namespace Guyusoft.IMS.DataContract
{
    public class NewsCategory : BaseModel
    {
        public int ParentId { get; set; }

        public string CategoryName { get; set; }
    }
}
