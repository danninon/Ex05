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

        private const string k_ComputerOpponentName = "[Computer]";
        private const string k_ErrorFormTitle = "Error log:";


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
                textInputPlayer2Name.Text = k_ComputerOpponentName;
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

                engine.InitializePlayerSkeleton(TextInputPlayer1Name.Text);
                engine.CreateGameBoard(comboBoxRows.SelectedItem.ToString(), comboBoxCols.SelectedItem.ToString());
                string userOpponentChoice = this.checkBoxPlayerTwo.Checked ? isAiOpponent : isHumanOpponent;
                engine.InitializePlayer2AndOpponent(userOpponentChoice, textInputPlayer2Name.Text);
                this.Hide();
                openGameForm();
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
                io_SystemOutPutToUserBuilder.Append("Please make sure you chose rows for the game table." + Environment.NewLine);
                errorAtForm = true;
            }

            if (textInputPlayer2Name.Text == "")
            {
                io_SystemOutPutToUserBuilder.Append("Please make sure you chose rows for the game table." + Environment.NewLine);
                errorAtForm = true;
            }

            if (comboBoxRows.SelectedItem == null)
            {
                //    comboBoxRows.BackColor = Color.IndianRed;
                io_SystemOutPutToUserBuilder.Append("Please make sure you chose rows for the game table." +
                                                 Environment.NewLine);
                errorAtForm = true;
            }

            if (comboBoxCols.SelectedItem == null)
            {
                //     comboBoxCols.BackColor = Color.IndianRed;
                io_SystemOutPutToUserBuilder.Append("Please make sure you chose columns for the game table." + Environment.NewLine);
                errorAtForm = true;
            }
            return errorAtForm;
        }


        private void openGameForm()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new GameForm(engine)); //<--- SettingsMenu
           DialogResult thisDR = this.DialogResult;
            // DialogResult dr = this.DialogResult.;
            GameForm gameForm = new GameForm(engine);
            this.Close();
        }

        private const string isAiOpponent = "1";
        private const string isHumanOpponent = "2";

        private void comboBoxRows_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
