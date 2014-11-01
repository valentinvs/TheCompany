namespace TheCompany.Data
{
    public abstract class MenuObject
    {
        public string TitleEN { get; set; }
        public string TitleBG { get; set; }
        public string PicturePath { get; set; }
        public string ThumbnailPath { get; set; }
        public bool Deleted { get; set; }
    }
}
