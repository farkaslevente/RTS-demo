using System.ComponentModel;
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

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        public string playerChoice { get; set; }
        public string botChoice { get; set; }
        public Status status { get; set; } = new Status();
        public MainWindow()
        {            
            InitializeComponent();
            this.DataContext = status;
            PlayerFighter.Source = new BitmapImage(new Uri("images/rock.png", UriKind.Relative));
            playerChoice = "images/rock.png";
        }

        private void BTNRock_Click(object sender, RoutedEventArgs e)
        {
            PlayerFighter.Source = new BitmapImage(new Uri("images/rock.png", UriKind.Relative));
            playerChoice = "images/rock.png";
        }

        private void BTNPaper_Click(object sender, RoutedEventArgs e)
        {
            PlayerFighter.Source = new BitmapImage(new Uri("images/paper.png", UriKind.Relative));
            playerChoice = "images/paper.png";
        }

        private void BTNScissors_Click(object sender, RoutedEventArgs e)
        {
            PlayerFighter.Source = new BitmapImage(new Uri("images/scissors.png", UriKind.Relative));
            playerChoice = "images/scissors.png";
        }

        private void BTNBattle_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int RPS = random.Next(1, 3);
            switch (RPS)
            {
                case 1:
                    BotFighter.Source = new BitmapImage(new Uri("images/rock.png", UriKind.Relative));
                    botChoice = "images/rock.png";
                    break;
                case 2:
                    BotFighter.Source = new BitmapImage(new Uri("images/paper.png", UriKind.Relative));
                    botChoice = "images/paper.png";
                    break;
                case 3:
                    BotFighter.Source = new BitmapImage(new Uri("images/scissors.png", UriKind.Relative));
                    botChoice = "images/scissors.png";
                    break;
            }
            status.WhoWon(playerChoice,botChoice);
        }

       
    }

    public class Status: INotifyPropertyChanged
    {
        private int _playerScore;
        private int _botScore;

        public int PlayerScore
        {
            get { return _playerScore; }
            set
            {
                if (_playerScore != value)
                {
                    _playerScore = value;
                    OnPropertyChanged(nameof(PlayerScore));
                }
            }
        }

        public int BotScore
        {
            get { return _botScore; }
            set
            {
                if (_botScore != value)
                {
                    _botScore = value;
                    OnPropertyChanged(nameof(BotScore));
                }
            }
        }


        public Status()
        {
            PlayerScore = 0;
            BotScore = 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void WhoWon(string PC, string BC)
        {
            if (PC == BC)
            {

            }
            else if (PC == "images/paper.png" && BC == "images/rock.png")
            {
                PlayerScore++;
            }
            else if (PC == "images/rock.png" && BC == "images/scissors.png")
            {
                PlayerScore++;
            }
            else if (PC == "images/scissors.png" && BC == "images/paper.png")
            {
                PlayerScore++;
            }
            else if (PC == "images/paper.png" && BC == "images/scissors.png")
            {
                BotScore++;
            }
            else if (PC == "images/rock.png" && BC == "images/paper.png")
            {
                BotScore++;
            }
            else if (PC == "images/scissors.png" && BC == "images/rock.png")
            {
                BotScore++;
            }           

        }
    }
}