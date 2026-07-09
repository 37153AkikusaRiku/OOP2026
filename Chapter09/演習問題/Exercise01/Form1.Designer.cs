namespace Exercise01 {
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
            button1 = new Button();
            button2 = new Button();
            outputBt2 = new Button();
            outputBt1 = new Button();
            outputBt3 = new Button();
            outputTextBox1 = new TextBox();
            outputTextBox2 = new TextBox();
            outputTextBox3 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(44, 162);
            button1.Name = "button1";
            button1.Size = new Size(164, 62);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(44, 44);
            button2.Name = "button2";
            button2.Size = new Size(164, 62);
            button2.TabIndex = 0;
            button2.Text = "button1";
            button2.UseVisualStyleBackColor = true;
            // 
            // outputBt2
            // 
            outputBt2.Location = new Point(44, 162);
            outputBt2.Name = "outputBt2";
            outputBt2.Size = new Size(164, 62);
            outputBt2.TabIndex = 0;
            outputBt2.Text = "button1";
            outputBt2.UseVisualStyleBackColor = true;
            outputBt2.Click += outputBt2_Click;
            // 
            // outputBt1
            // 
            outputBt1.Location = new Point(44, 44);
            outputBt1.Name = "outputBt1";
            outputBt1.Size = new Size(164, 62);
            outputBt1.TabIndex = 0;
            outputBt1.Text = "button1";
            outputBt1.UseVisualStyleBackColor = true;
            outputBt1.Click += button4_Click;
            // 
            // outputBt3
            // 
            outputBt3.Location = new Point(44, 290);
            outputBt3.Name = "outputBt3";
            outputBt3.Size = new Size(164, 62);
            outputBt3.TabIndex = 0;
            outputBt3.Text = "button1";
            outputBt3.UseVisualStyleBackColor = true;
            outputBt3.Click += outputBt3_Click;
            // 
            // outputTextBox1
            // 
            outputTextBox1.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 128);
            outputTextBox1.Location = new Point(251, 56);
            outputTextBox1.Name = "outputTextBox1";
            outputTextBox1.Size = new Size(467, 50);
            outputTextBox1.TabIndex = 1;
            // 
            // outputTextBox2
            // 
            outputTextBox2.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 128);
            outputTextBox2.Location = new Point(251, 174);
            outputTextBox2.Name = "outputTextBox2";
            outputTextBox2.Size = new Size(467, 50);
            outputTextBox2.TabIndex = 1;
            // 
            // outputTextBox3
            // 
            outputTextBox3.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 128);
            outputTextBox3.Location = new Point(251, 302);
            outputTextBox3.Name = "outputTextBox3";
            outputTextBox3.Size = new Size(467, 50);
            outputTextBox3.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(outputTextBox3);
            Controls.Add(outputTextBox2);
            Controls.Add(outputTextBox1);
            Controls.Add(outputBt1);
            Controls.Add(outputBt3);
            Controls.Add(outputBt2);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button outputBt2;
        private Button outputBt1;
        private Button outputBt3;
        private TextBox outputTextBox1;
        private TextBox outputTextBox2;
        private TextBox outputTextBox3;
    }
}
