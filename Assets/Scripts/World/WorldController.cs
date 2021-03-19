using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public enum StadiumOrientation
    {
        NS,
        NESW,
        EW,
        SENW,
        SN,
        SWNE,
        WE,
        NWSE
    }

    public StadiumOrientation orientation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetTopSideStr()
    {
        if (orientation == StadiumOrientation.NS)
        {
            return "N";
        }
        else if (orientation == StadiumOrientation.NESW)
        {
            return "NE";
        }
        else if (orientation == StadiumOrientation.EW)
        {
            return "E";
        }
        else if (orientation == StadiumOrientation.SENW)
        {
            return "SE";
        }
        else if (orientation == StadiumOrientation.SN)
        {
            return "S";
        }
        else if (orientation == StadiumOrientation.SWNE)
        {
            return "SW";
        }
        else if (orientation == StadiumOrientation.WE)
        {
            return "W";
        }
        else if (orientation == StadiumOrientation.NWSE)
        {
            return "NW";
        }
        else
        {
            return "N";
        }
    }

    public string GetBottomSideStr()
    {
        if (orientation == StadiumOrientation.NS)
        {
            return "S";
        }
        else if (orientation == StadiumOrientation.NESW)
        {
            return "SW";
        }
        else if (orientation == StadiumOrientation.EW)
        {
            return "W";
        }
        else if (orientation == StadiumOrientation.SENW)
        {
            return "NW";
        }
        else if (orientation == StadiumOrientation.SN)
        {
            return "N";
        }
        else if (orientation == StadiumOrientation.SWNE)
        {
            return "NE";
        }
        else if (orientation == StadiumOrientation.WE)
        {
            return "E";
        }
        else if (orientation == StadiumOrientation.NWSE)
        {
            return "SE";
        }
        else
        {
            return "S";
        }
    }
}
