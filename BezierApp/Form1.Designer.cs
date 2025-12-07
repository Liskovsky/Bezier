using BezierApp;

namespace BezierApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            button = new Button();
            buttonZ = new Button();
            buttonDZ = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BackColor = SystemColors.Control;
            pictureBox.Location = new Point(12, 12);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(776, 372);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // button
            // 
            button.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point);
            button.Location = new Point(12, 399);
            button.Name = "button";
            button.Size = new Size(224, 39);
            button.TabIndex = 1;
            button.Text = "Bézierova křivka VS";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // buttonZ
            // 
            buttonZ.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonZ.Location = new Point(549, 399);
            buttonZ.Name = "buttonZ";
            buttonZ.Size = new Size(239, 39);
            buttonZ.TabIndex = 2;
            buttonZ.Text = "Lineární úsečka bodů";
            buttonZ.UseVisualStyleBackColor = true;
            buttonZ.Visible = false;
            buttonZ.Click += buttonZ_Click;
            // 
            // buttonDZ
            // 
            buttonDZ.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDZ.Location = new Point(255, 399);
            buttonDZ.Name = "buttonDZ";
            buttonDZ.Size = new Size(219, 39);
            buttonDZ.TabIndex = 3;
            buttonDZ.Text = "Bezier dle zadání";
            buttonDZ.UseVisualStyleBackColor = true;
            buttonDZ.Click += buttonDZ_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonDZ);
            Controls.Add(buttonZ);
            Controls.Add(button);
            Controls.Add(pictureBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
        private Button button;
        private Button buttonZ;
        private Button buttonDZ;
    }
}