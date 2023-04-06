using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events.Features;
using Ambrosia.EventBus;
using Events.Others;
using System;

public class BalSfxController : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus<EV_BallHitSound>.AddListener(HitActivity);
        EventBus<EV_BallBlockCollide>.AddListener(BallBlockCollide);
        EventBus<EV_BallPaddleCollide>.AddListener(BallPaddleCollide);
        EventBus<EV_BallWallCollide>.AddListener(BallWallCollide);
    }
    private void OnDisable()
    {
        EventBus<EV_BallHitSound>.RemoveListener(HitActivity);
        EventBus<EV_BallBlockCollide>.RemoveListener(BallBlockCollide);
        EventBus<EV_BallPaddleCollide>.RemoveListener(BallPaddleCollide);
        EventBus<EV_BallWallCollide>.RemoveListener(BallWallCollide);
    }

    private void BallWallCollide(object sender, EV_BallWallCollide @event)
    {
        AudioManager.instance.PlaySound(Strings.BallHitWallSound);
    }

    private void BallPaddleCollide(object sender, EV_BallPaddleCollide @event)
    {
        AudioManager.instance.PlaySound(Strings.BallHitPaddleSound);
    }

    private void BallBlockCollide(object sender, EV_BallBlockCollide @event)
    {
        AudioManager.instance.PlaySound(Strings.BallHitBlockSound);
    }

    private void HitActivity(object sender, EV_BallHitSound @event)
    {
        AudioManager.instance.ChangeActivity(@event.Type);
    }
}
