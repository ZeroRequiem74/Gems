using Raylib_cs;
using System.Numerics;

namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {

            var ScreenHeight = 480;
            var ScreenWidth = 800;
            var Objects = new List<GameObject>();
            var Random = new Random();
            var Player = new Player();
            var Title = new Points("Link! Grab all the Rupees and avoid the rocks! -Zelda", Color.WHITE);
            var CountOfEachShape = 0;
            int points = 10;
            int addPoints = 0;


            Raylib.InitWindow(ScreenWidth, ScreenHeight, "GameObject");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                if (CountOfEachShape < 30){
                    // Add a new random object to the screen every iteration of our game loop
                    var whichType = Random.Next(2);

                    // Generate a random velocity for this object
                    var randomY = Random.Next(1, 2);
                    var randomX = Random.Next(ScreenWidth);

                    // Each object will start about the center of the screen
                    var position = new Vector2(randomX, 0);
                
                    switch (whichType) {
                        case 0:
                            Console.WriteLine("Creating a square");
                            var square = new Gem(Color.PURPLE, 2);
                            square.Position = position;
                            square.Velocity = new Vector2(0, randomY);
                            Objects.Add(square);
                            break;
                        case 1:
                            Console.WriteLine("Creating a circle");
                            var circle = new Stone(Color.GRAY, 1);
                            circle.Position = position;
                            circle.Velocity = new Vector2(0, randomY);
                            Objects.Add(circle);
                            break;
                        default:
                            break;
                    }
                    CountOfEachShape += 1;
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                // Draw all of the objects in their current location
                foreach (var obj in Objects) {
                    obj.Draw();
                }

                Raylib.EndDrawing();

                // Move all of the objects to their next location
                
                foreach (var obj in Objects) {
                if (obj is Gem) {
                    var shape = (Gem)obj;
                    if (Raylib.CheckCollisionRecs(Player.Rect(), shape.Rect())) {
                        addPoints = StonePoints.AddPoints();
                        points = Points.PlayerPoints(points, addPoints);
                        var message = $"Current Points:{points}";
                        Raylib.DrawText(message, 100, 100, 20, Color.WHITE);
                    }
                }
                if (obj is Stone) {
                    var shape = (Stone)obj;
                    if (Raylib.CheckCollisionRecs(Player.Rect(), shape.Rect())) {
                        addPoints = StonePoints.AddPoints();
                        points = Points.PlayerPoints(points, addPoints);
                        var message = $"Current Points:{points}";
                        Raylib.DrawText(message, 100, 100, 20, Color.WHITE);
                    }
                }

            }
            }

            Raylib.CloseWindow();
        }
    }
}

