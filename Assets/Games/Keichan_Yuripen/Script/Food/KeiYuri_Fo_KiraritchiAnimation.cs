using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_Fo_KiraritchiAnimation : MonoBehaviour
{
    private int currentSpriteNum;
    [SerializeField]
    private KeiYuri_EatingManager em;
    public SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite[] favoriteSprites;
    [SerializeField]
    private Sprite[] hatedSprites;
    [SerializeField]
    private Sprite[] normalSprites;
    private KiraritchiFoodPreferences.Preferences preferences;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnimation()
    {
        StartCoroutine(EatingAnimation());
    }

    IEnumerator EatingAnimation()
    {
        preferences = em.currentFoodsPreference;
        Debug.Log(preferences);
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 2; j++)
            {
                switch (preferences)
                {
                    case KiraritchiFoodPreferences.Preferences.D‚«:
                        spriteRenderer.sprite = favoriteSprites[j];
                        break;
                    case KiraritchiFoodPreferences.Preferences.Œ™‚¢:
                        spriteRenderer.sprite = hatedSprites[j];
                        break;
                    case KiraritchiFoodPreferences.Preferences.•’Ê:
                        spriteRenderer.sprite = normalSprites[j];
                        break;
                }
                yield return new WaitForSeconds(1);
            }
        }
        if(preferences == KiraritchiFoodPreferences.Preferences.Œ™‚¢)
        {
            spriteRenderer.sprite = hatedSprites[2];
            yield return new WaitForSeconds(1);
            spriteRenderer.sprite = hatedSprites[3];
        }
    }

    public void NextSprite()
    {
        
        currentSpriteNum = (currentSpriteNum + 1) % favoriteSprites.Length;
        
    }
}
