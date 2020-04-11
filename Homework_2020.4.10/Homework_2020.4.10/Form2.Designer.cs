namespace Homework_2020._4._10
{
    partial class Form2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.purchaseAmountTextBox = new System.Windows.Forms.TextBox();
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.customerNameTextBox);
            this.panel1.Controls.Add(this.customerNameLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.messageLabel);
            this.panel1.Controls.Add(this.ConfirmButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Controls.Add(this.purchaseAmountTextBox);
            this.panel1.Controls.Add(this.itemComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 450);
            this.panel1.TabIndex = 1;
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customerNameTextBox.Location = new System.Drawing.Point(236, 180);
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.Size = new System.Drawing.Size(121, 28);
            this.customerNameTextBox.TabIndex = 10;
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.Location = new System.Drawing.Point(79, 185);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(98, 18);
            this.customerNameLabel.TabIndex = 9;
            this.customerNameLabel.Text = "顾客姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 18);
            this.label3.TabIndex = 8;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(79, 380);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(62, 18);
            this.messageLabel.TabIndex = 7;
            this.messageLabel.Text = "状态：";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(122, 302);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(215, 41);
            this.ConfirmButton.TabIndex = 6;
            this.ConfirmButton.Text = "确定";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(122, 235);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(215, 41);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "添加";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // purchaseAmountTextBox
            // 
            this.purchaseAmountTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.purchaseAmountTextBox.Location = new System.Drawing.Point(236, 125);
            this.purchaseAmountTextBox.Name = "purchaseAmountTextBox";
            this.purchaseAmountTextBox.Size = new System.Drawing.Size(121, 28);
            this.purchaseAmountTextBox.TabIndex = 4;
            // 
            // itemComboBox
            // 
            this.itemComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.itemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(236, 70);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(121, 26);
            this.itemComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "购买数量：";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "购买物品：";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "添加订单";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox itemComboBox;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox purchaseAmountTextBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox customerNameTextBox;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Label label3;
    }
}