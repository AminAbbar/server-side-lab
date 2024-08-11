using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class playerData
{
    public string id;
    public int level;
    public int health;

    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>
        {

            { "level", level },
            { "health", health },

        };
    }

    public static playerData FromDictionary(Dictionary<string, object> dict)
    {
        return new playerData
        {   
            
            level = Convert.ToInt32(dict["level"]),
            health = Convert.ToInt32(dict["health"])
        };
    }
}
