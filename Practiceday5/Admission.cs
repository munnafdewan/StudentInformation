using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practiceday5
{
    public partial class Admission : Form
    {

        ErrorProvider erp = new ErrorProvider();

        
        List<string> ids = new List<string> ();
        List<string> names = new List<string> ();
        List<string> mobiles = new List<string> ();
        List<string> ages = new List<string> ();
        List<string> addres = new List<string> ();
        List<string> gpas = new List<string> ();

        string message = " ";
        int index = 0;
        public Admission()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            erp.Clear();

            if (idTextBox.Text.Equals(" ") || idTextBox.Text.Length != 4)
            {
                index++;
                erp.SetError(idTextBox, "Enter your Id in 4 character");
                return;
            }
            else if (checkDuplicateID()) ;
            else if (nameTextBox.Text.Equals(" ") || nameTextBox.Text.Length > 30)
            {
                index++;
                erp.SetError(nameTextBox, "Enter your Name less then 30 character");
                return;
            }

            else if (phoneTextBox.Text.Equals(" ") || phoneTextBox.Text.Length != 11)
            {
                index++;
                erp.SetError(phoneTextBox, "Enter your phone number in 11 character");
                return;
            }
            else if (checkDuplicateMobile()) ;

            else if (ageTextBox.Text.Equals(" ") || ageTextBox.Text.Length >50)
            {
                index++;
                erp.SetError(ageTextBox, "Enter your age ");
                return;
            }

            else if (addressTextBox.Text.Equals(" ") )
            {
                index++;
                erp.SetError(addressTextBox, "Write your address ");
                return;
            }

            else if (gpaTextBox.Text.Equals(" ") || (float.Parse(gpaTextBox.Text) < 1 || float.Parse(gpaTextBox.Text) > 4))
            {
                index++;
                erp.SetError(gpaTextBox, "GPA point must be in 1-4 ");
                return;
            }

            ids.Add(idTextBox.Text);
            names.Add(nameTextBox.Text);
            mobiles.Add(phoneTextBox.Text);
            ages.Add(ageTextBox.Text);
            addres.Add(addressTextBox.Text);
            gpas.Add(gpaTextBox.Text);

            richTextBox.Text = "ID : " + idTextBox.Text + "\n" + "Name : " + nameTextBox.Text + "\n" + "Mobile : " + phoneTextBox.Text + "\n" + "Age : " + ageTextBox.Text + "\n" + "Address : " + addressTextBox.Text + "\n" + "GPA : " + gpaTextBox.Text + "\n";
            MessageBox.Show("Student is admitted");
            Clear();
             
        }

      

        private void showButton_Click(object sender, EventArgs e)
        {
            String minName = " ", maxName = " ";
            float min = 10, max = 0, avg = 0, total = 0, gpatext;


            for(int j = 0; j<ids.Count(); j++)
            {
                gpatext = float.Parse(gpas[j]);
                    total += gpatext;

                if(min > gpatext)
                {
                    min = gpatext;
                    minName = names[j];
                }

                if(max < gpatext)
                {
                    max = gpatext;
                    maxName = names[j];

                }

                message += "ID : " + ids[j] + "\n" + "Name : " + names[j] + "\n" + "Mobile : " + mobiles[j] + "\n" + "Age : " + ages[j] + "\n" + "Address : " + addres[j] + "\n" + "GPA : " + gpas[j] + "\n" + "\n";

                maxTextBox.Text = max.ToString();
                nameMaxTextBox.Text = maxName;
                mimTextBox.Text = min.ToString();
                mimNameTextBox.Text = minName;
                totalTextBox.Text = total.ToString();
                averegeTextBox.Text = (total / ids.Count()).ToString();
            }
            richTextBox.Text = message;
           
        }

        private void Clear()
        {
            nameTextBox.Text = "";
            idTextBox.Text = "";
            phoneTextBox.Text = "";
            ageTextBox.Text = "";
            addressTextBox.Text = "";
            gpaTextBox.Text = "";
            maxTextBox.Text = "";
            mimTextBox.Text = "";
            nameMaxTextBox.Text = "";
            mimNameTextBox.Text = "";
            averegeTextBox.Text = "";
            totalTextBox.Text = "";

        }

        private void ShowStudent()
        {
           
            int id = Convert.ToInt32(idTextBox.Text);
            string name = nameTextBox.Text;
            string mobile = phoneTextBox.Text;
            int age = Convert.ToInt32(ageTextBox.Text);
            string address = addressTextBox.Text;
            double gpa = Convert.ToDouble(gpaTextBox.Text);

            for (int i = 0; i < names.Count(); i++)
            {
                message +="Id " + id + "\n" +"Name : " + name[index] + "\n" + "Mobile :" + mobile[index] + "\n " + "Age :" + age + "\n" + "Address :" + address[index] + "\n" + "GPA :" + gpa;

            }

            richTextBox.Text = (message);
        }

        private Boolean checkDuplicateID()
        {
            for(int i =0;i<ids.Count();i++)
            {
                if((idTextBox.Text).Equals(ids[i]))
                {
                    index++;
                    erp.SetError(idTextBox, "Id must be unique");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private Boolean checkDuplicateMobile()
        {
            for (int i = 0; i < mobiles.Count(); i++)
            {
                if ((phoneTextBox.Text).Equals(mobiles[i]))
                {
                    index++;
                    erp.SetError(phoneTextBox, "Phone number must be unique");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (idRadio.Checked == true)
            {
                richTextBox.Text = "";
                for (int i = 0; i < ids.Count(); i++)
                {
                    if (idTextBox.Text.Equals(ids[i]))
                    {
                        richTextBox.Text = "ID: " + ids[i] + "\n" + "Name: " + names[i] + "\n" + "Mobile: " + mobiles[i] + "\n" + "Age: " + ages[i] + "\n" +
                       "Address: " + addres[i] + "\n" + "GPA: " + gpas[i];

                    }
                    idTextBox.Text = "";
                    Clear();
                }
            }

            else if (nameRadio.Checked == true)
            {
                richTextBox.Text = "";
                for (int i = 0; i < names.Count(); i++)
                {
                    if (nameTextBox.Text.Equals(names[i]))
                    {
                        richTextBox.Text = "ID: " + ids[i] + "\n" + "Name: " + names[i] + "\n" + "Mobile: " + mobiles[i] + "\n" + "Age: " + ages[i] + "\n" +
                      "Address: " + addres[i] + "\n" + "GPA: " + gpas[i];
                    }
                    nameTextBox.Text = "";
                    Clear();
                }
            }

            else if (mobileRadio.Checked == true)
            {
                richTextBox.Text = "";
                for (int i = 0; i < mobiles.Count(); i++)
                {
                    if (phoneTextBox.Text.Equals(mobiles[i]))
                    {
                        richTextBox.Text = "ID: " + ids[i] + "\n" + "Name: " + names[i] + "\n" + "Mobile: " + mobiles[i] + "\n" + "Age: " + ages[i] + "\n" +
                    "Address: " + addres[i] + "\n" + "GPA: " + gpas[i];

                    }
                    phoneTextBox.Text = "";
                    Clear();
                }
            }
        }
    }
}
