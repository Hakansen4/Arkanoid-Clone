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
    private void Awake()
    {
        _Collision.Init(ScaleAnimSize, StretchAnimSize, HitColor, ColorfulColor);
    }
}
