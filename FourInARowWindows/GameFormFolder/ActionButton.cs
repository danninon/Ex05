using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FourInARowWindows
{
     public class ActionButton : Button
     {
          public ActionButton(int i_Index)
          {
               Text = i_Index.ToString();
          }
     }
}
