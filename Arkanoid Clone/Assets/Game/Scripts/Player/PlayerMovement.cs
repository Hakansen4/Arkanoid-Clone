using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    private float Speed;
    private bool StopMovement;
    private float MoveRange;
    private Transform transform;
    private Vector2 Destination;
    public PlayerMovement(float Speed, Transform transform,float MoveRange)
    {
        this.MoveRange = MoveRange;
        this.Speed = Speed;
        this.transform = transform;
        StopMovement = true;
    }
    public void Move()
    {
        if (StopMovement)
            return;

        Destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(Mathf.Clamp(Destination.x, -MoveRange, MoveRange), transform.position.y), Speed);
    }
    public Vector2 GetMovementDestination()
    {
        return Destination;
    }
    public void StartMovement()
    {
        StopMovement = false;
    }
}
