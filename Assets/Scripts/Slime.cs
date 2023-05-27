using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField]Color color;
    [SerializeField]SpriteRenderer spriteRenderer;
    public float timeGenerated;
    

    public void SetColor(Color color)
    {
        this.color = color;
        spriteRenderer.color = color;
    }


    private void OnEnable()
    {
        timeGenerated = Time.realtimeSinceStartup;
    }

}
