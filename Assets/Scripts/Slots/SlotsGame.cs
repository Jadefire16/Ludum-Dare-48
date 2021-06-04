using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;

public class SlotsGame : MonoBehaviour
{
    public static event Action<SlotType, bool, string> SlotPlayedEvent;
    //int difficulty = 1; maybe have some difficulty later
    //Create a slot class and processor similar to the minigame handler that deals with slots
    [SerializeField] int cost = 10;
    [SerializeField] List<GameObject> buttons = new List<GameObject>();

    [SerializeField] TMP_InputField costField;
    // When the game starts create a new set of slots based on the current cost, the floor cost should reflect the amount
    // When Player Begins The Slot 
    [ShowInInspector] Dictionary<SlotType, Slot> slots = new Dictionary<SlotType, Slot>();
    bool initialized;
    int maxRarityRange;
    int spins = 0;

    Vector3 worldMousePos;

    bool spinning = false;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (initialized)
            return;
        slots.Clear();

        var allSlots = Assembly.GetAssembly(typeof(Slot)).GetTypes().Where(t => t.IsSubclassOf(typeof(Slot)) && t.IsAbstract == false);
        int previousRarityRange = 0;
        foreach (var slotType in allSlots)
        {
           Debug.Log($"Current Previous Rarity Range {previousRarityRange}");
            Slot slot = Activator.CreateInstance(slotType) as Slot;
           slot.Cost = cost;
           slot.Range = new Vector2(previousRarityRange, previousRarityRange + slot.Rarity);
           Debug.Log($"Slot Rarity Range {slot.Range} of {slot}");
           previousRarityRange += slot.Rarity;
           Debug.Log($"New Previous Rarity Range {previousRarityRange}");
           maxRarityRange += slot.Rarity;
            slots.Add(slot.Type, slot);
        }
        initialized = true;
    }

    public void UpdateSlotCosts()
    {
        foreach (var item in slots.Values)
            item.Cost = cost;

    }

    [ContextMenu("Spin")]
    public void Spin()
    {
        if (spinning)
            return;
        spinning = true;
        if (spins > 25)
        {
            spins = 0;
            UnityEngine.Random.InitState((int)Mathf.PI * UnityEngine.Random.Range(2, 10000) / 2);
        }
        if (GameManager.Instance.Player.Esper < cost)
            return;
        GameManager.Instance.Player.Esper -= cost;
        int val = UnityEngine.Random.Range(0, maxRarityRange);
        Slot activeSlot = null;

        foreach (var slot in slots.Values)
        {
            if (val <= slot.Range.y && val >= slot.Range.x)
            {
                activeSlot = slot;
                break;
            }
            else
                continue;
        }
        if (activeSlot == null)
        {
            Debug.LogError($"Out Of Rarity Range! {val}");
            return;
        }
        bool success = activeSlot.Execute(); // set some event to notify text when this updates or something
        Debug.Log(success ? activeSlot.SuccessMessage : activeSlot.FailMessage);
        SlotPlayedEvent?.Invoke(activeSlot.Type, success, success ? activeSlot.SuccessMessage : activeSlot.FailMessage);
        StartCoroutine(Wait(3f));
    }

    public IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        spinning = false;
    }

    public void UpdateCost()
    {
        cost = int.Parse(costField.text);
        UpdateSlotCosts();
    }

}
