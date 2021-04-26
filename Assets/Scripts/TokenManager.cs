using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TokenManager : MonoBehaviour
{
    public bool HasEnteredName { get; set; } = false;
    public void EnteredName()
    {
        HasEnteredName = true;
    }

}
