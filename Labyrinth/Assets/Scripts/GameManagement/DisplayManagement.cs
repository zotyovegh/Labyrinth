using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI torchAmount;
    public TextMeshProUGUI hammerLife;
    public TextMeshProUGUI bulletAmount;

    public Image torchBg1;
    public Image torchBg2;
    public Image hammerBg1;
    public Image hammerBg2;
    public Image gunBg1;
    public Image gunBg2;

    private Color defColor = new Color(255, 255, 255, 0.05f);
    private Color pickedColor = new Color(255, 255, 0, 0.15f);

    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        torchAmount.text = GameSetup.torchAmount < 0 ? "∞" : GameSetup.torchAmount + "";
        hammerLife.text = GameSetup.hammerLife < 0 ? "∞" : GameSetup.hammerLife + "";
        bulletAmount.text = GameSetup.bulletAmount < 0 ? "∞" : GameSetup.bulletAmount + "";

        if (GameSetup.itemInHand.Equals("TorchHandler"))
        {
            ChangeTorchBg(pickedColor);
            ChangeHammerBg(defColor);
            ChangeGunBg(defColor);
        }
        else if (GameSetup.itemInHand.Equals("Gun"))
        {
            ChangeTorchBg(defColor);
            ChangeHammerBg(defColor);
            ChangeGunBg(pickedColor);
        }
        else if (GameSetup.itemInHand.Equals("Hammer"))
        {
            ChangeTorchBg(defColor);
            ChangeHammerBg(pickedColor);
            ChangeGunBg(defColor);
        }
    }

    public void ChangeTorchBg(Color c)
    {
        torchBg1.color = c;
        torchBg2.color = c;
    }

    public void ChangeHammerBg(Color c)
    {
        hammerBg1.color = c;
        hammerBg2.color = c;
    }

    public void ChangeGunBg(Color c)
    {
        gunBg1.color = c;
        gunBg2.color = c;
    }

   
}
