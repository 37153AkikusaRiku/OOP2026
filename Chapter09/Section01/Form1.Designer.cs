namespace Section01 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            dtpDate = new DateTimePicker();
            getBtn = new Button();
            outTb = new TextBox();
            nextDay = new NumericUpDown();
            label1 = new Label();
            dtp2 = new DateTimePicker();
            getBtn2 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            tb3 = new TextBox();
            label4 = new Label();
            tb4 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)nextDay).BeginInit();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(12, 28);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(253, 50);
            dtpDate.TabIndex = 0;
            dtpDate.ValueChanged += DateTimePicker1_ValueChanged;
            // 
            // getBtn
            // 
            getBtn.Location = new Point(762, 47);
            getBtn.Name = "getBtn";
            getBtn.Size = new Size(166, 71);
            getBtn.TabIndex = 1;
            getBtn.Text = "計算";
            getBtn.UseVisualStyleBackColor = true;
            getBtn.Click += getBtn_Click;
            // 
            // outTb
            // 
            outTb.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            outTb.Location = new Point(13, 124);
            outTb.Name = "outTb";
            outTb.Size = new Size(253, 39);
            outTb.TabIndex = 2;
            // 
            // nextDay
            // 
            nextDay.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nextDay.Location = new Point(12, 222);
            nextDay.Name = "nextDay";
            nextDay.Size = new Size(182, 39);
            nextDay.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(200, 231);
            label1.Name = "label1";
            label1.Size = new Size(55, 30);
            label1.TabIndex = 4;
            label1.Text = "日後";
            // 
            // dtp2
            // 
            dtp2.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtp2.Location = new Point(364, 68);
            dtp2.Name = "dtp2";
            dtp2.Size = new Size(254, 50);
            dtp2.TabIndex = 5;
            // 
            // getBtn2
            // 
            getBtn2.Location = new Point(762, 156);
            getBtn2.Name = "getBtn2";
            getBtn2.Size = new Size(168, 71);
            getBtn2.TabIndex = 6;
            getBtn2.Text = "計算";
            getBtn2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            textBox1.Location = new Point(12, 177);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(253, 39);
            textBox1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(269, 186);
            label2.Name = "label2";
            label2.Size = new Size(97, 30);
            label2.TabIndex = 4;
            label2.Text = "経過日数";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(269, 133);
            label3.Name = "label3";
            label3.Size = new Size(55, 30);
            label3.TabIndex = 4;
            label3.Text = "年齢";
            // 
            // tb3
            // 
            tb3.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tb3.Location = new Point(12, 299);
            tb3.Name = "tb3";
            tb3.Size = new Size(775, 39);
            tb3.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(13, 266);
            label4.Name = "label4";
            label4.Size = new Size(44, 30);
            label4.TabIndex = 4;
            label4.Text = "メモ";
            // 
            // tb4
            // 
            tb4.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tb4.Location = new Point(13, 398);
            tb4.Name = "tb4";
            tb4.Size = new Size(775, 39);
            tb4.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.Location = new Point(12, 353);
            label5.Name = "label5";
            label5.Size = new Size(147, 30);
            label5.TabIndex = 4;
            label5.Text = "次の誕生日まで";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.Location = new Point(269, 28);
            label6.Name = "label6";
            label6.Size = new Size(114, 30);
            label6.TabIndex = 4;
            label6.Text = "今日の日付";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label7.Location = new Point(624, 68);
            label7.Name = "label7";
            label7.Size = new Size(76, 30);
            label7.TabIndex = 4;
            label7.Text = "誕生日";
            // 
            // Form1
            // 
            ClientSize = new Size(978, 579);
            Controls.Add(tb4);
            Controls.Add(tb3);
            Controls.Add(textBox1);
            Controls.Add(getBtn2);
            Controls.Add(dtp2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(nextDay);
            Controls.Add(outTb);
            Controls.Add(getBtn);
            Controls.Add(dtpDate);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)nextDay).EndInit();
            ResumeLayout(false);
            PerformLayout();


            #endregion


        }
        private DateTimePicker dtpDate;
        private Button getBtn;
        private TextBox outTb;
        private NumericUpDown nextDay;
        private Label label1;
        private DateTimePicker dtp2;
        private Button getBtn2;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private TextBox tb3;
        private Label label4;
        private TextBox tb4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}
