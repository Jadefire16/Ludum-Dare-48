using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHearts : Slot
{
    public override int Rarity => 30;
    public override SlotType Type => SlotType.Hearts;

    public override string SuccessMessage => "Congratulations! You Won 1 Life!";

    public override string FailMessage => ShouldNotFailException.Message;


    public override bool Execute()
    {
        GameManager.Instance.Player.AddLife(1);
        return true;
    }
}
