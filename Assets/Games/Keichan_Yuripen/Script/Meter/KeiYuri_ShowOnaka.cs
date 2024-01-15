using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeiYuri_ShowOnaka : MonoBehaviour
{
    public SpriteRenderer[] onakas;
    public Sprite[] manpukuImages;
    public Sprite[] kuuhukuImages;
    public KeiYuri_KiraritchiData kd;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            if(i+1 <= kd.kiraritchiData.satietyLevel)
            {
                onakas[i].sprite = manpukuImages[i];
            }
            else
            {
                onakas[i].sprite = kuuhukuImages[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
