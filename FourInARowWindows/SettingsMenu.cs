using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            ComboBox rowsCB = comboBoxRows;
            ComboBox colsCB = comboBoxCols;
            foreach (var item in colsCB.Items)
            {
                Console.WriteLine(item.ToString());
            }
            //Add data validation!

            engine.InitializePlayerSkeleton();
            engine.CreateGameBoard(comboBoxRows.SelectedItem.ToString(), comboBoxCols.SelectedItem.ToString());
            string userOpponentChoice = this.checkBoxPlayerTwo.Checked ? isAiOpponent : isHumanOpponent; 
            engine.InitializePlayer2AndOpponent(userOpponentChoice);
            this.Close();
            GameForm gameForm = new GameForm(engine);


        }

        private const string isAiOpponent = "1";
        private const string isHumanOpponent = "2";
    }

     internal class GameForm
     {
         private readonly GameEngineLogic EngineLogic;

         public GameForm(IFourInARow engine)
         {

         }
     }
}
