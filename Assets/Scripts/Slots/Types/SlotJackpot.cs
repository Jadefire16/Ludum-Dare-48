using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotJackpot : Slot
{
    public override int Rarity => 10;

    public override SlotType Type => SlotType.Jackpot;

    public override string SuccessMessage => "JACKPOT! You Won 10x Esper!";

    public override string FailMessage => ShouldNotFailException.Message;

    public override bool Execute()
    {
        GameManager.Instance.Player.Esper += cost;
        GameManager.Instance.Player.Esper += cost * 10;
        return true;
    }
}
