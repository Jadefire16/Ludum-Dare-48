using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotCats : Slot
{
    public override int Rarity => 40;
    public override SlotType Type => SlotType.Cats;

    public override string SuccessMessage => "Congratulations! You Won 2x Esper!";

    public override string FailMessage => ShouldNotFailException.Message;

    public override bool Execute()
    {
        GameManager.Instance.Player.Esper += cost;
        GameManager.Instance.Player.Esper += cost * 2;
        return true;
    }
}
