using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Others;
using System;

public class BallControler : MonoBehaviour, IPoolable
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _physic;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private BallCollision _Collision;
    [Header("Features")]
    [SerializeField] private Material HitColor;
    [SerializeField] private Material ColorfulColor;
    [SerializeField] private Vector3 ScaleAnimSize;
    [SerializeField] private Vector3 StretchAnimSize;
    [SerializeField] private float Speed;
    [SerializeField] private int ParticleEffectPoolSize;
    [SerializeField] private GameObject _ParticleObject;
    [SerializeField] private GameObject _TrailObject;
    private BallMovement _Movement;
    private BalSfxController _SfxController;
    private ColorFeature _ColorFeature;
    private BallScaleFeature _ScaleFeature;
    private BallRotationFeature _RotateFeature;
    private BallStretchFeature _StretchFeature;
    private BallHitColorFeature _HitColorFeature;
    private BallVfxController _VfxController;
    private BallTrailFeature _TrailFeature;
    private void Awake()
    {
        _SfxController = new BalSfxController();
        _Movement = new BallMovement(GetComponent<Rigidbody2D>(), Speed);
        _ColorFeature = new ColorFeature(GetComponent<SpriteRenderer>(), ColorfulColor);
        _StretchFeature = new BallStretchFeature(transform, StretchAnimSize);
        _ScaleFeature = new BallScaleFeature(transform, ScaleAnimSize);
        _RotateFeature = new BallRotationFeature(transform);
        _HitColorFeature = new BallHitColorFeature(HitColor, ColorfulColor, _renderer, this);
        _VfxController = new BallVfxController(transform, ParticleEffectPoolSize, _ParticleObject);
        _TrailFeature = new BallTrailFeature(_TrailObject, ColorfulColor);
    }
    private void OnEnable()
    {
        _ColorFeature.SubEvents();
        _SfxController.SubEvents();
        _ScaleFeature.SubEvents();
        _RotateFeature.SubEvents();
        _StretchFeature.SubEvents();
        _HitColorFeature.SubEvents();
        _VfxController.SubEvents();
        _TrailFeature.SubEvents();
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
        _VfxController.UnSubEvents();
        _TrailFeature.UnSubEvents();
        EventBus<EV_BallCollide>.RemoveListener(PlayCollisionFeatures);
    }

    private void PlayCollisionFeatures(object sender, EV_BallCollide @event)
    {
        _Movement.CollideMove(@event.side);
        _RotateFeature.SetRotation(_physic.velocity);
        _StretchFeature.AnimateStretch();
        _ScaleFeature.ScaleEffect();
        _HitColorFeature.ColorEffect();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        ManuelCollision.SetBallTransform(transform);
        _Movement.StartMovement();
    }

    public void DeActivate()
    {
        gameObject.SetActive(false);
    }
}