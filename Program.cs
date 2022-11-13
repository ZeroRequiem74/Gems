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

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "GameObject");
            Raylib.SetTargetFPS(60);

            var Objects = new List<GameObject>();
            var Random = new Random();
            var Player = new Player();
            var Title = new Points("Link! Grab all the Rupees and avoid the rocks! -Zelda", Color.BLACK);
            var CountOfEachShape = 0;
            int points = 10;
            int addPoints = 0;

            
            Player.Position = new Vector2(400, 425);


            while (!Raylib.WindowShouldClose())
            {
                if (CountOfEachShape < 30){
                    // Add a new random object to the screen every iteration of our game loop
                    var whichType = Random.Next(2);

                    // Generate a random velocity for this object
                    var randomY = Random.Next(1, 3);
                    var randomX = Random.Next(ScreenWidth);

                    // Each object will start about the center of the screen
                    var position = new Vector2(randomX, 0);
                
                    switch (whichType) {
                        case 0:
                            Console.WriteLine("Creating a square");
                            var square = new Gem(Color.PURPLE, 20);
                            square.Position = position;
                            square.Velocity = new Vector2(0, randomY);
                            Objects.Add(square);
                            break;
                        case 1:
                            Console.WriteLine("Creating a circle");
                            var circle = new Stone(Color.GRAY, 10);
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
                
                Player.Draw();

                Title.Draw();
                // Move all of the objects to their next location
                
                foreach (var obj in Objects.ToList()) {
                if (obj is Gem) {
                    var shape = (Gem)obj;
                    if (Raylib.CheckCollisionRecs(Player.Rect(), shape.Rect())) {
                        addPoints = GemPoints.AddPoints();
                        points = Points.PlayerPoints(points, addPoints);
                        Objects.Remove(obj);
                        CountOfEachShape -= 1;
                    }
                }
                if (obj is Stone) {
                    var shape = (Stone)obj;
                    if (Raylib.CheckCollisionRecs(Player.Rect(), shape.Rect())) {
                        addPoints = StonePoints.AddPoints();
                        points = Points.PlayerPoints(points, addPoints);
                        Objects.Remove(obj);
                        CountOfEachShape -= 1;
                    }
                }
                if (obj.Position.Y > 480){
                    Objects.Remove(obj);
                    CountOfEachShape -= 1;
                }
            }
            var message = $"Current Points:{points}";
            Raylib.DrawText(message, 0, 30, 20, Color.BLACK);

            Raylib.EndDrawing();

                Player.Move();

                foreach(var obj in Objects.ToList()){
                    obj.Move();
                }
            }

            Raylib.CloseWindow();
        }
    }
}

