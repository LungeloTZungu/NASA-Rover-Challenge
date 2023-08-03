using System;
using System.Collections.Generic;
using System.Linq;

namespace NASA_Rover_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Code for plateau co-ordinates that user will input 
                Console.WriteLine("Enter the upper-right coordinates of the plateau  eaxmple : '4 4'");
                string[] plateauCoords = Console.ReadLine().Split(' ');
                int maxX = int.Parse(plateauCoords[0]);
                int maxY = int.Parse(plateauCoords[1]);

                // Get rover details and instructions
                Console.WriteLine("Enter the number of rovers: ");
                int numRovers = int.Parse(Console.ReadLine());
               
                List<Rover> rovers = new List<Rover>();
                Console.WriteLine("Legend for rover instructions:" + "\n" + "N = Up ; S = Down; E = Right; W = Left");
                Console.WriteLine(" ");
                for (int i = 0; i < numRovers; i++)
                {
                    Console.WriteLine($"Enter rover {i + 1}'s initial position example : '2 0'");
                    string roverPosition = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(roverPosition))
                    {
                        throw new Exception("Did not enter any co-ordinates in");
                    }

                    Console.WriteLine($"Enter rover {i + 1}'s instructions example : 'NEESSS'):");
                    string roverInstructions = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(roverInstructions))
                    {
                        throw new Exception("Did not enter any instructions");
                    }

                    string[] roverCoords = roverPosition.Split(' ');
                    int roverX = int.Parse(roverCoords[0]);
                    int roverY = int.Parse(roverCoords[1]);

                    Rover roverData = new Rover(roverX, roverY, roverInstructions);
                    rovers.Add(roverData);
                }
                // Find the intersection points
                List<RoverPoint> intersectionPoints = FindIntersectionPoints(rovers, maxX, maxY);

                // Order the intersection points by the order they are found
                intersectionPoints.Sort((p1, p2) =>
                {
                    int result = p1.X.CompareTo(p2.X);
                    return result != 0 ? result : p1.Y.CompareTo(p2.Y);
                });

                // Display the intersection points
                Console.WriteLine("Intersection points:");
                foreach (var intersectionPoint in intersectionPoints)
                {
                    if(intersectionPoints.Count == 0)
                    {
                        Console.WriteLine("No intersections Found");
                    }
                    else
                    {
                        Console.WriteLine($"{intersectionPoint.X} {intersectionPoint.Y}");
                    }
                  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Iterate through each rover and find its visited positions
        private static List<RoverPoint> FindIntersectionPoints(List<Rover> rovers, int maxX, int maxY)
        {
            List<RoverPoint> intersectionPoints = new List<RoverPoint>();

            // Dictionary to store visited positions for each rover
            Dictionary<Rover, List<RoverPoint>> roverPositions = new Dictionary<Rover, List<RoverPoint>>();

            // Iterate through each rover and find its visited positions
            foreach (var rover in rovers)
            {
                roverPositions[rover] = new List<RoverPoint>();
                roverPositions[rover].Add(new RoverPoint(rover.X, rover.Y));

                foreach (var instruction in rover.Instructions)
                {
                    rover.Move(instruction, maxX, maxY);
                    roverPositions[rover].Add(new RoverPoint(rover.X, rover.Y));
                }
            }

            // Compare the visited positions of each pair of rovers
            for (int i = 0; i < rovers.Count; i++)
            {
                for (int j = i + 1; j < rovers.Count; j++)
                {
                    Rover rover1 = rovers[i];
                    Rover rover2 = rovers[j];

                    foreach (var position in roverPositions[rover1])
                    {
                        if (roverPositions[rover2].Contains(position))
                        {
                            intersectionPoints.Add(position);
                        }
                    }
                }
            }

            return intersectionPoints;
        }

    }
}






