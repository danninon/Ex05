﻿
namespace FourInARowWindows
{
     partial class SettingsMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextInputPlayer1Name = new System.Windows.Forms.TextBox();
            this.checkBoxPlayerTwo = new System.Windows.Forms.CheckBox();
            this.textInputPlayer2Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.comboBoxRows = new System.Windows.Forms.ComboBox();
            this.comboBoxCols = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Players:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Players 1:";
            // 
            // TextInputPlayer1Name
            // 
            this.TextInputPlayer1Name.Location = new System.Drawing.Point(116, 35);
            this.TextInputPlayer1Name.Name = "TextInputPlayer1Name";
            this.TextInputPlayer1Name.Size = new System.Drawing.Size(100, 20);
            this.TextInputPlayer1Name.TabIndex = 2;
            // 
            // checkBoxPlayerTwo
            // 
            this.checkBoxPlayerTwo.AutoSize = true;
            this.checkBoxPlayerTwo.Location = new System.Drawing.Point(28, 61);
            this.checkBoxPlayerTwo.Name = "checkBoxPlayerTwo";
            this.checkBoxPlayerTwo.Size = new System.Drawing.Size(72, 17);
            this.checkBoxPlayerTwo.TabIndex = 4;
            this.checkBoxPlayerTwo.Text = "Players 2:";
            this.checkBoxPlayerTwo.UseVisualStyleBackColor = true;
            this.checkBoxPlayerTwo.CheckedChanged += new System.EventHandler(this.OnOpponentChanged);
            // 
            // textInputPlayer2Name
            // 
            this.textInputPlayer2Name.Enabled = false;
            this.textInputPlayer2Name.Location = new System.Drawing.Point(116, 61);
            this.textInputPlayer2Name.Name = "textInputPlayer2Name";
            this.textInputPlayer2Name.Size = new System.Drawing.Size(100, 20);
            this.textInputPlayer2Name.TabIndex = 5;
            this.textInputPlayer2Name.Text = "[computer]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Board Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rows:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cols:";
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(12, 140);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(217, 23);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.OnStartClicked);
            // 
            // comboBoxRows
            // 
            this.comboBoxRows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRows.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxRows.Location = new System.Drawing.Point(82, 113);
            this.comboBoxRows.Name = "comboBoxRows";
            this.comboBoxRows.Size = new System.Drawing.Size(69, 21);
            this.comboBoxRows.TabIndex = 12;
            this.comboBoxRows.SelectedIndexChanged += new System.EventHandler(this.comboBoxRows_SelectedIndexChanged);
            // 
            // comboBoxCols
            // 
            this.comboBoxCols.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCols.FormattingEnabled = true;
            this.comboBoxCols.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxCols.Location = new System.Drawing.Point(201, 113);
            this.comboBoxCols.Name = "comboBoxCols";
            this.comboBoxCols.Size = new System.Drawing.Size(69, 21);
            this.comboBoxCols.TabIndex = 13;
            // 
            // SettingsMenu
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 202);
            this.Controls.Add(this.comboBoxCols);
            this.Controls.Add(this.comboBoxRows);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textInputPlayer2Name);
            this.Controls.Add(this.checkBoxPlayerTwo);
            this.Controls.Add(this.TextInputPlayer1Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingsMenu";
            this.Text = "SettingsMenu123";
            this.ResumeLayout(false);
            this.PerformLayout();

          }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextInputPlayer1Name;
        private System.Windows.Forms.CheckBox checkBoxPlayerTwo;
        private System.Windows.Forms.TextBox textInputPlayer2Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ComboBox comboBoxRows;
        private System.Windows.Forms.ComboBox comboBoxCols;
    }
}

