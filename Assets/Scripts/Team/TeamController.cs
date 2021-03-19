using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    public bool atHome;
    private TeamInfo teamInfo;

    private void Awake()
    {
        atHome = String.Compare(gameObject.name, "Home", StringComparison.Ordinal) == 0;
        teamInfo = GetComponent<TeamInfo>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsHome()
    {
        return atHome;
    }

    public string GetAbbreviation()
    {
        return teamInfo.teamAbbreviation;
    }

    public override string ToString()
    {
        return teamInfo.teamName + " " + teamInfo.teamMascot + " - " + teamInfo.teamLocation;
        //return base.ToString();
    }
}
