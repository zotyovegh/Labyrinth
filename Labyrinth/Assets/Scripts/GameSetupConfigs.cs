using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetups
{
    public static void setEasy()
    {
        GameSetup.gameType = "easy";
    }

    public static void setMedium()
    {
        GameSetup.gameType = "medium";
    }

    public static void setHard()
    {
        GameSetup.gameType = "hard";
    }

    public static void setExtreme()
    {
        GameSetup.gameType = "extreme";
    }

    public static void setCustom()
    {
        GameSetup.gameType = "custom";
    }
}
