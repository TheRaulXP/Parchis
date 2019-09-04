using System;
using System.Drawing;

public class Locale
{

    // GUI
    public const string gameName = "Parchis";

    public const string green = "Green";
    public const string blue = "Blue";
    public const string yellow = "Yellow";
    public const string red = "Red";

    public const string startButton = "Start Match";
    public const string restart = "Restart Match";
    public const string skipButton = "Skip Turn";
    public const string turnOf = "Turn of:";
    public const string startingCoin = "Starting coin?";
    public const string diceButton = "Throw Dice";

    public const string restartMessage = "Restarting match.";
    public const string cancelRestart = "Restart cancelled.";

    public const string startMessage = "Are you sure that you want to (re)start the match?";

    // GAME STRINGS
    public const string bridgesPresent = "Movement not possible. There were bridges.";
    public const string move20 = "Move 20 squares.";
    public const string diceThrow = "Throwing dice...";
    public const string diceResult = "The dice got a {0} and a {1}";
    public const string diceSumFive = "The sum was 5, coin added";
    public const string noMove = "You cannot move any coin.";
    public const string coinArrived = "A coin arrived to its destination! {0} coins left to win.";
    public const string coinEat = "The coin {0} killed the coin {1}";
    public const string theWinnerIs = "The winner is ";
    public const string coinOut = "Taking out a coin from team ";

    // STATS SECTION
    public const string wonCoins = "Won coins: ";
    public const string enabled = "Enabled";
    public const string activeCoin = "Active coins: ";
    public const string atHCoin = "Coins at home: ";
    public const string info = "Information:";

    // DICE SYSTEM
    public const string diceSelect = "Dice {0} selected";
    public const string diceCoinAdd = ", coin added.";
    public const string diceValue = " with value {1}, select a coin.";
    public const string consecDoubles = "You got three double results in a row!";
    public const string whoStarts = "It was decided that {0} begins.";

    // DEBUG
    public const string debugCoinsCount = "There were {0} coins in that square.";

}
