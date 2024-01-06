using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tamatomo;
using static KiraritchiFoodPreferences;
using static FoodSettings;

public class KeiYuri_EatingTamatomo : MonoBehaviour
{
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float animationWaitTime;

    [SerializeField]
    private KeiYuri_TamatomoData currentTamatomo;
    [SerializeField]
    private KeiYuri_TamatomoManager tm;

    [SerializeField]
    private KeiYuri_EatenFood foodScript;

    private Preferences preference;

    private Sprite[] eatingSprites;
    private Sprite[] reactionSprites;
    [SerializeField]
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EatingTamatomo(Tamatomos currentTamatomoName, Foods currentFood)
    {
        currentTamatomo = SearchTamatomo(currentTamatomoName);
        preference = currentTamatomo.Eat(currentFood);
        switch (preference)
        {
            case Preferences.çDÇ´:
                eatingSprites = currentTamatomo.eatingSpriteFavorite;
                reactionSprites = currentTamatomo.happySprites;
                break;
            case Preferences.åôÇ¢:
                eatingSprites = currentTamatomo.eatingSpriteHated;
                reactionSprites = currentTamatomo.angrySprites;
                break;
            case Preferences.ïÅí :
                eatingSprites = currentTamatomo.eatingSpriteNormal;
                reactionSprites = currentTamatomo.yorokobiSprites;
                break;

        }
        StartCoroutine(EatingAnimation());
    }

    IEnumerator EatingAnimation()
    {
        foodScript.ChangeSprite(0);
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 2; j++)
            {
                sr.sprite = eatingSprites[j];
                yield return new WaitForSeconds(animationWaitTime);
                foodScript.ChangeSprite(i);
            }
        }

        switch(preference)
        {
            case Preferences.çDÇ´:
                StartCoroutine(FavoriteAnimation());
                break;
            case Preferences.åôÇ¢:
                StartCoroutine(HatedAnimation());
                break;
            case Preferences.ïÅí :
                StartCoroutine(NormalAnimation());
                break;

        }

        
    }

    IEnumerator FavoriteAnimation()
    {
        float[] y = { transform.position.y, transform.position.y + jumpHeight };
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                float x = transform.position.x;
                float z = transform.position.z;
                transform.position = new Vector3(x, y[i], z);

                sr.sprite = reactionSprites[i];
                yield return new WaitForSeconds(animationWaitTime);
            }

        }
    }

    IEnumerator HatedAnimation()
    {
        sr.sprite = reactionSprites[0];
        yield return new WaitForSeconds(animationWaitTime);
        sr.sprite = reactionSprites[1];
    }

    IEnumerator NormalAnimation()
    {
        sr.sprite = currentTamatomo.sit;
        yield return null;
    }

    private KeiYuri_TamatomoData SearchTamatomo(Tamatomos currentTamatomoName)
    {
        foreach(KeiYuri_TamatomoData tamatomoData in tm.tamatomoDatas)
        {
            if (tamatomoData.tamatomoName == currentTamatomoName) return tamatomoData;
        }
        return null;
    }
}
