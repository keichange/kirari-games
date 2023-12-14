using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_Selection : MonoBehaviour
{
    private bool iconIsActive = false;
    int select = -1;
    public GameObject[] icons;
    public string SceneNames;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            iconIsActive = true;
            select = (select + 1) % icons.Length;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            icons[select].GetComponent<KeiYuri_ChangeScene>().ChangeScene();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            iconIsActive = false;
            select = -1;
        }

        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].SetActive(i == select && iconIsActive);
        }

    }
}
