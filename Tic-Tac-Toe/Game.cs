using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Tic_Tac_Toe
    {
        private readonly char[] locations = new char[9];
        public char[] Locations { get { return locations; } }

        public Tic_Tac_Toe() { }
        public Tic_Tac_Toe(char[] locations) { this.locations = locations; }

        public void InitiateNewGame()
        {
            for (int i = 0; i < 9; i++) 
            {
                if (i > 5)
                    locations[i] = ' ';
                else
                    locations[i] = '_';
            }
        }      
        
        public void InsertUserInput(char input, int index) 
        {            
            if (index < 0 || index > 8)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (locations[index] != '_' || locations[index] != ' ')
                locations[index] = input;
            else
                throw new ArgumentException($"{nameof(input)} is already filled"); 
        }        

        public bool AreLocationsFilled()
        {
            var filled = true;
            for (int i = 0;i < 9;i++)
            {
                if (IsLocationEmpty(i))
                {
                    filled = false;
                    break;
                }                    
            }
            
            return filled;
        }

        private bool IsLocationEmpty(int index)
        {
            if (locations[index] == '_' || locations[index] == ' ')
                return true;
            else return false;
        }

        public char? DetermineWin()
        {
            char? CheckHorizontally()
            {
                char? inputWon = null;
                for (int i = 0; i < 3; i++)
                {
                    var index = i * 3;

                    var rowIsFilled = !(IsLocationEmpty(index)  || IsLocationEmpty(index + 1) || IsLocationEmpty(index + 2));

                    if (rowIsFilled)
                    {
                        var allThreeAreSame = locations[index] == locations[index + 1] && locations[index + 1] == locations[index + 2];
                        if (allThreeAreSame)
                        {
                            inputWon = locations[index];
                        }
                    }                    
                }

                return inputWon;
            }

            char? CheckVertically()
            {
                char? inputWon = null;
                for (int i = 0; i < 3; i++)
                {
                    var collumnIsFilled = !(IsLocationEmpty(i) || IsLocationEmpty(i + 3)  || IsLocationEmpty(i + 6));

                    if (collumnIsFilled)
                    {
                        var allThreeAreSame = locations[i] == locations[i + 3] && locations[i + 3] == locations[i + 6];
                        if (allThreeAreSame)
                            inputWon = locations[i];
                    }
                }

                return inputWon;                
            }

            char? CheckDiagonally()
            {
                char? inputWon = null;
                if (locations[0] == locations[4] && locations[4] == locations[8])
                    inputWon = locations[0];
                else
                    if (locations[2] == locations[4] && locations[4] == locations[6])
                        inputWon = locations[2];

                return inputWon;
            }

            char? inputWon = CheckHorizontally();
            
            if (inputWon != null)
                return inputWon;

            inputWon = CheckVertically();

            if (inputWon != null)
                return inputWon;

            inputWon = CheckDiagonally();

            return inputWon;
        }


    }
}
