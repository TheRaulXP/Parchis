using System;
using System.Drawing;

public class Locale
{

    // GUI
    public const string gameName = "Parchis";

    public static string[] colors = { green, yellow, blue, red };

    public const string green = "Green";
    public const string blue = "Blue";
    public const string yellow = "Yellow";
    public const string red = "Red";

    public const string startButton = "Start Match";
    public const string stop = "Stop Match";
    public const string skipButton = "Skip Turn";
    public const string turnOf = "Turn of:";
    public const string startingCoin = "Starting coin?";
    public const string diceButton = "Throw Dice";

    public const string startLogMessage = "Starting match.";
    public const string stopLogMessage = "Stopping match.";
    public const string cancelOperation = "Operation cancelled.";

    public const string startMessage = "Are you sure that you want to START the match?";
    public const string stopMessage = "Are you sure that you want to STOP the match?";

    // GAME STRINGS
    public const string bridgesPresent = "Movement not possible. There were bridges.";
    public const string move20 = "Move 20 squares.";
    public const string diceThrow = "Throwing dice...";
    public const string diceResult = "The dice got a {0} and a {1}";
    public const string diceSumFive = "The sum was 5, coin added";
    public const string noMove = "You cannot move any coin.";
    public const string coinArrived = "A coin arrived to its destination!";
    public const string coinEat = "The coin {0} killed the coin {1}";
    public const string theWinnerIs = "The winner is ";
    public const string coinOut = "Taking out a coin from team ";

    // STATS SECTION
    public const string enabled = "Enabled";

    // DICE SYSTEM
    public const string diceSelect = "Dice {0} selected";
    public const string diceValue = " with value {0}, select a coin.";
    public const string consecDoubles = "You got three double results in a row!";
    public const string whoStarts = "It was decided that {0} begins.";

    // DEBUG
    public const string debugCoinsCount = "There were {0} coins in that square.";

}
