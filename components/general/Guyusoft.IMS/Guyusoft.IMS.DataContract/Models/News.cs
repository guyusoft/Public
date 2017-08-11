namespace Guyusoft.IMS.DataContract
{
    public class News : BaseModel
    {
        public string Title { get; set; }

        public int NewsCategoryId { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; }
    }
}
