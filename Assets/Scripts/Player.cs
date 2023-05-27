using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Color color;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] GameObject SlimePrefab;
    [SerializeField] int numberOfSlimes;
    public Color Color
    {
        get { return color; }
        set
        {
            color = value;
            spriteRenderer.color = value;
        }
    }

    MoveInputHandler moveInputHandler;
    SlimeController slimeController;
    SpaceForSlimeChecker spaceForSlimeChecker;


    private void Awake()
    {
        moveInputHandler = new MoveInputHandler(transform,rigidbody2D);
        slimeController = new SlimeController(GenerateThisNumberOfSlimes(numberOfSlimes));
        spaceForSlimeChecker = new SpaceForSlimeChecker(transform);
    }


    private void Update()
    {
        moveInputHandler.SetMovement();
    }

    private void FixedUpdate()
    {
        moveInputHandler.MoveInFixedUpdate();
    }


    private List<Slime> GenerateThisNumberOfSlimes(int number)
    {
        var slimes = new List<Slime>();

        for(int i=0; i < number; i++)
        {
            slimes.Add(Instantiate(SlimePrefab, Vector2.zero, Quaternion.identity).GetComponent<Slime>());
        }
        return slimes;
    }

    
}
