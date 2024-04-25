using System;
using System.Dynamic;
using Pong;

public class GameManager {

    private static int p1Score, p2Score;
    public static int scoreToWin = 3;
    private static string curScore = "xs";

    public static string getCurScore() { return curScore; }
    public static void setCurScore(string input) { curScore = input; }

    public static void StartGame() {
        p1Score = 0;
        p2Score = 0;
        setCurScore($"{p1Score}   |   {p2Score}");
    }

    public static void PlayerScored(bool playerOne) {
        string temp = "";
        if(playerOne) {
            p1Score++;
            temp = $"{p1Score}   |   {p2Score}";
        } 
        else {
            p2Score++;
            temp = $"{p1Score}   |   {p2Score}";
        }

        if(p1Score == scoreToWin || p2Score == scoreToWin) {
            temp = "PLAYER  WINS";
            Manager.DeleteGameObject("ball");
        }

        if(p2Score == scoreToWin) {
            temp = "PLAYER 2 WINS";
            Manager.DeleteGameObject("ball");
        }

        setCurScore(temp);

    }

    public enum GAME_STATE
    {
        MENU,
        GAME,
        OVER
    }

}