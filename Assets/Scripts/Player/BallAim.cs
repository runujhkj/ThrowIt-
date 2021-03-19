using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAim : MonoBehaviour
{

    private CharacterController ctrl;
    private LineRenderer line;
    public Vector3 AimDirection { get; private set; }
    private float inputX;
    private Vector2 startDirection, currentDirection;
    
    // Start is called before the first frame update
    private void Start()
    {
        ctrl = GetComponent<CharacterController>();
        line = GameObject.FindWithTag("HUD").GetComponentInChildren<LineRenderer>();
        AimDirection = ctrl.transform.forward;
        line.SetPosition(0, ctrl.transform.position + ctrl.center);
        line.SetPosition(1, ctrl.transform.position + ctrl.center + (AimDirection * 2));
        startDirection = line.GetPosition(1) - line.GetPosition(0);
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, ctrl.transform.position + ctrl.center);
        line.SetPosition(1, ctrl.transform.position + ctrl.center + (AimDirection * 2));
        currentDirection = new Vector2(line.GetPosition(1).x - line.GetPosition(0).x,
            line.GetPosition(1).z - line.GetPosition(0).z);

        if (Input.GetAxis("Horizontal") > 0 && AimDirection.z > -0.5f)
        {
            AimDirection = Quaternion.AngleAxis(2f, Vector3.up) * AimDirection;
        }
        else if (Input.GetAxis("Horizontal") < 0 && AimDirection.z < 0.5f)
        {
            AimDirection = Quaternion.AngleAxis(-2f, Vector3.up) * AimDirection;
        }
        
        //print(currentDirection + "; " + Vector2.Angle(startDirection, currentDirection) + ";c" + (Vector2.Angle(startDirection, currentDirection) < 30f) + "\n" + AimDirection);
        /*if (Vector2.Angle(AimDirection, currentDirection) < 30f)
        {
            AimDirection = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * 2f, Vector3.up) * AimDirection;
        }*/
        //print(aimDirection);
    }
}
