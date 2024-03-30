using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Task3 : MonoBehaviour
{
    bool OutOfCards = false;

    int MaxCardsInDeck;

    float TimeBetweenDraws = 3f;
    float MaxTime;

    string CurrentLine;

    string[] Suits = { "♠", "♣", "♥", "♦" };
    string[] HonorTypes = {"K", "Q", "J", "A"};
    string[] Hand = new string[4];

    Stack Deck = new Stack();

    #region Unity Methods
    void Start()
    {
        MaxTime = TimeBetweenDraws;

        CreateDeck();
        DrawCards(4);
    }

    void Update()
    {
        if(Deck.Count <= 0)
        {
            OutOfCards = true;
        }

        DrawCardsOnTimer(1);
    }

    #endregion

    #region Deck Management
    void CreateDeck()
    {
        //Creates a temporary deck that will be shuffled into a stack.
        List<string> TempDeck = new List<string>();

        foreach (string suit in Suits)
        {
            foreach(string type in HonorTypes)
            {
                string NewCard = type + suit;
                TempDeck.Add(NewCard);
            }
        }

        //Shuffles the temp deck into a stack.
        while (TempDeck.Count > 0)
        {
            int RNG = Random.Range(0, TempDeck.Count);
            Deck.Push(TempDeck[RNG]);
            TempDeck.RemoveAt(RNG);
        }

        //Stores the max amount of cards in the deck.
        MaxCardsInDeck = Deck.Count;
    }

    void DrawCards(int cards)
    {
        if(Deck.Count == MaxCardsInDeck)
        {
            InitialDraw(cards);
        }
        else
        {
            ConsecutiveDraws(cards);
        }

        CheckForWinningHand();

        Debug.Log(CurrentLine);
    }

    void DrawCardsOnTimer(int cards)
    {
        if (TimeBetweenDraws > 0 && !OutOfCards)
        {
            TimeBetweenDraws -= Time.deltaTime;
        }
        else if(!OutOfCards)
        {
            DrawCards(cards);
            TimeBetweenDraws = MaxTime;
        }
    }

    #endregion

    #region DrawCards Methods
    void CheckForPeriod(int loopInt, int loopMaxInt, string currentCard)
    {
        if (loopInt == loopMaxInt - 1)
        {
            CurrentLine += currentCard + ". ";
        }
        else
        {
            CurrentLine += currentCard + ", ";
        }
    }

    void InitialDraw(int cards)
    {
        string CurrentCard;

        CurrentLine = "I made the initial deck and draw. My hand is: ";

        for (int i = 0; i < cards; i++)
        {
            CurrentCard = Deck.Pop().ToString();

            CheckForPeriod(i, cards, CurrentCard);

            Hand[i] = CurrentCard;
        }
    }

    void ConsecutiveDraws(int cards)
    {
        string CurrentCard;

        CurrentLine = "I discarded ";

        for (int i = 0; i < cards; i++)
        {
            //3 because Hand has four elements.
            int RNG = Random.Range(0, 3);

            CurrentLine += Hand[RNG] + " and drew ";

            CurrentCard = Deck.Pop().ToString();

            CheckForPeriod(i, cards, CurrentCard);

            Hand[RNG] = CurrentCard;

            CurrentLine += "My hand is: ";

            for (int j = 0; j < Hand.Length; j++)
            {
                CheckForPeriod(j, Hand.Length, Hand[j]);
            }
        }
    }

    void CheckForWinningHand()
    {
        //Element 1 is for Spades, 2 is for Clubs, 3 is for Hearts, 4 is for Diamonds.
        int[] SuitChecker = { 0, 0, 0, 0 };

        //Checks how many cards of each suit are in the hand.
        for(int i = 0; i < Hand.Length; i++)
        {
            CheckEachSuit(SuitChecker, i);
        }

        //Checks if there are three or more of any suit in the hand.
        bool WinningHandIsTrue = false;
        CheckSuitChecker(SuitChecker, ref WinningHandIsTrue);

        //Declares a winning hand and ends the game if WinningHandIsTrue returns true.
        if (WinningHandIsTrue)
        {
            CurrentLine += "The game is WON.";
            OutOfCards = true;
        }
        else
        {
            CurrentLine += "This is not a winning hand.";
        }
    }

    //Runs the suit check code for each suit.
    void CheckEachSuit(int[] suitChecker, int loopInt)
    {
        for(int j = 0; j < suitChecker.Length; j++)
        {
            if (Hand[loopInt].Contains(Suits[j]))
            {
                suitChecker[j]++;
            }
        }
    }

    void CheckSuitChecker(int[] suitChecker, ref bool winningHandIsTrue)
    {
        foreach(int value in suitChecker)
        {
            if(value >= 3)
            {
                winningHandIsTrue = true;
            }
        }
    }

    #endregion
}
