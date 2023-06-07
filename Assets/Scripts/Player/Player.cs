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
    [SerializeField] Transform slimeRespawnTransform;
    [SerializeField] LayerMask spaceToSlimeMask;

    Action<Color> OnCollorChange;
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

    //start de prueba
    private void Awake()
    {
        Initialize(color);
    }

    public void Initialize(Color color)
    {
        Color= color;
        moveInputHandler = new MoveInputHandler(transform,rigidbody2D);
        spaceForSlimeChecker = new SpaceForSlimeChecker(slimeRespawnTransform,spaceToSlimeMask);
        slimeController = new SlimeController(GenerateThisNumberOfSlimes(numberOfSlimes), spaceForSlimeChecker);
       
    }


    private void Update()
    {
        moveInputHandler.SetMovement();
        slimeController.PlaceSlime();
    }

    private void FixedUpdate()
    {
        moveInputHandler.MoveInFixedUpdate();
    }


    List<Slime> GenerateThisNumberOfSlimes(int number)
    {
        var slimes = new List<Slime>();
        for(int i=0; i < number; i++)
        {
            var slime = Instantiate(SlimePrefab, Vector2.zero, Quaternion.identity).GetComponent<Slime>();
            slime.SetColor(color);
            slimes.Add(slime);            
        }
        return slimes;
    }

    
}
