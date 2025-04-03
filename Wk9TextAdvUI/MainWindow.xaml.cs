using System;
using System.Windows;

namespace Wk9TextAdvUI
{
    public partial class MainWindow : Window
    {
        private int lives = 3;
        private int currentStage = 0;
        private bool gameCompleted = false;
        private string playerName;

        private (string story, string choiceA, string choiceB, string choiceC)[] stages =
        {
            ("Welcome to the Mystical Adventure! Enter your name to begin.", "", "", ""),
            ("You approach the rickety bridge...", "Cross carefully", "Look for another path", "Go back"),
            ("You enter the dark cave...", "Use a torch", "Feel your way forward", "Leave the cave"),
            ("You begin climbing the mountain...", "Follow a trail", "Climb directly up", "Turn back"),
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
            lives = 3; // Reset lives
            currentStage = 1; // Start from the first stage
            gameCompleted = false; // Reset game status
            PlayerNameInput.Visibility = Visibility.Visible; // Show the player name input
            StartButton.Visibility = Visibility.Visible; // Show the start button
            StoryText.Text = stages[0].story; // Show the initial story text
            ChoiceAButton.Visibility = Visibility.Hidden; // Hide the choices initially
            ChoiceBButton.Visibility = Visibility.Hidden;
            ChoiceCButton.Visibility = Visibility.Hidden;
        }

        private void RestartGame()
        {
            lives = 3; // Reset lives
            currentStage = 1; // Reset the stage
            gameCompleted = false; // Reset game completion flag
            PlayerNameInput.Visibility = Visibility.Visible; // Show the name input and start button
            StartButton.Visibility = Visibility.Visible;
            StoryText.Text = stages[0].story; // Set the initial story text
            ChoiceAButton.Visibility = Visibility.Hidden; // Hide the choice buttons
            ChoiceBButton.Visibility = Visibility.Hidden;
            ChoiceCButton.Visibility = Visibility.Hidden;
        }

        private void HandleChoice(int choice)
        {
            if (gameCompleted) return;

            if (currentStage == 0)
            {
                playerName = PlayerNameInput.Text == "" ? "Adventurer" : PlayerNameInput.Text; // Use default name if no input
                PlayerNameInput.Visibility = Visibility.Hidden; // Hide name input after starting
                StartButton.Visibility = Visibility.Hidden; // Hide start button after the game starts
                currentStage++; // Move to the next stage
            }
            else if (currentStage < stages.Length - 1)
            {
                // Story update
                StoryText.Text = stages[currentStage].story;

                // Update button choices
                ChoiceAButton.Content = stages[currentStage].choiceA;
                ChoiceBButton.Content = stages[currentStage].choiceB;
                ChoiceCButton.Content = stages[currentStage].choiceC;

                // Show buttons
                ChoiceAButton.Visibility = Visibility.Visible;
                ChoiceBButton.Visibility = Visibility.Visible;
                ChoiceCButton.Visibility = Visibility.Visible;

                currentStage++; // Move to the next stage
            }
            else
            {
                StoryText.Text = $"Congratulations, {playerName}! You've reached the end of your journey.";
                gameCompleted = true;
                ChoiceAButton.Visibility = Visibility.Hidden;
                ChoiceBButton.Visibility = Visibility.Hidden;
                ChoiceCButton.Visibility = Visibility.Hidden;
            }
        }

        private void ChoiceA_Click(object sender, RoutedEventArgs e)
        {
            // Handle choice logic, add consequences here
            if (currentStage == 1) // If wrong choice at stage 1
            {
                lives--;
                if (lives == 0)
                {
                    StoryText.Text = "Game Over! You have no lives left.";
                    gameCompleted = true;
                    ChoiceAButton.Visibility = Visibility.Hidden;
                    ChoiceBButton.Visibility = Visibility.Hidden;
                    ChoiceCButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    StoryText.Text = $"You have {lives} lives remaining. Try again.";
                    HandleChoice(0); // Retry the current stage
                }
            }
            else
            {
                HandleChoice(0); // Move to the next stage based on the choice
            }
        }

        private void ChoiceB_Click(object sender, RoutedEventArgs e)
        {
            // Handle choice logic, add consequences here
            if (currentStage == 1) // If wrong choice at stage 1
            {
                lives--;
                if (lives == 0)
                {
                    StoryText.Text = "Game Over! You have no lives left.";
                    gameCompleted = true;
                    ChoiceAButton.Visibility = Visibility.Hidden;
                    ChoiceBButton.Visibility = Visibility.Hidden;
                    ChoiceCButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    StoryText.Text = $"You have {lives} lives remaining. Try again.";
                    HandleChoice(1); // Retry the current stage
                }
            }
            else
            {
                HandleChoice(1); // Move to the next stage based on the choice
            }
        }

        private void ChoiceC_Click(object sender, RoutedEventArgs e)
        {
            // Handle choice logic, add consequences here
            if (currentStage == 1) // If wrong choice at stage 1
            {
                lives--;
                if (lives == 0)
                {
                    StoryText.Text = "Game Over! You have no lives left.";
                    gameCompleted = true;
                    ChoiceAButton.Visibility = Visibility.Hidden;
                    ChoiceBButton.Visibility = Visibility.Hidden;
                    ChoiceCButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    StoryText.Text = $"You have {lives} lives remaining. Try again.";
                    HandleChoice(2); // Retry the current stage
                }
            }
            else
            {
                HandleChoice(2); // Move to the next stage based on the choice
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Use the buttons to make your choices. Try to reach the end of the game!");
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RestartGame_Click(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }
    }
}
