using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRFPSControll : MonoBehaviour
{
    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    public float speed = 10.0f;
    public bool moveForward;
    public float jumpHeight = 500f;
    public bool isSitting = false;

    private CharacterController cc;
    private AudioSource aSrc;
    private GameObject player;

    public Vector3 startPosition;
    // Use this for initialization

    private void Awake()
    {
        startPosition = transform.position;
    }

    void Start()
    {
        cc = GetComponent<CharacterController>();
        aSrc = GetComponent<AudioSource>();
        player = GameObject.Find("Player");  
    }

    // Update is called once per frame
    void Update()
    {
        //move forward   
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f && !isSitting)
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }

        if (moveForward)
        {
            if (!aSrc.isPlaying)
            {
                aSrc.Play();
            }
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

            cc.SimpleMove(forward * speed);
        } else
        {
            if (aSrc.isPlaying)
            {
                aSrc.Stop();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Android close icon or back button tapped.
            Application.Quit();
        }

    }

}
