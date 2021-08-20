using System;

namespace TicTacTo
{
    class Program
    {
        static string[]  BordDataArr = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static bool GameEnded = false;

        static void Main()
        {
            Player player = new Player();
            player.number = "1";
            Console.Title = "Tic Tac Toe";
            drawBoard();
            Console.WriteLine("");
            
            do
            {
                if(player.number == "1"){
                    player.icon = "X";
                }else{
                    player.icon = "O";
                }
                Console.WriteLine($"Player: {player.number} ({player.icon}) choose your next move:");
                string userinput = waitForUserInput();
                Console.Clear();
                try{
                    int Intinput = Int16.Parse(userinput);
                    if(Intinput >= 1 && Intinput <= 9){
                        updateGameBoardLogic(player, Intinput.ToString());
                        Console.WriteLine("");
                    }else{
                invalidNumber();
                Console.WriteLine("");
                    }
                }catch{
                invalidNumber();
                Console.WriteLine("");
                }

            } while (!GameEnded);

            Console.WriteLine("");
            Console.WriteLine("Press any key to Continue");
            waitForUserInput();
            Console.Clear();
        }

        private static void updateGameBoardLogic(Player player, string userinput)
        {
            bool validPlacement = setBoardData(player, userinput);

            if(validPlacement){
                updateGame(player);
            }
            else{
                Console.WriteLine("");
                Console.WriteLine($"You cannot place your character at position: {userinput}");
                Console.WriteLine("");

                drawBoard();
            }
        }

        private static string waitForUserInput()
        {
            return Console.ReadLine();
        }

        static void invalidNumber(){
            Console.WriteLine("");
            Console.WriteLine("Not a Valid number.");
            Console.WriteLine("");

            drawBoard();
        }

        static bool setBoardData(Player player, string userinput){

            if(player.number == "1"){
                if(BordDataArr[Int32.Parse(userinput) - 1] == "X" || BordDataArr[Int16.Parse(userinput) - 1] == "O"){
                    return false;
                }
                else{
                    BordDataArr[Int32.Parse(userinput) - 1] = "X";
                    return true;
                }
            }
            else if(player.number == "2"){
                if(BordDataArr[Int32.Parse(userinput) - 1] == "X" || BordDataArr[Int16.Parse(userinput) - 1] == "O"){
                    return false;
                }
                else{
                    BordDataArr[Int32.Parse(userinput) - 1] = "O";
                    return true;
                }
            }
            else{
                return false;
            }
        }

        static void updateGame(Player player){
            drawBoard();

            checkScore(player);

            SwitchPlayers(player);
        }

        static void checkScore(Player player){
            string logg = "null";
            if(!BordDataArr[0].Equals("1") && !BordDataArr[1].Equals("2") && !BordDataArr[2].Equals("3")){
                if(!BordDataArr[3].Equals("4") && !BordDataArr[4].Equals("5") && !BordDataArr[5].Equals("6")){
                    if(!BordDataArr[6].Equals("7") && !BordDataArr[7].Equals("8") && !BordDataArr[8].Equals("9")){
                        logg = "Game ended, player 1 and player 2 tied.";
                    }
                }
            }

            if(BordDataArr[0] == BordDataArr[1] && BordDataArr[1] == BordDataArr[2]){ //Top row
                logg = $"Player: {player.number} won !";
            }

            if(BordDataArr[3] == BordDataArr[4] && BordDataArr[4] == BordDataArr[5]){ //Second row
                logg = $"Player: {player.number} won !";
            }

            if(BordDataArr[6] == BordDataArr[7] && BordDataArr[7] == BordDataArr[8]){ // Third row
                logg = $"Player: {player.number} won !";
            }

            if(BordDataArr[0] == BordDataArr[3] && BordDataArr[3] == BordDataArr[6]){ // Left column
                logg = $"Player: {player.number} won !";
            }

            if(BordDataArr[1] == BordDataArr[4] && BordDataArr[4] == BordDataArr[7]){ // Middle column
                logg = $"Player: {player.number} won !";
            }

            if(BordDataArr[2] == BordDataArr[5] && BordDataArr[5] == BordDataArr[8]){ // right column
                logg = $"Player: {player.number} won !";
            }

            if(BordDataArr[0] == BordDataArr[4] && BordDataArr[4] == BordDataArr[8]){ // Cross top left - bottom right
                logg = $"Player: {player.number} won !";
            }

            if(BordDataArr[2] == BordDataArr[4] && BordDataArr[4] == BordDataArr[6]){ // Cross top right - bottom left
                logg = $"Player: {player.number} won !";
            }

            if(!logg.Equals("null")){
                Console.WriteLine("");
                Console.WriteLine(logg);
                GameEnded = true;
            }
        }

        static void drawBoard(){
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", BordDataArr[0], BordDataArr[1], BordDataArr[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", BordDataArr[3], BordDataArr[4], BordDataArr[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", BordDataArr[6], BordDataArr[7], BordDataArr[8]);
            Console.WriteLine("     |     |      ");
        }

        private static void SwitchPlayers(Player player)
        {
            if(player.number == "1"){
                player.number = "2";
            }else if(player.number == "2"){
                player.number = "1";
            }
        }
    }

    public class Player{
        public string number;
        public string icon;
    }
}
