using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetups
{
    public static void SetEasy()
    {
        GameSetup.gameType = "easy";
        GameSetup.size = 9;
        GameSetup.safeDistance = 5;
        GameSetup.enemyAmount = 1;
        GameSetup.torchAmount = -1; //endless
        GameSetup.bulletAmount = -1; //endless
        GameSetup.hammerLife = 4;
    }

    public static void SetMedium()
    {
        GameSetup.gameType = "medium";
        GameSetup.size = 17;
        GameSetup.safeDistance = 8;
        GameSetup.enemyAmount = 10;
        GameSetup.torchAmount = 30;
        GameSetup.bulletAmount = -1; //endless
        GameSetup.hammerLife = 3;
    }

    public static void SetHard()
    {
        GameSetup.gameType = "hard";
        GameSetup.size = 27;
        GameSetup.safeDistance = 20;
        GameSetup.enemyAmount = 40;
        GameSetup.torchAmount = 70;
        GameSetup.bulletAmount = 200;
        GameSetup.hammerLife = 3;
    }

    public static void SetExtreme()
    {
        GameSetup.gameType = "extreme";
        GameSetup.size = 41;
        GameSetup.safeDistance = 20;
        GameSetup.enemyAmount = 100;
        GameSetup.torchAmount = 160;
        GameSetup.bulletAmount = 600;
        GameSetup.hammerLife = 3;
    }

    public static CustomSetup savedCustomSetup;

    public static void SetCustom(string size, string safeDistance, string enemyAmount, string torchAmount, string bulletAmount, string hammerLife)
    {
        GameSetup.gameType = "custom";
        int sizeValue = int.Parse(size);
        GameSetup.size = sizeValue % 2 != 0 ? sizeValue : sizeValue + 1;
        GameSetup.safeDistance = int.Parse(safeDistance);
        GameSetup.enemyAmount = int.Parse(enemyAmount);
        GameSetup.torchAmount = torchAmount.Equals("∞") ? -1 : int.Parse(torchAmount);
        GameSetup.bulletAmount = bulletAmount.Equals("∞") ? -1 : int.Parse(bulletAmount);
        GameSetup.hammerLife = int.Parse(hammerLife);

        savedCustomSetup = new CustomSetup(GameSetup.size, GameSetup.safeDistance, GameSetup.enemyAmount, GameSetup.torchAmount, GameSetup.bulletAmount, GameSetup.hammerLife);
    }
}
