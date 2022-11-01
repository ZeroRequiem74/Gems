using Raylib_cs;
using System.Numerics;

abstract class Ores
{
    bool mined;
    bool fell;
    int objects;
    

}

class Stones: Ores
{
    int points = -1;
}

class Gems: Ores
{
    int points = 1;
}

class Destructable
{
    public int Broken(bool mined, bool fell, int objects)
    {
        if(mined | fell)
        {
            objects -= 1;
        }
        return objects;
    }
}

class Creation
{
    public int NumberOfOres(int objects)
    {
        if (objects < 30)
        {
            objects += 1;
        }
        return objects;
    }
}

class Points
{
    public bool AddPoints(bool mined, bool fell)
    {
        bool add = false;

        if(mined)
        {
            add = true;
        }
        else if(fell)
        {
            add = false;
        }
        else
        {
            add = false;
        }

        return add;
    }
}

class Movement
{
    int MovementSpeed = 10;
}

class Miner
{
    int PlayerMovement = 15;

}