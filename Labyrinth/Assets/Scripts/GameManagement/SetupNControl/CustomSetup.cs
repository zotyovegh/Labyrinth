using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustomSetup
{
    public int size, safeDistance, enemyAmount, torchAmount, bulletAmount, hammerLife;

    public CustomSetup( int size, int safeDistance, int enemyAmount, int torchAmount, int bulletAmount, int hammerLife)
    {
        this.size = size;
        this.safeDistance = safeDistance;
        this.enemyAmount = enemyAmount;
        this.torchAmount = torchAmount;
        this.bulletAmount = bulletAmount;
        this.hammerLife = hammerLife;
    }

    public void InstallSavedCustom()
    {
        GameSetup.size = size;
        GameSetup.safeDistance = safeDistance;
        GameSetup.enemyAmount = enemyAmount;
        GameSetup.torchAmount = torchAmount;
        GameSetup.bulletAmount = bulletAmount;
        GameSetup.hammerLife = hammerLife;
    }
}
