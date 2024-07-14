using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreBoardApplication
{
    public partial class ScoreBoardForm : Form
    {
        private IController controller;
        private Label scoreBoardTitleLabel;
        private Font scoreBoardTitleFont = new Font(FontFamily.GenericSerif, 24f);
        private Label homeTeamScoreLabel; // Create score Label for home team
        private Label awayTeamScoreLabel; // Create score Label for away team
        private Font scoreLabelFont = new Font(FontFamily.GenericSerif, 20f);
        private TextBox homeTeamNameTextBox; // Create TextBox for home team
        private TextBox awayTeamNameTextBox; // Create TextBox for away team
        private Button buildScoreBoardButton; // Create Configure ScoreBoard Button
        private Button scoreBoardCloseButton; // Create Close ScoreBoard Button
        private TextBox updateScore; // Create TextBox for score update
        private Button updateHomeTeamScoreButton; // Create Update Button for home team score
        private Button updateAwayTeamScoreButton; // Create Update Button for away team score

        public ScoreBoardForm(IController controller)
        {
            InitializeComponent();
            this.controller = controller;
            LoadControls();
            //this.Resize += ScoreBoard_Resize;

        } // end constructor ScoreBoardForm()

        private void LoadControls()
        {
            AddScoreBoardTitle();
            AddHomeTeamScoreLabel();
            AddAwayTeamScoreLabel();
            AddHomeTeamNameTextBox();
            AddAwayTeamNameTextBox();
            AddBuildScoreButton();
            LoadCloseFormButton();
            AddUpdateScoreBoardTextBox();
            LoadUpdateHomeTeamScoreButton();
            LoadUpdateAwayTeamScoreButton();

        } // end method LoadControls()

        private void AddScoreBoardTitle()
        {
            int relativeWidth = Convert.ToInt32(this.ClientSize.Width * .33);
            scoreBoardTitleLabel = new Label();
            scoreBoardTitleLabel.Size = new Size((relativeWidth * 2), 50);
            scoreBoardTitleLabel.BorderStyle = BorderStyle.FixedSingle;
            scoreBoardTitleLabel.Font = scoreBoardTitleFont;
            scoreBoardTitleLabel.BackColor = Color.White;
            scoreBoardTitleLabel.Location = new Point(Convert.ToInt32(relativeWidth * .5), 10);
            scoreBoardTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            scoreBoardTitleLabel.Text = "The Big Match";
            this.Controls.Add(scoreBoardTitleLabel);

        } // end method AddScoreBoardTitle()

        private Label DesignScoreLabel()
        {
            Label scoreLabelDesign = new Label();
            scoreLabelDesign.Size = new Size(70, 70);   
            scoreLabelDesign.Text = $"--";
            scoreLabelDesign.Font = scoreLabelFont;
            scoreLabelDesign.Top = scoreBoardTitleLabel.Bottom + 25;
            scoreLabelDesign.TextAlign = ContentAlignment.MiddleCenter;

            return scoreLabelDesign;

        } // end method DesignScoreLabel()

        private void AddHomeTeamScoreLabel()
        {
            homeTeamScoreLabel = DesignScoreLabel();
            homeTeamScoreLabel.Location = new Point(150, homeTeamScoreLabel.Top);
            this.Controls.Add(homeTeamScoreLabel);

        } // end method AddHomeTeamScoreLabel()

        private void AddAwayTeamScoreLabel()
        {
            awayTeamScoreLabel = DesignScoreLabel();
            awayTeamScoreLabel.Left = homeTeamScoreLabel.Right + 350;
            this.Controls.Add(awayTeamScoreLabel);

        } // end method AddHomeTeamScoreLabel()

        private void AddHomeTeamNameTextBox()
        {
            homeTeamNameTextBox = new TextBox();
            homeTeamNameTextBox.Size = new Size(190, 50);
            homeTeamNameTextBox.Location = new Point(25, 250);
            homeTeamNameTextBox.PlaceholderText = "Enter home team name";
            this.Controls.Add(homeTeamNameTextBox);

        } // end method AddHomeTeamNameTextBox()

        private void AddAwayTeamNameTextBox()
        {
            awayTeamNameTextBox = new TextBox();
            awayTeamNameTextBox.Size = new Size(190, 50);
            awayTeamNameTextBox.Location = new Point(25, 313);
            awayTeamNameTextBox.PlaceholderText = "Enter away team name";
            this.Controls.Add(awayTeamNameTextBox);

        } // end method AddAwayTeamNameTextBox()

        private void AddBuildScoreButton()
        {
            buildScoreBoardButton = new Button();
            buildScoreBoardButton.Text = "Configure ScoreBoard";
            buildScoreBoardButton.Size = new Size(180, 50);
            buildScoreBoardButton.Location = new Point(25, 375);
            buildScoreBoardButton.Click += BuildScoreButton_Click;
            this.Controls.Add(buildScoreBoardButton);

        } // end method AddBuildScoreButton()

        private void LoadCloseFormButton()
        {
            scoreBoardCloseButton = new Button();
            scoreBoardCloseButton.Text = "Close Scoreboard";
            scoreBoardCloseButton.Size = new Size(180, 50);
            scoreBoardCloseButton.Location = new Point(600, 375);
            scoreBoardCloseButton.Click += CloseScoreBoardFrom_Click;
            this.Controls.Add(scoreBoardCloseButton);

        } // end method LoadCloseFormButton()

        private void BuildScoreButton_Click(object sender, EventArgs e)
        {
            if (controller.CheckTeamNamesValid(homeTeamNameTextBox.Text, awayTeamNameTextBox.Text))
            {
                scoreBoardTitleLabel.Text = controller.GetScoreBoardTitle();
                buildScoreBoardButton.Visible = false;
                homeTeamNameTextBox.Visible = false;
                awayTeamNameTextBox.Visible = false;
                updateScore.Visible = true;
                updateHomeTeamScoreButton.Visible = true;
                updateAwayTeamScoreButton.Visible = true;
                homeTeamScoreLabel.BorderStyle = BorderStyle.FixedSingle;
                awayTeamScoreLabel.BorderStyle = BorderStyle.FixedSingle;
                homeTeamScoreLabel.BackColor = Color.White;
                awayTeamScoreLabel.BackColor = Color.White;
                homeTeamScoreLabel.Text = $"{controller.HomeTeamScore}";
                awayTeamScoreLabel.Text = $"{controller.AwayTeamScore}";
            }
            else
            {
                MessageBox.Show(caption:"Error", text:controller.ErrorMessage, icon:MessageBoxIcon.Exclamation, buttons:MessageBoxButtons.OK);
            }

        } // end method BuildScoreButton_Click()

        private void CloseScoreBoardFrom_Click(object sender, EventArgs e)
        {
            this.Close();

        } // end method CloseScoreBoardFrom_Click(object sender, EventArgs e)

        private void AddUpdateScoreBoardTextBox()
        {
            updateScore = new TextBox();
            updateScore.Size = new Size(190, 50);
            updateScore.Location = new Point(25, 250);
            updateScore.Visible = false;
            this.Controls.Add(updateScore);
        }

        private void LoadUpdateHomeTeamScoreButton()
        {
            updateHomeTeamScoreButton = new Button();
            updateHomeTeamScoreButton.Text = "Update Home";
            updateHomeTeamScoreButton.Size = new Size(180, 50);
            updateHomeTeamScoreButton.Location = new Point(25, 315);
            updateHomeTeamScoreButton.Click += UpdateHomeTeamScore_Click;
            updateHomeTeamScoreButton.Visible = false;
            this.Controls.Add(updateHomeTeamScoreButton);

        } // end method BuildUpdateHomeTeamScoreButton()

        private void UpdateHomeTeamScore_Click(object sender, EventArgs e)
        {
            if (controller.CheckScoreEntryIsValid(updateScore.Text))
            {
                controller.EditHomeTeamScore(int.Parse(updateScore.Text));
                homeTeamScoreLabel.Text = controller.HomeTeamScore.ToString();
            }
            else
            {
                MessageBox.Show(caption:"Error", text:controller.ErrorMessage, icon:MessageBoxIcon.Exclamation, buttons:MessageBoxButtons.OK);
            }

        } // end method UpdateHomeTeamScore_Click()

        private void LoadUpdateAwayTeamScoreButton()
        {
            updateAwayTeamScoreButton = new Button();
            updateAwayTeamScoreButton.Text = "Update Away";
            updateAwayTeamScoreButton.Size = new Size(180, 50);
            updateAwayTeamScoreButton.Location = new Point(25, 375);
            updateAwayTeamScoreButton.Click += UpdateAwayTeamScore_Click;
            updateAwayTeamScoreButton.Visible = false;
            this.Controls.Add(updateAwayTeamScoreButton);

        } // end method BuildUpdateAwayScoreButton()

        private void UpdateAwayTeamScore_Click(object sender, EventArgs e)
        {
            if (controller.CheckScoreEntryIsValid(updateScore.Text))
            {
                controller.EditAwayTeamScore(int.Parse(updateScore.Text));
                awayTeamScoreLabel.Text = controller.AwayTeamScore.ToString();
            }
            else
            {
                MessageBox.Show(caption:"Error", text:controller.ErrorMessage, icon:MessageBoxIcon.Exclamation, buttons:MessageBoxButtons.OK);
            }

        } // end method UpdateAwayTeamScore_Click()

    } // end class ScoreBoardForm

} // end namespace ScoreBoardApplication