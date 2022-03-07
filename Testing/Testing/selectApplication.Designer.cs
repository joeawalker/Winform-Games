
namespace Testing
{
    partial class selectApplication
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
            this.TicTacToeBtn = new System.Windows.Forms.RadioButton();
            this.chessBtn = new System.Windows.Forms.RadioButton();
            this.launchBtn = new System.Windows.Forms.Button();
            this.MSbtn = new System.Windows.Forms.RadioButton();
            this.wordleBtn = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // TicTacToeBtn
            // 
            this.TicTacToeBtn.AutoSize = true;
            this.TicTacToeBtn.Location = new System.Drawing.Point(33, 42);
            this.TicTacToeBtn.Name = "TicTacToeBtn";
            this.TicTacToeBtn.Size = new System.Drawing.Size(46, 17);
            this.TicTacToeBtn.TabIndex = 0;
            this.TicTacToeBtn.TabStop = true;
            this.TicTacToeBtn.Text = "TTT";
            this.TicTacToeBtn.UseVisualStyleBackColor = true;
            // 
            // chessBtn
            // 
            this.chessBtn.AutoSize = true;
            this.chessBtn.Location = new System.Drawing.Point(33, 81);
            this.chessBtn.Name = "chessBtn";
            this.chessBtn.Size = new System.Drawing.Size(40, 17);
            this.chessBtn.TabIndex = 1;
            this.chessBtn.TabStop = true;
            this.chessBtn.Text = "CH";
            this.chessBtn.UseVisualStyleBackColor = true;
            // 
            // launchBtn
            // 
            this.launchBtn.Location = new System.Drawing.Point(149, 145);
            this.launchBtn.Name = "launchBtn";
            this.launchBtn.Size = new System.Drawing.Size(75, 23);
            this.launchBtn.TabIndex = 2;
            this.launchBtn.Text = "Launch";
            this.launchBtn.UseVisualStyleBackColor = true;
            this.launchBtn.Click += new System.EventHandler(this.launchBtn_Click);
            // 
            // MSbtn
            // 
            this.MSbtn.AutoSize = true;
            this.MSbtn.Location = new System.Drawing.Point(241, 42);
            this.MSbtn.Name = "MSbtn";
            this.MSbtn.Size = new System.Drawing.Size(41, 17);
            this.MSbtn.TabIndex = 3;
            this.MSbtn.TabStop = true;
            this.MSbtn.Text = "MS";
            this.MSbtn.UseVisualStyleBackColor = true;
            // 
            // wordleBtn
            // 
            this.wordleBtn.AutoSize = true;
            this.wordleBtn.Location = new System.Drawing.Point(241, 81);
            this.wordleBtn.Name = "wordleBtn";
            this.wordleBtn.Size = new System.Drawing.Size(36, 17);
            this.wordleBtn.TabIndex = 4;
            this.wordleBtn.TabStop = true;
            this.wordleBtn.Text = "W";
            this.wordleBtn.UseVisualStyleBackColor = true;
            // 
            // selectApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 180);
            this.Controls.Add(this.wordleBtn);
            this.Controls.Add(this.MSbtn);
            this.Controls.Add(this.launchBtn);
            this.Controls.Add(this.chessBtn);
            this.Controls.Add(this.TicTacToeBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "selectApplication";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "selectApplication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton TicTacToeBtn;
        private System.Windows.Forms.RadioButton chessBtn;
        private System.Windows.Forms.Button launchBtn;
        private System.Windows.Forms.RadioButton MSbtn;
        private System.Windows.Forms.RadioButton wordleBtn;
    }
}