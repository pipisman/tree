

using System;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;

class Branch : Tile
{
    int chance;
    float branchFrames;
    float branchFramesTimer;
    int cell = 0;
    bool growing = true;
    float life;
    Color branchColor;
    Random random;
    int priority;
    public Branch(Grid grid, int chance, float branchFrames, float life, int priority, Random random, Color colorb) : base(new Color(165 + (0 * 25), 45 + (0 * 25), 45 + (0 * 25)), false, true)
    {

        this.grid = grid;
        this.chance = chance;
        if (chance != 6)
            this.chance += 1;
        this.branchFrames = branchFrames - 1 + random.Next(0, 2);
        branchFramesTimer = branchFrames;
        updatedThisFrame = true;
        this.life = life;
        this.priority = priority;
        this.random = random;
        branchColor = colorb;
        if (chance >= 3)
            color = new Color((165 + branchColor.R) / 2, (45 + branchColor.G) / 2, (45 + branchColor.B) / 2);
    }

    public override void Update(int i)
    {
        if (updatedThisFrame) return;
        updatedThisFrame = true;
        cell = i;
        life--;
        if (life <= 2)
        {
            growing = false;
            return;
        }
        if (growing)
        {
            branch();
            grow();
        }

    }
    void grow()
    {


        if (random.Next(1, 6) > chance)
            grid.grow(cell, cell - grid.width, chance);
        else
        {
            /*
            if (priority == -1)
            {
                if (random.Next(0, 3) != 0)
                    grid.grow(cell, cell - 1, chance);
                else grid.grow(cell, cell + 1, chance);
            }
            else if (priority == 1)
            {
                if (random.Next(0, 3) == 0)
                    grid.grow(cell, cell - 1, chance);
                else grid.grow(cell, cell + 1, chance);
            }
            */
            if (random.Next(0, 2) == 0)
                grid.grow(cell, cell - 1, chance);
            else grid.grow(cell, cell + 1, chance);
        }

    }
    void branch()
    {

        if (branchFramesTimer <= 0)
        {
            branchFramesTimer = branchFrames * 5f / 6f;
            if (branchFramesTimer <= 1)
            {
                growing = false;
                return;
            }

            Console.WriteLine(branchFramesTimer);


            branchFrames = branchFramesTimer;

            grid.set(cell - 1 - grid.width, new Branch(grid, chance, branchFrames - 1, life, -1, random, branchColor));

            grid.set(cell + 1, new Branch(grid, chance, branchFrames - 1, life, 1, random, branchColor));

        }
        else branchFramesTimer--;
    }
}