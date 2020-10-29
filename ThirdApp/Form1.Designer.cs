namespace ThirdApp
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
            this.TEXT_SIGMA = new System.Windows.Forms.TextBox();
            this.TEXT_K = new System.Windows.Forms.TextBox();
            this.TEXT_V = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.YAMA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DRAW = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TEXT_SIGMA
            // 
            this.TEXT_SIGMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TEXT_SIGMA.Location = new System.Drawing.Point(132, 15);
            this.TEXT_SIGMA.Name = "TEXT_SIGMA";
            this.TEXT_SIGMA.Size = new System.Drawing.Size(100, 23);
            this.TEXT_SIGMA.TabIndex = 3;
            this.TEXT_SIGMA.Text = "0,05";
            // 
            // TEXT_K
            // 
            this.TEXT_K.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TEXT_K.Location = new System.Drawing.Point(312, 15);
            this.TEXT_K.Name = "TEXT_K";
            this.TEXT_K.Size = new System.Drawing.Size(100, 23);
            this.TEXT_K.TabIndex = 4;
            this.TEXT_K.Text = "0,01";
            // 
            // TEXT_V
            // 
            this.TEXT_V.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TEXT_V.Location = new System.Drawing.Point(486, 15);
            this.TEXT_V.Name = "TEXT_V";
            this.TEXT_V.Size = new System.Drawing.Size(100, 23);
            this.TEXT_V.TabIndex = 5;
            this.TEXT_V.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(67, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sigma";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(260, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "k";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(434, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "V";
            // 
            // YAMA
            // 
            this.YAMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.YAMA.Location = new System.Drawing.Point(132, 53);
            this.YAMA.Name = "YAMA";
            this.YAMA.Size = new System.Drawing.Size(100, 23);
            this.YAMA.TabIndex = 10;
            this.YAMA.Text = "30";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(55, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Size yama";
            // 
            // DRAW
            // 
            this.DRAW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DRAW.Location = new System.Drawing.Point(988, 18);
            this.DRAW.Name = "DRAW";
            this.DRAW.Size = new System.Drawing.Size(114, 42);
            this.DRAW.TabIndex = 12;
            this.DRAW.Text = "DRAW";
            this.DRAW.UseVisualStyleBackColor = true;
            this.DRAW.Click += new System.EventHandler(this.DRAW_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(659, 408);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox2.Location = new System.Drawing.Point(691, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(659, 408);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox4.Location = new System.Drawing.Point(761, 53);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 23);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox2.Location = new System.Drawing.Point(761, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Yellow;
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.DRAW);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.YAMA);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TEXT_V);
            this.groupBox1.Controls.Add(this.TEXT_K);
            this.groupBox1.Controls.Add(this.TEXT_SIGMA);
            this.groupBox1.Location = new System.Drawing.Point(81, 423);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1124, 88);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1361, 523);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox TEXT_SIGMA;
        private System.Windows.Forms.TextBox TEXT_K;
        private System.Windows.Forms.TextBox TEXT_V;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox YAMA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button DRAW;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

