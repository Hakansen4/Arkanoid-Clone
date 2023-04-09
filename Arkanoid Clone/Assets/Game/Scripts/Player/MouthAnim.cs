using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Others;
using DG.Tweening;
using System;

public class MouthAnim : MonoBehaviour
{
    private Transform Ball;
    private bool isSmiling;
    private void OnEnable()
    {
        Ball = GameObject.FindGameObjectWithTag("Ball")?.transform;
        EventBus<EV_BallPaddleCollide>.AddListener(Smile);
    }
    private void OnDisable()
    {
        EventBus<EV_BallPaddleCollide>.RemoveListener(Smile);
    }
    private void Update()
    {
        CheckSad();
    }
    private void CheckSad()
    {
        if(Ball.position.y < 2)
        {
            if (!isSmiling)
                transform.localScale = new Vector3(0.2f, 0.01f, 1);
            
            return;
        }

        var value = Ball.position.y * 0.05f;
        transform.localScale = new Vector3(0.2f,
            value,
            1);
    }

    private void Smile(object sender, EV_BallPaddleCollide @event)
    {
        isSmiling = true;
        transform.DOComplete();
        transform.DOScaleY(-0.1f, 0.2f);
        StartCoroutine(ResetMouth(1));
    }
    private IEnumerator ResetMouth(float time)
    {
        yield return new WaitForSeconds(time);
        transform.DOScaleY(0.01f, 1).OnComplete(SmilingFinished);
    }
    private void SmilingFinished()
    {
        isSmiling = false;
    }
}
