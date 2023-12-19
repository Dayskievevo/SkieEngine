public class GameManager {

    private static int p1Score, p2Score;
    public static int scoreToWin = 3;

    public class GameTracker {
        public void StartGame() {
            p1Score = 0;
            p2Score = 0;
        }

        public static int getP1Score() {return p1Score; }
        public static int getP2Score() {return p2Score;}

        public static void PlayerScored(bool playerOne) {
            if(playerOne) {p1Score++;} 
            else {
                p2Score++;
            }
        }

        public enum GAME_STATE
        {
            MENU,
            GAME,
            OVER
        }
    }
}