using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBugs : Slot
{
    public override int Rarity => 3;

    public override SlotType Type => SlotType.Bugs;

    public override string SuccessMessage => ShouldNotSucceedException.Message;

    public override string FailMessage => "Error";

    public override bool Execute()
    {
        return false;
    }
}
