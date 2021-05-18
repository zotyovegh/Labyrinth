using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayManagement : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI torchAmount;
    [SerializeField]
    public TextMeshProUGUI hammerLife;
    [SerializeField]
    public TextMeshProUGUI bulletAmount;
    [SerializeField]
    public Image torchBg1;
    [SerializeField]
    public Image torchBg2;
    [SerializeField]
    public Image hammerBg1;
    [SerializeField]
    public Image hammerBg2;
    [SerializeField]
    public Image gunBg1;
    [SerializeField]
    public Image gunBg2;

    private readonly Color _defColor = new Color(255, 255, 255, 0.05f);
    private readonly Color _pickedColor = new Color(255, 255, 0, 0.15f);

    void Start()
    {
        UpdateUI();
    }
    
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
            ChangeTorchBg(_pickedColor);
            ChangeHammerBg(_defColor);
            ChangeGunBg(_defColor);
        }
        else if (GameSetup.itemInHand.Equals("Gun"))
        {
            ChangeTorchBg(_defColor);
            ChangeHammerBg(_defColor);
            ChangeGunBg(_pickedColor);
        }
        else if (GameSetup.itemInHand.Equals("Hammer"))
        {
            ChangeTorchBg(_defColor);
            ChangeHammerBg(_pickedColor);
            ChangeGunBg(_defColor);
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
