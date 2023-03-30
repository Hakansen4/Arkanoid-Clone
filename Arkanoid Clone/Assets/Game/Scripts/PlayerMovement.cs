using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    private float Speed;
    private bool StopMovement;
    private Transform transform;
    private Vector2 Destination;
    public PlayerMovement(float Speed, Transform transform)
    {
        this.Speed = Speed;
        this.transform = transform;
        StopMovement = true;
    }
    public void Move()
    {
        if (StopMovement)
            return;

        Destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Destination.x, transform.position.y), Speed);
    }

    public void StartMovement()
    {
        StopMovement = false;
    }
}
