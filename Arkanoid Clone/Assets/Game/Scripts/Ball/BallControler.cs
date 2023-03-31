using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    [SerializeField] private BallCollision _Collision;
    [SerializeField] private Vector3 ScaleAnimSize;

    private void Awake()
    {
        _Collision.Init(ScaleAnimSize);
    }
}
