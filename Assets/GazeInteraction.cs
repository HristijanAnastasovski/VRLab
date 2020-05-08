using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GazeInteraction : MonoBehaviour
{
    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    public GameObject player;
    public GameObject descriptionText;
    private bool showText = false;
    public TextMeshProUGUI descriptionButtonTitle;
    public GameObject door;
    public GameObject bench; 
    private VRFPSControll fpsScript;
    private Vector3 currentPlayerPosition;

    // Use this for initialization
    void Start()
    {
       fpsScript = player.GetComponent<VRFPSControll>();
       currentPlayerPosition = player.transform.position; 
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

    public void InteractWithDoor()
    {
        if (door.transform.eulerAngles.y == 90.0f)
        {
            door.transform.Rotate(new Vector3(0, -90, 0));
        } else
        {
            door.transform.Rotate(new Vector3(0, 90, 0));
        }
     
    }

    public void SitOrStandInteraction()
    {
        if (!fpsScript.isSitting)
        {
            //Sit down
            fpsScript.isSitting = true;
            currentPlayerPosition = player.transform.position;
            Vector3 sittingPosition = new Vector3(bench.transform.position.x, bench.transform.position.y + 1, bench.transform.position.z);
            player.transform.position = sittingPosition;
        } else
        {
            //Stand up
            fpsScript.isSitting = false;
            player.transform.position = new Vector3(player.transform.position.x, currentPlayerPosition.y, player.transform.position.z + 2f);
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
        timer = 0;
        Debug.Log("PointerExit");
    }

    public void PointerDown()
    {
        Debug.Log("PointerDown");
    }
}
