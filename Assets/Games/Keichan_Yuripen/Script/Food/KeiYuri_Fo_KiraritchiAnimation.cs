using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_Fo_KiraritchiAnimation : MonoBehaviour
{
    private int currentSpriteNum;
    [SerializeField] private KeiYuri_EatingManager em;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] favoriteSprites;
    [SerializeField] private Sprite[] hatedSprites;
    [SerializeField] private Sprite[] normalSprites;
    [SerializeField] private Sprite[] drunkSprites;
    private Sprite[] animationSprites;
    [SerializeField] private Sprite sitSprite;

    private KiraritchiFoodPreferences.Preferences preferences;
    [SerializeField]
    private GameObject YorokobiKiraritchi;
    [SerializeField]
    private GameObject ChouYorokobiKiraritchi;

    [SerializeField]
    private KeiYuri_EatenFood foodScript;
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
        foodScript.ChangeSprite(0);
        preferences = em.currentFoodsPreference;
        if (em.currentFood == FoodSettings.Foods.���{��)
        {
            foreach (Sprite sprite in drunkSprites)
            {
                spriteRenderer.sprite = sprite;
                yield return new WaitForSeconds(1);
            }
        }
        else
        {
            switch (preferences)
            {
                case KiraritchiFoodPreferences.Preferences.�D��:
                    animationSprites = favoriteSprites;
                    break;
                case KiraritchiFoodPreferences.Preferences.����:
                    animationSprites = hatedSprites;
                    break;
                case KiraritchiFoodPreferences.Preferences.����:
                    animationSprites = normalSprites;
                    break;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    spriteRenderer.sprite = animationSprites[j];
                    yield return new WaitForSeconds(1);
                    foodScript.ChangeSprite(i);
                }
            }
        }
        switch(preferences)
        {
            case KiraritchiFoodPreferences.Preferences.����:
                StartHatedAnimation();
                break;
            case KiraritchiFoodPreferences.Preferences.�D��:
                gameObject.SetActive(false);
                StartChouYorokobiAnimation();
                break;
            case KiraritchiFoodPreferences.Preferences.����:
                spriteRenderer.sprite = sitSprite;
                break;
        }
    }

    private void StartHatedAnimation()
    {
        StartCoroutine(HatedAnimation());
    }

    private void StartYorokobiAnimation()
    {
        YorokobiKiraritchi.SetActive(true);
    }

    private void StartChouYorokobiAnimation()
    {
        ChouYorokobiKiraritchi.SetActive(true);
    }

    IEnumerator HatedAnimation()
    {
        spriteRenderer.sprite = hatedSprites[2];
        yield return new WaitForSeconds(1);
        spriteRenderer.sprite = hatedSprites[3];
    }

    public void NextSprite()
    {
        
        currentSpriteNum = (currentSpriteNum + 1) % favoriteSprites.Length;
        
    }
}
