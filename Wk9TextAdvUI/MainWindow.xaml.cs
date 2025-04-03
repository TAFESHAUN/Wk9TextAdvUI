using System;
using System.Windows;

namespace Wk9TextAdvUI
{
    public partial class MainWindow : Window
    {
        private int lives;
        private int currentStage;
        private bool gameCompleted;
        private string playerName;

        private (string story, string choiceA, string choiceB, string choiceC)[] stages =
        {
            ("Welcome to the Mystical Adventure! Enter your name to begin.", "", "", ""),
            ("You approach the rickety bridge.", "Cross carefully", "Look for another path", "Go back"),
            ("You enter the dark cave.", "Use a torch", "Feel your way forward", "Leave the cave"),
            ("You begin climbing the mountain.", "Follow a trail", "Climb directly up", "Turn back"),
            ("You face a warrior at the bridge. What do you do?", "Fight", "Talk", "Run"),
            ("The cave is dark. How do you proceed?", "Use a lantern", "Feel the walls", "Shout for help"),
            ("The mountain is steep. Choose your path wisely.", "Take the rope path", "Find a tunnel", "Climb with bare hands")
        };

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            lives = 3;
            currentStage = 0;
            gameCompleted = false;
            StoryText.Text = stages[0].story;
            PlayerNameInput.Visibility = Visibility.Visible;
            StartButton.Visibility = Visibility.Visible;
            ChoiceAButton.Visibility = Visibility.Hidden;
            ChoiceBButton.Visibility = Visibility.Hidden;
            ChoiceCButton.Visibility = Visibility.Hidden;
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            playerName = string.IsNullOrWhiteSpace(PlayerNameInput.Text) ? "Adventurer" : PlayerNameInput.Text;
            PlayerNameInput.Visibility = Visibility.Hidden;
            StartButton.Visibility = Visibility.Hidden;
            currentStage = 1;
            UpdateStory();
        }

        private void RestartGame_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void HandleChoice(int choice)
        {
            if (gameCompleted) return;

            if (currentStage >= stages.Length - 1)
            {
                StoryText.Text = $"Congratulations, {playerName}! You've completed your journey.";
                gameCompleted = true;
                HideChoiceButtons();
                return;
            }

            if (choice == 2) // Assume choice C is always a wrong choice
            {
                lives--;
                if (lives == 0)
                {
                    StoryText.Text = "Game Over! You have no lives left.";
                    gameCompleted = true;
                    HideChoiceButtons();
                    return;
                }
                else
                {
                    StoryText.Text = $"Wrong choice! You have {lives} lives remaining.";
                }
            }

            currentStage++;
            UpdateStory();
        }

        private void UpdateStory()
        {
            StoryText.Text = stages[currentStage].story;
            ChoiceAButton.Content = stages[currentStage].choiceA;
            ChoiceBButton.Content = stages[currentStage].choiceB;
            ChoiceCButton.Content = stages[currentStage].choiceC;
            ShowChoiceButtons();
        }

        private void ChoiceA_Click(object sender, RoutedEventArgs e) => HandleChoice(0);
        private void ChoiceB_Click(object sender, RoutedEventArgs e) => HandleChoice(1);
        private void ChoiceC_Click(object sender, RoutedEventArgs e) => HandleChoice(2);

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Use the buttons to make choices. Try to reach the end!");
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowChoiceButtons()
        {
            ChoiceAButton.Visibility = Visibility.Visible;
            ChoiceBButton.Visibility = Visibility.Visible;
            ChoiceCButton.Visibility = Visibility.Visible;
        }

        private void HideChoiceButtons()
        {
            ChoiceAButton.Visibility = Visibility.Hidden;
            ChoiceBButton.Visibility = Visibility.Hidden;
            ChoiceCButton.Visibility = Visibility.Hidden;
        }
    }
}
