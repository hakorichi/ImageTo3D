using Emgu.CV;
using Emgu.CV.Structure;
using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
using Tao.DevIl;
using System.IO;
using System.Threading;

namespace _3D_converter
{
    public partial class Form1 : Form
    {
        #region Переменные
        Object_3D Obj;
        /*
        Object_3D.Point Zero = new Object_3D.Point(0, 0, 1);
        Object_3D.Point Rot = new Object_3D.Point(0, 0, 1);
        Object_3D.Point Normal = new Object_3D.Point(1, 0, 0);
        double Y = 0;
        */
        float rotation_x = 0;
        float rotation_y = 0;

        float Z_pos = 0f;
        float Z_start = -4f;

        bool flag_Right = false;
        bool flag_Down = false;
        bool flag_Up = false;
        bool flag_Zoom_p = false;
        bool flag_Zoom_m = false;
        bool flag_Left = false;

        float x_min = 0;
        float x_max = 0;
        float y_min = 0;
        float y_max = 0;
        float z_min = 0;
        float z_max = 0;

        private int rot = 0;
        // флаг - загружена ли текстура
        private bool textureIsLoad = false;
        // имя текстуры
        public string texture_name = "";
        // идентификатор текстуры
        public int imageId = 0;
        // текстурный объект
        public uint mGlTextureObject = 0;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }
        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();


            if (flag_Up) RotetionX(1f);
            //--------------------------------------------------------
            if (flag_Down) RotetionX(-1f);
            //--------------------------------------------------------
            if (flag_Right) RotetionY(-1f);
            //--------------------------------------------------------
            if (flag_Left) RotetionY(1f);
            //--------------------------------------------------------
            if (flag_Zoom_p) Z_pos += 0.5f;
            //--------------------------------------------------------
            if (flag_Zoom_m) Z_pos -= 0.5f;
            //--------------------------------------------------------


            if (checkBox_Texture.Checked)
             {
                 Gl.glEnable(Gl.GL_TEXTURE_2D);
            }

            Gl.glColor3b(255, 255, 255);


            Gl.glTranslatef(0f, -0.75f, Z_start + Z_pos);
            Gl.glRotatef(rotation_x, 1, 0, 0);
            Gl.glRotatef(rotation_y, 0, 1, 0);
            Gl.glNormal3f(0.0f, 0.0f, 1.0f); // указываем направление нормалей    

            foreach (Object_3D.Pole var in Obj.Poles)
            {
                try
                {
                    Gl.glBegin(Gl.GL_TRIANGLES);

                    if ((Obj.TexturePoints.Count != 0)&&(checkBox_Texture.Checked))
                    {
                        Gl.glNormal3f(Obj.Normales[var.NormalT1 - 1].x, Obj.Normales[var.NormalT1 - 1].y, Obj.Normales[var.NormalT1 - 1].z);
                        Gl.glTexCoord2f(Obj.TexturePoints[var.TextT1 - 1].x, Obj.TexturePoints[var.TextT1 - 1].y);
                        Gl.glVertex3f(Obj.Points[var.T1 - 1].x, Obj.Points[var.T1 - 1].y, Obj.Points[var.T1 - 1].z);

                        Gl.glNormal3f(Obj.Normales[var.NormalT2 - 1].x, Obj.Normales[var.NormalT2 - 1].y, Obj.Normales[var.NormalT2 - 1].z);
                        Gl.glTexCoord2f(Obj.TexturePoints[var.TextT2 - 1].x, Obj.TexturePoints[var.TextT2 - 1].y);
                        Gl.glVertex3f(Obj.Points[var.T2 - 1].x, Obj.Points[var.T2 - 1].y, Obj.Points[var.T2 - 1].z);

                        Gl.glNormal3f(Obj.Normales[var.NormalT3 - 1].x, Obj.Normales[var.NormalT3 - 1].y, Obj.Normales[var.NormalT3 - 1].z);
                        Gl.glTexCoord2f(Obj.TexturePoints[var.TextT3 - 1].x, Obj.TexturePoints[var.TextT3 - 1].y);
                        Gl.glVertex3f(Obj.Points[var.T3 - 1].x, Obj.Points[var.T3 - 1].y, Obj.Points[var.T3 - 1].z);
                    }
                    else
                    {
                        Gl.glNormal3f(Obj.Normales[var.NormalT1 - 1].x, Obj.Normales[var.NormalT1 - 1].y, Obj.Normales[var.NormalT1 - 1].z);
                        Gl.glVertex3f(Obj.Points[var.T1 - 1].x, Obj.Points[var.T1 - 1].y, Obj.Points[var.T1 - 1].z);

                        Gl.glNormal3f(Obj.Normales[var.NormalT2 - 1].x, Obj.Normales[var.NormalT2 - 1].y, Obj.Normales[var.NormalT2 - 1].z);
                        Gl.glVertex3f(Obj.Points[var.T2 - 1].x, Obj.Points[var.T2 - 1].y, Obj.Points[var.T2 - 1].z);

                        Gl.glNormal3f(Obj.Normales[var.NormalT3 - 1].x, Obj.Normales[var.NormalT3 - 1].y, Obj.Normales[var.NormalT3 - 1].z);
                        Gl.glVertex3f(Obj.Points[var.T3 - 1].x, Obj.Points[var.T3 - 1].y, Obj.Points[var.T3 - 1].z);
                    }
                    Gl.glEnd();
                }
                catch
                {};
            }
            #region Mirror
            if (checkBox_Mirror.Checked)
            {
                foreach (Object_3D.Pole var in Obj.Poles)
                {
                    try
                    {
                        Gl.glBegin(Gl.GL_TRIANGLES);
                        Gl.glColor3f(0.5f, 0.5f, 0.5f);

                        if ((Obj.TexturePoints.Count != 0) && (checkBox_Texture.Checked))
                        {
                            Gl.glNormal3f(Obj.Normales[var.NormalT1 - 1].x, Obj.Normales[var.NormalT1 - 1].y, -Obj.Normales[var.NormalT1 - 1].z);
                            Gl.glTexCoord2f(Obj.TexturePoints[var.TextT1 - 1].x, Obj.TexturePoints[var.TextT1 - 1].y);
                            Gl.glVertex3f(Obj.Points[var.T1 - 1].x, Obj.Points[var.T1 - 1].y, -Obj.Points[var.T1 - 1].z);

                            Gl.glNormal3f(Obj.Normales[var.NormalT2 - 1].x, Obj.Normales[var.NormalT2 - 1].y, -Obj.Normales[var.NormalT2 - 1].z);
                            Gl.glTexCoord2f(Obj.TexturePoints[var.TextT2 - 1].x, Obj.TexturePoints[var.TextT2 - 1].y);
                            Gl.glVertex3f(Obj.Points[var.T2 - 1].x, Obj.Points[var.T2 - 1].y, -Obj.Points[var.T2 - 1].z);

                            Gl.glNormal3f(Obj.Normales[var.NormalT3 - 1].x, Obj.Normales[var.NormalT3 - 1].y, -Obj.Normales[var.NormalT3 - 1].z);
                            Gl.glTexCoord2f(Obj.TexturePoints[var.TextT3 - 1].x, Obj.TexturePoints[var.TextT3 - 1].y);
                            Gl.glVertex3f(Obj.Points[var.T3 - 1].x, Obj.Points[var.T3 - 1].y, -Obj.Points[var.T3 - 1].z);
                        }
                        else
                        {
                            Gl.glNormal3f(Obj.Normales[var.NormalT1 - 1].x, Obj.Normales[var.NormalT1 - 1].y, -Obj.Normales[var.NormalT1 - 1].z);
                            Gl.glVertex3f(Obj.Points[var.T1 - 1].x, Obj.Points[var.T1 - 1].y, -Obj.Points[var.T1 - 1].z);

                            Gl.glNormal3f(Obj.Normales[var.NormalT2 - 1].x, Obj.Normales[var.NormalT2 - 1].y, -Obj.Normales[var.NormalT2 - 1].z);
                            Gl.glVertex3f(Obj.Points[var.T2 - 1].x, Obj.Points[var.T2 - 1].y, -Obj.Points[var.T2 - 1].z);

                            Gl.glNormal3f(Obj.Normales[var.NormalT3 - 1].x, Obj.Normales[var.NormalT3 - 1].y, -Obj.Normales[var.NormalT3 - 1].z);
                            Gl.glVertex3f(Obj.Points[var.T3 - 1].x, Obj.Points[var.T3 - 1].y, -Obj.Points[var.T3 - 1].z);
                        }
                        Gl.glEnd();
                    }
                    catch
                    { };
                }
            }
            #endregion
            
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }
        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            Glut.glutInit();
            // инициализация режима экрана 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            // инициализация библиотеки openIL 
            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);
            // установка цвета очистки экрана (RGBA) 
            Gl.glClearColor(0.2f, 0.2f, 0.2f, 1);
            // установка порта вывода 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // установка перспективы 
            Glu.gluPerspective(30, AnT.Width / AnT.Height, 1, 100);
            Gl.glLoadIdentity();
            // начальные настройки OpenGL 
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Obj = new Object_3D();
        }

        private void RotetionX(float Rotate)
        {
            rotation_x += Rotate;
        }
        private void RotetionY(float Rotate)
        {
            rotation_y += Rotate;
        }

        #region ButtonEvent
        private void ButtonEnable(Boolean B)
        {
            ConvertButton.Enabled = B;
            textBox3.Enabled = B;
            textBox4.Enabled = B;
            label5.Enabled = B;
            label6.Enabled = B;
            pictureBox1.Visible = B;
        }
        private void ConvertButton_Click(object sender, EventArgs e)
        {
            try
            {
                Obj.Z = (float)Convert.ToDouble(textBox4.Text);
                Obj.SetPicselsInPole(Convert.ToInt32(textBox3.Text));
            }
            catch { };
            Obj.Convert();
        }
        public void ProgressTheard()
        {
            /*
            Action showMethod = delegate () { progressBar1.Refresh(); };

            while (progressBar1.Value<100)
            {
                
                progressBar1.BeginInvoke(new Action<int>((s) => progressBar1.Value = s), Obj.Progress);
                progressBar1.BeginInvoke(showMethod);
                Thread.Sleep(100);
            }
            progressBar1.BeginInvoke(new Action<int>((s) => progressBar1.Value = s), 0);
            progressBar1.BeginInvoke(showMethod);
            */
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            while (progressBar1.Value < 100)
            {
              
            progressBar1.Value = Obj.Progress;
            progressBar1.Refresh();
                Thread.Sleep(100);
            }
            progressBar1.Value = 0;
            progressBar1.Refresh();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Obj.Smoothing();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Obj.Flat();
        }

        #endregion

        #region ButtonEventMovetable
        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W: { flag_Up = true; break; }
                case Keys.S: { flag_Down = true; break; }
                case Keys.A: { flag_Left = true; break; }
                case Keys.D: { flag_Right = true; break; }
                case Keys.Q: { flag_Zoom_p = true; break; }
                case Keys.E: { flag_Zoom_m = true; break; }
            }
        }
        private void openGLControl1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W: { flag_Up = false; break; }
                case Keys.S: { flag_Down = false; break; }
                case Keys.A: { flag_Left = false; break; }
                case Keys.D: { flag_Right = false; break; }
                case Keys.Q: { flag_Zoom_p = false; break; }
                case Keys.E: { flag_Zoom_m = false; break; }
            }
        }

        private void button_R_Up_MouseDown(object sender, MouseEventArgs e)
        {
            flag_Up = true;
        }
        private void button_R_Right_MouseDown(object sender, MouseEventArgs e)
        {
            flag_Right = true;
        }
        private void button_R_Left_MouseDown(object sender, MouseEventArgs e)
        {
            flag_Left = true;
        }
        private void button_R_Down_MouseDown(object sender, MouseEventArgs e)
        {
            flag_Down = true;
        }
        private void button_Z_sub_MouseDown(object sender, MouseEventArgs e)
        {
            flag_Zoom_m = true;
        }
        private void button_Z_add_MouseDown(object sender, MouseEventArgs e)
        {
            flag_Zoom_p = true;
        }

        private void button_R_Up_MouseUp(object sender, MouseEventArgs e)
        {
            flag_Up = false;
        }
        private void button_R_Down_MouseUp(object sender, MouseEventArgs e)
        {
            flag_Down = false;
        }
        private void button_R_Right_MouseUp(object sender, MouseEventArgs e)
        {
            flag_Right = false;
        }
        private void button_R_Left_MouseUp(object sender, MouseEventArgs e)
        {
            flag_Left = false;
        }
        private void button_Z_sub_MouseUp(object sender, MouseEventArgs e)
        {
            flag_Zoom_m = false;
        }
        private void button_Z_add_MouseUp(object sender, MouseEventArgs e)
        {
            flag_Zoom_p = false;
        }
        #endregion

        #region  TextureControl
        private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            // идентификатор текстурного объекта 
            uint texObject;

            // генерируем текстурный объект 
            Gl.glGenTextures(1, out texObject);

            // устанавливаем режим упаковки пикселей 
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);

            // создаем привязку к только что созданной текстуре 
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);

            // устанавливаем режим фильтрации и повторения текстуры 
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);

            // создаем RGB или RGBA текстуру 
            switch (Format)
            {
                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
            }

            // возвращаем идентификатор текстурного объекта 
            return texObject;
        }


        public void LoadTexture(String FileName)
        {
            try
            {
                Obj.TextureName = FileName;
                string url = FileName;
                Bitmap BitmapIn = new Bitmap(url);
                pictureBox2.Image = new Bitmap(url);
                Image<Bgr, Byte> im = new Image<Bgr, Byte>(BitmapIn);
                int SizeTexture = 8;
                if (SizeTexture < im.Bitmap.Width) SizeTexture = im.Bitmap.Width;
                if (SizeTexture < im.Bitmap.Height) SizeTexture = im.Bitmap.Height;

                double Log = Math.Log(SizeTexture, 2);
                int LogI = (int)Log;
                if (LogI < Log) LogI++;
                SizeTexture = (int)Math.Pow(2, LogI);
                if (SizeTexture > 1024) SizeTexture = 1024;
                im = im.Resize(SizeTexture, SizeTexture, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                url += "_texture";
                im.Save(url);

                // создаем изображение с идентификатором imageId 
                Il.ilGenImages(1, out imageId);
                // делаем изображение текущим 
                Il.ilBindImage(imageId);
                // адрес изображения полученный с помощью окна выбора файла 

                // пробуем загрузить изображение 
                if (Il.ilLoadImage(url))
                {
                    // если загрузка прошла успешно 
                    // сохраняем размеры изображения 
                    int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                    int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                    // определяем число бит на пиксель 
                    int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);

                    switch (bitspp) // в зависимости от полученного результата 
                    {
                        // создаем текстуру, используя режим GL_RGB или GL_RGBA 
                        case 24:
                            mGlTextureObject = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                            break;
                        case 32:
                            mGlTextureObject = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                            break;
                    }

                    // активируем флаг, сигнализирующий загрузку текстуры 
                    textureIsLoad = true;
                    // очищаем память 
                    Il.ilDeleteImages(1, ref imageId);

                }
                File.Delete(url);
            }
            catch { };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog(); //описываем и порождаем объект dialog класса OpenFileDialog
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (dialog.ShowDialog() == DialogResult.OK)//вызываем диалоговое окно и проверяем выбран ли файл
            {
                LoadTexture(dialog.FileName);
            }
        }
        #endregion

        #region ContextMenu
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "1";

            Thread threadprogress = new Thread(ProgressTheard);
            threadprogress.Start();

            ButtonEnable(Obj.Open(this));
            textBox3.Text = Obj.GetPicselsInPole().ToString();
            pictureBox1.Image = Obj.GetBitmap();
            foreach (Object_3D.Point var in Obj.Points)
            {
                if (var.x < x_min) x_min = var.x;
                if (var.x > x_max) x_max = var.x;

                if (var.y < y_min) y_min = var.y;
                if (var.y > y_max) y_max = var.y;

                if (var.z < z_min) z_min = var.z;
                if (var.z > z_max) z_max = var.z;
            }
        }
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savedialog = new SaveFileDialog();//описываем и порождаем объект savedialog 
                                                                 //задаем свойства для savedialog
                savedialog.Title = "Сохранить как ...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "OBJ File(*.obj)|*.obj";
                savedialog.ShowHelp = true;
                // If selected, save
                if (savedialog.ShowDialog() == DialogResult.OK)//вызываем диалоговое окно и проверяем задано ли имя файла
                {
                    // в строку fileName записываем указанный в savedialog полный путь к файлу
                    string fileName = savedialog.FileName;




                    Obj.Save(fileName);
                }
            }
            catch { };
        }
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
