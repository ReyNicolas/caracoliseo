using UnityEngine;

public class SpaceForSlimeChecker
{
    Transform transform;
    LayerMask mask;
    public SpaceForSlimeChecker(Transform transform, LayerMask mask)
    {
        this.transform = transform;
        this.mask = mask;
    }
       

    public bool IsThereSpaceForSlime() => 
        !Physics2D.CircleCast(transform.position, 0.5f, Vector2.zero, 0, mask);

    public Vector2 GetPosition()=> 
        transform.position;
}