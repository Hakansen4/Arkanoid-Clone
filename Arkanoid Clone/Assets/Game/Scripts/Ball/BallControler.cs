using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Others;
using System;

public class BallControler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _physic;
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private BallCollision _Collision;
    [SerializeField] private Material HitColor;
    [SerializeField] private Material ColorfulColor;
    [SerializeField] private Vector3 ScaleAnimSize;
    [SerializeField] private Vector3 StretchAnimSize;
    [SerializeField] private float Speed;
    private BallMovement _Movement;
    private BalSfxController _SfxController;
    private ColorFeature _ColorFeature;
    private BallScaleFeature _ScaleFeature;
    private BallRotationFeature _RotateFeature;
    private BallStretchFeature _StretchFeature;
    private BallHitColorFeature _HitColorFeature;
    private void Awake()
    {
        _SfxController = new BalSfxController();
        _Movement = new BallMovement(GetComponent<Rigidbody2D>(), Speed);
        _ColorFeature = new ColorFeature(GetComponent<SpriteRenderer>(), ColorfulColor);
        _StretchFeature = new BallStretchFeature(transform, StretchAnimSize);
        _ScaleFeature = new BallScaleFeature(transform, ScaleAnimSize);
        _RotateFeature = new BallRotationFeature(transform);
        _HitColorFeature = new BallHitColorFeature(HitColor, ColorfulColor, _renderer, this);
    }
    private void OnEnable()
    {
        _Movement.StartMovement();
        _ColorFeature.SubEvents();
        _SfxController.SubEvents();
        _ScaleFeature.SubEvents();
        _RotateFeature.SubEvents();
        _StretchFeature.SubEvents();
        _HitColorFeature.SubEvents();
        EventBus<EV_BallCollide>.AddListener(PlayCollisionFeatures);
    }
    private void OnDisable()
    {
        _ColorFeature.UnSubEvents();
        _SfxController.UnSubEvents();
        _ScaleFeature.UnSubEvents();
        _RotateFeature.UnSubEvents();
        _StretchFeature.UnSubEvents();
        _HitColorFeature.UnSubEvents();
        EventBus<EV_BallCollide>.RemoveListener(PlayCollisionFeatures);
    }

    private void PlayCollisionFeatures(object sender, EV_BallCollide @event)
    {
        _RotateFeature.SetRotation(_physic.velocity);
        _StretchFeature.AnimateStretch();
        _ScaleFeature.ScaleEffect();
        _HitColorFeature.ColorEffect();
    }
}