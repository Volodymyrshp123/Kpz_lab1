using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Game2048Lib;
using _2048ClassLibrary;

namespace Game2048WinForms
{
    public partial class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel tableLayoutPanel1;
        private Label scoreLabel;
        private Label timeLabel;
        private GameBoard game;
        private ScoreCounter scoreCounter;
        private Label[,] labels;
        private Stopwatch stopwatch;
        private System.Windows.Forms.Timer timer;

        public MainForm()
        {
            InitializeComponent();
            game = new GameBoard();
            scoreCounter = new ScoreCounter();
            labels = new Label[GameConfig.BoardSize, GameConfig.BoardSize];
            stopwatch = new Stopwatch();
            stopwatch.Start();

            InitializeBoard();
            InitializeTimer();
            UpdateUI();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.scoreLabel = new Label();
            this.timeLabel = new Label();

            this.timeLabel.Text = "Time: 00:00";
            this.timeLabel.Dock = DockStyle.Top;
            this.timeLabel.Font = new Font("Times New Roman", 14, FontStyle.Italic);
            this.timeLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.timeLabel.Padding = new Padding(15, -1, 0, 5);

            this.scoreLabel.Text = "Score: 0";
            this.scoreLabel.Dock = DockStyle.Top;
            this.scoreLabel.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            this.scoreLabel.TextAlign = ContentAlignment.MiddleCenter;

            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.RowCount = 4;
            for (int i = 0; i < 4; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }
            this.tableLayoutPanel1.Dock = DockStyle.Fill;

            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timeLabel);
            this.Name = "MainForm";
            this.Text = "2048";
            this.ClientSize = GameConfig.WindowSize;
            this.ResumeLayout(false);
        }
private void HandleVictory()
{
    timer.Stop();
    stopwatch.Stop();
    var result = MessageBox.Show(
        $"You Win! Time: {stopwatch.Elapsed.Minutes:D2}:{stopwatch.Elapsed.Seconds:D2}\nRestart?",
        "Victory", MessageBoxButtons.YesNo);

    if (result == DialogResult.Yes)
        Application.Restart();
    else
        this.Close();
}
private void HandleGameOver()
{
    timer.Stop();
    stopwatch.Stop();
var result = MessageBox.Show("Game Over! ... Restart?", "Game Over", MessageBoxButtons.YesNo);
if (result == DialogResult.Yes)
    Application.Restart();
else
    this.Close();

}
        private void InitializeBoard()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    Label lbl = new Label
                    {
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Times New Roman", 24, FontStyle.Bold),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.White
                    };
                    tableLayoutPanel1.Controls.Add(lbl, j, i);
                    labels[i, j] = lbl;
                }
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {
                var elapsed = stopwatch.Elapsed;
                timeLabel.Text = $"Time: {elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
            };
            timer.Start();
        }

        private Color GetColorForValue(int value)
        {
            return value switch
            {
                2 => Color.LightYellow,
                4 => Color.Khaki,
                8 => Color.Orange,
                16 => Color.OrangeRed,
                32 => Color.Red,
                64 => Color.DarkRed,
                128 => Color.Purple,
                256 => Color.MediumPurple,
                512 => Color.Blue,
                1024 => Color.DarkBlue,
                2048 => Color.Gold,
                _ => Color.WhiteSmoke,
            };
        }

        private void UpdateUI()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    int value = game.Board[i, j];
                    labels[i, j].Text = value == 0 ? "" : value.ToString();
                    labels[i, j].BackColor = GetColorForValue(value);
                }
        }

        private void UpdateScore(int points)
        {
            scoreCounter.AddPoints(points);
            scoreLabel.Text = $"Score: {scoreCounter.TotalScore}";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int points = 0;
            bool moved = false;

            switch (keyData)
            {
                case Keys.Left:
                    moved = game.MoveLeft(out points); break;
                case Keys.Right:
                    moved = game.MoveRight(out points); break;
                case Keys.Up:
                    moved = game.MoveUp(out points); break;
                case Keys.Down:
                    moved = game.MoveDown(out points); break;
            }

           if (game.Has2048Tile())
{
    HandleVictory();
    return true;
}

if (!game.CanMove())
{
    HandleGameOver();
}

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
