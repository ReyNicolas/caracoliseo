using UnityEngine;

public class SpaceForSlimeChecker
{
    Transform transform;
    LayerMask mask;
    public SpaceForSlimeChecker(Transform transform)
    {
        this.transform = transform;
    }   

    public bool IsPaceFormSlime()
    {
        return Physics2D.CircleCast(transform.position, 0.5f, Vector2.zero,0,mask);
    }
}