using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parchis
{
    class Tablero
    {

        public RichTextBox console;
        public Ficha [] fichas;
        public int turn = -1; // Match not started
        public bool [] enabledPlayers = { true, true, true, true };
        public bool startingCoin = false;
        public int activeDices = -1; // Waiting for dice throw
        public int selectedValue = -1;
        public PictureBox selectedDice = null;
        public Ficha lastSelectedCoin = null;
        public int[] dice;
        public PictureBox tablero, turnCircle, dice0, dice1;
        public Timer gameCheck;
        public Random r;
        public Ficha previewFicha;
        public int doublesInARow = 0;
        public bool wasDouble = false;
        public bool specialMovement = false;

        public Tablero(Ficha [] f, PictureBox t, Timer time, PictureBox circle, PictureBox dice0, PictureBox dice1, Ficha p, RichTextBox c) {
            this.console = c;
            this.fichas = f;
            this.tablero = t;
            this.gameCheck = time;
            this.turnCircle = circle;
            this.dice0 = dice0;
            this.dice1 = dice1;
            this.previewFicha = p;
            this.dice = new int[2];
            this.r = new Random();

            this.tablero.Controls.Add(this.turnCircle);
            this.turnCircle.Visible = false;

            this.tablero.Controls.Add(p.img);

            this.tablero.Controls.Add(dice0);
            this.tablero.Controls.Add(dice1);

            dice0.Location = new Point(296, 345);
            dice1.Location = new Point(341, 345);

            for (int i = 0; i < fichas.Length; i++)
            {
                this.tablero.Controls.Add(fichas[i].img);
                sendHome(this.fichas[i]);
                fichas[i].img.Visible = true;
                fichas[i].img.BringToFront();
            }

            dice0.BringToFront();
            dice1.BringToFront();

        }

        public void stopMatch()
        {

            for (int i=0; i<4; i++)
            {
                setTeamCoins(i, false);
            }

            this.turnCircle.Visible = false;
            this.gameCheck.Enabled = false;
            this.turn = -1;
            this.dice0.Enabled = false;
            this.dice1.Enabled = false;

        }

        public void startMatch() {

            // Move all coins to home
            for (int i = 0; i < this.fichas.Length; i++)
            {
                if (this.fichas[i].pos != -1)
                    sendHome(this.fichas[i]);
                this.fichas[i].img.Enabled = false;
            }

            // Initial turn chosen random
            do { turn = r.Next(0, 4); }
            while (!enabledPlayers[turn]);

            this.turnCircle.Visible = true;
            this.turnCircle.Location = Const.turnLocations[turn];
            this.activeDices = -1;
            this.gameCheck.Enabled = true;

            if (startingCoin)
            {
                for (int i=0; i<4; i++)
                {
                    if (enabledPlayers[i])
                    {
                        newCoin(i);
                    }
                }
            }

        }

        public void nextTurn()
        {

            if (wasDouble) doublesInARow++;
            else
            {
                do { turn = (turn + 1) % 4; }
                while (!enabledPlayers[turn]);

                doublesInARow = 0;
            }

            this.dice0.Enabled = false;
            this.dice1.Enabled = false;
            this.selectedValue = -1;

            this.turnCircle.Location = Const.turnLocations[turn];
            this.activeDices = -1;

        }

        public int hasWon()
        {

            for (int i=0; i<4; i++)
            {
                bool win = true;
                Ficha[] coins = getTeamCoins(i);

                for (int j=0; j<coins.Length && win; j++)
                {
                    if (coins[i].pos != -3)
                    {
                        win = false;
                    }
                }

                if (win) return i;
            }

            return -1;
        }

        public void throwDice()
        {

            log(Locale.diceThrow);

            dice[0] = r.Next(1, 7);
            dice[1] = r.Next(1, 7);

            log(String.Format(Locale.diceResult, dice[0], dice[1]));

            wasDouble = (dice[0] == dice[1]);

            // Check if third double
            if (wasDouble && doublesInARow == 2)
            {
                log(Locale.consecDoubles);
                sendHome(lastSelectedCoin); // Send home last moved coin
                doublesInARow = 0;
                wasDouble = false;
                activeDices = 0;
            } else activeDices = 2;

            setDiceValue(dice[0], dice[1]);
            setTeamCoins(turn, true);

            if (dice[0] == 5 && newCoin(turn))
            {
                activeDices--;
                this.dice0.Enabled = false;
            }
            else if (dice[1] == 5 && newCoin(turn))
            {
                activeDices--;
                this.dice1.Enabled = false;
            }
            else if (dice[0] + dice[1] == 5 && newCoin(turn)) {
                activeDices -= 2;
                this.dice0.Enabled = false;
                this.dice1.Enabled = false;
                log(Locale.diceSumFive);
            }

        }

        public bool canMoveFicha(Ficha f, int amount, Ficha previewFicha)
        {

            if (f.atHome())
            {
                return canMoveHome(f, ((f.pos / 100) + amount), previewFicha);
            }

            // Console.WriteLine("Moving coin of team " + f.team + " with " + amount + " moves.");

            int prev = f.pos;

            int newPos = (f.pos + amount - 1) % Const.cells.Length;
            previewFicha.pos = newPos + 1;
            previewFicha.img.Location = Const.cells[newPos];

            // Entering home
            if ((f.team == Const.RED && prev <= 34 && previewFicha.pos > 34) ||
                (f.team == Const.BLUE && prev <= 17 && previewFicha.pos > 17) ||
                (f.team == Const.YELLOW && prev > 40 && prev <= 68 && (prev + amount) > 68) ||
                (f.team == Const.GREEN && prev <= 51 && previewFicha.pos > 51))
            {
                int amountCasa = (prev + amount - Const.preWinCells[f.team]);

                // Check bridges for path outside home
                if (isBridges(f, Const.preWinCells[f.team]))
                {
                    return false;
                }

                return canMoveHome(f, amountCasa, previewFicha);
            }

            // Si hay puentes (y no en casa), devolver null (false)
            if (isBridges(f, newPos + 1))
            {
                return false;
            }

            return true;

        }

        public bool canMoveHome(Ficha f, int pos, Ficha previewFicha)
        {

            if (isBridgesHome(f, pos))
            {
                return false; // There were bridges, could not move
            }

            if (pos == 8)
            {
                previewFicha.pos = -3;      // Coin has arrived
            }
            else if (pos > 8)
            {
                return false;                // Could not move
            }
            else
            {
                previewFicha.pos = pos * 100; // Pos >= 100 means at home
            }

            previewFicha.img.Location = Const.winPaths[f.team, pos - 1];

            return true;

        }

        public bool canMove(int team)
        {

            Ficha auxFicha = new Ficha(new PictureBox(), -1);

            // Needed in case that there are coins at home
            if (activeDices == -1)
                return true;

            Ficha[] coins = getTeamCoins(team);

            for (int i=0; i<coins.Length; i++)
            {

                if (coins[i].pos >= 1 && (
                    (this.dice0.Enabled && canMoveFicha(coins[i], dice[0], auxFicha)) || 
                    (this.dice1.Enabled && canMoveFicha(coins[i], dice[1], auxFicha)) ||
                    (selectedValue > 0 && canMoveFicha(coins[i], selectedValue, auxFicha)) ))
                {
                    return true;
                }

            }

            log(Locale.noMove);
            return false;

        }

        public void setTeamCoins(int team, bool enabled)
        {

            Ficha[] teamCoins = getTeamCoins(team);

            for (int i=0; i<4; i++)
            {
                if (teamCoins[i].pos > -1)
                    teamCoins[i].img.Enabled = enabled;
            }

        }

        private Ficha [] getTeamCoins(int team)
        {

            Ficha[] teamCoins = new Ficha[4];

            for (int i=0, j=0; i<this.fichas.Length; i++)
            {
                if (this.fichas[i].team == team)
                {
                    teamCoins[j++] = this.fichas[i];
                }
            }

            return teamCoins;

        }

        private void setDiceValue(int val0, int val1)
        {

            if (val0 <= 0 || val0 > 6 || val1 <= 0 || val1 > 6)
            {
                log("Internal error");
                return;
            }

            this.dice0.Enabled = true;
            this.dice1.Enabled = true;

            Bitmap[] dices = {
                Properties.Resources.dice1,
                               Properties.Resources.dice2,
                               Properties.Resources.dice3,
                               Properties.Resources.dice4,
                               Properties.Resources.dice5,
                               Properties.Resources.dice6
                             };

            this.dice0.Image = dices[val0-1];
            this.dice1.Image = dices[val1-1];

        }

        public bool move(Ficha f, int amount)
        {
            specialMovement = false;

            Ficha aux = testPosition(f, amount);
            if (aux == null)
            {
                return false;
            } else
            {

                log("Moving coin of team " + Locale.colors[f.team] + " with " + amount + " moves.");

                // Kill a coin
                if (aux.pos < 100)
                {
                    List<Ficha> l = coinsAt(aux.pos, f.team);
                    if (l.Count() == 1 && 
                        l[0].team != f.team && 
                        !isSegura(aux.pos))
                    {
                        log(String.Format(Locale.coinEat, Locale.colors[f.team], Locale.colors[l[0].team]));
                        sendHome(l[0]);
                        selectedValue = 20;
                        specialMovement = true;
                        log(Locale.move20);
                    }
                }

                lastSelectedCoin = f;
                int prevPos = f.pos;
                f.pos = aux.pos;
                f.img.Location = aux.img.Location;
                fixPos(prevPos, f.team);
                fixPos(f.pos, f.team);

                // Move 10 positions when arriving home
                if (f.pos == -3) {
                    selectedValue = 10;
                    specialMovement = true;
                    log(Locale.coinArrived);
                }

                return true;
            }

        }

        public bool preview(Ficha f, int amount)
        {
            return (testPosition(f, amount) != null);
        }

        public Ficha testPosition(Ficha f, int amount)
        {

            if (f.atHome()) {
                return moveAtHome(f, ((f.pos / 100) + amount));
            }

            int prev = f.pos;

            int newPos = (f.pos + amount - 1) % Const.cells.Length;
            previewFicha.pos = newPos + 1;
            previewFicha.img.Location = Const.cells[newPos];

            // Entering home
            if ((f.team == Const.RED    && prev <= 34   && previewFicha.pos > 34) ||
                (f.team == Const.BLUE   && prev <= 17   && previewFicha.pos > 17) ||
                (f.team == Const.YELLOW && prev > 40    && prev <= 68 && (prev + amount) > 68) ||
                (f.team == Const.GREEN  && prev <= 51   && previewFicha.pos > 51))
            {
                int amountCasa = (prev + amount - Const.preWinCells[f.team]);

                // Check bridges for path outside home
                if (isBridges(f, Const.preWinCells[f.team]))
                {
                    return null;
                }

                return moveAtHome(f, amountCasa);
            }

            // Si hay puentes (y no en casa), devolver null (false)
            if (isBridges(f, newPos + 1))
            {
                return null;
            }

            return this.previewFicha;

        }

        public Ficha moveAtHome(Ficha f, int pos)
        {

            if (isBridgesHome(f, pos))
            {
                return null; // There were bridges, could not move
            }

            if (pos == 8)
            {
                previewFicha.pos = -3;      // Coin has arrived
            } else if (pos > 8)
            {
                return null;                // Could not move
            } else
            {
                previewFicha.pos = pos * 100; // Pos >= 100 means at home
            }

            previewFicha.img.Location = Const.winPaths[f.team, pos - 1];
            
            return this.previewFicha;

        }

        public bool newCoin(int team)
        {

            for (int i=0; i<this.fichas.Length; i++)
            {
                int data = Const.homeCells[team];

                if (this.fichas[i].team == team && 
                    this.fichas[i].pos == -1)
                {

                    bool killed = false;

                    List<Ficha> l = coinsAt(data, -1);
                    if (l.Count() >= 2)
                    {

                        for (int j = 0; j < l.Count() && !killed; j++)
                        {
                            if (l[j].team != team)
                            {
                                sendHome(l[j]);
                                fixPos(data, -1);
                                activeDices++;
                                selectedValue = 20;
                                killed = true;
                                log(Locale.move20);
                            }
                        }

                    }
                    else killed = true;

                    if (!killed) return false;

                    this.fichas[i].pos = data;
                    this.fichas[i].img.Location = Const.cells[data-1];
                    this.fichas[i].img.Enabled = true;
                    fixPos(data, -1);
                    log(Locale.coinOut + Locale.colors[this.fichas[i].team]);
                    return true;
                }

            }

            return false;

        }

        protected void sendHome(Ficha f)
        {

            if (turn != -1 && (f.pos >= 100 || f.pos <= 0))
                return;

            int freeSlot = freeHomeSlot(f.team);

            f.img.Location = Const.homeSlots[f.team, freeSlot];

            f.pos = -1;

        }

        private int freeHomeSlot(int team)
        {

            bool[] slots = new bool[4];

            for (int i=0; i<this.fichas.Length; i++)
            {
                if (this.fichas[i].team == team)
                {
                    if (this.fichas[i].pos == -1) {
                        slots[i % 4] = false;
                    } else {
                        slots[i % 4] = true;
                    }
                } 
            }

            for (int i=0; i<slots.Length; i++) {
                if (slots[i])
                {
                    return i;
                }
            }

            return -1;

        }

        public void fixPos(int pos, int team)
        {

            List<Ficha> coins = coinsAt(pos, team);
            if (coins.Count == 1)
            {
                if (coins[0].atHome())
                {

                    int inPos = (coins[0].pos / 100) - 1;
                    coins[0].img.Location = Const.winPaths[coins[0].team, inPos];

                } else
                {
                    coins[0].img.Location = Const.cells[(coins[0].pos - 1)];
                }
                
            }
            else if (coins.Count == 2)
            {
                Ficha first = coins[0];
                Ficha second = coins[1];

                int posX = first.img.Location.X;
                int posY = first.img.Location.Y;

                // At home
                if (first.atHome() && second.atHome())
                {
                    if (first.team == Const.GREEN || first.team == Const.BLUE)
                    {
                        first.img.Location = new Point(posX, posY + 20);
                        second.img.Location = new Point(posX, posY - 20);
                    }
                    if (first.team == Const.RED || first.team == Const.YELLOW)
                    {
                        first.img.Location = new Point(posX + 20, posY);
                        second.img.Location = new Point(posX - 20, posY);
                    }
                }
                // Normal horizontal
                else if (   (first.pos >= 52 && first.pos <= 59)    || 
                            (first.pos >= 9 && first.pos <= 17)     || 
                            (first.pos >= 18 && first.pos <= 25)    || 
                            (first.pos >= 43 && first.pos <= 51)    )
                {
                    first.img.Location = new Point(posX, posY + 20);
                    second.img.Location = new Point(posX, posY - 20);
                }
                // Normal vertical
                else
                {
                    first.img.Location = new Point(posX + 20, posY);
                    second.img.Location = new Point(posX - 20, posY);
                }

            }
            else return;

        }

        public bool isSegura(int pos)
        {
            int[] seguras = { 5, 12, 17, 22, 29, 34, 39, 46, 51, 56, 63, 68 };

            return Array.Find(seguras, element => element.Equals(pos)) != 0;
        }

        public List<Ficha> coinsAt(int pos, int team) {

            List<Ficha> list = new List<Ficha>();
            if (pos <= 0) return list;

            for (int i = 0; i < this.fichas.Length; i++)
            {

                bool condition;
                if (pos >= 100)
                {
                    condition = this.fichas[i].pos == pos && this.fichas[i].team == team;
                }
                else condition = this.fichas[i].pos == pos;

                if (condition)
                {
                    list.Add(this.fichas[i]);
                }

            }

            return list;

        }

        public bool isBridges(Ficha f, int dest) {

            // Map -> <position, fichasAmount>
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < this.fichas.Length; i++) {

                if (map.ContainsKey(this.fichas[i].pos))
                {
                    map[this.fichas[i].pos]++;
                }
                else map.Add(this.fichas[i].pos, 1);

            }

            int origen = ((f.pos + 1) == 69) ? 1 : (f.pos + 1);
            bool cont = true;
            // log("Scanning from " + origen + " until " + dest);
            for (int i=origen; cont; i++ /*= (i + 1) % Const.cells.Length*/)
            {

                i = (i == 69) ? 1 : i;

                if (map.ContainsKey(i) && map[i] > 1)
                {
                    log("There are bridges at position " + i);
                    return true;
                }

                if (i == dest)
                {
                    cont = false;
                }
            }

            // log("No bridges present");
            return false;

        }

        public bool isBridgesHome(Ficha f, int dest)
        {

            List<Ficha> coins = new List<Ficha>();
                        
            for (int i = 0; i < this.fichas.Length; i++)
            {
                if (this.fichas[i].team == f.team && this.fichas[i].atHome())
                {
                    coins.Add(this.fichas[i]);
                }
            }

            // Iterar camino casa (costoso)
            int currentPos = (f.pos / 100);
            int finalPos = (7 > dest) ? dest : 7;

            for (int i = currentPos+1; i != finalPos+1; i++)
            {
                int amount = 0;
                for (int j = 0; j<coins.Count; j++)
                {
                    int pos = (coins[j].pos / 100);
                    if (pos == i)
                    {
                        amount++;
                    }
                }
                if (amount > 1) {
                    log("There were bridges at position " + i);
                    return true;
                }
            }

            return false;
        }

        public void log(string s)
        {
            Console.WriteLine("MSG: " + s);
            this.console.AppendText(s + "\n");
            // Set the current caret position to the end
            this.console.SelectionStart = this.console.Text.Length;
            // Scroll it automatically
            this.console.ScrollToCaret();
        }

    }
}
