using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsVisuals : MonoBehaviour
{
    public Transform spawnPos;
    [Header("Effects")]
    public GameObject particlePrefab;
    public Animator lights, handle;
    [Header("Visuals")]
    public SpriteRenderer[] sprites = new SpriteRenderer[3];

    bool randomizing;


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

    private void Update()
    {
        if (randomizing)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].sprite = datas[Random.Range(0, slotDatas.Count)].sprite;
                if (sprites[i].sprite == null)
                    sprites[i].sprite = datas[0].sprite;
            }
        }
    }

    public Sprite GetSprite(SlotType type) => slotDatas[type].sprite;
    
    public void SpawnParticle(SlotType type)
    {

        ParticleSystem system = Instantiate(particlePrefab, spawnPos.position, spawnPos.rotation).GetComponent<ParticleSystem>();
        system.textureSheetAnimation.SetSprite(0, GetSprite(type)); // always set the 0th index of the animation to the correct slot
        Destroy(system.gameObject, 6f);
    }

    private void SlotPlayed(SlotType type, bool success, string message)
    {
        StartCoroutine(Animation(type,success, message));
    }

    public IEnumerator Animation(SlotType type, bool success, string message)
    {
        handle.Play("Spin");
        yield return new WaitForSeconds(0.25f);
        randomizing = true;
        yield return new WaitForSeconds(2.75f);
        randomizing = false;
        if (type != SlotType.None)
        {
            SpawnParticle(type);

            if(success)
                lights.Play("Win");

            for (int i = 0; i < sprites.Length; i++)
                sprites[i].sprite = slotDatas[type].sprite;
            yield return null;
        }
        else
            yield return null;


    }
}
