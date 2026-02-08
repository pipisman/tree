using System;
using Microsoft.Xna.Framework;

class Tile
{
    public Color color;
    public bool empty;
    public static Random rand = new Random();
    public Grid grid;
    public bool updatedThisFrame;

    public Tile(Color color, bool empty, bool ditter)
    {
        this.color = ditter ? VaryColor(color) : color;
        this.empty = empty;
    }
    public static Color VaryColor(Color color)
    {
        int r = Math.Clamp(color.R * 2 / 3 + rand.Next(-30, 31), 0, 255);
        int g = Math.Clamp(color.G * 2 / 3 + rand.Next(-30, 31), 0, 255);
        int b = Math.Clamp(color.B * 2 / 3 + rand.Next(-10, 11), 0, 255);

        return new Color(r + rand.Next(1, 31), g + rand.Next(1, 31), b + rand.Next(1, 13), color.A);
    }


    public virtual void Update(int i)
    {

    }
}