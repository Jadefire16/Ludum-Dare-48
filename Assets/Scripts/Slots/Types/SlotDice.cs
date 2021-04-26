using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotDice : Slot
{
    public override int Rarity => 30;
    public override SlotType Type => SlotType.Dice;

    public override string SuccessMessage => "Congratulations! You Won Double Your Esper and Gain 1 Life!";

    public override string FailMessage => "Lose! You Lost 1 Life and Half Your Esper!";

    public override bool Execute()
    {
        int x = UnityEngine.Random.Range(0, 100);
        bool success = x <= 50;
        if (success)
        {
            GameManager.Instance.Player.AddLife(1);
            GameManager.Instance.Player.Esper *= 2;
        }
        else
        {
            GameManager.Instance.Player.SubtractLife(1);
            GameManager.Instance.Player.Esper = Mathf.RoundToInt(GameManager.Instance.Player.Esper * 0.5f);
        }
        return success;
    }
}
