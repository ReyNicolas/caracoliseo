using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlimeController
{
    List<Slime> slimes;
    SpaceForSlimeChecker spaceForSlimeChecker;


    public SlimeController(List<Slime> slimes,SpaceForSlimeChecker spaceForSlimeChecker) { 
         this.slimes = slimes;
         this.slimes.ForEach(slime => { slime.gameObject.SetActive(false); });
        this.spaceForSlimeChecker = spaceForSlimeChecker;
    }

    public void PlaceSlime()
    {
        if (spaceForSlimeChecker.IsThereSpaceForSlime())
        {
            var slime = GetSlime();
            slime.gameObject.SetActive(true);
            slime.SetPosition(spaceForSlimeChecker.GetPosition());
        }
    }

    Slime GetSlime()
    {
        var slime = GetSlimeInActive();
        return (slime != null) ? slime : GetOldestSlime();
    }
    Slime GetSlimeInActive() => 
        slimes.Find(slime => !slime.gameObject.activeSelf);

    Slime GetOldestSlime() => 
        slimes.Find(slime => slime.timeGenerated == GetSlimesOldestTime());

    float GetSlimesOldestTime() => 
        slimes.Select(slime => slime.timeGenerated).Min();
}
