namespace Андрей
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label10 = new Label();
            label9 = new Label();
            comboBox1 = new ComboBox();
            button3 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel4 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 192, 128);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(845, 44);
            panel1.TabIndex = 4;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(570, 12);
            label10.Name = "label10";
            label10.Size = new Size(32, 17);
            label10.TabIndex = 21;
            label10.Text = "\" / \"";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Comic Sans MS", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(329, 10);
            label9.Name = "label9";
            label9.Size = new Size(108, 19);
            label9.TabIndex = 13;
            label9.Text = "Фильтр скидки";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Все диапазоны", "0-9,99% ", "10-14,99% ", "15% и более" });
            comboBox1.Location = new Point(443, 8);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 12;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 128, 0);
            button3.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(733, 8);
            button3.Name = "button3";
            button3.Size = new Size(100, 23);
            button3.TabIndex = 11;
            button3.Text = "К заказу";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 128, 0);
            button2.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(627, 8);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 10;
            button2.Text = "Добавить";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(161, 8);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(139, 23);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 10);
            label4.Name = "label4";
            label4.Size = new Size(143, 19);
            label4.TabIndex = 8;
            label4.Text = "Поиск по названию";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(138, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 192, 128);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 304);
            panel2.Name = "panel2";
            panel2.Size = new Size(845, 146);
            panel2.TabIndex = 5;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(label1);
            panel4.Location = new Point(598, 24);
            panel4.Name = "panel4";
            panel4.Size = new Size(116, 103);
            panel4.TabIndex = 21;
            panel4.Paint += panel4_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(34, 35);
            label1.Name = "label1";
            label1.Size = new Size(44, 19);
            label1.TabIndex = 13;
            label1.Text = "Label";
            label1.Click += label1_Click;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(264, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(328, 120);
            panel3.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(6, 17);
            label6.Name = "label6";
            label6.Size = new Size(37, 17);
            label6.TabIndex = 18;
            label6.Text = "Label";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(112, 70);
            label7.Name = "label7";
            label7.Size = new Size(37, 17);
            label7.TabIndex = 19;
            label7.Text = "Label";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(112, 99);
            label8.Name = "label8";
            label8.Size = new Size(37, 17);
            label8.TabIndex = 20;
            label8.Text = "Label";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(112, 17);
            label2.TabIndex = 15;
            label2.Text = "Описание товара:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 70);
            label3.Name = "label3";
            label3.Size = new Size(103, 17);
            label3.TabIndex = 16;
            label3.Text = "Производитель:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(3, 96);
            label5.Name = "label5";
            label5.Size = new Size(40, 17);
            label5.TabIndex = 17;
            label5.Text = "Цена:";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 128, 0);
            button1.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(0, 123);
            button1.Name = "button1";
            button1.Size = new Size(72, 23);
            button1.TabIndex = 9;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(845, 260);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.Paint += dataGridView1_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 450);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Button button1;
        private Button button3;
        private Button button2;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Panel panel3;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label1;
        private Panel panel4;
        private DataGridView dataGridView1;
        private Label label10;
        private Label label9;
    }
}