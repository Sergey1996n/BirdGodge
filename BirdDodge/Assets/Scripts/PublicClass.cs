using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PublicClass : object
{
    public static int coint = 0;
    public static int proverkaCoint = 0;
    public static bool lose = false;
    public static float updateSpeed = 0;
    public static float time = 0.8f;

    public static (int, bool) x2 = (0, false);
    public static (int, bool) shield = (0, false);
    public static (int, bool) timer = (0, false);

    public static (int, bool) rating = (0, false);

}
