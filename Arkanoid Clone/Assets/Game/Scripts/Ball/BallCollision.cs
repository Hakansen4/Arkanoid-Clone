using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _physic;

    private BallScaleFeature _ScaleFeature;
    private BallRotationFeature _RotateFeature;
    private void OnEnable()
    {
        _ScaleFeature.SubEvents();
        _RotateFeature.SubEvents();
    }

    private void OnDisable()
    {
        _ScaleFeature.UnSubEvents();
        _RotateFeature.UnSubEvents();
    }

    public void Init(Vector3 ScaleAnimSize)
    {
        _ScaleFeature = new BallScaleFeature(transform, ScaleAnimSize);
        _RotateFeature = new BallRotationFeature(transform);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _ScaleFeature.ScaleEffect();
        _RotateFeature.SetRotation(_physic.velocity);
    }
}
