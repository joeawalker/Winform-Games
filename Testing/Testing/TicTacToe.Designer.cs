
namespace Testing
{
    partial class TicTacToe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicTacToe));
            this.tile1 = new System.Windows.Forms.Button();
            this.tile2 = new System.Windows.Forms.Button();
            this.tile4 = new System.Windows.Forms.Button();
            this.tile5 = new System.Windows.Forms.Button();
            this.tile3 = new System.Windows.Forms.Button();
            this.tile6 = new System.Windows.Forms.Button();
            this.tile7 = new System.Windows.Forms.Button();
            this.tile8 = new System.Windows.Forms.Button();
            this.tile9 = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.tileBox = new System.Windows.Forms.GroupBox();
            this.Score = new System.Windows.Forms.Label();
            this.tileBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tile1
            // 
            this.tile1.Location = new System.Drawing.Point(15, 19);
            this.tile1.Name = "tile1";
            this.tile1.Size = new System.Drawing.Size(96, 96);
            this.tile1.TabIndex = 0;
            this.tile1.UseVisualStyleBackColor = true;
            this.tile1.Click += new System.EventHandler(this.tile1_Click);
            // 
            // tile2
            // 
            this.tile2.Location = new System.Drawing.Point(117, 19);
            this.tile2.Name = "tile2";
            this.tile2.Size = new System.Drawing.Size(96, 96);
            this.tile2.TabIndex = 1;
            this.tile2.UseVisualStyleBackColor = true;
            this.tile2.Click += new System.EventHandler(this.tile2_Click);
            // 
            // tile4
            // 
            this.tile4.Location = new System.Drawing.Point(15, 121);
            this.tile4.Name = "tile4";
            this.tile4.Size = new System.Drawing.Size(96, 96);
            this.tile4.TabIndex = 2;
            this.tile4.UseVisualStyleBackColor = true;
            this.tile4.Click += new System.EventHandler(this.tile4_Click);
            // 
            // tile5
            // 
            this.tile5.Location = new System.Drawing.Point(117, 121);
            this.tile5.Name = "tile5";
            this.tile5.Size = new System.Drawing.Size(96, 96);
            this.tile5.TabIndex = 3;
            this.tile5.UseVisualStyleBackColor = true;
            this.tile5.Click += new System.EventHandler(this.tile5_Click);
            // 
            // tile3
            // 
            this.tile3.Location = new System.Drawing.Point(219, 19);
            this.tile3.Name = "tile3";
            this.tile3.Size = new System.Drawing.Size(96, 96);
            this.tile3.TabIndex = 4;
            this.tile3.UseVisualStyleBackColor = true;
            this.tile3.Click += new System.EventHandler(this.tile3_Click);
            // 
            // tile6
            // 
            this.tile6.Location = new System.Drawing.Point(219, 121);
            this.tile6.Name = "tile6";
            this.tile6.Size = new System.Drawing.Size(96, 96);
            this.tile6.TabIndex = 5;
            this.tile6.UseVisualStyleBackColor = true;
            this.tile6.Click += new System.EventHandler(this.tile6_Click);
            // 
            // tile7
            // 
            this.tile7.Location = new System.Drawing.Point(15, 223);
            this.tile7.Name = "tile7";
            this.tile7.Size = new System.Drawing.Size(96, 96);
            this.tile7.TabIndex = 6;
            this.tile7.UseVisualStyleBackColor = true;
            this.tile7.Click += new System.EventHandler(this.tile7_Click);
            // 
            // tile8
            // 
            this.tile8.Location = new System.Drawing.Point(117, 223);
            this.tile8.Name = "tile8";
            this.tile8.Size = new System.Drawing.Size(96, 96);
            this.tile8.TabIndex = 7;
            this.tile8.UseVisualStyleBackColor = true;
            this.tile8.Click += new System.EventHandler(this.tile8_Click);
            // 
            // tile9
            // 
            this.tile9.Location = new System.Drawing.Point(219, 223);
            this.tile9.Name = "tile9";
            this.tile9.Size = new System.Drawing.Size(96, 96);
            this.tile9.TabIndex = 8;
            this.tile9.UseVisualStyleBackColor = true;
            this.tile9.Click += new System.EventHandler(this.tile9_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(243, 353);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 23);
            this.resetBtn.TabIndex = 9;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // tileBox
            // 
            this.tileBox.Controls.Add(this.tile1);
            this.tileBox.Controls.Add(this.tile2);
            this.tileBox.Controls.Add(this.tile9);
            this.tileBox.Controls.Add(this.tile4);
            this.tileBox.Controls.Add(this.tile8);
            this.tileBox.Controls.Add(this.tile5);
            this.tileBox.Controls.Add(this.tile7);
            this.tileBox.Controls.Add(this.tile3);
            this.tileBox.Controls.Add(this.tile6);
            this.tileBox.Location = new System.Drawing.Point(12, 12);
            this.tileBox.Name = "tileBox";
            this.tileBox.Size = new System.Drawing.Size(330, 333);
            this.tileBox.TabIndex = 10;
            this.tileBox.TabStop = false;
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Location = new System.Drawing.Point(27, 362);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(40, 13);
            this.Score.TabIndex = 11;
            this.Score.Text = "X:    O:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 384);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.tileBox);
            this.Controls.Add(this.resetBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tic Tac Toe";
            this.tileBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tile1;
        private System.Windows.Forms.Button tile2;
        private System.Windows.Forms.Button tile4;
        private System.Windows.Forms.Button tile5;
        private System.Windows.Forms.Button tile3;
        private System.Windows.Forms.Button tile6;
        private System.Windows.Forms.Button tile7;
        private System.Windows.Forms.Button tile8;
        private System.Windows.Forms.Button tile9;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.GroupBox tileBox;
        private System.Windows.Forms.Label Score;
    }
}

