using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Threading;
using System.Windows.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace memoire
{
    [Serializable]
    public class Player
    {
        public String playerName { get; set; }
        public int playerScore { get; set; }
        public int pairs { get; set; }
        public Boolean[] check { get; set; }
        public String[] pics { get; set; }

        public Boolean[] checkedButton;

        public Player()
            {
            this.playerScore = 0;
            checkedButton = new Boolean[] { false, false, false };
            }

       



    }
    /// <summary>
    /// Initializing the Main Window creating variables for our window
    /// </summary>
    /// playerScore-keeps track of score
    /// scores-keeps track of leaderboard scores
    /// dir- contains directory path
    /// check- to check if image has been matched
    /// squares- containing images relating to the cards seen
    /// pairs-keeps track of pairs matched
    /// sel1, sel2- used to keep track of the position of the card within any arrays
    /// pics-keeps the source paths of the images
    /// gameTimer-keeps track of time
    ///  beginWasClicked-keep track wether the game is running
    ///  levels keeps track of the buttons being checked

    public partial class MainWindow : Window
    {
        //private int playerScore;
        //private Boolean[] check;
        
        //private String[] pics;
       // private int pairs;

       //private String PlayerName;

        private Image[] squares;

        private int[] scores;

        private List<String> LeaderboardNames;

        private String dir;

        private int sel1 = -1;

        private int sel2 = -1;

        DispatcherTimer gameTimer;

        int increment;

        DispatcherTimer pause;

        int inc;

        Player player = new Player();

        Boolean beginWasClicked;

        RadioButton[] levels;

        Boolean stopClicked;

        //initializing everything created above.
        public MainWindow()
        {
            InitializeComponent();

            scores = new int[3];

            LeaderboardNames = new List<String>();

            dir = System.IO.Directory.GetCurrentDirectory();

            squares = new Image[] { sq1, sq2, sq3, sq4, sq5, sq6, sq7, sq8, sq9, sq10, sq11, sq12 };

            player.check = new Boolean[] { false, false, false, false, false, false, false, false, false, false, false, false };

            player.pairs = 0;

            player.pics = new string[] { "naruto.png", "goku.png", "meliodas.png", "deku.png", "kaneki.png", "soul.png", "naruto.png", "goku.png", "meliodas.png", "deku.png", "kaneki.png", "soul.png" };

            Set_Timer();

            levels = new RadioButton[] { lvl1rb, lvl2rb, lvl3rb };

            lvl1rb.IsChecked = true;

            stopClicked = false;

            beginWasClicked = false;

            Leaderboard();

        }


        /// <summary>
        /// All squares_MouseLeftButton Down contain the same method calls corresponding to their own.
        /// </summary>
        /// sq# relating to the image and its source
        /// 
        ///
        private void Sq1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sq1.IsEnabled = false;

            sq1.Source = new BitmapImage(new Uri(player.pics[0], UriKind.Relative));

            Set_Selected(0);

            if (sel1 != -1 && sel2 != -1)
            {
                checkGame();
            }
        }

        private void Sq2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sq2.IsEnabled = false;

            sq2.Source = new BitmapImage(new Uri(player.pics[1], UriKind.Relative));

            Set_Selected(1);

            if (sel1 != -1 && sel2 != -1)
            {
                checkGame();
            }
        }

        private void Sq3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sq3.IsEnabled = false;

            sq3.Source = new BitmapImage(new Uri(player.pics[2], UriKind.Relative));

            Set_Selected(2);

            if (sel1 != -1 && sel2 != -1)
            {
                checkGame();
            }
        }

        private void Sq4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sq4.IsEnabled = false;

            sq4.Source = new BitmapImage(new Uri(player.pics[3], UriKind.Relative));

            Set_Selected(3);

            if (sel1 != -1 && sel2 != -1)
            {
                checkGame();
            }
        }

        private void Sq5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sq5.IsEnabled = false;

            sq5.Source = new BitmapImage(new Uri(player.pics[4], UriKind.Relative));

            Set_Selected(4);

            if (sel1 != -1 && sel2 != -1)
            {
                checkGame();
            }
        }

        private void Sq6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sq6.IsEnabled = false;

            sq6.Source = new BitmapImage(new Uri(player.pics[5], UriKind.Relative));

            Set_Selected(5);

            if (sel1 != -1 && sel2 != -1)
            {
                checkGame();
            }
        }

        private void Sq7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sq7.IsEnabled = false;

            sq7.Source = new BitmapImage(new Uri(player.pics[6], UriKind.Relative));

            Set_Selected(6);

            if (sel1 != -1 && sel2 != -1)
            {
                checkGame();
            }
        }

        private void Sq8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sq8.IsEnabled = false;

            sq8.Source = new BitmapImage(new Uri(player.pics[7], UriKind.Relative));

            Set_Selected(7);

            if (sel1 != -1 && sel2 != -1)
            {
                checkGame();
            }
        }

        private void Sq9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sq9.IsEnabled = false;

            sq9.Source = new BitmapImage(new Uri(player.pics[8], UriKind.Relative));

            Set_Selected(8);

            if (sel1 != -1 && sel2 != -1)
            {
                checkGame();
            }
        }

        private void Sq10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sq10.IsEnabled = false;

            sq10.Source = new BitmapImage(new Uri(player.pics[9], UriKind.Relative));

            Set_Selected(9);

            if (sel1 != -1 && sel2 != -1)
            {
                checkGame();
            }
        }

        private void Sq11_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sq11.IsEnabled = false;

            sq11.Source = new BitmapImage(new Uri(player.pics[10], UriKind.Relative));

            Set_Selected(10);

            if (sel1 != -1 && sel2 != -1)
            {
                checkGame();
            }
        }

        private void Sq12_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sq12.IsEnabled = false;

            sq12.Source = new BitmapImage(new Uri(player.pics[11], UriKind.Relative));

            Set_Selected(11);

            if (sel1 != -1 && sel2 != -1)
            {
                checkGame();
            }
        }
        /// <summary>
        /// Randomizer takes in a String array of pictures, to randmoize the order of them.
        /// </summary>
        /// <param name="pics"> String array containing pictures</param>
        public static void Randomizer(string[] pics)
        {

            Random ran = new Random();

            for (int i = 0; i < pics.Length - 1; i++)
            {
                int r = ran.Next(i, pics.Length);

                String temp = pics[r];
                pics[r] = pics[i];
                pics[i] = temp;
            }
        }
        /// <summary>
        /// Checks to see if game is over by matching the number of pairs collected
        /// pairs are collected by comparing the source of pic1 and pic2, stopping the timer to not allow from pics to be selected
        /// </summary>
        public void checkGame()
        {
            Deny_Tap();

            pause.Start();

            if (player.pics[sel1].Equals(player.pics[sel2]))
            {
                player.pairs++;

                pause.Stop();


                player.check[sel1] = true;
                player.check[sel2] = true;

                Tap_Unmatched();

                sel1 = -1;
                sel2 = -1;


            }


            if (player.pairs == 6)
            {
                gameTimer.Stop();
                player.playerScore = int.Parse(timelbl.Content.ToString());


                System.Windows.MessageBox.Show("YOU WIN!!");

                CalcScore();
                updateFiles();
                Leaderboard();
            }

        }


        /// <summary>
        /// Writing to files to update the score and leaderboard, using streamWriter to write to the text file.
        /// </summary>
        private void updateFiles()
        {
            System.IO.StreamWriter fileWriteLName = new System.IO.StreamWriter(dir + @"\LeaderBoard.txt");
            for (int i = 0; i < 3; i++)
            {
                fileWriteLName.WriteLine(LeaderboardNames.ElementAt(i));
            }

            fileWriteLName.Close();
        }

        /// <summary>
        /// Calculates the players score and putting against the current Leaderboard holders.
        /// </summary>
        private void CalcScore()
        {
            for (int i = 0; i < 3; i++)
            {
                String temp = LeaderboardNames.ElementAt(i);
                temp = temp.Substring(temp.Length - 3, 3);
                scores[i] = Int32.Parse(temp);
            }
            if (player.playerScore < scores[0])
            {
                LeaderboardNames.Insert(0, Name.Text + " " + player.playerScore);
            }
            else if (player.playerScore < scores[1])
            {
                LeaderboardNames.Insert(1, Name.Text + " " + player.playerScore);
            }
            else if (player.playerScore < scores[2])
            {
                LeaderboardNames.Insert(2, Name.Text + " " + player.playerScore);
            }
            else
            {
                System.Windows.MessageBox.Show("YOU DIDN'T PLACE ON THE LEADERBOARD");


            }
        }

        /// <summary>
        /// Updating the leaderboard by reading from the files and inputing them into the leaderboard.
        /// </summary>
        private void Leaderboard()
        {
            System.IO.StreamReader fileReadLeader = new System.IO.StreamReader(dir + @"\Leaderboard.txt");

            for (int i = 0; i < 3; i++)
            {
                LeaderboardNames.Add(fileReadLeader.ReadLine());
            }

            First.Content = LeaderboardNames.ElementAt(0);
            Second.Content = LeaderboardNames.ElementAt(1);
            Third.Content = LeaderboardNames.ElementAt(2);
            fileReadLeader.Close();
        }

        /// <summary>
        /// set selected values to positions clicked by the user
        /// </summary>
        /// <param name="pos"> number of the card selected</param>
        private void Set_Selected(int pos)
        {

            if (sel1 == -1)
            {
                sel1 = pos;
            }
            else if (sel2 == -1)
            {
                sel2 = pos;
            }
        }
        /// <summary>
        /// Begins time when the beginbtn is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Beginbtn_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(Name.Text.Trim()) == false)
            {
                Allow_Tap();

                beginWasClicked = true;

                stopClicked = false;


                gameTimer.Start();
            }
            else
            {
                MessageBox.Show("Please enter your name in the textbox above");
            }


        }


        private void gameTimer_Tick(object sender, EventArgs e)
        {

            increment++;
            timelbl.Content = increment;
        }

        private void Pause_Tick(object sender, EventArgs e)
        {
            inc++;

            if (pause.IsEnabled)
            {
                pause.Stop();


                squares[sel1].Source = new BitmapImage(new Uri("square.jpg", UriKind.Relative));

                squares[sel2].Source = new BitmapImage(new Uri("square.jpg", UriKind.Relative));



                sel1 = -1;
                sel2 = -1;

                if (player.pairs == 0)
                {
                    Allow_Tap();
                }
                else
                {
                    Tap_Unmatched();
                }


            }
        }

        /// <summary>
        /// Only allowing the stopbtn to be clicked when the start button has already been clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stopbtn_Click(object sender, RoutedEventArgs e)
        {
            if (beginWasClicked)
            {
                gameTimer.Stop();
                player.playerScore = Int32.Parse(timelbl.Content.ToString());
                stopClicked = true;
            }
        }
        /// <summary>
        /// Allowing all cards to be clicked
        /// </summary>
        private void Allow_Tap()
        {
            foreach (Image i in squares)
            {
                i.IsEnabled = true;
            }
        }
        /// <summary>
        /// Denying all cards to be clicked until beginbtn is clicked.
        /// </summary>
        private void Deny_Tap()
        {
            foreach (Image i in squares)
            {
                i.IsEnabled = false;
            }
        }
        /// <summary>
        /// Permtting all cards to be clicked except for the ones to be matched.
        /// </summary>
        /// <param name="permit"></param>
        private void Permit_Some_Tap(Boolean permit)
        {
            for (int i = 0; i < squares.Length; i++)
            {
                if (squares[i] != squares[sel1] && squares[i] != squares[sel2])
                {

                    squares[i].IsEnabled = permit;
                }
            }
        }

        private void Tap_Unmatched()
        {
            for (int i = 0; i < player.check.Length; i++)
            {
                if (player.check[i] == false)
                {
                    squares[i].IsEnabled = true;
                }
            }
        }
        /// <summary>
        /// The following methods change the flip speed corresponding to the radio buttons aka LvL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lvl1rb_Checked(object sender, RoutedEventArgs e)
        {
            Store_Level(0);
            Restart();
            Flip_Speed(1000);

            
             
        }
        private void Lvl2rb_Checked(object sender, RoutedEventArgs e)
        {
            Store_Level(1);
            Restart();
            Flip_Speed(500);

            
        }

        private void Lvl3rb_Checked(object sender, RoutedEventArgs e)
        {
            Store_Level(2);
            Restart();
            Flip_Speed(250);

           
        }

        private void Store_Level(int index)
        {
            for (int i = 0; i < player.checkedButton.Length; i++)
            {
                if (i == index)
                {
                    player.checkedButton[i] = true;
                }
             
            }
        }

        private void Face_Down()
        {
            foreach (Image i in squares)
            {
                i.Source = new BitmapImage(new Uri("square.jpg", UriKind.Relative));
            }
        }

        /// <summary>
        /// takes in an int and changes the speed at which the card shows its image
        /// </summary>
        /// <param name="flip"></param>
        private void Flip_Speed(int flip)
        {
            pause = new DispatcherTimer();
            pause.Interval = new TimeSpan(0, 0, 0, 0, flip);

            inc = 0;
            pause.Tick += Pause_Tick;
        }
        private void setInc(int num)
        {
            increment = num;
        }
        /// <summary>
        /// Resets all values to begin the game with a fresh start
        /// </summary>
        private void Restart()
        {
            gameTimer.Stop();
            Face_Down();
            Set_Timer();

            player.pairs = 0;
            Deny_Tap();
            for (int i = 0; i < player.check.Length; i++)
            {
                player.check[i] = false;

            }



            Randomizer(player.pics);



        }
        private void Set_Timer()
        {
            gameTimer = new DispatcherTimer();

            gameTimer.Interval = new TimeSpan(0, 0, 1);

            timelbl.Content = 0;

            gameTimer.Tick += gameTimer_Tick;

            increment = 0;
        }
        /// <summary>
        /// calls the restart method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Restartbtn_Click(object sender, RoutedEventArgs e)
        {
            Restart();
        }

        /// <summary>
        /// saves players game state
        /// </summary>

        private void Save()
        {
            if (stopClicked == true)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream output = new FileStream(dir + @"\Save.ser", FileMode.Open, FileAccess.Write);
                formatter.Serialize(output, player);
                output.Close();
            }
            else
            {
                MessageBox.Show("Click on stop before you save");
            }
        }


        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        /// <summary>
        /// loads players game state
        /// </summary>
        private void Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream input = new FileStream(dir + @"\Save.ser", FileMode.Open, FileAccess.Read);
            Player playerUpd=(Player)formatter.Deserialize(input);
            input.Close();
           
            Name.Text = playerUpd.playerName;
            
            for(int i = 0; i < levels.Length; i++)
            {
                levels[i].IsChecked = player.checkedButton[i];
            }

            timelbl.Content = playerUpd.playerScore;
            player.check = playerUpd.check;
            player.pics = playerUpd.pics;
            player.pairs = playerUpd.pairs;
            increment = playerUpd.playerScore;
            updSqs();
            
        }

        private void updSqs(){

            for (int i = 0; i< squares.Length; i++)
            {
                if (player.check[i])
                {
                    squares[i].Source = new BitmapImage(new Uri(player.pics[i], UriKind.Relative));
                }
            }
        }

        private void Loadbtn_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            player.playerName = Name.Text;
        }
    }

        
}
