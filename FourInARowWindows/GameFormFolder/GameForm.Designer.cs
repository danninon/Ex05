
namespace FourInARowWindows
{
     public partial class GameForm
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
               this.gameTable = new System.Windows.Forms.TableLayoutPanel();
               this.SuspendLayout();
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(130, 396);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(51, 20);
               this.label1.TabIndex = 0;
               this.label1.Text = "label1";
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.Location = new System.Drawing.Point(478, 396);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(51, 20);
               this.label2.TabIndex = 1;
               this.label2.Text = "label2";
               // 
               // gameTable
               // 
               this.gameTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
               this.gameTable.ColumnCount = 2;
               this.gameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
               this.gameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
               this.gameTable.Dock = System.Windows.Forms.DockStyle.Top;
               this.gameTable.Location = new System.Drawing.Point(0, 0);
               this.gameTable.Name = "gameTable";
               this.gameTable.RowCount = 2;
               this.gameTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
               this.gameTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
               this.gameTable.Size = new System.Drawing.Size(665, 393);
               this.gameTable.TabIndex = 2;
               // 
               // GameForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.AutoSize = true;
               this.BackColor = System.Drawing.SystemColors.AppWorkspace;
               this.ClientSize = new System.Drawing.Size(665, 450);
               this.Controls.Add(this.gameTable);
               this.Controls.Add(this.label2);
               this.Controls.Add(this.label1);
               this.MaximizeBox = false;
               this.Name = "GameForm";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
               this.Text = "4 in a Raw !!";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.TableLayoutPanel gameTable;
     }
}