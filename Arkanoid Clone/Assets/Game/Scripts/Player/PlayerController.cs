using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
    #endregion

    private TweenFeatures _TweenFeature;
    private PlayerElasticFeature _ElasticFeature;
    private PlayerMovement Movement;
    
    private void Awake()
    {
        Movement = new PlayerMovement(Speed, transform, MoveRange);
        _ElasticFeature = new PlayerElasticFeature(transform, MinScaleY, MaxScaleY, ElasticSpeed);
        _TweenFeature = new TweenFeatures(TweenDistance, transform, StandartTweenDuration,MaxTweenDuration,MinTweenDuration);
    }

    private void Update()
    {
        Movement.Move();
        _ElasticFeature.Animate(Movement.GetMovementDestination());
    }
    private void OnEnable()
    {
        _TweenFeature.SubEvents();
        _ElasticFeature.SubEvents();
    }
    private void OnDisable()
    {
        _TweenFeature.UnSubEvents();
        _ElasticFeature.UnSubEvents();
    }

    public void StartGame()
    {
        Movement.StartMovement();
    }
}
