using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlimeController
{
    List<Slime> slimes;
    
    public SlimeController(List<Slime> slimes) { 
         this.slimes = slimes;
         this.slimes.ForEach(slime => { slime.gameObject.SetActive(false); });
    }

    public Slime GetSlime()
    {
        var slime = GetSlimeInActive();
        return (slime != null) ? slime : GetOldestSlime();
    }
    Slime GetSlimeInActive()
    {
        return slimes.Find(slime => !slime.gameObject.activeSelf);
    }

    Slime GetOldestSlime()
    {
        return slimes.Find(slime => slime.timeGenerated == GetSlimesOldestTime());
    }

    float GetSlimesOldestTime()
    {
        return slimes.Select(slime=> slime.timeGenerated).Min();
    }
}
