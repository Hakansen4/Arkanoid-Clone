using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement
{
    Rigidbody2D physic;
    public float Speed;
    public BallMovement(Rigidbody2D rigidbody, float Speed)
    {
        physic = rigidbody;
        this.Speed = Speed;
    }
    public void StartMovement()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        physic.velocity = new Vector2(Speed * x, Speed * y);
    }
    public void CollideMove(BallCollisionSide Side)
    {
        switch (Side)
        {
            case BallCollisionSide.Left:
                physic.velocity *= new Vector2(-1, 1);
                break;
            case BallCollisionSide.Right:
                physic.velocity *= new Vector2(-1, 1);
                break;
            case BallCollisionSide.Bottom:
                physic.velocity *= new Vector2(1, -1);
                break;
            case BallCollisionSide.Top:
                physic.velocity *= new Vector2(1, -1);
                break;
            default:
                break;
        }
    }
}
