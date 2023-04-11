using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events.Others;
using Ambrosia.EventBus;
using System;

public class EyeTrack : MonoBehaviour
{
    Transform myTransform;
    Transform Ball;
    private void OnEnable()
    {
        myTransform = GetComponent<Transform>();
        Ball = GameObject.FindGameObjectWithTag("Ball")?.transform;
    }

    private void Update()
    {
        EyeFollow();
    }
    private void EyeFollow()
    {
        if (Ball == null)
            return;

        Vector2 direction = new Vector2(
            Ball.position.x - transform.position.x,
            Ball.position.y - transform.position.y
            );
        myTransform.up = direction;
    }
}
