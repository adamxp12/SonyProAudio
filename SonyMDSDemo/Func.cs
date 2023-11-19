using SonyMDSDemo.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SonyMDSDemo
{
    public class Func
    {
        public static ImageList SetupImageList(string img1, string img2)
        {
            ImageList i = new ImageList();
            i.ImageSize = new Size(120, 60);
            i.Images.Add((Bitmap)Resources.ResourceManager.GetObject(img1));
            i.Images.Add((Bitmap)Resources.ResourceManager.GetObject(img2));
            return i;
        }
    }
}
