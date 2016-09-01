namespace Gravity
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
            this.components = new System.ComponentModel.Container();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblMouseY = new System.Windows.Forms.Label();
            this.lblMouseX = new System.Windows.Forms.Label();
            this.tmrMouseCoords = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCountBad = new System.Windows.Forms.Label();
            this.lblCountGood = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRandX = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.SuspendLayout();
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(90, 85);
            this.pb1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(792, 1050);
            this.pb1.TabIndex = 0;
            this.pb1.TabStop = false;
            this.pb1.Click += new System.EventHandler(this.pb1_Click);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 10;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "X: ";
            this.label2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb1_Click);
            // 
            // lblMouseY
            // 
            this.lblMouseY.AutoSize = true;
            this.lblMouseY.BackColor = System.Drawing.Color.Black;
            this.lblMouseY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblMouseY.ForeColor = System.Drawing.Color.Purple;
            this.lblMouseY.Location = new System.Drawing.Point(56, 63);
            this.lblMouseY.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMouseY.Name = "lblMouseY";
            this.lblMouseY.Size = new System.Drawing.Size(41, 44);
            this.lblMouseY.TabIndex = 1;
            this.lblMouseY.Text = "0";
            this.lblMouseY.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb1_Click);
            // 
            // lblMouseX
            // 
            this.lblMouseX.AutoSize = true;
            this.lblMouseX.BackColor = System.Drawing.Color.Black;
            this.lblMouseX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblMouseX.ForeColor = System.Drawing.Color.Purple;
            this.lblMouseX.Location = new System.Drawing.Point(56, 17);
            this.lblMouseX.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMouseX.Name = "lblMouseX";
            this.lblMouseX.Size = new System.Drawing.Size(41, 44);
            this.lblMouseX.TabIndex = 1;
            this.lblMouseX.Text = "0";
            this.lblMouseX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb1_Click);
            // 
            // tmrMouseCoords
            // 
            this.tmrMouseCoords.Interval = 10;
            this.tmrMouseCoords.Tick += new System.EventHandler(this.tmrMouseCoords_Tick);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(10, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 46);
            this.label3.TabIndex = 1;
            this.label3.Text = "X: ";
            this.label3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(834, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Good:";
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb1_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.ForeColor = System.Drawing.Color.Purple;
            this.label4.Location = new System.Drawing.Point(834, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 46);
            this.label4.TabIndex = 1;
            this.label4.Text = "Bad:";
            this.label4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb1_Click);
            // 
            // lblCountBad
            // 
            this.lblCountBad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountBad.AutoSize = true;
            this.lblCountBad.BackColor = System.Drawing.Color.Black;
            this.lblCountBad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblCountBad.ForeColor = System.Drawing.Color.Purple;
            this.lblCountBad.Location = new System.Drawing.Point(948, 63);
            this.lblCountBad.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCountBad.Name = "lblCountBad";
            this.lblCountBad.Size = new System.Drawing.Size(41, 44);
            this.lblCountBad.TabIndex = 1;
            this.lblCountBad.Text = "0";
            this.lblCountBad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb1_Click);
            // 
            // lblCountGood
            // 
            this.lblCountGood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountGood.AutoSize = true;
            this.lblCountGood.BackColor = System.Drawing.Color.Black;
            this.lblCountGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblCountGood.ForeColor = System.Drawing.Color.Purple;
            this.lblCountGood.Location = new System.Drawing.Point(948, 17);
            this.lblCountGood.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCountGood.Name = "lblCountGood";
            this.lblCountGood.Size = new System.Drawing.Size(41, 44);
            this.lblCountGood.TabIndex = 1;
            this.lblCountGood.Text = "0";
            this.lblCountGood.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb1_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.ForeColor = System.Drawing.Color.Purple;
            this.label5.Location = new System.Drawing.Point(834, 137);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 46);
            this.label5.TabIndex = 1;
            this.label5.Text = "Rx: ";
            this.label5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb1_Click);
            // 
            // lblRandX
            // 
            this.lblRandX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRandX.AutoSize = true;
            this.lblRandX.BackColor = System.Drawing.Color.Black;
            this.lblRandX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblRandX.ForeColor = System.Drawing.Color.Purple;
            this.lblRandX.Location = new System.Drawing.Point(908, 137);
            this.lblRandX.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRandX.Name = "lblRandX";
            this.lblRandX.Size = new System.Drawing.Size(41, 44);
            this.lblRandX.TabIndex = 1;
            this.lblRandX.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 1229);
            this.Controls.Add(this.lblCountGood);
            this.Controls.Add(this.lblMouseX);
            this.Controls.Add(this.lblRandX);
            this.Controls.Add(this.lblCountBad);
            this.Controls.Add(this.lblMouseY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pb1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMouseY;
        private System.Windows.Forms.Label lblMouseX;
        private System.Windows.Forms.Timer tmrMouseCoords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCountBad;
        private System.Windows.Forms.Label lblCountGood;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRandX;
    }
}

