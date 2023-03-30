using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int TweenDistance;
    [SerializeField] private int TweenDuration;

    private TweenFeatures _TweenFeature;
    private void Awake()
    {
        _TweenFeature = new TweenFeatures(TweenDistance, transform, TweenDuration);
    }
    private void OnEnable()
    {
        _TweenFeature.SubEvents();
    }
    private void OnDisable()
    {
        _TweenFeature.UnSubEvents();
    }
}
