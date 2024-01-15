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
    [SerializeField]
    private KeiYuri_BecomeTamatomo becomeTamatomo;
    private void Start()
    {
        currentTamatomo = tm.currentTamatomo;
        if(currentTamatomo != null )
        {
            sr.sprite = currentTamatomo.idle;
            gameObject.SetActive(true);
            if (!currentTamatomo.tData.isTamatomo)
            {
                if (currentTamatomo.tData.count == 3)
                {
                    ReceiveBadge();
                }
                else if (currentTamatomo.IsLeave())
                {
                    LeaveTamatomo();

                }
            }
        }
        else gameObject.SetActive(false);
    }

    private void ReceiveBadge()
    {
        selectIcon.enabled = false;
        badge.SetActive(true);
        badge.GetComponent<KeiYuri_TamatomoBadge>().ReceiveBadge(tm.currentTamatomo.tData.tamatomoBadge);
        currentTamatomo.ReceiveBadge();
        StartCoroutine(ReceiveBadgeAnimation());
        kiraritchiMove.Yorokobi(3);
    }

    IEnumerator ReceiveBadgeAnimation()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 2; j++)
            {
                sr.sprite = currentTamatomo.yorokobiSprites[j];
                yield return new WaitForSeconds(waitTime);
            }
        }
        sr.sprite = currentTamatomo.yorokobiSprites[0];
        badge.SetActive(false);
        selectIcon.enabled = true;
        if (currentTamatomo.tData.tamatomoBadge == 3) BecomeTamatomo();
        else if (currentTamatomo.IsLeave()) LeaveTamatomo();
    }

    private void BecomeTamatomo()
    {
        currentTamatomo.BecomeTamatomo();
        becomeTamatomo.gameObject.SetActive(true);
        becomeTamatomo.StartAnimation();
    }

    public void Invited()
    {
        selectIcon.enabled = false;
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
        selectIcon.enabled = true;
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
