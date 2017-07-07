namespace _3DEngine
{
    partial class Form1
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
            this.picBoxCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxCanvas
            // 
            this.picBoxCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxCanvas.Location = new System.Drawing.Point(0, 0);
            this.picBoxCanvas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBoxCanvas.Name = "picBoxCanvas";
            this.picBoxCanvas.Size = new System.Drawing.Size(513, 436);
            this.picBoxCanvas.TabIndex = 0;
            this.picBoxCanvas.TabStop = false;
            this.picBoxCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoxCanvas_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 436);
            this.Controls.Add(this.picBoxCanvas);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxCanvas;
    }
}

