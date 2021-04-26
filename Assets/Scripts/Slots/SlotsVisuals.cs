using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsVisuals : MonoBehaviour
{
    public GameObject particlePrefab;
    public Transform spawnPos;
    public Animator lights, handle;

    [SerializeField] List<SlotData> datas = new List<SlotData>();

    Dictionary<SlotType, SlotData> slotDatas = new Dictionary<SlotType, SlotData>();


    private void OnEnable()
    {
        SlotsGame.SlotPlayedEvent += SlotPlayed;

        for (int i = 0; i < datas.Count; i++)
            slotDatas.Add(datas[i].type, datas[i]);

    }

    private void OnDisable()
    {
        SlotsGame.SlotPlayedEvent -= SlotPlayed;
    }

    public Sprite GetSprite(SlotType type) => slotDatas[type].sprite;
    
    public void SpawnParticle(SlotType type)
    {

        ParticleSystem system = Instantiate(particlePrefab, spawnPos.position, spawnPos.rotation).GetComponent<ParticleSystem>();
        system.textureSheetAnimation.SetSprite(0, GetSprite(type)); // always set the 0th index of the animation to the correct slot
        Destroy(system.gameObject, 6f);
    }

    private void SlotPlayed(SlotType type, string message)
    {
        StartCoroutine(Animation(type, message));
    }

    public IEnumerator Animation(SlotType type, string message)
    {
        handle.Play("Spin");
        yield return new WaitForSeconds(3);
        if (type != SlotType.None)
        {
            SpawnParticle(type);
            lights.Play("Win");
            yield return null;
        }
        else
            yield return null;


    }

}
