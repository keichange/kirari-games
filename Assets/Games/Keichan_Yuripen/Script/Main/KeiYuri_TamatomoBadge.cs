using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_TamatomoBadge : MonoBehaviour
{
    [SerializeField]
    private Sprite[] badgeSprites;
    [SerializeField]
    private SpriteRenderer sr;
    private void Start()
    {
    }

    public void ReceiveBadge(int level)
    {
        sr.sprite = badgeSprites[level];
    }
}
