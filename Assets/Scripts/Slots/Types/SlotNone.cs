using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotNone : Slot
{
    public override int Rarity => 300;

    public override SlotType Type => SlotType.None;

    public override string SuccessMessage => ShouldNotSucceedException.Message;

    public override string FailMessage => "Too Bad! Didn't Win Anything This Time!";

    public override bool Execute()
    {
        return false;
    }
}
