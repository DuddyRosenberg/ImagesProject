using System;

namespace ImagesProject.Data
{
    public class Image
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Likes { get; set; }
    }
}
