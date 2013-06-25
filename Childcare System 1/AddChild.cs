using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Childcare_System_1
{
    public partial class AddChild : Form
    {
        private MySqlConnection connection2;

        private string server = "sql3.freesqldatabase.com";
        private string database = "sql312170";
        private string uid = "sql312170";
        private string password = "wC8*yN3*";
        private string port = "3306";

        public AddChild()
        {
            InitializeComponent();
        }

        private void addChildBtn_Click(object sender, EventArgs e)
        {

            string firstName = firstNameAdd.Text;
            int ageComboIndex = ageComboAdd.SelectedIndex;
            string age = this.ageComboAdd.Items[ageComboIndex].ToString();

            int genderComboIndex = genderComboAdd.SelectedIndex;
            string gender = this.genderComboAdd.Items[genderComboIndex].ToString();

            string address = addressAdd.Text;

            string caregiverOneName = caregiver1NameAdd.Text;
            string caregiverOnePhone = caregiver1PhoneAdd.Text;
            string caregiverTwoName = caregiver2NameAdd.Text;
            string caregiverTwoPhone = caregiver2PhoneAdd.Text;

            DialogResult result = MessageBox.Show("Please ensure the following information is correct:\n" +
                "Name: " + firstName + "\n" +
                "Gender: " + gender + "\n" +
                "Age: " + age + "\n" +
                "Address: " + address + "\n" +
                "Caregiver #1 Name: " + caregiverOneName + "\n" +
                "Caregiver #1 Phone: " + caregiverOnePhone + "\n" +
                "Caregiver #2 Name: " + caregiverTwoName + "\n" +
                "Caregiver #2 Phone: " + caregiverTwoPhone + "\n", "Check over this information", MessageBoxButtons.OKCancel);

            switch (result)
            {
                case DialogResult.OK:
                    {
                        // Example #2: Write one string to a text file. 
                        string text = "\n" + firstName + "," + gender + "," + age + "," + address + "," + caregiverOneName + "," + caregiverOnePhone + "," + caregiverTwoName + "," + caregiverTwoPhone;
                        // WriteAllText creates a file, writes the specified string to the file, 
                        // and then closes the file.
                        System.IO.File.AppendAllText(@"C:\test\WriteText.txt", text);

                        this.Text = "[OK]";
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        this.Text = "[Cancel]";
                        break;
                    }
            }

       
            MySqlConnection connection2 = new MySqlConnection("Server=" + server + ";" + "Port=" + port + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";");

            Console.WriteLine("We got here 1");
            try
                {

                    connection2.Open();
                    string query = "INSERT INTO childDatabase (name2, age, gender, adress, caregiver1Name, caregiver1Phone, caregiver2Name, caregiver2Phone) VALUES('" + firstName + "','" + age + "','" + gender + "','" + address + "','" + caregiverOneName + "','" + caregiverOnePhone + "','" + caregiverTwoName + "','" + caregiverTwoPhone + "')";
                    MySqlCommand cmd = new MySqlCommand(query, connection2);

                    cmd.ExecuteNonQuery();
                    connection2.Close();
                    MessageBox.Show("Successfully added into the database!");

                   
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Failed");
                    //updateStatus(ex.Message.ToString());
                }
                connection2.Close();
                AddChild form = new AddChild();
                form.Close();
            }
        }
    }
