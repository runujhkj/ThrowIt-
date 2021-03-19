using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        StartCoroutine(WaitToDespawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitToDespawn()
    {
        yield return new WaitForSeconds(6);
        Destroy(this.gameObject);
    }
}
