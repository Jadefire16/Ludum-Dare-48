using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoSingleton<EventManager>
{
    public static event System.Action RequestGameStart;


    public void PlayerReady() => RequestGameStart?.Invoke();
}
