namespace _3D_converter
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AnT = new SharpGL.OpenGLControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button_R_Up = new System.Windows.Forms.Button();
            this.button_R_Down = new System.Windows.Forms.Button();
            this.button_R_Left = new System.Windows.Forms.Button();
            this.button_R_Right = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Z_add = new System.Windows.Forms.Button();
            this.button_Z_sub = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkBox_Mirror = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_Texture = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.AnT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AnT
            // 
            this.AnT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnT.DrawFPS = false;
            this.AnT.Location = new System.Drawing.Point(0, 0);
            this.AnT.Name = "AnT";
            this.AnT.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.AnT.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.AnT.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.AnT.Size = new System.Drawing.Size(1184, 701);
            this.AnT.TabIndex = 1;
            this.AnT.OpenGLInitialized += new System.EventHandler(this.openGLControl1_OpenGLInitialized);
            this.AnT.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            this.AnT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openGLControl1_KeyDown);
            this.AnT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.openGLControl1_KeyUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 181);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Enabled = false;
            this.ConvertButton.Location = new System.Drawing.Point(6, 106);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(75, 23);
            this.ConvertButton.TabIndex = 8;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(66, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rotation";
            // 
            // button_R_Up
            // 
            this.button_R_Up.Location = new System.Drawing.Point(66, 55);
            this.button_R_Up.Name = "button_R_Up";
            this.button_R_Up.Size = new System.Drawing.Size(75, 23);
            this.button_R_Up.TabIndex = 10;
            this.button_R_Up.Text = "Up";
            this.button_R_Up.UseVisualStyleBackColor = true;
            this.button_R_Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_R_Up_MouseDown);
            this.button_R_Up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_R_Up_MouseUp);
            // 
            // button_R_Down
            // 
            this.button_R_Down.Location = new System.Drawing.Point(66, 111);
            this.button_R_Down.Name = "button_R_Down";
            this.button_R_Down.Size = new System.Drawing.Size(75, 23);
            this.button_R_Down.TabIndex = 11;
            this.button_R_Down.Text = "Down";
            this.button_R_Down.UseVisualStyleBackColor = true;
            this.button_R_Down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_R_Down_MouseDown);
            this.button_R_Down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_R_Down_MouseUp);
            // 
            // button_R_Left
            // 
            this.button_R_Left.Location = new System.Drawing.Point(20, 83);
            this.button_R_Left.Name = "button_R_Left";
            this.button_R_Left.Size = new System.Drawing.Size(75, 23);
            this.button_R_Left.TabIndex = 12;
            this.button_R_Left.Text = "Left";
            this.button_R_Left.UseVisualStyleBackColor = true;
            this.button_R_Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_R_Left_MouseDown);
            this.button_R_Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_R_Left_MouseUp);
            // 
            // button_R_Right
            // 
            this.button_R_Right.Location = new System.Drawing.Point(111, 83);
            this.button_R_Right.Name = "button_R_Right";
            this.button_R_Right.Size = new System.Drawing.Size(75, 23);
            this.button_R_Right.TabIndex = 13;
            this.button_R_Right.Text = "Right";
            this.button_R_Right.UseVisualStyleBackColor = true;
            this.button_R_Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_R_Right_MouseDown);
            this.button_R_Right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_R_Right_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.Location = new System.Drawing.Point(73, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "Zoom";
            // 
            // button_Z_add
            // 
            this.button_Z_add.Location = new System.Drawing.Point(111, 177);
            this.button_Z_add.Name = "button_Z_add";
            this.button_Z_add.Size = new System.Drawing.Size(75, 23);
            this.button_Z_add.TabIndex = 16;
            this.button_Z_add.Text = "+";
            this.button_Z_add.UseVisualStyleBackColor = true;
            this.button_Z_add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_Z_add_MouseDown);
            this.button_Z_add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_Z_add_MouseUp);
            // 
            // button_Z_sub
            // 
            this.button_Z_sub.Location = new System.Drawing.Point(20, 177);
            this.button_Z_sub.Name = "button_Z_sub";
            this.button_Z_sub.Size = new System.Drawing.Size(75, 23);
            this.button_Z_sub.TabIndex = 15;
            this.button_Z_sub.Text = "-";
            this.button_Z_sub.UseVisualStyleBackColor = true;
            this.button_Z_sub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_Z_sub_MouseDown);
            this.button_Z_sub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_Z_sub_MouseUp);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(13, 43);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(81, 20);
            this.textBox3.TabIndex = 17;
            this.textBox3.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(10, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "length poles";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(124, 43);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(81, 20);
            this.textBox4.TabIndex = 19;
            this.textBox4.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(124, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "height Z";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 135);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(199, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 21;
            // 
            // checkBox_Mirror
            // 
            this.checkBox_Mirror.AutoSize = true;
            this.checkBox_Mirror.Location = new System.Drawing.Point(23, 219);
            this.checkBox_Mirror.Name = "checkBox_Mirror";
            this.checkBox_Mirror.Size = new System.Drawing.Size(52, 17);
            this.checkBox_Mirror.TabIndex = 26;
            this.checkBox_Mirror.Text = "Mirror";
            this.checkBox_Mirror.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(9, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(194, 181);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(36, 206);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(135, 23);
            this.button4.TabIndex = 31;
            this.button4.Text = "Texture";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_Texture);
            this.groupBox1.Controls.Add(this.button_Z_add);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button_R_Up);
            this.groupBox1.Controls.Add(this.button_R_Down);
            this.groupBox1.Controls.Add(this.button_R_Left);
            this.groupBox1.Controls.Add(this.button_R_Right);
            this.groupBox1.Controls.Add(this.checkBox_Mirror);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button_Z_sub);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 266);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ViewSettings";
            // 
            // checkBox_Texture
            // 
            this.checkBox_Texture.AutoSize = true;
            this.checkBox_Texture.Checked = true;
            this.checkBox_Texture.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Texture.Location = new System.Drawing.Point(23, 237);
            this.checkBox_Texture.Name = "checkBox_Texture";
            this.checkBox_Texture.Size = new System.Drawing.Size(62, 17);
            this.checkBox_Texture.TabIndex = 27;
            this.checkBox_Texture.Text = "Texture";
            this.checkBox_Texture.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(3, 270);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 233);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Texture";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(153, 106);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 23);
            this.button6.TabIndex = 27;
            this.button6.Text = "Flat";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(97, 106);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 23);
            this.button5.TabIndex = 26;
            this.button5.Text = "Smooth";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ConvertButton);
            this.groupBox4.Controls.Add(this.progressBar1);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(3, 505);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(211, 168);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fileToolStripMenuItem.Text = "Menu";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(965, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 677);
            this.panel1.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 701);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.AnT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1200, 740);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AnT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SharpGL.OpenGLControl AnT;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_R_Up;
        private System.Windows.Forms.Button button_R_Down;
        private System.Windows.Forms.Button button_R_Left;
        private System.Windows.Forms.Button button_R_Right;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Z_add;
        private System.Windows.Forms.Button button_Z_sub;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBox_Mirror;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_Texture;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
    }
}

