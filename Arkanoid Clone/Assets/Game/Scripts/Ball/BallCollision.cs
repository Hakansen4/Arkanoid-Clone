using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _physic;
    [SerializeField] private SpriteRenderer _renderer;

    private BallScaleFeature _ScaleFeature;
    private BallRotationFeature _RotateFeature;
    private BallStretchFeature _StretchFeature;
    private BallHitColorFeature _HitColorFeature;
    private void OnEnable()
    {
        _ScaleFeature.SubEvents();
        _RotateFeature.SubEvents();
        _StretchFeature.SubEvents();
        _HitColorFeature.SubEvents();
    }

    private void OnDisable()
    {
        _ScaleFeature.UnSubEvents();
        _RotateFeature.UnSubEvents();
        _StretchFeature.UnSubEvents();
        _HitColorFeature.UnSubEvents();
    }

    public void Init(Vector3 ScaleAnimSize,Vector3 StretchSize,Material HitColor,Material ColorfulColor)
    {
        _StretchFeature = new BallStretchFeature(transform, StretchSize);
        _ScaleFeature = new BallScaleFeature(transform, ScaleAnimSize);
        _RotateFeature = new BallRotationFeature(transform);
        _HitColorFeature = new BallHitColorFeature(HitColor, ColorfulColor, _renderer, this);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _RotateFeature.SetRotation(_physic.velocity);
        _StretchFeature.AnimateStretch();
        _ScaleFeature.ScaleEffect();
        _HitColorFeature.ColorEffect();
    }
}
