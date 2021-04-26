using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMegaJackpot : Slot
{
    public override int Rarity => 3;

    public override SlotType Type => SlotType.MegaJackpot;

    public override string SuccessMessage => "MEGA JACKPOT! You Won 100x Esper!";

    public override string FailMessage => ShouldNotFailException.Message;

    public override bool Execute()
    {
        GameManager.Instance.Player.Esper += cost;
        GameManager.Instance.Player.Esper += cost * 100;
        return true;
    }
}
