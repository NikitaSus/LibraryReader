using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace LibraryReader
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnBookCardClick(object sender, MouseButtonEventArgs e)
        {
            Border clickedBorder = sender as Border;
            if (clickedBorder != null)
            {
                StackPanel stackPanel = clickedBorder.Child as StackPanel;
                if (stackPanel != null)
                {
                    TextBlock titleBlock = stackPanel.Children[1] as TextBlock;
                    TextBlock authorBlock = stackPanel.Children[2] as TextBlock;

                    string bookTitle = titleBlock?.Text;
                    string bookAuthor = authorBlock?.Text;

                    BookTextWindow bookTextWindow = new BookTextWindow();
                    if (bookTitle == "Идиот" && bookAuthor == "Фёдор Достоевский")
                    {
                        string filePath = "C:/Users/suspi/source/repos/LibraryReader/res/Idiot.txt"; // Путь к файлу с текстом книги
                        bookTextWindow.SetBookContent(bookTitle, bookAuthor, filePath);
                    }
                    // Добавьте обработку для других книг, если необходимо
                    bookTextWindow.Show();
                }
            }
        }

    }
}
