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
          private const string k_ComputerTextBoxName = "[Computer]";
          private const string k_ErrorFormTitle = "Error log:";
          private const string k_ComputerDisplayName = "Computer";


          public SettingsMenu()
          {
               //logical configuring - might want to put into separate method
               InitializeComponent();
          }

          private void OnOpponentChanged(object sender, EventArgs e)
          {
               CheckBox checkBox = sender as CheckBox;
               if (checkBox.Checked == true)
               {
                    textInputPlayer2Name.Clear();
                    textInputPlayer2Name.Enabled = true;
               }
               else //is false
               {

                    textInputPlayer2Name.Enabled = false;
                    textInputPlayer2Name.Text = k_ComputerTextBoxName;
               }
          }


          private void OnStartClicked(object sender, EventArgs e)
          {
               //   validateSettingsForm();
               bool errorAtForm;
               StringBuilder errorStringForm = new StringBuilder(k_ErrorFormTitle + Environment.NewLine);

               errorAtForm = validateForm(errorStringForm);

               if (errorAtForm == false)
               {
                    IFourInARow engine = new GameEngineLogic(NUDRows.Text, NUDCols.Text);
                    engine.GetPlayer1().Name = TextInputPlayer1Name.Text;
                    string userOpponentChoice = this.checkBoxPlayerTwo.Checked ? isAiOpponent : isHumanOpponent;
                    engine.InitializePlayer2AndOpponent(userOpponentChoice, textInputPlayer2Name.Text);
                    this.Hide();
                    openGameForm(engine);
               }
               else // errorAtForm == true
               {
                    MessageBox.Show(errorStringForm.ToString());
               }
          }

          private bool validateForm(StringBuilder io_SystemOutPutToUserBuilder)
          {
               bool errorAtForm = false;

               if (TextInputPlayer1Name.Text == "")
               {
                    io_SystemOutPutToUserBuilder.Append("Please make sure you enter a name for player 1" + Environment.NewLine);
                    errorAtForm = true;
               }

               if (textInputPlayer2Name.Text == "")
               {
                    io_SystemOutPutToUserBuilder.Append("Please make sure you enter a name for player 2" + Environment.NewLine);
                    errorAtForm = true;
               }

               return errorAtForm;
          }


          private void openGameForm(IFourInARow i_engine)
          {
               if(i_engine.GetPlayer2().IsAnAi == true)
               {
                    i_engine.GetPlayer2().Name = k_ComputerDisplayName;
               }
               GameForm gameForm = new GameForm(i_engine);
               this.Close();
          }

          private const string isAiOpponent = "1";
          private const string isHumanOpponent = "2";


     }

}
