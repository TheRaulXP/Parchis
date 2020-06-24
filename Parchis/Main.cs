using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parchis
{
    public partial class Main : Form
    {

        Tablero t;

        public Main()
        {

            InitializeComponent();

            Ficha[] fichas = {
                new Ficha(redCoin1,     Const.RED),
                new Ficha(redCoin2,     Const.RED),
                new Ficha(redCoin3,     Const.RED),
                new Ficha(redCoin4,     Const.RED),
                new Ficha(blueCoin1,    Const.BLUE),
                new Ficha(blueCoin2,    Const.BLUE),
                new Ficha(blueCoin3,    Const.BLUE),
                new Ficha(blueCoin4,    Const.BLUE),
                new Ficha(greenCoin1,   Const.GREEN),
                new Ficha(greenCoin2,   Const.GREEN),
                new Ficha(greenCoin3,   Const.GREEN),
                new Ficha(greenCoin4,   Const.GREEN),
                new Ficha(yellowCoin1,  Const.YELLOW),
                new Ficha(yellowCoin2,  Const.YELLOW),
                new Ficha(yellowCoin3,  Const.YELLOW),
                new Ficha(yellowCoin4,  Const.YELLOW)
            };

            StartMatch.Text = Locale.startButton;
            initialCoin.Text = Locale.startingCoin;
            skipTurn.Text = Locale.skipButton;
            turnOf.Text = Locale.turnOf;
            DiceButton.Text = Locale.diceButton;

            redLabel1.Text = Locale.red;
            blueLabel1.Text = Locale.blue;
            yellowLabel1.Text = Locale.yellow;
            greenLabel1.Text = Locale.green;

            enableRed.Text = Locale.enabled;
            enableBlue.Text = Locale.enabled;
            enableYellow.Text = Locale.enabled;
            enableGreen.Text = Locale.enabled;

            t = new Tablero(fichas, Tablero, gameCheck, currentTurn, diceGraph0, diceGraph1, new Ficha(auxFicha, -1), consoleLogs);

            Tablero.Controls.Add(blur0);
            Tablero.Controls.Add(blur1);

            blur0.Location = new Point(296, 305);
            blur1.Location = new Point(341, 305);

            blur0.Visible = false;
            blur1.Visible = false;

        }

        private void StartMatch_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show((t.turn == -1) ? Locale.startMessage : Locale.stopMessage, Locale.gameName, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (t.turn == -1)
                {
                    t.startMatch();
                    t.log(Locale.startLogMessage);
                    t.log(String.Format(Locale.whoStarts, Locale.colors[t.turn]));
                    StartMatch.Text = Locale.stop;

                    DiceButton.Enabled = true;

                    skipTurn.Enabled = true;
                    initialCoin.Enabled = false;

                    enableRed.Enabled = false;
                    enableBlue.Enabled = false;
                    enableGreen.Enabled = false;
                    enableYellow.Enabled = false;
                } else
                {
                    t.stopMatch();
                    t.log(Locale.stopLogMessage);
                    StartMatch.Text = Locale.startButton;

                    DiceButton.Enabled = false;

                    blur0.Visible = false;
                    blur1.Visible = false;

                    skipTurn.Enabled = false;
                    initialCoin.Enabled = true;

                    enableRed.Enabled = true;
                    enableBlue.Enabled = true;
                    enableGreen.Enabled = true;
                    enableYellow.Enabled = true;
                }
                
            }
            else if (dialogResult == DialogResult.No)
            {
                t.log(Locale.cancelOperation);
            }

        }

        private void InitialCoin_CheckedChanged(object sender, EventArgs e)
        {
            t.startingCoin = initialCoin.Checked;
        }

        private void PasaTurno_Tick(object sender, EventArgs e)
        {
            int win = t.hasWon();
            if (win != -1)
            {
                t.stopMatch();
                t.log(Locale.theWinnerIs + Locale.colors[win] + "!");
                StartMatch.Text = Locale.startButton;

                DiceButton.Enabled = false;

                blur0.Visible = false;
                blur1.Visible = false;

                skipTurn.Enabled = false;
                initialCoin.Enabled = true;

                enableRed.Enabled = true;
                enableBlue.Enabled = true;
                enableGreen.Enabled = true;
                enableYellow.Enabled = true;
            }

            if (t.turn != -1)
            {
                turnLabel.Text = Locale.colors[t.turn];
            }

            if ((t.activeDices == 0 && t.selectedValue <= 0) || !t.canMove(t.turn))
            {
                blur0.Visible = false;
                blur1.Visible = false;
                t.setTeamCoins(t.turn, false);
                t.nextTurn();
                DiceButton.Enabled = true;
            }
        }

        private void EnableRed_CheckedChanged(object sender, EventArgs e)
        {
            t.enabledPlayers[3] = enableRed.Checked;
        }

        private void EnableGreen_CheckedChanged(object sender, EventArgs e)
        {
            t.enabledPlayers[0] = enableGreen.Checked;
        }

        private void EnableBlue_CheckedChanged(object sender, EventArgs e)
        {
            t.enabledPlayers[2] = enableBlue.Checked;
        }

        private void EnableYellow_CheckedChanged(object sender, EventArgs e)
        {
            t.enabledPlayers[1] = enableYellow.Checked;
        }

        private void SkipTurn_Click(object sender, EventArgs e)
        {
            t.activeDices = 0;
            t.selectedValue = -1;
        }

        private void DiceButton_Click(object sender, EventArgs e)
        {
            t.throwDice();
            DiceButton.Enabled = false;
        }

        private void DiceGraph0_Click(object sender, EventArgs e)
        {
            t.specialMovement = false;
            blur0.Visible = true;
            blur1.Visible = false;
            t.selectedValue = t.dice[0];
            t.selectedDice = diceGraph0;
            t.log(String.Format(Locale.diceSelect, 0) + String.Format(Locale.diceValue, t.selectedValue));
        }

        private void DiceGraph1_Click(object sender, EventArgs e)
        {
            t.specialMovement = false;
            blur0.Visible = false;
            blur1.Visible = true;
            t.selectedValue = t.dice[1];
            t.selectedDice = diceGraph1;
            t.log(String.Format(Locale.diceSelect, 1) + String.Format(Locale.diceValue, t.selectedValue));
        }

        private int getCoin(object sender)
        {
            if (/* t.selectedDice == null || */ t.selectedValue < 1 || !((PictureBox)sender).Enabled) { return -1; }

            string name = ((PictureBox)sender).Name;
            int id = Int32.Parse(name.Substring(name.Length - 1));
            string team = name.Substring(0, name.IndexOf("Coin"));

            int baseID = -2;

            // Index of the array to select corresponding coins
            switch (team)
            {
                case "blue":
                    baseID = 3;
                    break;
                case "red":
                    baseID = -1;
                    break;
                case "green":
                    baseID = 7;
                    break;
                case "yellow":
                    baseID = 11;
                    break;
            }

            return baseID + id;
        }

        private void CoinClick(object sender, EventArgs e)
        {

            int coin = getCoin(sender);
            if (coin == -1) return;

            if (t.fichas[coin].pos <= 0 || t.fichas[coin].team != t.turn)
                return;

            if (t.move(t.fichas[coin], t.selectedValue))
            {
                if (t.selectedDice != null) {
                    t.selectedDice.Enabled = false;
                    t.selectedDice = null;
                }
                if (!t.specialMovement)
                {
                    t.selectedValue = -1;
                    t.activeDices--;
                }
            }

        }

        private void PreviewCoin(object sender, EventArgs e)
        {

            int coin = getCoin(sender);
            if (coin == -1) return;

            if (t.fichas[coin].pos <= 0 || t.fichas[coin].team != t.turn)
                return;

            if (t.preview(t.fichas[coin], t.selectedValue))
            {
                auxFicha.Visible = true;
            }

        }

        private void HidePreviewCoin(object sender, EventArgs e)
        {
            auxFicha.Visible = false;
        }

    }

}
