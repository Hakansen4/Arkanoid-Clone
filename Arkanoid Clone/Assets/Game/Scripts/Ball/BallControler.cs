using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    [SerializeField] private BallCollision _Collision;
    [SerializeField] private Material HitColor;
    [SerializeField] private Material ColorfulColor;
    [SerializeField] private Vector3 ScaleAnimSize;
    [SerializeField] private Vector3 StretchAnimSize;
    private ColorFeature _ColorFeature;
    private void Awake()
    {
        _Collision.Init(ScaleAnimSize, StretchAnimSize, HitColor, ColorfulColor);
        _ColorFeature = new ColorFeature(GetComponent<SpriteRenderer>(), ColorfulColor);
    }
    private void OnEnable()
    {
        _ColorFeature.SubEvents();
    }
    private void OnDisable()
    {
        _ColorFeature.UnSubEvents();
    }
}
