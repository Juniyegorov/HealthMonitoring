
namespace HealthMonitoring.Presentation.WinForms
{
    partial class SetPersonalIngormation
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
            this._growthLabel = new System.Windows.Forms.Label();
            this._weightLabel = new System.Windows.Forms.Label();
            this._surnameLabel = new System.Windows.Forms.Label();
            this._nameLabel = new System.Windows.Forms.Label();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._surnameTextBox = new System.Windows.Forms.TextBox();
            this._weightTextBox = new System.Windows.Forms.TextBox();
            this._growthTextBox = new System.Windows.Forms.TextBox();
            this._saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _growthLabel
            // 
            this._growthLabel.AutoSize = true;
            this._growthLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this._growthLabel.Location = new System.Drawing.Point(12, 87);
            this._growthLabel.Name = "_growthLabel";
            this._growthLabel.Size = new System.Drawing.Size(63, 19);
            this._growthLabel.TabIndex = 8;
            this._growthLabel.Text = "Growth:";
            // 
            // _weightLabel
            // 
            this._weightLabel.AutoSize = true;
            this._weightLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this._weightLabel.Location = new System.Drawing.Point(12, 61);
            this._weightLabel.Name = "_weightLabel";
            this._weightLabel.Size = new System.Drawing.Size(59, 19);
            this._weightLabel.TabIndex = 7;
            this._weightLabel.Text = "Weight:";
            // 
            // _surnameLabel
            // 
            this._surnameLabel.AutoSize = true;
            this._surnameLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this._surnameLabel.Location = new System.Drawing.Point(12, 34);
            this._surnameLabel.Name = "_surnameLabel";
            this._surnameLabel.Size = new System.Drawing.Size(74, 19);
            this._surnameLabel.TabIndex = 6;
            this._surnameLabel.Text = "Surname:";
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this._nameLabel.Location = new System.Drawing.Point(12, 9);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(52, 19);
            this._nameLabel.TabIndex = 5;
            this._nameLabel.Text = "Name:";
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(115, 9);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(100, 23);
            this._nameTextBox.TabIndex = 9;
            // 
            // _surnameTextBox
            // 
            this._surnameTextBox.Location = new System.Drawing.Point(115, 34);
            this._surnameTextBox.Name = "_surnameTextBox";
            this._surnameTextBox.Size = new System.Drawing.Size(100, 23);
            this._surnameTextBox.TabIndex = 10;
            // 
            // _weightTextBox
            // 
            this._weightTextBox.Location = new System.Drawing.Point(115, 61);
            this._weightTextBox.Name = "_weightTextBox";
            this._weightTextBox.Size = new System.Drawing.Size(100, 23);
            this._weightTextBox.TabIndex = 11;
            // 
            // _growthTextBox
            // 
            this._growthTextBox.Location = new System.Drawing.Point(115, 87);
            this._growthTextBox.Name = "_growthTextBox";
            this._growthTextBox.Size = new System.Drawing.Size(100, 23);
            this._growthTextBox.TabIndex = 12;
            // 
            // _saveButton
            // 
            this._saveButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._saveButton.Location = new System.Drawing.Point(71, 130);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(89, 28);
            this._saveButton.TabIndex = 13;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this._saveButton_Click);
            // 
            // SetPersonalIngormation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 167);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._growthTextBox);
            this.Controls.Add(this._weightTextBox);
            this.Controls.Add(this._surnameTextBox);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this._growthLabel);
            this.Controls.Add(this._weightLabel);
            this.Controls.Add(this._surnameLabel);
            this.Controls.Add(this._nameLabel);
            this.Name = "SetPersonalIngormation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetPersonalIngormation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _growthLabel;
        private System.Windows.Forms.Label _weightLabel;
        private System.Windows.Forms.Label _surnameLabel;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.TextBox _surnameTextBox;
        private System.Windows.Forms.TextBox _weightTextBox;
        private System.Windows.Forms.TextBox _growthTextBox;
        private System.Windows.Forms.Button _saveButton;
    }
}