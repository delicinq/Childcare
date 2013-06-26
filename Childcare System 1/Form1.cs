using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//Add MySql Library
using MySql.Data.MySqlClient;

namespace Childcare_System_1
{
    public partial class Form1 : Form
    {
        private static string name1;
        private static string name2;
        private static string name;






        private MySqlConnection connection;
            
        //private string server = "localhost";
       // private string database = "childeren1";
       // private string uid = "root";
        //private string password = "password";
        //private string port = "3306";




            private string server = "sql3.freesqldatabase.com";
            private string database = "sql312170";
            private string uid = "sql312170";
            private string password = "wC8*yN3*";
            private string port = "3306";
     
        public Form1()
        {
            InitializeComponent();
            
           
            
            loadChilderen();
            
        }


       
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        public void readDB()
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(@"c:\test\WriteText.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] inputArray = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(inputArray[2]);
                Console.WriteLine(line);
                counter++;
            }

            file.Close();

            // Suspend the screen.
            Console.ReadLine();
        }

        public void search()
        {
            MySqlConnection connection2 = new MySqlConnection("Server=" + server + ";" + "Port=" + port + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";");

           
                connection2.Open();
                string query = @"SELECT DISTINCT name2 FROM childDatabase WHERE name2 Like '%" + childSearch.Text + "%'";
                   // string query = "SELECT name2 FROM childDatabase WHERE name2 = @idParam";
                     MySqlCommand cmd = new MySqlCommand(query, connection2);

                    cmd.ExecuteNonQuery();

                    MySqlDataAdapter da = new MySqlDataAdapter(query, connection2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);



                    childSearchCombo.DataSource = dt;
                    childSearchCombo.ValueMember = dt.Columns[0].ColumnName;
                    connection2.Close();

                    System.Console.WriteLine(dt.Rows[0][0] + "");
                    connection2.Close();


                    System.Console.WriteLine();
                   // cmd.Parameters.Add("@idParam", SqlDbType.Int).Value = 1; //your id parameter!
                    //cmd.Connection = sqlConn;

            /*
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            System.Console.WriteLine("We get here?");
                            firstNameDisp.Text = (string)reader[0];
                            //textBox2.Text = (string)reader[1];
                        }
                    }
             * 
             * 
             * 
             * */



                    connection2.Close();
                    MessageBox.Show("Successfully added into the database!");

       
                
        /*
            using (MySqlConnection sqlConn = new MySqlConnection("Server=" + server + ";" + "Port=" + port + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";");
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = @"SELECT name2 FROM childDatabase WHERE Employee_ID = @idParam";
                    cmd.Parameters.Add("@idParam", SqlDbType.Int).Value = 1; //your id parameter!
                    cmd.Connection = sqlConn;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox1.Text = (string)reader[0];
                            //textBox2.Text = (string)reader[1];
                        }
                    }
                }
            }



       
    











            string nameSearching = childSearch.Text;
           
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(@"c:\test\WriteText.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] inputArray = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (inputArray[0] == nameSearching)
                {
                    name1 = inputArray[0];
                    name2 = inputArray[1];
                    name = inputArray[0] + " " + inputArray[1];
                    childSearchCombo.Items.Add(inputArray[0] + " " + inputArray[1]);
                    Console.WriteLine("MATCH NIGGA");
                }
                else
                    Console.WriteLine("No match man");
                Console.WriteLine(inputArray[0]);
                Console.WriteLine(line);
                
                counter++;
            }

            file.Close();

            // Suspend the screen.
            Console.ReadLine();
 }
         * */
        }
        
        private void addChildBtn_Click(object sender, EventArgs e)
        {
            
          /*
          //  string lastName = lastNameAdd.Text;

            string firstName = firstNameDisp.Text;
            int ageComboIndex = ageDisp.SelectedIndex;
            string age = this.ageDisp.Items[ageComboIndex].ToString();

            int genderComboIndex = genderDisp.SelectedIndex;
            string gender = this.genderDisp.Items[genderComboIndex].ToString();

            string address = addressDisp.Text;

            string caregiverOneName = caregiver1NameDisp.Text;
            string caregiverOnePhone = caregiver1PhoneDisp.Text;
            string caregiverTwoName = caregiver2NameDisp.Text;
            string caregiverTwoPhone = caregiver2PhoneDisp.Text;

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
                        string text = "\n"+firstName+","+gender+","+age+","+address+","+caregiverOneName+","+caregiverOnePhone+","+caregiverTwoName+","+caregiverTwoPhone;
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

            server = "localhost";
            port = "3306";
            database = "childeren1";
            uid = "root";
            password = "password";

            MySqlConnection connection2 = new MySqlConnection("Server=" + server + ";" + "Port=" + port + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";");

            Console.WriteLine("We got here 1");

            try
            {


                // Perform databse operations
                try
                {

                    connection2.Open();
                    string query = "INSERT INTO childdatabase (name2, age, gender, adress, caregiver1Name, caregiver1Phone, caregiver2Name, caregiver2Phone) VALUES('" + firstName + "','" + age + "','" + gender + "','" + address + "','" + caregiverOneName + "','" + caregiverOnePhone + "','" + caregiverTwoName + "','" + caregiverTwoPhone + "')";
                    MySqlCommand cmd = new MySqlCommand(query, connection2);

                    cmd.ExecuteNonQuery();
                    connection2.Close();











                 

                    connection2.Open();

                   // MySqlConnection myconn = new MySqlConnection("server=localhost;database=octupus_db;userid=root;password=sys");
                    MySqlDataAdapter sqlgender = new MySqlDataAdapter("SELECT name2 FROM childdatabase WHERE id=@idParam ", connection2);

                    DataTable dtgen = new DataTable("names");
                    sqlgender.Fill(dtgen);

                    
                    childSearchCombo.DataSource = dtgen;
                    childSearchCombo.ValueMember = dtgen.Columns[0].ColumnName;
                    childSearchCombo.DisplayMember = dtgen.Columns[1].ColumnName;
                    connection2.Close();
                     
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Failed");
                    //updateStatus(ex.Message.ToString());
                }
                
                connection2.Close();
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }

            }
        
         */
        }


        private void childSearchBtn_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection2 = new MySqlConnection("Server=" + server + ";" + "Port=" + port + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";");

            connection2.Open();
            string query = @"SELECT DISTINCT name2, age, gender FROM childDatabase";
            MySqlCommand cmd = new MySqlCommand(query, connection2);

            cmd.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(query, connection2);
            DataTable dt = new DataTable();
            da.Fill(dt);

          
            firstNameDisp.Text = dt.Columns[0].ColumnName;
            ageDisp.Text = dt.Columns[1].ColumnName;
            genderDisp.Text = dt.Columns[2].ColumnName;
      
            System.Console.WriteLine(dt.Rows[0][0] + "");
            connection2.Close();

        }


        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "connectcsharptomysql";
            uid = "username";
            password = "password";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            OpenConnection();
        }

        //open connection to database
        private bool OpenConnection()
        {
            MySqlConnection connection2 = new MySqlConnection("Server=" + server + ";" + "Port=" + port + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";");

            try
            {
                connection2.Open();
                MessageBox.Show("Test");
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            MySqlConnection connection2 = new MySqlConnection("Server=" + server + ";" + "Port=" + port + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";");

            try
            {
                connection2.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
            MySqlConnection connection2 = new MySqlConnection("Server=" + server + ";" + "Port=" + port + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";");

            string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection2);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] Select()
        {
         
            string query = "SELECT * FROM childDatabase";
            MySqlConnection connection2 = new MySqlConnection("Server=" + server + ";" + "Port=" + port + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";");
            connection2.Open();
            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection2);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"].ToString() + "");
                    list[1].Add(dataReader["name2"] + "");
                    list[2].Add(dataReader["age"] + "");
                    System.Console.WriteLine("THIS IS LIST AT 1"+list[0]);
                }
           
                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
                System.Console.WriteLine(list);


                string test1 = list[0].ToString();

                for (int i = 0; i <2; i++)
                    Console.WriteLine(list[i]);

              /*  foreach (string Txt in list)
                {

                    MessageBox.Show(Txt);

                }
               * */
                //return list to be displayed
                return list;
             
        }

        //Load customer ID to a combobox
        private void loadChilderen()
        {
            var connectionString = "Server=" + server + ";" + "Port=" + port + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT name2 FROM childDatabase";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            childSearchCombo.Items.Add(reader.GetString("name2"));
                        }
                    }
                }
            }
        }

        /*
        //Load customer details using the ID
        private void LoadCustomerDetailsById(int id)
        {
            var connectionString = "Server=" + server + ";" + "Port=" + port + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT id, name2, age FROM childdatabase WHERE id = @id";
                using (var command = new MySqlCommand(query, connection))
                {
                    //Always use SQL parameters to avoid SQL injection and it automatically escapes characters
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        //No customer found by supplied ID
                        if (!reader.HasRows)
                            return;

                        addressDisp.Text = reader.GetInt32("id").ToString();
                       firstNameDisp.Text = reader.GetString("name2");
                        ageComboDisp.Text = reader.GetString("age");
                    }
                }
            }
        }
        */

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM childdatabase";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to backup!");
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to Restore!");
            }
        }
        
        private void childSearchCombo_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
           // var customerId = Convert.ToInt32(childSearchCombo.Text);
            //string customerId = childSearchCombo.Text;
            //LoadCustomerDetailsById(customerId);
        }
        
       
        private void aboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Childcare Database v0.0.1\nBy Christopher Banyard.");
        }

        private void childToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AddChild form = new AddChild();
            form.ShowDialog();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            AddChild form = new AddChild();
            form.ShowDialog();
        }
    
    }


}
