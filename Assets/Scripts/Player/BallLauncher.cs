using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour {

    public GameObject ballPrefab;
    public float ballSpeed = 5.0f;
    public float powerSpeed = 5.0f;
    private GameObject cameraBrain;
    private CharacterController characterController;
    private Rigidbody rb;
    private Slider slider;
    private BallAim ballAim;

    private static GameObject instance;

    private float timer;
    
    // Use this for initialization
    private void Start ()
    {
        ballAim = GetComponent<BallAim>();
        slider = GameObject.FindWithTag("HUD").GetComponentInChildren<Slider>();
        timer = 0.0f;
        cameraBrain = GameObject.FindWithTag("MainCamera");
        characterController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
    private void Update () {
        if (Input.GetButtonDown("Throw"))
        {
            timer = Time.time;
            slider.value += Time.deltaTime * powerSpeed;
            instance = Instantiate(ballPrefab);
            instance.transform.position = characterController.transform.position;
            instance.transform.position += new Vector3(0f, characterController.height * 2f / 3f, 0f);
            instance.transform.position += characterController.transform.forward;
            rb = instance.GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
        if (Input.GetButton("Throw"))
        {
            slider.value += Time.deltaTime * powerSpeed;
        }
        //print(cameraBrain.transform.rotation);
        if (Input.GetButtonUp("Throw"))
        {
            slider.value = 0f;
            timer = Time.time - timer;
            rb.isKinematic = false;
            rb.velocity = ballAim.AimDirection * 2 + ballAim.AimDirection * (ballSpeed * (timer < 3 ? timer/1.25f : 3f/1.25f));
            //print(rb.velocity + ", " + timer);
            timer = 0;
        }
    }
}
