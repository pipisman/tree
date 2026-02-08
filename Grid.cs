
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;

class Grid
{
    public int width;
    public int height;
    public Random random = new Random();
    public List<Tile> cells = new List<Tile>();
    Color LeavesColor = Color.DarkGreen;
    int leavesSize = 5;
    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;

        for (int i = 0; i < width * height; i++)
            cells.Add(new Tile(Color.Black, true, false));

        cells[convertToIndex(50, 95)] = new Branch(this, 0, 14, 60, 0, random, LeavesColor);
    }
    public void Update()
    {
        for (int i = 0; i < cells.Count; i++)
            cells[i].updatedThisFrame = false;

        for (int i = 0; i < cells.Count; i++)
            cells[i].Update(i);
    }
    public void grow(int cell, int gcell, int iter)
    {
        cells[gcell] = cells[cell];

        if (iter >= 3)
        {
            cells[cell] = new Tile(new Color(LeavesColor.R + 50, LeavesColor.G + 50, LeavesColor.B + 50), false, true);
            for (int x = -leavesSize / 2; x < (leavesSize / 2) + 1; x++)
                for (int y = -leavesSize / 2; y < (leavesSize / 2) + 1; y++)
                    if (cells[convertToIndex(x, y) + gcell].empty && convertToIndex(x, y) + gcell != gcell)
                        cells[convertToIndex(x, y) + gcell] = new Tile(new Color(LeavesColor.R + (-y * 25), LeavesColor.G + (-y * 25), LeavesColor.B + (-y * 25)), false, true);
        }
        else cells[cell] = new Tile(new Color(165 + (0 * 25), 45 + (0 * 25), 45 + (0 * 25)), false, true);
        //new Color(50 + (2 * 25), 178 + (2 * 25), 50 + (2 * 25))
        //new Color(165 + (0 * 25), 45 + (0 * 25), 45 + (0 * 25))
        //new Color(50 + (-y * 25), 178 + (-y * 25), 50 + (-y * 25))
    }
    public void set(int index, Tile cell)
    {
        cells[index] = cell;
    }
    public int convertToIndex(int x, int y)
    {
        return y * width + x;
    }
}