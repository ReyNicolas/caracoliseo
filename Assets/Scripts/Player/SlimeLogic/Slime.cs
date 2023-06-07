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

    public void SetPosition(Vector2 position) 
    {
        transform.position = position;
        SetTimeGenerated();
    }



    private void OnEnable()
    {
        SetTimeGenerated();
    }

     void SetTimeGenerated() => 
        timeGenerated = Time.realtimeSinceStartup;
}
