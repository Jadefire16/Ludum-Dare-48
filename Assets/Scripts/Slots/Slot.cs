using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Slot
{
    public abstract int Rarity { get; }
    public abstract SlotType Type { get; }
    public abstract string SuccessMessage { get; }
    public abstract string FailMessage { get; }
    public int Cost { get => cost; set => cost = value; }
    public Vector2 Range { get => range; set => range = value; }

    protected int cost;
    protected Vector2 range;

    public abstract bool Execute();

    public static System.Exception ShouldNotFailException { get => throw new System.Exception("Null, Should Not Fail!"); }
    public static System.Exception ShouldNotSucceedException { get => throw new System.Exception("Null, Should Not Succeed!"); }


}
