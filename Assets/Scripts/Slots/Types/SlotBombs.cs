using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBombs : Slot
{
    public override int Rarity => 14;

    public override SlotType Type => SlotType.Bombs;

    public override string SuccessMessage => ShouldNotSucceedException.Message;

    public override string FailMessage => " A Bomb Went Off! Poor Luck! You Lost 1 Life And 25% of Your Esper!";

    public override bool Execute()
    {
        GameManager.Instance.Player.SubtractLife(1);
        GameManager.Instance.Player.Esper = Mathf.RoundToInt(GameManager.Instance.Player.Esper * 0.25f);
        return false;
    }
}
