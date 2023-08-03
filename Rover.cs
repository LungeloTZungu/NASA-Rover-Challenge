using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_Rover_challenge
{
    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Instructions { get; private set; }
        public string InitialPosition { get; private set; }

        public Rover(int x, int y, string instructions)
        {
            X = x;
            Y = y;
            Instructions = instructions;
            InitialPosition = $"{x} {y}";
        }

        public void Move(char instruction, int maxX, int maxY)
        {
            int prevX = X;
            int prevY = Y;

            switch (instruction)
            {
                case 'N':
                    if (X < maxX)
                        X++;
                    break;
                case 'S':
                    if (X > 0)
                        X--;
                    break;
                case 'E':
                    if (Y < maxX)
                        Y++;
                    break;
                case 'W':
                    if (Y > 0)
                        Y--;
                    break;
                default:
                    throw new ArgumentException($"Invalid instruction: '{instruction}'");
            }

            // Check if the new position is within the plateau boundaries
            if (X >= 0 && X <= maxX && Y >= 0 && Y <= maxY)
            {
                // If within boundaries, add to visited positions
                return;
            }
            else
            {
                // If outside boundaries, throw exception
                throw new Exception("Rover is now out of bounds from plateau");
            
            }
        }

        public void DisplayJourney(int maxX, int maxY)
        {
            // Display the rover's journey from initial position to final position
            Console.Write($"{InitialPosition} ");
            foreach (var instruction in Instructions)
            {
                Move(instruction, maxX, maxY);
                Console.Write($"({X} {Y}) ");
            }
            Console.WriteLine();
        }
    }
}




