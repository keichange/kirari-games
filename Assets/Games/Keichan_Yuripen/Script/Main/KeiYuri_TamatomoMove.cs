using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_TamatomoMove : MonoBehaviour
{
    [SerializeField]
    private KeiYuri_TamatomoManager tm;
    [SerializeField]
    private SpriteRenderer sr;

    [SerializeField]
    private KeiYuri_SelectIcon selectIcon;

    private KeiYuri_TamatomoData currentTamatomo;
    [SerializeField]
    private float waitTime = 1;
    private void OnEnable()
    {
        currentTamatomo = tm.currentTamatomo;
        if(currentTamatomo != null )
        {
            sr.sprite = currentTamatomo.idle;
            gameObject.SetActive(true);
            if(currentTamatomo.IsLeave())
            {
                selectIcon.enabled = false;
                currentTamatomo.Leave();
                tm.currentTamatomo = null;
                StartCoroutine(LeaveAnimation());
            }
        }
        else gameObject.SetActive(false);
        
    }

    public void Invited()
    {
        currentTamatomo = tm.currentTamatomo;
        currentTamatomo.Invite();
        StartCoroutine(InvitedAnimation());

    }

    IEnumerator InvitedAnimation()
    {
        sr.sprite = currentTamatomo.yorokobiSprites[0];
        transform.position = new Vector2(2.5f, 3.5f);
        yield return new WaitForSeconds(waitTime);
        sr.sprite = currentTamatomo.yorokobiSprites[1];
        transform.position = new Vector2(2.5f, 1.5f);
        yield return new WaitForSeconds(waitTime);
        sr.sprite = currentTamatomo.yorokobiSprites[0];
        transform.position = new Vector2(2.5f, -0.6f);
        yield return new WaitForSeconds(waitTime);
        sr.sprite = currentTamatomo.yorokobiSprites[1];
        yield return new WaitForSeconds(waitTime);
        sr.sprite = currentTamatomo.yorokobiSprites[0];
    }

    IEnumerator LeaveAnimation()
    {
        sr.sprite = currentTamatomo.yorokobiSprites[0];
        yield return new WaitForSeconds(waitTime);
        sr.sprite = currentTamatomo.yorokobiSprites[1];
        yield return new WaitForSeconds(waitTime);
        sr.sprite = currentTamatomo.yorokobiSprites[0];
        transform.position = new Vector2(2.5f, -0.6f);
        yield return new WaitForSeconds(waitTime);
        sr.sprite = currentTamatomo.yorokobiSprites[1];
        transform.position = new Vector2(2.5f, 1.5f);
        yield return new WaitForSeconds(waitTime);
        sr.sprite = currentTamatomo.yorokobiSprites[0];
        transform.position = new Vector2(2.5f, 3.5f);
        yield return new WaitForSeconds(waitTime);

        gameObject.SetActive(false);
        selectIcon.enabled = true;
    }
}
