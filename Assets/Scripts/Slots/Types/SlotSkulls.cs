using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSkulls : Slot
{
    public override int Rarity => 5;

    public override SlotType Type => SlotType.Skulls;

    public override string SuccessMessage => ShouldNotSucceedException.Message;

    public override string FailMessage => "Hard Loss! You Only Have 1 Life Now!";

    public override bool Execute()
    {
        GameManager.Instance.Player.SetLife = 1;
        return false;
    }
}
