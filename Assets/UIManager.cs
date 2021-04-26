using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthUI;
    public TextMeshProUGUI esperUI;
    public TextMeshProUGUI armorUI;

    public const string times = "x";


    private void OnEnable()
    {
        Player.UpdateHealthEvent += UpdateHealth;
        Player.UpdateArmorEvent += UpdateArmor;
        Player.UpdateEsperEvent += UpdateEsper;
    }

    private void OnDisable()
    {
        Player.UpdateHealthEvent -= UpdateHealth;
        Player.UpdateArmorEvent -= UpdateArmor;
        Player.UpdateEsperEvent -= UpdateEsper;
    }

    public void UpdateHealth(int health) => healthUI.text = times + health.ToString();
    public void UpdateEsper(int esper)
    {
        Debug.Log($"Esper: {esper}");
        esperUI.text = times + esper.ToString();
    }
    public void UpdateArmor(int armor) => armorUI.text = times + armor.ToString();



}
