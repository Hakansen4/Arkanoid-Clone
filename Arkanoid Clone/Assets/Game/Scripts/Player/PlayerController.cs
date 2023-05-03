using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Others;

public class PlayerController : MonoBehaviour,ICollisionable
{
    #region SerializeField Variables
    [Header("Movement")]
    [SerializeField] private float Speed;
    [SerializeField] private float MoveRange;
    [Header("Tweening Feature")]
    [SerializeField] private int TweenDistance;
    [SerializeField] private int StandartTweenDuration;
    [SerializeField] private int MinTweenDuration;
    [SerializeField] private int MaxTweenDuration;
    [Header("Elastic Feature")]
    [SerializeField] private float ElasticSpeed;
    [SerializeField] private float MaxScaleY;
    [SerializeField] private float MinScaleY;
    [Header("Color Feature")]
    [SerializeField] private Material Color;
    [Header("Visual Effects")]
    [SerializeField] private GameObject Confetti;
    [SerializeField] private Transform LeftEye;
    [SerializeField] private Transform RightEye;
    [SerializeField] private GameObject Mouth;
    #endregion

    private TweenFeatures _TweenFeature;
    private PlayerElasticFeature _ElasticFeature;
    private ColorFeature _ColorFeature;
    private PlayerMovement Movement;
    private PlayerVfxController _VfxController;
    
    private void Awake()
    {
        Movement = new PlayerMovement(Speed, transform, MoveRange);
        _ElasticFeature = new PlayerElasticFeature(transform, MinScaleY, MaxScaleY, ElasticSpeed);
        _TweenFeature = new TweenFeatures(TweenDistance, transform, StandartTweenDuration,MaxTweenDuration,MinTweenDuration);
        _ColorFeature = new ColorFeature(GetComponent<SpriteRenderer>(), Color);
        _VfxController = new PlayerVfxController(transform, Confetti, LeftEye, RightEye, Mouth);
    }

    private void Update()
    {
        Movement.Move();
        _ElasticFeature.Animate(Movement.GetMovementDestination());
    }
    private void FixedUpdate()
    {
        CheckCollision();
    }
    private void OnEnable()
    {
        _TweenFeature.SubEvents();
        _ElasticFeature.SubEvents();
        _ColorFeature.SubEvents();
        _VfxController.SubEvents();
    }
    private void OnDisable()
    {
        _TweenFeature.UnSubEvents();
        _ElasticFeature.UnSubEvents();
        _ColorFeature.UnSubEvents();
        _VfxController.UnSubEvents();
    }

    public void StartGame()
    {
        Movement.StartMovement();
    }

    public void CheckCollision()
    {
        if (ManuelCollision.CheckBallCollision(transform))
            EventBus<EV_BallPaddleCollide>.Emit(this, new EV_BallPaddleCollide());
    }
}
