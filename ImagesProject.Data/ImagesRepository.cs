using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImagesProject.Data
{
    public class ImagesRepository
    {
        private readonly string _connectionString;
        public ImagesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Image> GetImages()
        {
            using (var context = new ImagesContext(_connectionString))
            {
                return context.Images.OrderBy(i => i.Date).ToList();
            }
        }
        public void AddImage(Image image)
        {
            using (var context = new ImagesContext(_connectionString))
            {
                image.Date = DateTime.Now;
                context.Images.Add(image);
                context.SaveChanges();
            }
        }
        public Image GetImage(int id)
        {
            using (var context = new ImagesContext(_connectionString))
            {
                return context.Images.FirstOrDefault(i => i.ID == id);
            }
        }
        public void LikeImage(int id)
        {
            using (var context = new ImagesContext(_connectionString))
            {
                context.Images.FirstOrDefault(i => i.ID == id).Likes++;
                context.SaveChanges();
            }
        }
    }
}
