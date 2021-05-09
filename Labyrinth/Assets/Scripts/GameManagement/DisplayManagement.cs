using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI torchAmount;
    public TextMeshProUGUI hammerLife;
    public TextMeshProUGUI bulletAmount;

    void Start()
    {
        torchAmount.text = GameSetup.torchAmount < 0 ? "∞" : GameSetup.torchAmount + "";
        hammerLife.text = GameSetup.hammerLife < 0 ? "∞" : GameSetup.hammerLife + "";
        bulletAmount.text = GameSetup.bulletAmount < 0 ? "∞" : GameSetup.bulletAmount + "";
    }

    // Update is called once per frame
    void Update()
    {
        torchAmount.text = GameSetup.torchAmount < 0 ? "∞" : GameSetup.torchAmount + "";
        hammerLife.text = GameSetup.hammerLife < 0 ? "∞" : GameSetup.hammerLife + "";
        bulletAmount.text = GameSetup.bulletAmount < 0 ? "∞" : GameSetup.bulletAmount + "";
    }
}
