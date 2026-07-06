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
            ((System.ComponentModel.ISupportInitialize)nextDay).BeginInit();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(12, 12);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(253, 50);
            dtpDate.TabIndex = 0;
            dtpDate.ValueChanged += DateTimePicker1_ValueChanged;
            // 
            // getBtn
            // 
            getBtn.Location = new Point(12, 221);
            getBtn.Name = "getBtn";
            getBtn.Size = new Size(166, 71);
            getBtn.TabIndex = 1;
            getBtn.Text = "計算";
            getBtn.UseVisualStyleBackColor = true;
            getBtn.Click += getBtn_Click;
            // 
            // outTb
            // 
            outTb.Location = new Point(12, 119);
            outTb.Name = "outTb";
            outTb.Size = new Size(253, 23);
            outTb.TabIndex = 2;
            // 
            // nextDay
            // 
            nextDay.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nextDay.Location = new Point(12, 158);
            nextDay.Name = "nextDay";
            nextDay.Size = new Size(182, 39);
            nextDay.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(200, 167);
            label1.Name = "label1";
            label1.Size = new Size(55, 30);
            label1.TabIndex = 4;
            label1.Text = "日後";
            // 
            // Form1
            // 
            ClientSize = new Size(978, 579);
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
    }
}
