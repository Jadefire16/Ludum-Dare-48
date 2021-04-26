using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotArmors : Slot
{
    public override int Rarity => 40;

    public override SlotType Type => SlotType.Armors;

    public override string SuccessMessage => "A Little Armor Goes A Long Way! You Gained 2 Armor!";

    public override string FailMessage => ShouldNotFailException.Message;

    public override bool Execute()
    {
        GameManager.Instance.Player.Armor += 2;
        return true;
    }
}
