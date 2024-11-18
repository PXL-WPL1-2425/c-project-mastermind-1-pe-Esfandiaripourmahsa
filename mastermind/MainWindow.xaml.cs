using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace mastermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string[] codeColors = { "Red", "Orange", "Yellow", "Green", "White", "Blue" };
        private string[] generatedCode = new string[4];
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();      
            GenerateRandomCode();
            NewTitle();

            //  timer.Tick += StartCountDown; 
            // timer.Interval = new TimeSpan(0, 0, 1); 
            // timer.Start();

        }

        private void StartCountDown(object sender, EventArgs e)
        {
            //timeLabel.Content = $"{DateTime.Now.ToLongTimeString()}";
        }


        private int currentAttempt = 0;


        private void GenerateRandomCode()
        {
            Random random = new Random();
            generatedCode = new string[4];

            for (int i = 0; i < 4; i++)
            {
                generatedCode[i] = codeColors[random.Next(codeColors.Length)];
            }
            

        }
        private void NewTitle()
        {

            //Title = "MasterMind  /  Code: ( " + string.Join(" , ", generatedCode)+" )";
            Title = $"MasterMind - Poging {currentAttempt}";
        }

        private Brush BrushColor(string colorName)

        {
            switch (colorName)
            {
                case "Red":
                    return Brushes.Red;
                case "Orange":
                    return Brushes.Orange;
                case "Yellow":
                    return Brushes.Yellow;
                case "Green":
                    return Brushes.Green;
                case "White":
                    return Brushes.White;
                case "Blue":
                    return Brushes.Blue;
                default:
                    return Brushes.Transparent;


            }
        }

            private void color1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (color1.SelectedItem is ComboBoxItem selectedItem && selectedItem.Content is string colorName) 
            {
                color1Label.Background = BrushColor(colorName);
            
            }
        }

        private void color2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (color2.SelectedItem is ComboBoxItem selectedItem && selectedItem.Content is string colorName)
            {
                color2Label.Background = BrushColor(colorName);
            }

        }

        private void color3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (color3.SelectedItem is ComboBoxItem selectedItem && selectedItem.Content is string colorName)
            {
                color3Label.Background = BrushColor(colorName);
            }
        }

        private void color4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (color4.SelectedItem is ComboBoxItem selectedItem && selectedItem.Content is string colorName)
            {
                color4Label.Background = BrushColor(colorName);
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            string guess1 = (color1.SelectedItem as ComboBoxItem)?.Content.ToString() ?? string.Empty;
            string guess2 = (color2.SelectedItem as ComboBoxItem)?.Content.ToString() ?? string.Empty;
            string guess3 = (color3.SelectedItem as ComboBoxItem)?.Content.ToString() ?? string.Empty;
            string guess4 = (color4.SelectedItem as ComboBoxItem)?.Content.ToString() ?? string.Empty;

            CheckGuesses(guess1, guess2, guess3, guess4);
            currentAttempt++;
            NewTitle();

        }
        
        
        private void ClearBorder()
        {
            color1Label.BorderBrush = Brushes.Transparent;
            color2Label.BorderBrush = Brushes.Transparent;
            color3Label.BorderBrush = Brushes.Transparent;
            color4Label.BorderBrush = Brushes.Transparent;
        }

        private void CheckGuesses(string guess1, string guess2, string guess3, string guess4)
        {
           List<string?> guesses = new List<string?> { guess1, guess2, guess3, guess4 };

            string?[] copy = (string?[])generatedCode.Clone();
            ClearBorder();



            for (int i = 0; i < guesses.Count; i++)
            {
                if (guesses[i] == copy[i] && guesses[i] != null && copy[i] != null)
                {
                    GetLabel(i).BorderBrush = Brushes.DarkRed;
                    GetLabel(i).BorderThickness = new Thickness(2);
                    copy[i] = null;
                    guesses[i]= null;
                }
                else if (guesses[i] != null && copy.Contains(guesses[i]))
                {

                    GetLabel(i).BorderBrush = Brushes.Wheat;
                    GetLabel(i).BorderThickness = new Thickness(2);

                }
            }
            

        }

        
        private Label? GetLabel(int Index)
        {
            switch (Index)
            {
                case 0: return color1Label.Child as Label;
                case 1: return color2Label.Child as Label;
                case 2:return color3Label.Child as Label;
                case 3: return color4Label.Child as Label;
                default:return null;
            }


        }
    }
}