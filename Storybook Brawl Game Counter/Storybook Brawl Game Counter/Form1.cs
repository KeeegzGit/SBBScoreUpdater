using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Storybook_Brawl_Game_Counter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a string variable with the selected placement in the combo box
            string placement = comboBox1.Text;
            //create an interger to store the number of the placements previously added
            int number = 0;
            // Set a variable to the Documents path.
            string docPath =
              @"C:\Users\shado\Documents\StorybookBrawlcounter\";
            // Read the file as one string.
            string text = File.ReadAllText(docPath + placement + ".txt");
            //check if the text in the file is an interger
            bool v = int.TryParse(text, out number);
            //if text is an interger then store it in an interger variable
            if (v == true)
            {
                //changing the previous amount of placements into an interger
                int numplace = int.Parse(text);
                //adding 1 to the text file
                if (radioButtonAdd.Checked == true)
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, placement + ".txt")))
                    {
                        outputFile.WriteLine(numplace + 1);
                    }
                }
                else
                {
                    if (radioButtonRemove.Checked == true)
                    {
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, placement + ".txt")))
                        {
                            outputFile.WriteLine(numplace - 1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select add or remove");
                    }
                } 
            }
            else 
            {
                MessageBox.Show("Text in file" + placement + ".txt is not in a valid format");
            }
            // Write the string array to a new file named "WriteLines.txt".
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //get the date and time
            DateTime Now = DateTime.Now;
            // Set a variable to the Documents path.
            string docPath =
              @"C:\Users\shado\Documents\StorybookBrawlcounter\";
            //add info in documents to array
            string[] lines =  
            { 
                File.ReadAllText(docPath + "1.txt"),
                File.ReadAllText(docPath + "2.txt"),
                File.ReadAllText(docPath + "3.txt"),
                File.ReadAllText(docPath + "4.txt"),
                File.ReadAllText(docPath + "5.txt"),
                File.ReadAllText(docPath + "6.txt"),
                File.ReadAllText(docPath + "7.txt"),
                File.ReadAllText(docPath + "8.txt"),
            };
            //writes the current scores to a file with todays date
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, Now.ToString("yyyyMMdd") + ".txt")))
            {
                outputFile.WriteLine(Now);                
                foreach(string line in lines)
                {
                    outputFile.WriteLine(line);
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //create an interger
            int i;
            // Set a variable to the Documents path.
            string docPath =
              @"C:\Users\shado\Documents\StorybookBrawlcounter\";
            //clear the contents of each text document
            for(i = 1; i < 9; i++)
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, i + ".txt")))
            {
                outputFile.WriteLine(0);
            }
        }
    }
}
