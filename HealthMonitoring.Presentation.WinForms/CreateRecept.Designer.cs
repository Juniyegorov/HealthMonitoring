
namespace HealthMonitoring.Presentation.WinForms
{
    partial class CreateRecept
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
            this._categoryComboBox = new System.Windows.Forms.ComboBox();
            this._categoryLabel = new System.Windows.Forms.Label();
            this._countLabel = new System.Windows.Forms.Label();
            this._productLabel = new System.Windows.Forms.Label();
            this._productsComboBox = new System.Windows.Forms.ComboBox();
            this._countTextBox = new System.Windows.Forms.TextBox();
            this._receptListBox = new System.Windows.Forms.ListBox();
            this._addButton = new System.Windows.Forms.Button();
            this._receptNameLabel = new System.Windows.Forms.Label();
            this._receptNameTextBox = new System.Windows.Forms.TextBox();
            this._createButton = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _categoryComboBox
            // 
            this._categoryComboBox.FormattingEnabled = true;
            this._categoryComboBox.Location = new System.Drawing.Point(46, 56);
            this._categoryComboBox.Name = "_categoryComboBox";
            this._categoryComboBox.Size = new System.Drawing.Size(121, 23);
            this._categoryComboBox.TabIndex = 0;
            this._categoryComboBox.SelectedIndexChanged += new System.EventHandler(this._categoryComboBox_SelectedIndexChanged);
            // 
            // _categoryLabel
            // 
            this._categoryLabel.AutoSize = true;
            this._categoryLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._categoryLabel.Location = new System.Drawing.Point(46, 34);
            this._categoryLabel.Name = "_categoryLabel";
            this._categoryLabel.Size = new System.Drawing.Size(77, 19);
            this._categoryLabel.TabIndex = 1;
            this._categoryLabel.Text = "Categories:";
            // 
            // _countLabel
            // 
            this._countLabel.AutoSize = true;
            this._countLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._countLabel.Location = new System.Drawing.Point(329, 34);
            this._countLabel.Name = "_countLabel";
            this._countLabel.Size = new System.Drawing.Size(54, 19);
            this._countLabel.TabIndex = 3;
            this._countLabel.Text = "Weight:";
            // 
            // _productLabel
            // 
            this._productLabel.AutoSize = true;
            this._productLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._productLabel.Location = new System.Drawing.Point(190, 34);
            this._productLabel.Name = "_productLabel";
            this._productLabel.Size = new System.Drawing.Size(66, 19);
            this._productLabel.TabIndex = 5;
            this._productLabel.Text = "Products:";
            // 
            // _productsComboBox
            // 
            this._productsComboBox.FormattingEnabled = true;
            this._productsComboBox.Location = new System.Drawing.Point(190, 56);
            this._productsComboBox.Name = "_productsComboBox";
            this._productsComboBox.Size = new System.Drawing.Size(121, 23);
            this._productsComboBox.TabIndex = 4;
            // 
            // _countTextBox
            // 
            this._countTextBox.Location = new System.Drawing.Point(329, 55);
            this._countTextBox.Name = "_countTextBox";
            this._countTextBox.Size = new System.Drawing.Size(80, 23);
            this._countTextBox.TabIndex = 6;
            // 
            // _receptListBox
            // 
            this._receptListBox.FormattingEnabled = true;
            this._receptListBox.ItemHeight = 15;
            this._receptListBox.Location = new System.Drawing.Point(46, 85);
            this._receptListBox.Name = "_receptListBox";
            this._receptListBox.Size = new System.Drawing.Size(454, 124);
            this._receptListBox.TabIndex = 7;
            // 
            // _addButton
            // 
            this._addButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._addButton.Location = new System.Drawing.Point(425, 56);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(75, 23);
            this._addButton.TabIndex = 8;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this._addButton_Click);
            // 
            // _receptNameLabel
            // 
            this._receptNameLabel.AutoSize = true;
            this._receptNameLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._receptNameLabel.Location = new System.Drawing.Point(554, 85);
            this._receptNameLabel.Name = "_receptNameLabel";
            this._receptNameLabel.Size = new System.Drawing.Size(107, 19);
            this._receptNameLabel.TabIndex = 9;
            this._receptNameLabel.Text = "Name of recept:";
            // 
            // _receptNameTextBox
            // 
            this._receptNameTextBox.Location = new System.Drawing.Point(539, 108);
            this._receptNameTextBox.Name = "_receptNameTextBox";
            this._receptNameTextBox.Size = new System.Drawing.Size(136, 23);
            this._receptNameTextBox.TabIndex = 10;
            // 
            // _createButton
            // 
            this._createButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._createButton.Location = new System.Drawing.Point(568, 150);
            this._createButton.Name = "_createButton";
            this._createButton.Size = new System.Drawing.Size(75, 23);
            this._createButton.TabIndex = 11;
            this._createButton.Text = "Create";
            this._createButton.UseVisualStyleBackColor = true;
            this._createButton.Click += new System.EventHandler(this._createButton_Click);
            // 
            // _saveButton
            // 
            this._saveButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._saveButton.Location = new System.Drawing.Point(290, 215);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 12;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this._saveButton_Click);
            // 
            // CreateRecept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 268);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._createButton);
            this.Controls.Add(this._receptNameTextBox);
            this.Controls.Add(this._receptNameLabel);
            this.Controls.Add(this._addButton);
            this.Controls.Add(this._receptListBox);
            this.Controls.Add(this._countTextBox);
            this.Controls.Add(this._productLabel);
            this.Controls.Add(this._productsComboBox);
            this.Controls.Add(this._countLabel);
            this.Controls.Add(this._categoryLabel);
            this.Controls.Add(this._categoryComboBox);
            this.Name = "CreateRecept";
            this.Text = "CreateRecept";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _categoryComboBox;
        private System.Windows.Forms.Label _categoryLabel;
        private System.Windows.Forms.Label _countLabel;
        private System.Windows.Forms.Label _productLabel;
        private System.Windows.Forms.ComboBox _productsComboBox;
        private System.Windows.Forms.TextBox _countTextBox;
        private System.Windows.Forms.ListBox _receptListBox;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Label _receptNameLabel;
        private System.Windows.Forms.TextBox _receptNameTextBox;
        private System.Windows.Forms.Button _createButton;
        private System.Windows.Forms.Button _saveButton;
    }
}