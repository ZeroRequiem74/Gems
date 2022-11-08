using Raylib_cs;
using System.Numerics;

class GameObject {
    public Vector2 Position { get; set; } = new Vector2(0, 0);
    public Vector2 Velocity { get; set; } = new Vector2(0, 0);

    virtual public void Draw() {
        // Base game objects do not have anything to draw
    }

    virtual public int Points() {
        int points = 0;
        return points;
    }

    public void Move() {
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

    override public void Draw() {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, Size, Size, Color);
    }
}

class GemPoints: Gem {
    override public int Points() {
        int points = 1;
        return points;
    }
}


class Stone: ColoredObject {

    public int Radius { get; set; }

    public Stone(Color color, int radius): base(color) {
        Radius = radius;
    }
    override public void Draw() {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, Radius, Color);
    }
}

class StonePoints: Stone {
    override public int Points() {
        int points = -1;
        return points;
    }
}

class Player {

}

class Score {

}