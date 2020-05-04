using ImagesProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagesProject.Models
{
    public class ImageViewModel
    {
        public Image Image { get; set; }
        public bool LikedImage { get; set; }
    }
}
