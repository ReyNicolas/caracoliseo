using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputHandler
{
    Transform transform;
     Rigidbody2D rigidbody2D;
     float acSpeed = 1.0f;
     float maxSpeed = 2f;
     float actualSpeed = 0;
     Vector2 movement;

    public MoveInputHandler(Transform transform, Rigidbody2D rigidbody2D)
    {
        this.transform = transform;
        this.rigidbody2D = rigidbody2D;
    }

     public void SetMovement()
    {
        movement = Vector2.ClampMagnitude(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), 1f);
        transform.LookAt(LookAtDirection(), transform.right);
    }
    public void MoveInFixedUpdate()
    {
        Move(movement);
    }

    void Move(Vector2 direction)
    {
        rigidbody2D.AddForce( direction * acSpeed * Time.deltaTime, ForceMode2D.Impulse);
        actualSpeed = rigidbody2D.velocity.magnitude;

        if (actualSpeed > maxSpeed)
        {
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed;
        }

    }

    Vector3 LookAtDirection() => new Vector3 (rigidbody2D.velocity.x + transform.position.x, rigidbody2D.velocity.y + transform.position.y,0);
}
