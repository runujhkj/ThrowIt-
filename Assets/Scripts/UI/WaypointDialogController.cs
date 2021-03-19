using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointDialogController : MonoBehaviour
{
    private bool triggered = false;
    private Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = this.GetComponent<Text>();
        txt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player in trigger, not already triggered");
                txt.enabled = true;
                triggered = true;
                /*StartCoroutine(Wait5Sec());
                txt.enabled = false;*/
            }
        }
    }

    IEnumerator Wait5Sec()
    {
        yield return new WaitForSeconds(5);
    }
}
