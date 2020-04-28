using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonInteraction : MonoBehaviour
{
    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    public GameObject player;
    public GameObject descriptionText;
    private bool showText = false;
    public TextMeshProUGUI descriptionButtonTitle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gazedAt)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                // execute pointerdown handler
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                timer = 0f;
            }
        }

    }

    public void newGame()
    {
        player.transform.position = new Vector3((float)9.45, (float)1.82, (float)-9.02);
    }

    public void exitGame()
    {
        Application.Quit();
        
    }

    public void showHideDescription()
    {
        if (!showText)
        {
            descriptionButtonTitle.text = "Hide Info";
            descriptionText.SetActive(true);
            showText = true;
        } else
        {
            descriptionButtonTitle.text = "Show Info";
            descriptionText.SetActive(false);
            showText = false;
        }
    }

    public void PointerEnter()
    {
        gazedAt = true;
        Debug.Log("PointerEnter");
    }

    public void PointerExit()
    {
        gazedAt = false;
        Debug.Log("PointerExit");
    }

    public void PointerDown()
    {
        Debug.Log("PointerDown");
    }
}
