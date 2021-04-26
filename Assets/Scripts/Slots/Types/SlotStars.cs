using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotStars : Slot
{
    public override int Rarity => 20;
    public override SlotType Type => SlotType.Stars;

    public override string SuccessMessage => "Congratulations! You Won 3x Esper!";
    public override string FailMessage => ShouldNotFailException.Message;

    public override bool Execute()
    {
        GameManager.Instance.Player.Esper += cost;
        GameManager.Instance.Player.Esper += cost * 3;
        return true;
    }
}
