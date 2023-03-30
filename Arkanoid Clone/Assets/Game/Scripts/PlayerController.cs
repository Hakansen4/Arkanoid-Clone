using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region SerializeField Variables
    [SerializeField] private float Speed;
    [SerializeField] private int TweenDistance;
    [SerializeField] private int StandartTweenDuration;
    [SerializeField] private int MinTweenDuration;
    [SerializeField] private int MaxTweenDuration;
    [SerializeField] private float MoveRange;
    #endregion

    private TweenFeatures _TweenFeature;
    private PlayerMovement Movement;
    private void Awake()
    {
        Movement = new PlayerMovement(Speed, transform, MoveRange);
        _TweenFeature = new TweenFeatures(TweenDistance, transform, StandartTweenDuration,MaxTweenDuration,MinTweenDuration);
    }

    private void Update()
    {
        Movement.Move();
    }
    private void OnEnable()
    {
        _TweenFeature.SubEvents();
    }
    private void OnDisable()
    {
        _TweenFeature.UnSubEvents();
    }

    public void StartGame()
    {
        Movement.StartMovement();
    }
}
