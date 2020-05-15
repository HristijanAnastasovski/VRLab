using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RadioInteraction : MonoBehaviour
{
    public AudioSource aSrc;
    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    // Start is called before the first frame update
    void Start()
    {
        aSrc = GetComponent<AudioSource>();
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

    public void PointerEnter()
    {
        gazedAt = true;
    }

    public void PointerExit()
    {
        gazedAt = false;
        timer = 0;
    }

    public void PointerDown()
    {
        if (!aSrc.isPlaying)
        {
            aSrc.Play();
        } else
        {
            aSrc.Stop();
        }
    }
}
