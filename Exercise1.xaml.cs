using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace Collection
{
    /// <summary>
    /// Interaction logic for Exercise1.xaml
    /// </summary>
    public partial class Exercise1 : Window
    {
        Counter counter;
        //= new Counter();

        public Exercise1()
        {
            InitializeComponent();
        }

        private void BrowseFile_button_Click(object sender, RoutedEventArgs e)
        {
            Stream fileStream = null;
            var textList = new List<char>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select text file";
            openFileDialog.Filter = "txt file (*.txt)|*.txt";
            openFileDialog.Multiselect = false;

            openFileDialog.InitialDirectory = "c:\\"; //tmp

            openFileDialog.ShowDialog();
            try
            {
                counter = new Counter();
                if ((fileStream = openFileDialog.OpenFile()) != null)
                {
                    using (fileStream)
                    {
                        StreamReader streamReader = new StreamReader(fileStream);

                        counter.fillCharList(streamReader);

                        streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                        ContentFile_textBlock.Text = streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }


        private void Check_button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ContentFile_textBlock.Text))
            {
                System.Windows.Forms.MessageBox.Show("No file load, or empty file!", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(CharInput_textBox.Text))
            {
                System.Windows.Forms.MessageBox.Show("Not specified character!");
            }
            else
            {
                counter.countChars(CharInput_textBox.Text[0]);
            }     
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }



    public class Counter
    {
        private List<char> charList;
        
        public Counter()
        {
            charList = new List<char>();
        }
        
        public void fillCharList(StreamReader stream)
        {
            while (stream.Peek() >= 0)
            {
                charList.Add((char)stream.Read());
            }
        }

        public void countChars(char wantedChar)
        {
            int counter = 0;
            foreach(var ch in charList)
            {
                if(ch == wantedChar)
                {
                    counter++;
                }
            }
            System.Windows.Forms.MessageBox.Show("Character " + wantedChar + " occurred " + counter + " times.");
        }
    }
}
