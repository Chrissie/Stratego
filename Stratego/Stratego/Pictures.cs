using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    class Pictures
    {
        public static Dictionary<string, Image[]> Images = new Dictionary<string, Image[]>();
        public static Image[] Maarschalk = new Image[2];
        public static Image[] Generaal = new Image[2];
        public static Image[] Kolonel = new Image[2];
        public static Image[] Majoor = new Image[2];
        public static Image[] Kapitein = new Image[2];
        public static Image[] Lieutenant = new Image[2];
        public static Image[] Sergeant = new Image[2];
        public static Image[] Mineur = new Image[2];
        public static Image[] Verkenner = new Image[2];
        public static Image[] Spion = new Image[2];
        public static Image[] Bom = new Image[2];
        public static Image[] Vlag = new Image[2];

        public static void CreatePictures()
        {
            //BLAUW
            Bitmap sheet;
            using (var bmpTemp = Image.FromFile(@"Images\alles blauw.png"))
            {
                sheet = new Bitmap(bmpTemp);
            }

            Rectangle rectangle = new Rectangle(new Point(0, 0), new Size(sheet.Width / 6, sheet.Height / 2));
            Vlag[0] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Maarschalk[0] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Generaal[0] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Kolonel[0] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Majoor[0] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Kapitein[0] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);

            rectangle.X = 0;
            rectangle.Y = rectangle.Height;
            Lieutenant[0] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Sergeant[0] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Mineur[0] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Verkenner[0] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Spion[0] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Bom[0] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            //ROOD
            using (var bmpTemp = Image.FromFile(@"Images\alles rood.png"))
            {
                sheet = new Bitmap(bmpTemp);
            }

            rectangle = new Rectangle(new Point(0, 0), new Size(sheet.Width / 6, sheet.Height / 2));
            Vlag[1] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Maarschalk[1] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Generaal[1] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Kolonel[1] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Majoor[1] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Kapitein[1] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);

            rectangle.X = 0;
            rectangle.Y = rectangle.Height;
            Lieutenant[1] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Sergeant[1] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Mineur[1] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Verkenner[1] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Spion[1] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);
            rectangle.X = rectangle.X + rectangle.Width;
            Bom[1] = sheet.Clone(rectangle, System.Drawing.Imaging.PixelFormat.DontCare);

            Images.Add("Maarschalk", Maarschalk);
            Images.Add("Generaal", Generaal);
            Images.Add("Kolonel", Kolonel);
            Images.Add("Majoor", Majoor);
            Images.Add("Kapitein", Kapitein);
            Images.Add("Lieutenant", Lieutenant);
            Images.Add("Sergeant", Sergeant);
            Images.Add("Mineur", Mineur);
            Images.Add("Verkenner", Verkenner);
            Images.Add("Spion", Spion);
            Images.Add("Bom", Bom);
            Images.Add("Vlag", Vlag);

        }
    }
}
