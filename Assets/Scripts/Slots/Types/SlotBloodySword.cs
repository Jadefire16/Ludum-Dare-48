using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBloodySword : Slot
{
    public override int Rarity => 10;

    public override SlotType Type => SlotType.BloodySwords;

    public override string SuccessMessage => "You Gain 1 Life But At The Cost Of Another Spin!";

    public override string FailMessage => "You Lose 1 Life But Return The Spin Cost!";

    public override bool Execute()
    {
        int x = 500;
        bool success = x > Random.Range(0, 1000);
        if (success)
        {
            GameManager.Instance.Player.AddLife(1);
            GameManager.Instance.Player.Esper -= cost;
        }
        else
        {
            GameManager.Instance.Player.Esper += cost;
            GameManager.Instance.Player.SubtractLife(1);
        }
        return success;
    }
}
