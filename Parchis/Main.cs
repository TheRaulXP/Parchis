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

        private static int[] lastDice = new int[2];
        private static bool inGame = false;
        private int selectedValue = 0;
        private int turn = 0;
        private int activeDices = -1;
        private int consecDoubles = 0;

        // Jugadores activados
        private bool[] enabledPlayers = { true, true, true, true };

        // Fichas en juego
        private int[] active = { 0, 0, 0, 0 };

        // Fichas ganadoras
        private int[] atHome = { 0, 0, 0, 0 };

        Ficha v1, v2, v3, v4, am1, am2, am3, am4, az1, az2, az3, az4, r1, r2, r3, r4;

        Ficha lastClicked;

        Ficha f1;

        private void SacaFicha_Click(object sender, EventArgs e)
        {
            sacarFicha(Convert.ToInt32(textBox4.Text));
        }

        public Main()
        {

            InitializeComponent();

            StartMatch.Text = Locale.startButton;
            label1.Text = Locale.turnOf;
            skipTurn.Text = Locale.skipButton;
            initialCoin.Text = Locale.startingCoin;
            DiceButton.Text = Locale.diceButton;

            enableGreen.Text = Locale.enabled;
            enableRed.Text = Locale.enabled;
            enableBlue.Text = Locale.enabled;
            enableYellow.Text = Locale.enabled;

            infoLabel.Text = Locale.info;

            lastClicked = null;
            f1 = new Ficha(auxFicha, -1, Const.VERDE);

            v1 = new Ficha(fVerde1, -1, Const.VERDE);
            v2 = new Ficha(fVerde2, -1, Const.VERDE);
            v3 = new Ficha(fVerde3, -1, Const.VERDE);
            v4 = new Ficha(fVerde4, -1, Const.VERDE);

            am1 = new Ficha(fAmarilla1, -1, Const.AMARILLA);
            am2 = new Ficha(fAmarilla2, -1, Const.AMARILLA);
            am3 = new Ficha(fAmarilla3, -1, Const.AMARILLA);
            am4 = new Ficha(fAmarilla4, -1, Const.AMARILLA);

            az1 = new Ficha(fAzul1, -1, Const.AZUL);
            az2 = new Ficha(fAzul2, -1, Const.AZUL);
            az3 = new Ficha(fAzul3, -1, Const.AZUL);
            az4 = new Ficha(fAzul4, -1, Const.AZUL);

            r1 = new Ficha(fRoja1, -1, Const.ROJA);
            r2 = new Ficha(fRoja2, -1, Const.ROJA);
            r3 = new Ficha(fRoja3, -1, Const.ROJA);
            r4 = new Ficha(fRoja4, -1, Const.ROJA);

            updateStats();

        }

        private void matchStart() {

            Random r = new Random();
            do { turn = r.Next(0, 4); }
            while (!enabledPlayers[turn]);
            label2.Text = typeToString(turn);
            log(String.Format(Locale.whoStarts, typeToString(turn)));
            inGame = true;

            active[0] = 0;
            active[1] = 0;
            active[2] = 0;
            active[3] = 0;

            enableGreen.Enabled = false;
            enableYellow.Enabled = false;
            enableRed.Enabled = false;
            enableBlue.Enabled = false;

            greenCount.Text = Locale.wonCoins + "0";
            redCount.Text = Locale.wonCoins + "0";
            yellowCount.Text = Locale.wonCoins + "0";
            blueCount.Text = Locale.wonCoins + "0";

            PasaTurno.Enabled = true;
            DiceButton.Enabled = true;
            initializeBoard();

            if (initialCoin.Checked) {
                sacarFicha(Const.VERDE);
                sacarFicha(Const.AZUL);
                sacarFicha(Const.AMARILLA);
                sacarFicha(Const.ROJA);
            }

            updateStats();

        }

        private String typeToString(int t) {
            switch (t) {
                case Const.VERDE:
                    return Locale.green;
                case Const.AZUL:
                    return Locale.blue;
                case Const.ROJA:
                    return Locale.red;
                case Const.AMARILLA:
                    return Locale.yellow;
            }

            return null;

        }

        // f.Pos == -1 (En Casa)
        private bool sacarFicha(int t) {

            int initPos = 0;

            switch (t) {
                case Const.VERDE:
                    initPos = 55;
                    break;
                case Const.ROJA:
                    initPos = 38;
                    break;
                case Const.AZUL:
                    initPos = 21;
                    break;
                case Const.AMARILLA:
                    initPos = 4;
                    break;
            }
            
            Ficha[] pos = typeArray(t);

            // Mata fichas en base al sacar
            if (coinsInPoint(Const.casilla[initPos])>1) {

                Ficha matar = findCoin(Const.casilla[initPos]);

                if (matar == null) {
                    return false;
                }

                placeHome(matar);
                //log(Locale.theCoin + typeToString(turn) + Locale.coinEaten + typeToString(matar.Type));
                log(String.Format(Locale.coinEat, typeToString(turn), typeToString(matar.Type)));
                selectedValue = 20;
                activeDices++;
                enableCoins(turn);
                log(Locale.move20);

                return true;
            }

            bool found = false;
            for (int i = 0; i < 4 && !found; i++) {
                if (pos[i].Pos == -1) {
                    pos[i].Img.Location = Const.casilla[initPos];
                    pos[i].Pos = initPos;
                    fixCoins(Const.casilla[initPos]);
                    active[t]++;
                    return true;
                }
            }

            return false;

        }

        private void changeCoins(bool e) {

            Ficha[] fichas = { v1, v2, v3, v4, am1, am2, am3, am4, az1, az2, az3, az4, r1, r2, r3, r4 };

            for (int i = 0; i < fichas.Length; i++) {
                fichas[i].Img.Enabled = e;
            }

            
            if (!e) activeDices--;

        }

        private void enableCoins(int type) {

            Ficha[] fichas = typeArray(type);

            for (int i = 0; i < fichas.Length; i++)
            {
                if (fichas[i].Pos>=0 && !fichas[i].Won) fichas[i].Img.Enabled = true;
            }

        }

        private void diceGraph0_Click(object sender, EventArgs e)
        {
            selectedValue = lastDice[0];
            blur0.Visible = true;
            blur1.Visible = false;
            diceGraph0.Enabled = false;
            if (selectedValue == 5 && sacarFicha(turn))
            {
                // log("Dice 0 selected, coin added");
                log(String.Format(Locale.diceSelect + Locale.diceCoinAdd, 0));
                activeDices--;
            }
            else
            {
                enableCoins(turn);
                // log("Dice 0 selected with value " + selectedValue + ", select a coin");
                log(String.Format(Locale.diceSelect + Locale.diceValue, 0, selectedValue));
            }

        }

        private void diceGraph1_Click(object sender, EventArgs e)
        {
            selectedValue = lastDice[1];
            blur1.Visible = true;
            blur0.Visible = false;
            diceGraph1.Enabled = false;
            if (selectedValue == 5 && sacarFicha(turn))
            {
                // log("Dice 1 selected, coin added");
                log(String.Format(Locale.diceSelect + Locale.diceCoinAdd, 1));
                activeDices--;
            }
            else
            {
                enableCoins(turn);
                // log("Dice 1 selected with value " + selectedValue + ", select a coin");
                log(String.Format(Locale.diceSelect + Locale.diceValue, 1, selectedValue));
            }
        }

        private void fVerde4_Click(object sender, EventArgs e)
        {
            coinClick(v4);
        }

        private void fVerde1_Click(object sender, EventArgs e)
        {
            coinClick(v1);
        }

        private void fVerde3_Click(object sender, EventArgs e)
        {
            coinClick(v3);
        }

        private void fVerde2_Click(object sender, EventArgs e)
        {
            coinClick(v2);
        }

        private void fAmarilla1_Click(object sender, EventArgs e)
        {
            coinClick(am1);
        }

        private void fAmarilla2_Click(object sender, EventArgs e)
        {
            coinClick(am2);
        }

        private void fAmarilla3_Click(object sender, EventArgs e)
        {
            coinClick(am3);
        }

        private void fAmarilla4_Click(object sender, EventArgs e)
        {
            coinClick(am4);
        }

        private void fAzul1_Click(object sender, EventArgs e)
        {
            coinClick(az1);
        }

        private void fAzul2_Click(object sender, EventArgs e)
        {
            coinClick(az2);
        }

        private void fAzul3_Click(object sender, EventArgs e)
        {
            coinClick(az3);
        }

        private void fAzul4_Click(object sender, EventArgs e)
        {
            coinClick(az4);
        }

        private void fRoja1_Click(object sender, EventArgs e)
        {
            coinClick(r1);
        }

        private void fRoja2_Click(object sender, EventArgs e)
        {
            coinClick(r2);
        }

        private void fRoja3_Click(object sender, EventArgs e)
        {
            coinClick(r3);
        }

        private void fRoja4_Click(object sender, EventArgs e)
        {
            coinClick(r4);
        }

        private void coinClick(Ficha f) {

            // MessageBox.Show("You clicked!");

            lastClicked = f;

            if (!isBridges(f.Pos, (selectedValue + f.Pos) % 68))
            {
                if (f.Pos != -1) moveFicha(f, selectedValue);
                changeCoins(false);
            }
            else
            {
                log(Locale.bridgesPresent);
            }

        }

        private void PasaTurno_Tick(object sender, EventArgs e)
        {

            if (activeDices == 0) {
                if (lastDice[0] != lastDice[1])
                {
                    turn = (turn + 1) % 4;

                    while (!enabledPlayers[turn]) {
                        turn = (turn + 1) % 4;
                    }

                    consecDoubles = 0;
                }
                else consecDoubles++;
                label2.Text = typeToString(turn);
                DiceButton.Enabled = true;
                blur0.Visible = false;
                blur1.Visible = false;
                activeDices = -1;

                currentTurn.Location = Const.turnLocations[turn];
            }
            updateStats();
            winnerExists();
        }

        
        private void updateStats() {

            Label[] atH = { atHGreen, atHYellow, atHBlue, atHRed };
            Label[] activeC = { activeGreen, activeYellow, activeBlue, activeRed };

            int[] notOut = new int[4];

            for (int i = 0; i < 4; i++) {

                Ficha[] fic = typeArray(i);

                for (int j = 0; j < 4; j++) {
                    if (fic[j].Pos == -1) notOut[i]++;
                }
                 
            }

            for (int i = 0; i < 4; i++) {

                int activeCount = 4 - atHome[i] - notOut[i];
                int atHomeCount = notOut[i];

                atH[i].Text = Locale.atHCoin + atHomeCount;
                activeC[i].Text = Locale.activeCoin + active[i];

            }

        }

        private void skipTurn_Click(object sender, EventArgs e)
        {
            // Fix other dice when a dice is clicked but there is no coin available
            activeDices = 0;
        }

        private void killCoin_Click(object sender, EventArgs e)
        {
            placeHome(am1);
        }

        /* Deprecated, implemented in sacarFicha()
        private Ficha twoCoinsHome(int t) {

            int casilla = 0;
            switch (t)
            {
                case Const.VERDE:
                    casilla = 55;
                    break;
                case Const.ROJA:
                    casilla = 38;
                    break;
                case Const.AZUL:
                    casilla = 21;
                    break;
                case Const.AMARILLA:
                    casilla = 4;
                    break;
            }

            if (coinsInPoint(Const.casilla[casilla])==1) return null;

            return null;
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            if (isBridges(Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text)))
                label3.Text = "True";
            else label3.Text = "False";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = "Hay " + coinsInPoint(Const.casilla[Convert.ToInt32(textBox7.Text)]) + " fichas.";
        }

        private int coinsInPoint(Point c) {

            Ficha[] fichas = { v1, v2, v3, v4, am1, am2, am3, am4, az1, az2, az3, az4, r1, r2, r3, r4, f1 };

            Point p1 = new Point(c.X + 20, c.Y);
            Point p2 = new Point(c.X - 20, c.Y);

            Point p3 = new Point(c.X, c.Y + 20);
            Point p4 = new Point(c.X, c.Y - 20);

            int count = 0;

            for (int i = 0; i < fichas.Length; i++)
            {
                if (fichas[i].Img.Location.Equals(c)) { count++; }
                if (fichas[i].Img.Location.Equals(p1)) { count++; }
                if (fichas[i].Img.Location.Equals(p2)) { count++; }
                if (fichas[i].Img.Location.Equals(p3)) { count++; }
                if (fichas[i].Img.Location.Equals(p4)) { count++; }
            }

            return count;

        }

        private Ficha findCoin(Point c)
        {

            Ficha[] fichas = { v1, v2, v3, v4, am1, am2, am3, am4, az1, az2, az3, az4, r1, r2, r3, r4, f1 };

            Point p1 = new Point(c.X + 20, c.Y);
            Point p2 = new Point(c.X - 20, c.Y);

            Point p3 = new Point(c.X, c.Y + 20);
            Point p4 = new Point(c.X, c.Y - 20);

            for (int i = 0; i < fichas.Length; i++)
            {
                if (fichas[i].Img.Location.Equals(c) && fichas[i].Type != turn) { return fichas[i]; }
                if (fichas[i].Img.Location.Equals(p1) && fichas[i].Type != turn) { return fichas[i]; }
                if (fichas[i].Img.Location.Equals(p2) && fichas[i].Type != turn) { return fichas[i]; }
                if (fichas[i].Img.Location.Equals(p3) && fichas[i].Type != turn) { return fichas[i]; }
                if (fichas[i].Img.Location.Equals(p4) && fichas[i].Type != turn) { return fichas[i]; }
            }

            return null;

        }

        private int numCasilla(Point p) {

            int pos = -1;

            for (int i=0; i<Const.casilla.Length; i++) {
                if (Const.casilla[i].Equals(p)) { pos = i; break; }
            }

            return pos;
        }

        private bool isSegura(Point p) {

            int[] seguras = { 4, 11, 16, 21, 30, 38, 45, 50, 55, 62, 67 };
            int casilla = numCasilla(p);

            for (int i = 0; i < seguras.Length; i++) {
                if (casilla == seguras[i]) return true;
            }

            return false;
        }

        private void fixCoins(Point c) {

            Ficha[] fichas = { v1, v2, v3, v4, am1, am2, am3, am4, az1, az2, az3, az4, r1, r2, r3, r4, f1 };

            int count = coinsInPoint(c);

            // logDebug("Habia " + count + " fichas en la casilla.");
            logDebug(String.Format(Locale.debugCoinsCount, count));

            if (count > 1) {

                Ficha first = null;
                Ficha second = null;

                for (int i = 0; i < fichas.Length; i++)
                {
                    if (fichas[i].Img.Location.Equals(c)) { first = fichas[i]; break; }
                }

                for (int i = fichas.Length - 1; i >= 0; i--)
                {
                    if (fichas[i].Img.Location.Equals(c)) { second = fichas[i]; break; }
                }

                int posX = first.Img.Location.X;
                int posY = first.Img.Location.Y;

                if (isSegura(c) || (first.Type == second.Type)) {
                    // At home
                    if (first.HomeRoad && second.HomeRoad) {
                        if (first.Type == Const.VERDE || first.Type == Const.AZUL)
                        {
                            first.Img.Location = new Point(posX, posY + 20);
                            second.Img.Location = new Point(posX, posY - 20);
                        }
                        if (first.Type == Const.ROJA || first.Type == Const.AMARILLA)
                        {
                            first.Img.Location = new Point(posX + 20, posY);
                            second.Img.Location = new Point(posX - 20, posY);
                        }
                    }
                    // Normal Horizontal
                    else if ((first.Pos >= 51 && first.Pos <= 58) || (first.Pos >= 8 && first.Pos <= 15) || (first.Pos >= 17 && first.Pos <= 24) || (first.Pos >= 42 && first.Pos <= 49))
                    {
                        first.Img.Location = new Point(posX, posY + 20);
                        second.Img.Location = new Point(posX, posY - 20);
                    }
                    // Normal Vertical
                    else
                    {
                        first.Img.Location = new Point(posX + 20, posY);
                        second.Img.Location = new Point(posX - 20, posY);
                    }
                }

            }
            if (count == 1) {

                Point p1 = new Point(c.X + 20, c.Y);
                Point p2 = new Point(c.X - 20, c.Y);

                Point p3 = new Point(c.X, c.Y + 20);
                Point p4 = new Point(c.X, c.Y - 20);

                for (int i = 0; i < fichas.Length; i++) {
                    if (fichas[i].Img.Location.Equals(p1)) { fichas[i].Img.Location = c; }
                    if (fichas[i].Img.Location.Equals(p2)) { fichas[i].Img.Location = c; }
                    if (fichas[i].Img.Location.Equals(p3)) { fichas[i].Img.Location = c; }
                    if (fichas[i].Img.Location.Equals(p4)) { fichas[i].Img.Location = c; }
                }

            }

        }

        private void EnableRed_CheckedChanged(object sender, EventArgs e)
        {
            if (enableRed.Checked) enabledPlayers[3] = true;
            else enabledPlayers[3] = false;
        }

        private void EnableBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (enableBlue.Checked) enabledPlayers[2] = true;
            else enabledPlayers[2] = false;
        }

        private void EnableGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (enableGreen.Checked) enabledPlayers[0] = true;
            else enabledPlayers[0] = false;
        }

        private void EnableYellow_CheckedChanged(object sender, EventArgs e)
        {
            if (enableYellow.Checked) enabledPlayers[1] = true;
            else enabledPlayers[1] = false;
        }

        private void initializeBoard() {

            Ficha[] fichas = { v1, v2, v3, v4, am1, am2, am3, am4, az1, az2, az3, az4, r1, r2, r3, r4 };

            Tablero.Controls.Add(diceGraph0);
            Tablero.Controls.Add(blur0);

            Tablero.Controls.Add(currentTurn);
            currentTurn.Visible = true;
            currentTurn.Location = Const.turnLocations[turn];

            Tablero.Controls.Add(diceGraph1);
            Tablero.Controls.Add(blur1);

            diceGraph0.Location = new Point(296, 345);
            diceGraph1.Location = new Point(341, 345);

            blur0.Visible = false;
            blur1.Visible = false;

            blur0.Location = new Point(296, 305);
            blur1.Location = new Point(341, 305);

            for (int i = 0; i < fichas.Length; i++)
            {
                Tablero.Controls.Add(fichas[i].Img);
                fichas[i].Img.Location = new Point(0, 0);
                placeHome(fichas[i]);
                fichas[i].Img.Visible = true;
                fichas[i].Img.BringToFront();
            }

        }

        private Ficha[] typeArray(int t) {

            Ficha[] posVerde = { v1, v2, v3, v4 };
            Ficha[] posAmarilla = { am1, am2, am3, am4 };
            Ficha[] posAzul = { az1, az2, az3, az4 };
            Ficha[] posRoja = { r1, r2, r3, r4 };

            switch (t) {
                case Const.VERDE:
                    return posVerde;
                case Const.AZUL:
                    return posAzul;
                case Const.AMARILLA:
                    return posAmarilla;
                case Const.ROJA:
                    return posRoja;
            }

            return null;

        }

        // Modificar para tener posiciones (Ficha [])
        private void placeHome(Ficha f) {

            Ficha[] pos = typeArray(f.Type);
            Point[] home = new Point[4];

            switch (f.Type) {
                case Const.VERDE:
                    home = Const.homeVerde;
                    break;
                case Const.AMARILLA:
                    home = Const.homeAmarilla;
                    break;
                case Const.AZUL:
                    home = Const.homeAzul;
                    break;
                case Const.ROJA:
                    home = Const.homeRoja;
                    break;
            }

            if (active[f.Type]>0) active[f.Type]--;

            for (int i = 0; i < home.Length; i++)
            {
                bool empty = true;
                for (int j = 0; j < pos.Length && empty; j++)
                {
                    if (home[i].Equals(pos[j].Img.Location)) { empty = false; }
                }
                if (empty) {
                    f.Img.Location = home[i];
                    f.Pos = -1;
                    return;
                }
                
            }
                
        }

        private void throwDice() {

            Random r = new Random();

            activeDices = 2;

            log(Locale.diceThrow);

            diceGraph0.Visible = true;
            diceGraph1.Visible = true;

            int[] dice = new int[2];

            dice[0] = r.Next(1, 7);
            dice[1] = r.Next(1, 7);

            // log(Locale.diceResult1 + dice[0] + Locale.diceResult2 + dice[1]);
            log(String.Format(Locale.diceResult, dice[0], dice[1]));

            switch (dice[0]) {
                case 1:
                    diceGraph0.Image = Properties.Resources.dice1;
                    break;
                case 2:
                    diceGraph0.Image = Properties.Resources.dice2;
                    break;
                case 3:
                    diceGraph0.Image = Properties.Resources.dice3;
                    break;
                case 4:
                    diceGraph0.Image = Properties.Resources.dice4;
                    break;
                case 5:
                    diceGraph0.Image = Properties.Resources.dice5;
                    break;
                case 6:
                    diceGraph0.Image = Properties.Resources.dice6;
                    break;
            }

            switch (dice[1])
            {
                case 1:
                    diceGraph1.Image = Properties.Resources.dice1;
                    break;
                case 2:
                    diceGraph1.Image = Properties.Resources.dice2;
                    break;
                case 3:
                    diceGraph1.Image = Properties.Resources.dice3;
                    break;
                case 4:
                    diceGraph1.Image = Properties.Resources.dice4;
                    break;
                case 5:
                    diceGraph1.Image = Properties.Resources.dice5;
                    break;
                case 6:
                    diceGraph1.Image = Properties.Resources.dice6;
                    break;
            }

            lastDice = dice;

            // Tres dobles seguidos
            if (consecDoubles > 1 && (dice[0]==dice[1]) && lastClicked != null)
            {
                placeHome(lastClicked);
                log(Locale.consecDoubles);
                lastDice[0] = -1;
                lastDice[1] = -2;
                activeDices = 0;

                DiceButton.Enabled = false;

                return;
            }

            bool enableZero = true;
            bool enableOne = true;

            if (lastDice[0] + lastDice[1] == 5 && sacarFicha(turn))
            {
                activeDices = 0;
                log(Locale.diceSumFive);
            }
            else if (dice[0] != 5 && dice[1] != 5 && active[turn] == 0)
            {
                activeDices = 0;
                log(Locale.noMove);
            }
            else {

                if (dice[0] == 5 && sacarFicha(turn))
                {
                    enableZero = false;
                    log(Locale.coinOut + typeToString(turn));
                    activeDices--;
                }
                if (dice[1] == 5 && sacarFicha(turn))
                {
                    enableOne = false;
                    log(Locale.coinOut + typeToString(turn));
                    activeDices--;
                }
                                
                if (enableZero) diceGraph0.Enabled = true;
                if (enableOne) diceGraph1.Enabled = true;
                
            }

            DiceButton.Enabled = false;

        }

        private bool isBridges(int pos, int fPos) {

            for (int i = pos+1; i <= fPos; i++) {
                if (coinsInPoint(Const.casilla[i]) > 1) return true;
            }

            return false;

        }

        private bool moveFicha(Ficha f, int pos) {

            Ficha[] fichas = { v1, v2, v3, v4, am1, am2, am3, am4, az1, az2, az3, az4, r1, r2, r3, r4 };

            int posFinal = (pos + f.Pos) % 68;

            if (f.HomeRoad) { return moveInsideHome(f, pos, posFinal); }

            // REVISAR
            if (f.Type == Const.AZUL && posFinal > 16 && f.Pos <= 16) { return goWin(f, pos, posFinal); }
            if (f.Type == Const.AMARILLA && (pos + f.Pos) > 67 && f.Pos <= 67) { return goWin(f, pos, posFinal); }
            if (f.Type == Const.VERDE && posFinal > 50 && f.Pos <= 50) { return goWin(f, pos, posFinal); }
            if (f.Type == Const.ROJA && posFinal > 33 && f.Pos <= 33) { return goWin(f, pos, posFinal); }

            if (coinsInPoint(Const.casilla[posFinal]) > 1) return false;

            // Matar ficha
            if (coinsInPoint(Const.casilla[posFinal]) == 1 &&
                !isSegura(Const.casilla[posFinal])) {

                Ficha aux = null;

                for (int i = 0; i < fichas.Length; i++) {
                    if (fichas[i].Img.Location.Equals(Const.casilla[posFinal])) aux = fichas[i];
                }

                if (aux.Type != f.Type) {
                    placeHome(aux);
                    // log(Locale.theCoin + typeToString(f.Type) + Locale.coinEaten + typeToString(aux.Type));
                    log(String.Format(Locale.coinEat, typeToString(f.Type), typeToString(aux.Type)));
                    selectedValue = 20;
                    activeDices++;
                    enableCoins(turn);
                    log(Locale.move20);
                }

            }

            f.Img.Location = Const.casilla[posFinal];

            if (f.Pos>0) fixCoins(Const.casilla[f.Pos]);

            f.Pos = posFinal;

            /* Entrar en casa (considerar si se pasa del final)
            if (f.Type == Const.AZUL && pos < 21) {
                if(f.Pos.Equals(Const.casilla[17])){
                    f.Img.Location = Const.winAzul[0];
                    f.Pos = 118;
                }
                if (f.Pos.Equals(Const.casilla[18]))
                {
                    f.Img.Location = Const.winAzul[1];
                    f.Pos = 119;
                }
            }*/

            fixCoins(Const.casilla[posFinal]);

            return true;

        }

        // Comprueba si algun equipo ha ganado
        public void winnerExists() {

            for (int i = 0; i < atHome.Length; i++)
            {
                if (atHome[i] >= 4)
                {
                    PasaTurno.Enabled = false;
                    inGame = false;
                    log(Locale.theWinnerIs + typeToString(atHome[i]));

                    enableGreen.Enabled = true;
                    enableYellow.Enabled = true;
                    enableRed.Enabled = true;
                    enableBlue.Enabled = true;
                }
            }

        }

        private bool moveInsideHome(Ficha f, int pos, int posFinal) {

            const int POS_WIN = 107;
            int dest = pos + f.Pos;

            if (dest > POS_WIN) return false;

            switch (f.Type)
            {

                case Const.VERDE:
                    if (coinsInPoint(Const.winVerde[dest - 100]) > 1) return false;
                    f.Img.Location = Const.winVerde[dest-100];

                    fixCoins(Const.winVerde[f.Pos - 100]);

                    f.Pos = dest;

                    fixCoins(Const.winVerde[dest - 100]);

                    break;
                case Const.ROJA:
                    if (coinsInPoint(Const.winRoja[dest - 100]) > 1) return false;
                    f.Img.Location = Const.winRoja[dest-100];

                    fixCoins(Const.winRoja[f.Pos - 100]);

                    f.Pos = dest;

                    fixCoins(Const.winRoja[dest - 100]);

                    break;
                case Const.AZUL:
                    if (coinsInPoint(Const.winAzul[dest - 100]) > 1) return false;
                    f.Img.Location = Const.winAzul[dest-100];

                    fixCoins(Const.winAzul[f.Pos - 100]);

                    f.Pos = dest;

                    fixCoins(Const.winAzul[dest - 100]);

                    break;
                case Const.AMARILLA:
                    if (coinsInPoint(Const.winAmarilla[dest - 100]) > 1) return false;
                    f.Img.Location = Const.winAmarilla[dest-100];

                    fixCoins(Const.winAmarilla[f.Pos - 100]);

                    f.Pos = dest;

                    fixCoins(Const.winAmarilla[dest - 100]);

                    break;
                default:
                    return false;

            }

            fixCoins(Const.winVerde[f.Pos - 100]);

            f.Pos = dest;

            fixCoins(Const.winVerde[dest - 100]);

            if (dest == POS_WIN) {
                atHome[f.Type]++;

                switch (f.Type)
                {

                    case Const.VERDE:
                        greenCount.Text = Locale.wonCoins + atHome[f.Type];
                        break;
                    case Const.ROJA:
                        redCount.Text = Locale.wonCoins + atHome[f.Type];
                        break;
                    case Const.AZUL:
                        blueCount.Text = Locale.wonCoins + atHome[f.Type];
                        break;
                    case Const.AMARILLA:
                        yellowCount.Text = Locale.wonCoins + atHome[f.Type];
                        break;
                    default:
                        return false;

                }

                f.Won = true;

                // log("Una ficha ha llegado a casa! Quedan " + (4-atHome[f.Type]) + " para ganar!");
                log(String.Format(Locale.coinArrived, (4 - atHome[f.Type])));
            }

            return true;
        }

        private bool goWin(Ficha f, int pos, int posFinal) {

            int avance = 0;

            switch (f.Type) {

                case Const.VERDE:
                    avance = posFinal - 50 - 1;
                    f.Img.Location = Const.winVerde[avance];
                    break;
                case Const.ROJA:
                    avance = posFinal - 33 - 1;
                    f.Img.Location = Const.winRoja[avance];
                    break;
                case Const.AZUL:
                    avance = posFinal - 16 - 1;
                    f.Img.Location = Const.winAzul[avance];
                    break;
                case Const.AMARILLA:
                    avance = posFinal;
                    f.Img.Location = Const.winAmarilla[avance];
                    break;
                default:
                    return false;

            }

            if (f.Pos > 0) fixCoins(Const.casilla[f.Pos]);

            f.HomeRoad = true;
            f.Pos = 100 + avance;

            if (f.Pos == 107)
            {
                atHome[f.Type]++;

                switch (f.Type)
                {

                    case Const.VERDE:
                        greenCount.Text = Locale.wonCoins + atHome[f.Type];
                        break;
                    case Const.ROJA:
                        redCount.Text = Locale.wonCoins + atHome[f.Type];
                        break;
                    case Const.AZUL:
                        blueCount.Text = Locale.wonCoins + atHome[f.Type];
                        break;
                    case Const.AMARILLA:
                        yellowCount.Text = Locale.wonCoins + atHome[f.Type];
                        break;
                    default:
                        return false;

                }

                f.Won = true;

                // log("Una ficha ha llegado a casa! Quedan " + (4-atHome[f.Type]) + " para ganar!");
                log(String.Format(Locale.coinArrived, (4 - atHome[f.Type])));
            }

            return true;
        
        }

        private void logDebug(String l) {

            debugLog.Text += "[" + typeToString(turn) + "] " + l + "\n";

        }

        private void log(String l) {

            // LabelLog.Visible = true;
            // LabelLog.Text = l;

            switch (turn) {

                case Const.AMARILLA:
                    yellowLog.Text += l + "\n";
                    break;
                case Const.VERDE:
                    greenLog.Text += l + "\n";
                    break;
                case Const.ROJA:
                    redLog.Text += l + "\n";
                    break;
                case Const.AZUL:
                    blueLog.Text += l + "\n";
                    break;

            }

        }

        private void DiceButton_Click(object sender, EventArgs e)
        {
            throwDice();
        }

        private void StartMatch_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Locale.startMessage, Locale.gameName, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                matchStart();
                StartMatch.Text = Locale.restart;
                log(Locale.restartMessage);
            }
            else if (dialogResult == DialogResult.No)
            {
                log(Locale.cancelRestart);
            }
        }

        private void debugSet_Click(object sender, EventArgs e)
        {
            Tablero.Controls.Add(auxFicha);
            auxFicha.Location = new Point(0, 0);
            auxFicha.Location = new Point(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            auxFicha.Visible = true;

        }

        private void Move_Click(object sender, EventArgs e)
        {
            moveFicha(f1, Convert.ToInt32(textBox3.Text));
        }
    }

    class Ficha {

        private PictureBox img;
        private int pos;
        private int type;
        private bool homeRoad;
        private bool won;

        public Ficha() { }

        public Ficha(PictureBox img, int pos, int type) {
            this.img = img;
            this.pos = pos;
            this.type = type;
            this.homeRoad = false;
            this.won = false;
        }

        public bool Won { get => won; set => won = value; }
        public bool HomeRoad { get => homeRoad; set => homeRoad = value; }
        public int Pos { get => pos; set => pos = value; }
        public PictureBox Img { get => img; set => img = value; }
        public int Type { get => type; set => type = value; }
    }

}
