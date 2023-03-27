using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    Rigidbody2D physic;
    public float Speed;
    private void Awake()
    {
        physic = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        StartMovement();
    }
    private void StartMovement()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        physic.velocity = new Vector2(Speed * x, Speed * y);
    }
}
