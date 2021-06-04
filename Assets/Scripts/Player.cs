using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action<int> UpdateHealthEvent;
    public static event Action<int> UpdateEsperEvent;
    public static event Action<int> UpdateArmorEvent;

    public static event Action PlayerIsDeadEvent;

    bool dead = false;

    public void SubtractLife(int value)
    {
        if(currentArmor == 0)
        {
            currentLife -= value;
        }
        else if(currentArmor < value)
        {
            _ = currentArmor - value * -1;
            currentArmor = 0;
            currentLife -= value;
        }
        if (currentArmor >= value)
            currentArmor -= value;
        UpdateHealthEvent?.Invoke(currentLife);
        UpdateArmorEvent?.Invoke(currentArmor);
        CheckLife();
    }
    public void AddLife(int value)
    {
        currentLife += value;
        currentLife = Mathf.Clamp(currentLife, 0, maxLife);
        UpdateHealthEvent?.Invoke(currentLife);
    }

    public void AddEsper(int value) // Unity needs to get their shit together and add support for properties god damnitt
    {
        Esper += value;
    }

    public int SetLife { set { currentLife = value; UpdateHealthEvent?.Invoke(currentLife); CheckLife(); } } // use to ignore armor!
    public int Life { get => currentLife; }
    public int Esper { get => currentEsper; set { currentEsper = value; UpdateEsperEvent?.Invoke(currentEsper); } }
    public int Armor { get => currentArmor; set { currentArmor = value; UpdateArmorEvent?.Invoke(currentArmor); } }


    [Header("Values")]
    [SerializeField] int currentLife = 3;
    [SerializeField] int currentEsper = 1000;
    [SerializeField] int currentArmor = 0;

    int maxLife = 3;

    private void Update()
    {
        CheckLife();
    }

    public void CheckLife()
    {
        if (!dead)
        {
            if (currentLife <= 0)
            {
                Debug.Log("Dead");
                PlayerIsDeadEvent?.Invoke();
                dead = true;
            }
        }
    }

}
