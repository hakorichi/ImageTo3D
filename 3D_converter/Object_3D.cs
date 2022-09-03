using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Emgu.CV;
using Emgu.CV.Structure;




namespace _3D_converter
{
    class Object_3D
    {

        #region Переменные
        const int Optimized = 100;

        private struct Smooth
        {
            public List<Point> Normales;
            public Smooth(int n)
            {
                Normales = new List<Point>();
            }
        }
        public struct Point
        {
           public float x;
           public float y;
           public float z;
           public Point(float X, float Y, float Z) { x = X; y = Y;z = Z; }
           public Point minus(Point P)
            {
                return new Point(x - P.x, y - P.y, z - P.z);
            }
            public Point div(float K)
            {
                return new Point(x /K, y / K, z / K);
            }
            public Point plus(Point P)
            {
                return new Point(x + P.x, y + P.y, z + P.z);
            }
           public void NormaliseNormal()
            {
                float length = (float)Math.Sqrt(x * x + y * y + z * z);
                x /= length;
                y /= length;
                z /= length;
            }
        }
        public struct Pole
        {
            public int NormalT1;
            public int NormalT2;
            public int NormalT3;
            public int T1;
            public int T2;
            public int T3;
            public int TextT1;
            public int TextT2;
            public int TextT3;
            public Pole(int in1, int in2, int in3, int inT1, int inT2, int inT3, int normal )
            {
                T1 = in1; T2 = in2; T3 = in3;
                TextT1 = inT1; TextT2 = inT2; TextT3 = inT3;
                NormalT1 = normal; NormalT2 = normal; NormalT3 = normal;
            }
            public Pole(int in1, int in2, int in3, int normal)
            {
                T1 = in1; T2 = in2; T3 = in3;
                TextT1 = 0; TextT2 = 0; TextT3 = 0;
                NormalT1 = normal; NormalT2 = normal; NormalT3 = normal;
            }
            public Pole(int in1, int in2, int in3, int NT1, int NT2, int NT3)
            {
                T1 = in1; T2 = in2; T3 = in3;
                TextT1 = 0; TextT2 = 0; TextT3 = 0;
                NormalT1 = NT1; NormalT2 = NT2; NormalT3 = NT3;
            }
            public Pole(int in1, int in2, int in3, int inT1, int inT2, int inT3, int NT1, int NT2, int NT3)
            {
                T1 = in1; T2 = in2; T3 = in3;
                TextT1 = T1; TextT2 = T2; TextT3 = T3;
                NormalT1 = NT1; NormalT2 = NT2; NormalT3 = NT3;
            }
        }
        public float M = (float)0.1;
        public String CName;
        public List<Point> Points;
        public List<Point> Normales;
        public List<Point> TexturePoints;
        public List<Pole> Poles;

        public Boolean ImageB;
        private Bitmap bmp1, bmp2;
        public string TextureName;
        private int PicselsInPole = 1;
        public float Z = 1f;
        
        public int brightness = 100;
        public int contrast = 100;

        public int Progress;
        #endregion

        public Object_3D()
        {
            Points = new List<Point>();
            Normales = new List<Point>();
            TexturePoints = new List<Point>();
            Poles = new List<Pole>();
            CName = "NoName";
            Progress = 0;
        }

        public Boolean Open(Form1 F1= null)
        {
            OpenFileDialog dialog = new OpenFileDialog(); //описываем и порождаем объект dialog класса OpenFileDialog
            dialog.Filter = "Image files (*.OBJ,*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.obj;*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (dialog.ShowDialog() == DialogResult.OK)//вызываем диалоговое окно и проверяем выбран ли файл
            {

                String SafeFile = dialog.SafeFileName.Substring(dialog.SafeFileName.Length - 4);
                if (SafeFile == ".obj")
                {
                    LoadModel(dialog.FileName,F1);
                    ImageB = false;
                    return false;
                }
                else
                {         
                    Image image = Image.FromFile(dialog.FileName); //Загружаем в image изображение из выбранного файла
                    bmp1 = new Bitmap(image, image.Width, image.Height); //создаем и загружаем из image изображение в форматье bmp
                    bmp2 = bmp1;
                    Z = 1;
                    SetAutoPicselsInPole();
                    Convert();
                    ImageB = true;
                    return true;
                }
            }
            return ImageB;
        }
        private void LoadModel(String path, Form1 F1 = null)
        {
            bmp1 = Properties.Resources.obj;
            bmp2 = bmp1;

            TexturePoints = new List<Point>();
            Normales = new List<Point>();
            Points = new List<Point>();
            Poles = new List<Pole>();

            String line;
            System.IO.FileStream fileStream = new System.IO.FileStream(path, System.IO.FileMode.Open);
            System.IO.StreamReader reader = new System.IO.StreamReader(fileStream, Encoding.Default);

            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("v "))
                {
                    float x = float.Parse(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1].Replace('.', ','));
                    float y = float.Parse(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[2].Replace('.', ','));
                    float z = float.Parse(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[3].Replace('.', ','));
                    Points.Add(new Point(x, y, z));
                }
                else if (line.StartsWith("vn "))
                {
                    float x1 = float.Parse(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1].Replace('.', ','));
                    float y1 = float.Parse(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[2].Replace('.', ','));
                    float z1 = float.Parse(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[3].Replace('.', ','));
                    Normales.Add(new Point(x1, y1, z1));
                }
                else if (line.StartsWith("vt "))
                {
                    float x1 = float.Parse(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1].Replace('.', ','));
                    float y1 = float.Parse(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[2].Replace('.', ','));
                    TexturePoints.Add(new Point(x1, y1, 0f));
                }
                else if (line.StartsWith("f "))
                {

                    if ((line.Split(new char[] { ' ', '/' })[2] == "") || (line.Split(new char[] { ' ', '/' })[5] == "") || (line.Split(new char[] { ' ', '/' })[8] == ""))
                    {
                        Poles.Add(new Pole(
                          (int)(int.Parse(line.Split(new char[] { ' ', '/' })[1])),
                          (int)(int.Parse(line.Split(new char[] { ' ', '/' })[4])),
                          (int)(int.Parse(line.Split(new char[] { ' ', '/' })[7])),
                          (int)(int.Parse(line.Split(new char[] { ' ', '/' })[3])),
                          (int)(int.Parse(line.Split(new char[] { ' ', '/' })[6])),
                          (int)(int.Parse(line.Split(new char[] { ' ', '/' })[9]))));
                    }
                    else
                    {
                        Poles.Add(new Pole(
                            (int)(int.Parse(line.Split(new char[] { ' ', '/' })[1])),
                            (int)(int.Parse(line.Split(new char[] { ' ', '/' })[4])),
                            (int)(int.Parse(line.Split(new char[] { ' ', '/' })[7])),
                            (int)(int.Parse(line.Split(new char[] { ' ', '/' })[2])),
                            (int)(int.Parse(line.Split(new char[] { ' ', '/' })[5])),
                            (int)(int.Parse(line.Split(new char[] { ' ', '/' })[8])),
                            (int)(int.Parse(line.Split(new char[] { ' ', '/' })[3])),
                            (int)(int.Parse(line.Split(new char[] { ' ', '/' })[6])),
                            (int)(int.Parse(line.Split(new char[] { ' ', '/' })[9]))));
                    }
                }
            }

            if (F1 !=null)
            {
                if (System.IO.File.Exists(path.Remove(path.Length - 3) + "mtl"))
                {
                    fileStream = new System.IO.FileStream(path.Remove(path.Length - 3) + "mtl", System.IO.FileMode.Open);

                    reader = new System.IO.StreamReader(fileStream, Encoding.Default);
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("map_Kd "))
                        {
                            F1.LoadTexture(line.Split(new char[] { ' ', '/' })[1]);
                            break;
                        }
                    }
                }
            }
        }
        private Bitmap ConvertGray(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    int R = bmp.GetPixel(i, j).R; //извлекаем в R значение красного цвета в текущей точке
                    int G = bmp.GetPixel(i, j).G; //извлекаем в G значение зеленого цвета в текущей точке
                    int B = bmp.GetPixel(i, j).B; //извлекаем в B значение синего цвета в текущей точке
                    int Gray = (R + G + B) / 3; // высчитываем среденее арифметическое трех каналов
                    Color p = Color.FromArgb(255, Gray, Gray, Gray); //переводим int в значение цвета. 255 - показывает степень прозрачности. остальные значения одинаковы для трех каналов R,G,B
                    bmp.SetPixel(i, j, p); //записываме полученный цвет в текущую точку
                }
            return bmp;
        }
        private Bitmap OpenFile()
        {
            Bitmap Bmp = new Bitmap(1,1);
            try
            {
                OpenFileDialog dialog = new OpenFileDialog(); //описываем и порождаем объект dialog класса OpenFileDialog
                dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
                if (dialog.ShowDialog() == DialogResult.OK)//вызываем диалоговое окно и проверяем выбран ли файл
                {

                    if (dialog.SafeFileName == ".Obj")
                    CName = dialog.FileName;
                    Image image = Image.FromFile(dialog.FileName); //Загружаем в image изображение из выбранного файла
                    Bmp = new Bitmap(image, image.Width, image.Height); //создаем и загружаем из image изображение в форматье bmp
                }
            }
            catch
            {
     
            }
            return Bmp;
        }
        public void Convert()
        {
            Bitmap BitmapC = ConvertGray(bmp2);

            TexturePoints = new List<Point>();
            Normales = new List<Point>();
            Points = new List<Point>();
            Poles = new List<Pole>();

            int Width = (int)((double)BitmapC.Width / PicselsInPole);
            int Height = (int)((double)BitmapC.Height / PicselsInPole);

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Points.Add(new Point((i - (int)(Width / 2)) * M, -(j - (int)(Height / 2)) * M, (float)BitmapC.GetPixel(i * PicselsInPole, j * PicselsInPole).G / 128 * Z));
                    TexturePoints.Add(new Point((float)i / Width, 1 - (float)j / Height, 0));
                }
                Progress = (int)(((double)i / Width) * 50);
            }

                Point Zero = new Point(0, 0, 0);
            for (int i = 0; i < Width - 1; i++)
            {
                for (int j = 0; j < Height - 1; j++)
                {
                    int T1 = i * Height + j + 1;
                    int T2 = i * Height + j + 1 + 1;
                    int T3 = (i + 1) * Height + j + 1;
                    int T4 = (i + 1) * Height + j + 1 + 1;

                    Poles.Add(new Pole(T2, T4, T1, T2, T4, T1, Poles.Count + 1));
                    Point Np = Normal(Points[T2 - 1],
                                      Points[T4 - 1],
                                      Points[T1 - 1]);
                    Normales.Add(Np);

                    Poles.Add(new Pole(T3, T1, T4, T3, T1, T4, Poles.Count + 1));
                    Np = Normal(Points[T3 - 1],
                                Points[T1 - 1],
                                Points[T4 - 1]);
                    Normales.Add(Np);
                }
                Progress = (int)(((double)i / Width) * 50) +50;
            }
            Progress = 100;
            }
        public void ConvertSmooth()
        {
            Bitmap BitmapC = ConvertGray(bmp2);
            List<Smooth> PointsSmooth = new List<Smooth>();

            TexturePoints = new List<Point>();
            Normales = new List<Point>();
            Points = new List<Point>();
            Poles = new List<Pole>();

            int Width = (int)((double)BitmapC.Width / PicselsInPole);
            int Height = (int)((double)BitmapC.Height / PicselsInPole);

            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                {
                    Points.Add(new Point((i - (int)(Width / 2)) * M, -(j - (int)(Height / 2)) * M, (float)BitmapC.GetPixel(i * PicselsInPole, j * PicselsInPole).G / 128 * Z));
                    TexturePoints.Add(new Point((float)i / Width, 1 - (float)j / Height, 0));
                    PointsSmooth.Add(new Smooth(0));
                }

            Point Zero = new Point(0, 0, 0);
            for (int i = 0; i < Width - 1; i++)
                for (int j = 0; j < Height - 1; j++)
                {
                    int T1 = i * Height + j + 1;
                    int T2 = i * Height + j + 1 + 1;
                    int T3 = (i + 1) * Height + j + 1;
                    int T4 = (i + 1) * Height + j + 1 + 1;

                    Poles.Add(new Pole(T2, T4, T1, T2, T4, T1, T2, T4, T1));
                    Point Np = Normal(Points[T2 - 1],
                                      Points[T4 - 1],
                                      Points[T1 - 1]);
                    PointsSmooth[T2 - 1].Normales.Add(Np);
                    PointsSmooth[T4 - 1].Normales.Add(Np);
                    PointsSmooth[T1 - 1].Normales.Add(Np);

                    Poles.Add(new Pole(T3, T1, T4, T3, T1, T4, T3, T1, T4));
                    Np = Normal(Points[T3 - 1],
                                Points[T1 - 1],
                                Points[T4 - 1]);
                    PointsSmooth[T3 - 1].Normales.Add(Np);
                    PointsSmooth[T1 - 1].Normales.Add(Np);
                    PointsSmooth[T4 - 1].Normales.Add(Np);
                }


            foreach (Smooth element in PointsSmooth)
            {
                Point NormalT = new Point(0, 0, 0);
                foreach (Point elementN in element.Normales)
                {
                    NormalT = NormalT.plus(elementN);
                }
                NormalT.NormaliseNormal();
                Normales.Add(NormalT);
            }
        }
        public void Smoothing()
        {
            List<Smooth> PointsSmooth = new List<Smooth>();
            List<Pole> Poles2 = new List<Pole>();

            foreach (Point element in Points)
            {
                PointsSmooth.Add(new Smooth(0));
            }

            foreach (Pole element in Poles)
            {
                Point Np = Normales[element.NormalT1-1].plus(Normales[element.NormalT2-1]).plus(Normales[element.NormalT3-1]).div(3);

                PointsSmooth[element.T1 - 1].Normales.Add(Np);
                PointsSmooth[element.T2 - 1].Normales.Add(Np);
                PointsSmooth[element.T3 - 1].Normales.Add(Np);

                Poles2.Add(new Pole(element.T1, element.T2, element.T3, element.TextT1, element.TextT2, element.TextT3, element.T1, element.T2, element.T3));
            }

            Normales = new List<Point>();
            foreach (Smooth element in PointsSmooth)
            {
                Point NormalT = new Point(0, 0, 0);
                foreach (Point elementN in element.Normales)
                {
                    NormalT = NormalT.plus(elementN);
                }
                NormalT.NormaliseNormal();
                Normales.Add(NormalT);
            }
            Poles = Poles2;
        }
        public void Flat()
        {
            Normales = new List<Point>();
            List<Pole> Poles2 = new List<Pole>();

            foreach (Pole element in Poles)
            {        
                Poles2.Add(new Pole(element.T1, element.T2, element.T3, element.T1, element.T2, element.T3, Poles2.Count + 1));
                Point Np = Normal(Points[ element.T1-1], Points[element.T2-1], Points[element.T3-1]);
                Normales.Add(Np);
            }
      
            Poles = Poles2;
        }
        public static Point Normal(Point T1, Point T2, Point T3)
        {
            float A = T1.y * (T2.z - T3.z) + T2.y * (T3.z - T1.z) + T3.y * (T1.z - T2.z);
            float B = T1.z * (T2.x - T3.x) + T2.z * (T3.x - T1.x) + T3.z * (T1.x - T2.x);
            float C = T1.x * (T2.y - T3.y) + T2.x * (T3.y - T1.y) + T3.x * (T1.y - T2.y);
            float D = -(T1.x * (T2.y * T3.z - T3.y * T2.z) + T2.x * (T3.y * T1.z - T1.y * T3.z) + T3.x * (T1.y * T2.z - T2.y * T1.z));

            Point Nor = new Point(A, B, C);
            //if (D > 0) Nor = new Point(-A, -B, -C);

            float length = (float)Math.Sqrt(Nor.x * Nor.x + Nor.y * Nor.y + Nor.z * Nor.z);
            Nor.x /= length;
            Nor.y /= length;
            Nor.z /= length;

            return Nor;
        }
        public void Save( String Name)
        {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(Name);

            SaveFile.WriteLine("# 3D_Converter OBJ File:");
            SaveFile.WriteLine("# Date:" + System.DateTime.Today.ToString());
            foreach (Point element in Points)
            { 
                SaveFile.WriteLine("v" +" "+ element.x.ToString(System.Globalization.CultureInfo.InvariantCulture) + " " + element.y.ToString(System.Globalization.CultureInfo.InvariantCulture) + " " + element.z.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
            foreach (Point element in Normales)
            {
                SaveFile.WriteLine("vn" + " " + element.x.ToString(System.Globalization.CultureInfo.InvariantCulture) + " " + element.y.ToString(System.Globalization.CultureInfo.InvariantCulture) + " " + element.z.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
            foreach (Point element in TexturePoints)
            {
                SaveFile.WriteLine("vt" + " " + element.x.ToString(System.Globalization.CultureInfo.InvariantCulture) + " " + element.y.ToString(System.Globalization.CultureInfo.InvariantCulture) + " " + element.z.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
            foreach (Pole element in Poles)
            {

                    SaveFile.WriteLine("f" + " " + element.T1.ToString() + "/" + element.T1.ToString() + "/" + element.NormalT1.ToString()
                                           + " " + element.T2.ToString() + "/" + element.T2.ToString() + "/" + element.NormalT2.ToString()
                                           + " " + element.T3.ToString() + "/" + element.T3.ToString() + "/" + element.NormalT3.ToString());
            }
            SaveFile.Close();

            if (TextureName != null)
            {
                SaveFile = new System.IO.StreamWriter(Name.Remove(Name.Length - 3) + "mtl");
                SaveFile.WriteLine("# 3D_Converter MTL File:");
                SaveFile.WriteLine("# Date:" + System.DateTime.Today.ToString());
                SaveFile.WriteLine("Ns 100.000000");
                SaveFile.WriteLine("Kd 0.640000 0.640000 0.640000");
                SaveFile.WriteLine("Ka 1.000000 1.000000 1.000000");
                SaveFile.WriteLine("Ks 0.500000 0.500000 0.500000");
                SaveFile.WriteLine("Ke 0.000000 0.000000 0.000000");
                SaveFile.WriteLine("Ni 1.000000 d 1.000000");
                SaveFile.WriteLine("illum 2");
                SaveFile.WriteLine("map_Kd " + TextureName);
                SaveFile.Close();
            }
        }
        public Bitmap GetBitmap()
        {
            return bmp2;
        }
        private void SetAutoPicselsInPole()
        {
            int Height = bmp1.Height;
            int Width = bmp1.Width;

            if ((Height>=Width)&&(Height>= Optimized))
            {
                SetPicselsInPole((int)((double)Height / Optimized));
                return;
            }
            if ((Width >= Height) && (Width >= Optimized))
            {
                SetPicselsInPole((int)((double)Width / Optimized));
                return;
            }
            SetPicselsInPole(1);
            return;
        }
        public void SetPicselsInPole(int K)
        {
            if (K > 0) PicselsInPole = K;
        }
        public int GetPicselsInPole()
        {
            return PicselsInPole;
        }

        public void ConvertImage()
        {
            Image<Bgr, Byte> im = new Image<Bgr, Byte>(bmp1);
            
            if (brightness != 100)
            {
                if (brightness > 100)
                    im += (byte)((((double)brightness - 100) / 100) * 255);
                else
                    im -= (byte)(((100 - (double)brightness) / 100) * 255);
            }
            if (contrast != 100)
            {
                im *= ((double)contrast * contrast / 10000);
            }

            bmp2 = im.Bitmap;
        }
    }
}
