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
                if ((fileStream = openFileDialog.OpenFile()) != null)
                {
                    using (fileStream)
                    {
                        StreamReader streamReader = new StreamReader(fileStream);
                        while (streamReader.Peek() >= 0)
                        {
                            textList.Add((char)streamReader.Read());
                        };

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
    }
}
