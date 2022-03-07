
namespace Testing
{
    partial class MS
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
            this.gameBox = new System.Windows.Forms.GroupBox();
            this.xLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.testLabel = new System.Windows.Forms.Label();
            this.settingsBox = new System.Windows.Forms.GroupBox();
            this.settingsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameBox
            // 
            this.gameBox.Location = new System.Drawing.Point(12, 12);
            this.gameBox.Name = "gameBox";
            this.gameBox.Size = new System.Drawing.Size(592, 426);
            this.gameBox.TabIndex = 0;
            this.gameBox.TabStop = false;
            // 
            // xLength
            // 
            this.xLength.Location = new System.Drawing.Point(26, 32);
            this.xLength.Name = "xLength";
            this.xLength.Size = new System.Drawing.Size(29, 20);
            this.xLength.TabIndex = 1;
            this.xLength.Text = "10";
            this.xLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.xLength_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Grid Size";
            // 
            // yLength
            // 
            this.yLength.Location = new System.Drawing.Point(79, 32);
            this.yLength.Name = "yLength";
            this.yLength.Size = new System.Drawing.Size(29, 20);
            this.yLength.TabIndex = 3;
            this.yLength.Text = "10";
            this.yLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.xLength_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "x";
            // 
            // refreshBtn
            // 
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refreshBtn.Location = new System.Drawing.Point(26, 59);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(82, 23);
            this.refreshBtn.TabIndex = 5;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // testLabel
            // 
            this.testLabel.AutoSize = true;
            this.testLabel.Location = new System.Drawing.Point(667, 116);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(0, 13);
            this.testLabel.TabIndex = 7;
            // 
            // settingsBox
            // 
            this.settingsBox.Controls.Add(this.label1);
            this.settingsBox.Controls.Add(this.xLength);
            this.settingsBox.Controls.Add(this.refreshBtn);
            this.settingsBox.Controls.Add(this.yLength);
            this.settingsBox.Controls.Add(this.label2);
            this.settingsBox.Location = new System.Drawing.Point(610, 13);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.Size = new System.Drawing.Size(127, 100);
            this.settingsBox.TabIndex = 8;
            this.settingsBox.TabStop = false;
            // 
            // MS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 449);
            this.Controls.Add(this.settingsBox);
            this.Controls.Add(this.testLabel);
            this.Controls.Add(this.gameBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MS";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MS_FormClosing);
            this.settingsBox.ResumeLayout(false);
            this.settingsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gameBox;
        private System.Windows.Forms.TextBox xLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox yLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Label testLabel;
        private System.Windows.Forms.GroupBox settingsBox;
    }
}