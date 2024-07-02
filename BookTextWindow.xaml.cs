using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryReader
{
    /// <summary>
    /// Логика взаимодействия для BookTextWindow.xaml
    /// </summary>
    public partial class BookTextWindow : Window
    {
        private List<string> pages;
        private int currentPage;

        public BookTextWindow()
        {
            InitializeComponent();
            pages = new List<string>();
            currentPage = 0;
        }

        public void SetBookContent(string title, string author, string filePath)
        {
            BookTitle.Text = title;
            BookAuthor.Text = author;
            LoadBookContent(filePath);
            DisplayPage(currentPage);
        }

        private void LoadBookContent(string filePath) 
        {
            if (File.Exists(filePath)) 
            { 
                string bookText = File.ReadAllText(filePath);
                int charsPerPage = 1000;

                for (int i = 0; i < bookText.Length; i += charsPerPage)
                {
                    pages.Add(bookText.Substring(i, Math.Min(charsPerPage, bookText.Length - i)));
                }
            }
        }

        private void DisplayPage(int pageNumber)
        {
            if (pageNumber >= 0 && pageNumber < pages.Count)
            {
                BookContent.Text = pages[pageNumber];
                PageNumber.Text = $"{pageNumber + 1} / {pages.Count}";
                ReadingProgress.Value = (double)(pageNumber + 1) / pages.Count * 100;
            }
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                DisplayPage(currentPage);
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage < pages.Count - 1)
            {
                currentPage++;
                DisplayPage(currentPage);
            }
        }
    }
}
