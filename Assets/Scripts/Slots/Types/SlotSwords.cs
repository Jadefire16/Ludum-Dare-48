using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSwords : Slot
{
    public override int Rarity => 20;
    public override SlotType Type => SlotType.Swords;

    public override string SuccessMessage => "Congratulations! You Won The Duel And Doubled Your Esper!";

    public override string FailMessage => "Bad Luck! You Lost The Duel Costing You 1 Life!";

    public override bool Execute()
    {
        int x = Random.Range(0, 1000);
        bool success = x < 250;
        if (success)
        {
            GameManager.Instance.Player.AddLife(1);
            GameManager.Instance.Player.Esper *= 2;
        }
        else
            GameManager.Instance.Player.SubtractLife(1);

        return success;
    }
}
