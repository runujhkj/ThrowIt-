using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public float vehicleSpeed;
    private CharacterController ctrl;
    
    // Start is called before the first frame update
    void Start()
    {
        ctrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ctrl.Move(ctrl.transform.forward * (vehicleSpeed * Time.deltaTime));
    }
}
