using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    
    private TeamController home, away;
    private WorldController wc;
    private WorldController.StadiumOrientation orientation;
    private int tossWinner, winnerChoice;
    private bool awayPicksHeads;

    private void Awake()
    {
        wc = GameObject.FindWithTag("GameController").GetComponent<WorldController>();
        orientation = wc.orientation;
        TeamController[] temp = GameObject.FindWithTag("Teams").GetComponentsInChildren<TeamController>();
        (home, away) = temp[0].IsHome() ? (temp[0], temp[1]) : (temp[1], temp[0]);
        //print("Home: " + home + "\nAway: " + away);
    }

    // Start is called before the first frame update
    void Start()
    {
        GetStadiumDirection();
        ChooseTossWinner(awayPicksHeads);
        DetermineWinnerChoice();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Heads"))
        {
            awayPicksHeads = true;
        }
        else if (Input.GetButton("Tails"))
        {
            awayPicksHeads = false;
        }
        else
        {
            awayPicksHeads = true;
        }
    }

    void GetStadiumDirection()
    {
        string topSide, bottomSide;
        print("Stadium: " + orientation);
    }

    public string ChooseTossWinner(bool awayHeads)
    {
        var awayTeamChoice = GetAwayTeamCoinChoiceStr(awayHeads);
        
        tossWinner = Random.Range(0, 2);
        bool awayWon = (tossWinner == 1 && awayHeads) || (tossWinner == 0 && !awayHeads);
        print("Coin-toss winners: " + (!awayWon ? home.GetAbbreviation() : away.GetAbbreviation()));
        return awayTeamChoice;
    }

    string GetAwayTeamCoinChoiceStr(bool heads)
    {
        return heads ? "Heads" : "Tails";
    }

    void DetermineWinnerChoice()
    {
        winnerChoice = Random.Range(1, 5);
        var winnerChoiceStr = winnerChoice switch
        {
            1 => "Defend " + wc.GetTopSideStr(),
            2 => "Kick",
            3 => "Receive",
            4 => "Defend " + wc.GetBottomSideStr(),
            _ => "Kick"
        };
        print("Winner " + (tossWinner == 1 ? home.GetAbbreviation() : away.GetAbbreviation()) + " picks: " + winnerChoiceStr);
    }
}
