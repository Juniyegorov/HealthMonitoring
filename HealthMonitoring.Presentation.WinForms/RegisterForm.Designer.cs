
namespace HealthMonitoring.Presentation.WinForms
{
    partial class RegisterForm
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
            this._mainPanel = new System.Windows.Forms.Panel();
            this._authorisationLabel = new System.Windows.Forms.Label();
            this._registerButton = new System.Windows.Forms.Button();
            this._passField = new System.Windows.Forms.TextBox();
            this._passwordPictureBox = new System.Windows.Forms.PictureBox();
            this._loginField = new System.Windows.Forms.TextBox();
            this._loginPictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this._closeButton = new System.Windows.Forms.Label();
            this._topLabel = new System.Windows.Forms.Label();
            this._mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._passwordPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._loginPictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainPanel
            // 
            this._mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(194)))), ((int)(((byte)(60)))));
            this._mainPanel.Controls.Add(this._authorisationLabel);
            this._mainPanel.Controls.Add(this._registerButton);
            this._mainPanel.Controls.Add(this._passField);
            this._mainPanel.Controls.Add(this._passwordPictureBox);
            this._mainPanel.Controls.Add(this._loginField);
            this._mainPanel.Controls.Add(this._loginPictureBox);
            this._mainPanel.Controls.Add(this.panel2);
            this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPanel.Location = new System.Drawing.Point(0, 0);
            this._mainPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.Size = new System.Drawing.Size(468, 472);
            this._mainPanel.TabIndex = 1;
            // 
            // _authorisationLabel
            // 
            this._authorisationLabel.AutoSize = true;
            this._authorisationLabel.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this._authorisationLabel.ForeColor = System.Drawing.Color.Blue;
            this._authorisationLabel.Location = new System.Drawing.Point(202, 421);
            this._authorisationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._authorisationLabel.Name = "_authorisationLabel";
            this._authorisationLabel.Size = new System.Drawing.Size(99, 35);
            this._authorisationLabel.TabIndex = 7;
            this._authorisationLabel.Text = "Authorization";
            this._authorisationLabel.Click += new System.EventHandler(this.authorisationLabel_Click);
            // 
            // _registerButton
            // 
            this._registerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(153)))), ((int)(((byte)(5)))));
            this._registerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this._registerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(25)))), ((int)(((byte)(150)))));
            this._registerButton.FlatAppearance.BorderSize = 0;
            this._registerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(87)))), ((int)(((byte)(21)))));
            this._registerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(214)))), ((int)(((byte)(7)))));
            this._registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._registerButton.Font = new System.Drawing.Font("Gabriola", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._registerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(25)))), ((int)(((byte)(150)))));
            this._registerButton.Location = new System.Drawing.Point(219, 337);
            this._registerButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._registerButton.Name = "_registerButton";
            this._registerButton.Size = new System.Drawing.Size(92, 54);
            this._registerButton.TabIndex = 5;
            this._registerButton.Text = "Register";
            this._registerButton.UseVisualStyleBackColor = false;
            this._registerButton.Click += new System.EventHandler(this.register_Click);
            // 
            // _passField
            // 
            this._passField.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this._passField.Location = new System.Drawing.Point(105, 275);
            this._passField.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._passField.Name = "_passField";
            this._passField.PasswordChar = '*';
            this._passField.Size = new System.Drawing.Size(338, 35);
            this._passField.TabIndex = 4;
            this._passField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passField_KeyDown);
            // 
            // _passwordPictureBox
            // 
            this._passwordPictureBox.Image = global::HealthMonitoring.Presentation.WinForms.Properties.Resources.Lock;
            this._passwordPictureBox.Location = new System.Drawing.Point(18, 268);
            this._passwordPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._passwordPictureBox.Name = "_passwordPictureBox";
            this._passwordPictureBox.Size = new System.Drawing.Size(63, 62);
            this._passwordPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._passwordPictureBox.TabIndex = 3;
            this._passwordPictureBox.TabStop = false;
            // 
            // _loginField
            // 
            this._loginField.Font = new System.Drawing.Font("Gabriola", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this._loginField.Location = new System.Drawing.Point(105, 192);
            this._loginField.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._loginField.Multiline = true;
            this._loginField.Name = "_loginField";
            this._loginField.Size = new System.Drawing.Size(338, 48);
            this._loginField.TabIndex = 2;
            // 
            // _loginPictureBox
            // 
            this._loginPictureBox.Image = global::HealthMonitoring.Presentation.WinForms.Properties.Resources.User;
            this._loginPictureBox.Location = new System.Drawing.Point(18, 178);
            this._loginPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._loginPictureBox.Name = "_loginPictureBox";
            this._loginPictureBox.Size = new System.Drawing.Size(63, 62);
            this._loginPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._loginPictureBox.TabIndex = 1;
            this._loginPictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(43)))), ((int)(((byte)(191)))));
            this.panel2.Controls.Add(this._closeButton);
            this.panel2.Controls.Add(this._topLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 115);
            this.panel2.TabIndex = 0;
            // 
            // _closeButton
            // 
            this._closeButton.AutoSize = true;
            this._closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this._closeButton.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this._closeButton.ForeColor = System.Drawing.Color.White;
            this._closeButton.Location = new System.Drawing.Point(430, 0);
            this._closeButton.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(32, 45);
            this._closeButton.TabIndex = 1;
            this._closeButton.Text = "X";
            this._closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // _topLabel
            // 
            this._topLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._topLabel.Font = new System.Drawing.Font("Gabriola", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this._topLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(153)))), ((int)(((byte)(5)))));
            this._topLabel.Location = new System.Drawing.Point(0, 0);
            this._topLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._topLabel.Name = "_topLabel";
            this._topLabel.Size = new System.Drawing.Size(468, 115);
            this._topLabel.TabIndex = 0;
            this._topLabel.Text = "Registration";
            this._topLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._topLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topLabel_MouseDown);
            this._topLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topLabel_MouseMove);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 472);
            this.Controls.Add(this._mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this._mainPanel.ResumeLayout(false);
            this._mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._passwordPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._loginPictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _mainPanel;
        private System.Windows.Forms.Button _registerButton;
        private System.Windows.Forms.TextBox _passField;
        private System.Windows.Forms.PictureBox _passwordPictureBox;
        private System.Windows.Forms.TextBox _loginField;
        private System.Windows.Forms.PictureBox _loginPictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label _closeButton;
        private System.Windows.Forms.Label _topLabel;
        private System.Windows.Forms.Label _authorisationLabel;
    }
}