using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngine;

namespace FourInARowWindows
{
     public partial class SettingsMenu : Form
     {
          private readonly IFourInARow engine;
          private readonly GameBoard gameBoard;
          public SettingsMenu()
          {
               //logical configuring - might want to put into separate method
               engine = new GameEngineLogic();
               InitializeComponent();
          }

          public SettingsMenu(IFourInARow i_Engine)
          {
               engine = i_Engine;
          }

          private void label1_Click(object sender, EventArgs e)
          {

          }

          private void validateData(object sender, EventArgs e)
          {
               //testing
               string fullName = sender.GetType().FullName;
               Console.WriteLine(fullName);
               Console.WriteLine("ALL GOOD!");

               //for now always true
               bool status = true;
               TextBox senderTB = sender as TextBox;
               if (status == true)
               {
                    senderTB.BackColor = Color.LightGreen;
               }
          }

          private void listBoxPlayer2Opponent_SelectedIndexChanged(object sender, EventArgs e)
          {

          }

          private void label3_Click(object sender, EventArgs e)
          {

          }

          private void OnOpponentChanged(object sender, EventArgs e)
          {
               CheckBox checkBox = sender as CheckBox;
               if (checkBox.Checked == true)
               {
                    textBoxPlayer2Input.Enabled = true;
               }
               else //is false
               {
                    textBoxPlayer2Input.Enabled = false;
               }
          }

          private void OnStartClicked(object sender, EventArgs e)
          {
               //   validateSettingsForm();
               bool errorAtForm = false;
               StringBuilder systemOutPutToUserBuilder = new StringBuilder();
               if (comboBoxRows.SelectedItem == null)
               {
                    comboBoxRows.BackColor = Color.IndianRed;
                    systemOutPutToUserBuilder.Append("Please make sure you chose rows for the game table.");
                    errorAtForm = true;
               }
               else if (comboBoxCols.SelectedItem == null)
               {
                    comboBoxCols.BackColor = Color.IndianRed;
                    systemOutPutToUserBuilder.Append("Please make sure you chose columns for the game table.");
                    errorAtForm = true;
               }
               else
               {
                    //replaces the exception
                    engine.InitializePlayerSkeleton(TextpInputPlayer1Name.Text);
                    engine.CreateGameBoard(comboBoxRows.SelectedItem.ToString(), comboBoxCols.SelectedItem.ToString());
                    string userOpponentChoice = this.checkBoxPlayerTwo.Checked ? isAiOpponent : isHumanOpponent;
                    engine.InitializePlayer2AndOpponent(userOpponentChoice, textBoxPlayer2Input.Text);
                    this.Hide();
                    openGameForm();
               }

               if (errorAtForm == true)
               {
                    MessageBox.Show(systemOutPutToUserBuilder.ToString());
               }
          }


          private void openGameForm()
          {
               //Application.EnableVisualStyles();
               //Application.SetCompatibleTextRenderingDefault(false);
               //Application.Run(new GameForm(engine)); //<--- SettingsMenu
               GameForm gameForm = new GameForm(engine);
               this.Close();
          }

          private const string isAiOpponent = "1";
          private const string isHumanOpponent = "2";
     }
}
