using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class ThrowItController : MonoBehaviour
{
    public GameObject[] pedestrians, vehicles;
    public int PlayerScore { get; set; } = 0;

    private SpawnZones spawnZones;
    private Text score;
    private Canvas results;
    private UserInput input;


    // Start is called before the first frame update
    void Start()
    {
        spawnZones = GameObject.FindWithTag("Respawn").GetComponent<SpawnZones>();
        score = GameObject.FindWithTag("HUD").GetComponent<Text>();
        results = GameObject.FindWithTag("Finish").GetComponent<Canvas>();
        results.enabled = false;
        input = GameObject.FindWithTag("Player").GetComponent<UserInput>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + PlayerScore + "/300";
        if (PlayerScore >= 300)
        {
            results.enabled = true;
            input.ReleaseControl();
        }
    }
}
