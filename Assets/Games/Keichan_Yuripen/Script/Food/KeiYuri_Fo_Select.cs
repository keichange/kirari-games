using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_Fo_Select : MonoBehaviour
{
    public GameObject[] buttons;
    private int currentButtonNum = 0;
    private GameObject currentButton;
    public float x;

    private void OnEnable()
    {
        currentButtonNum = 0;
        MoveCursor();
    }

    // Start is called before the first frame update
    void Start()
    {
        MoveCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeCurrentButtonNum();
            MoveCursor();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)) Select();

    }

    private void ChangeCurrentButtonNum()
    {
        currentButtonNum = (currentButtonNum + 1) % buttons.Length;
    }

    private void MoveCursor()
    {
        currentButton = buttons[currentButtonNum];
        Vector3 cbPos = Camera.main.ScreenToWorldPoint(currentButton.transform.position);
        Vector3 pos = new Vector3(x, cbPos.y, 0);
        transform.position = pos;
    }

    private void Select()
    {
        buttons[currentButtonNum].GetComponent<KeiYuri_SelectEvent>().OnSelected();
    }
}
