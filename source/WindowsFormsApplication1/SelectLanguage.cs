using System;

using System.Collections.Generic;

using System.Text;

using System.Reflection;

using System.Resources;

using System.Threading;

using System.Globalization;

using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class SelectLanguage
    {
        public SelectLanguage()
        {

        }



        private string formName;



        public ResourceManager GetCurrentCulture()
        {

            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            ResourceManager rm = new ResourceManager(

               "WindowsFormsApplication1.Resource",

               Assembly.GetExecutingAssembly());

            return rm;

        }



        public System.Drawing.Bitmap GetImage(string strObjectId)
        {

            ResourceManager rm = GetCurrentCulture();

            object obj = rm.GetObject(strObjectId);

            return (System.Drawing.Bitmap)obj;

        }



        public string getMsg(string strId)
        {

            string currentLanguage = "";

            try
            {

                ResourceManager rm = GetCurrentCulture();

                CultureInfo ci = Thread.CurrentThread.CurrentCulture;

                currentLanguage = rm.GetString(strId, ci);

            }

            catch
            {

                currentLanguage = "Cannot Found:" + strId +

                    " , Please Add it to Resource File.";

            }

            return currentLanguage;



        }



        public void SetLanguage(System.Windows.Forms.Control control)
        {

            //MessageBox.Show(control.GetType().BaseType.Name);

            if (control.GetType().BaseType.Name == "Form")
            {

                formName = control.Name;

                control.Text = getMsg(control.Name);

            }



            for (int i = 0; i < control.Controls.Count; i++)
            {

                //MessageBox.Show(

                //  control.Controls[i].GetType().Name + 

                //  "-" + control.Controls[i].Name);

                switch (control.Controls[i].GetType().Name)
                {

                    case "Label":

                    case "Button":

                    case "CheckBox":

                    case "LinkLabel":

                        control.Controls[i].Text = getMsg(

                            formName + control.Controls[i].Name);

                        break;

                    case "Panel":

                        SetLanguage(control.Controls[i]);

                        break;

                    case "TabControl":

                        TabControl tbc = (TabControl)control.Controls[i];

                        for (int j = 0; j < tbc.TabCount; j++)
                        {

                            tbc.TabPages[j].Text = getMsg(

                                formName + tbc.TabPages[j].Name);

                            SetLanguage(tbc.TabPages[j]);

                        }

                        break;

                    default:

                        break;

                }

            }

        }
    }
}
