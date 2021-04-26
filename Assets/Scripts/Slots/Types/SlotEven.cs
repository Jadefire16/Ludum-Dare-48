using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotEven : Slot
{
    public override int Rarity => 50;

    public override SlotType Type => SlotType.Even;

    public override string SuccessMessage => "Lucky! You Broke Even, Returning Your Spin!";

    public override string FailMessage => ShouldNotFailException.Message;

    public override bool Execute()
    {
        GameManager.Instance.Player.Esper += cost;
        return true;
    }
}
