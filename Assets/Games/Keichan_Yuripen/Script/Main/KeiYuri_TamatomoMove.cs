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

    [SerializeField]
    private GameObject badge;
    [SerializeField]
    private KeiYuri_Main_KiraritchiMove kiraritchiMove;
    private void OnEnable()
    {
        currentTamatomo = tm.currentTamatomo;
        if(currentTamatomo != null )
        {
            sr.sprite = currentTamatomo.idle;
            gameObject.SetActive(true);
            if(currentTamatomo.count == 3)
            {
                ReceiveSeal();
            }
            else if(currentTamatomo.IsLeave())
            {
                LeaveTamatomo();
                
            }
        }
        else gameObject.SetActive(false);
    }

    private void ReceiveSeal()
    {
        badge.SetActive(true);
        badge.GetComponent<KeiYuri_TamatomoBadge>().ReceiveBadge(tm.currentTamatomo.tamatomoSeal);
        currentTamatomo.ReceiveSeal();
        StartCoroutine(ReceiveSealAnimation());
        kiraritchiMove.Yorokobi(3);
    }

    IEnumerator ReceiveSealAnimation()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 2; j++)
            {
                sr.sprite = currentTamatomo.yorokobiSprites[j];
                yield return new WaitForSeconds(waitTime);
            }
        }
        badge.SetActive(false);
        LeaveTamatomo();
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

    public void LeaveTamatomo()
    {
        selectIcon.enabled = false;
        currentTamatomo.Leave();
        tm.currentTamatomo = null;
        StartCoroutine(LeaveAnimation());
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
