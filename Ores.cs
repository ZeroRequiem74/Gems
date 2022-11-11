using Raylib_cs;
using System.Numerics;

class GameObject {
    public Vector2 Position { get; set; } = new Vector2(0, 0);
    public Vector2 Velocity { get; set; } = new Vector2(0, 0);

    virtual public void Draw() {
        // Base game objects do not have anything to draw
    }

    virtual public void Move() {
        Vector2 NewPosition = Position;
        NewPosition.X += Velocity.X;
        NewPosition.Y += Velocity.Y;
        Position = NewPosition;
    }
}

class ColoredObject: GameObject {
    public Color Color { get; set; }

    public ColoredObject(Color color) {
        Color = color;
    }
}

class Gem: ColoredObject {

    
    public int Size { get; set; }

    public Gem(Color color, int size): base(color) {
        Size = size;
    }

    public Rectangle Rect() {
        return new Rectangle(Position.X, Position.Y, Size, Size);
    }

    override public void Draw() {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, Size, Size, Color);
    }
}

class GemPoints{
    static public int AddPoints() {
        int Addpoints = 1;
        return Addpoints;
    }
}


class Stone: ColoredObject {

    
    public int Radius { get; set; }

    public Stone(Color color, int radius): base(color) {
        Radius = radius;
    }

    public Rectangle Rect() {
        return new Rectangle(Position.X, Position.Y, Radius, Radius);
    }

    override public void Draw() {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, Radius, Color);
    }
}

class StonePoints{
    static public int AddPoints() {
        int Addpoints = -1;
        return Addpoints;
    }
}

class Player: GameObject {

    Texture2D texture;

    public Player() {
        
        var image = Raylib.LoadImage("link.png");
        this.texture = Raylib.LoadTextureFromImage(image);
        Raylib.UnloadImage(image);
    }

    public Rectangle Rect() {
        return new Rectangle(Position.X, Position.Y, 50, 53);
    }

    public override void Move()
    {
        // Reset the velocity every frame unless keys are being pressed
        var velocity = new Vector2();
        var movementSpeed = 10;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
            velocity.X = movementSpeed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
            velocity.X = -movementSpeed;
        }

        Velocity = velocity;

        base.Move();
    }

    public override void Draw() {
        Raylib.DrawTexture(this.texture, (int)Position.X, (int)Position.Y, Color.WHITE);
    }
}

class Points: ColoredObject{

    string Text;

    public Points(string text, Color color): base(color) {
        Text = text;
    }

    public override void Draw() {
        Raylib.DrawText(this.Text, (int)Position.X, (int)Position.Y, 20, this.Color);
    }
    static public int PlayerPoints(int points, int addPoints){
        points += addPoints;
        return points;
    }


}