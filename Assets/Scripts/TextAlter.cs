using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAlter : MonoBehaviour
{
    public TokenManager token;
    TextMeshProUGUI text;
    public Color entryColour;

    private void Start()
    {
        if (text == null)
            text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (token.HasEnteredName)
            {
                text.text = "Awaiting Player Data";
                StartCoroutine(nameof(PlayerReadySequence));
            }
            else
                text.text = "Please Insert A Token";
        }
    }
    private IEnumerator PlayerReadySequence()
    {
        yield return new WaitForSeconds(1f);
        text.text = "Awaiting Soul Upload";
        text.color = entryColour;
        yield return new WaitForSeconds(1f);
        EventManager.Instance.PlayerReady();
    }
}
