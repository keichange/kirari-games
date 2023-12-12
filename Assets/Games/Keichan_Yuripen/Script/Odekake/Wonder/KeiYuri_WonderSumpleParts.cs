using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class KeiYuri_WonderSampleParts : MonoBehaviour
{
    [SerializeField]
    private int id;
    [SerializeField]
    private KeiYuri_GameSettings gs;
    private SpriteRenderer sr;
    private WonderSettings ws;
    private OchimonoParts partsData;

    // Start is called before the first frame update
    void Start()
    {
        ws = gs.wonder;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSample(int[] partsIds)
    {
        partsData = ws.getParts(partsIds[id]);
        sr.sprite = partsData.img;
        transform.position = new Vector3(transform.position.x, transform.position.y, partsData.layer);
    }
}
