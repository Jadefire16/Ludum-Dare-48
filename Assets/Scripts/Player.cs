using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public void SubtractLife(int value)
    {
        if(currentArmor < value)
        {
            int remainder = currentArmor - value * -1;
            currentArmor = 0;
            currentLife -= value;
        }
        if (currentArmor >= value)
            currentArmor -= value;
    }
    public void AddLife(int value)
    {
        currentLife += value;
        currentLife = Mathf.Clamp(currentLife, 0, maxLife);
    }

    public int SetLife { set => currentLife = value; } // use to ignore armor!
    public int Life { get => currentLife; }
    public int Esper { get => currentEsper; set => currentEsper = value; }
    public int Armor { get => currentArmor; set => currentArmor = value; }


    [Header("Values")]
    [SerializeField] int currentLife = 100;
    [SerializeField] int currentEsper = 100;
    [SerializeField] int currentArmor = 100;

    int maxLife = 100;

    private void Start()
    {
        // Load previous Esper
    }

    private void OnDisable()
    {
        // Save Esper
    }
}
