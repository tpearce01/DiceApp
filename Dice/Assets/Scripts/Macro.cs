using UnityEngine;
using System.Collections;

public class Macro
{
    public int d4;
    public int d6;
    public int d8;
    public int d10;
    public int d12;
    public int d20;

    public Macro()
    {
        d4 = 0;
        d6 = 0;
        d8 = 0;
        d10 = 0;
        d12 = 0;
        d20 = 0;
    }

    public Macro(int d44, int d66, int d88, int d100, int d122, int d200)
    {
        d4 = d44;
        d6 = d66;
        d8 = d88;
        d10 = d100;
        d12 = d122;
        d20 = d200;
    }
}
