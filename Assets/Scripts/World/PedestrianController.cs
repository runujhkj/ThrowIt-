using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianController : MonoBehaviour
{

    private Animator animator;
    private CharacterController ctrl;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ctrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ctrl.Move((ctrl.transform.forward + ctrl.transform.up) * Time.deltaTime);
    }
}
