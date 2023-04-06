using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Others;
public class BallCollision : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerHitEvents(collision.gameObject.tag);
    }
    private void TriggerHitEvents(string collidedObject)
    {
        EventBus<EV_BallCollide>.Emit(this, new EV_BallCollide());
        if (collidedObject == Strings.BoxTag)
            EventBus<EV_BallBlockCollide>.Emit(this, new EV_BallBlockCollide());
        else if (collidedObject == Strings.PlayerTag)
            EventBus<EV_BallPaddleCollide>.Emit(this, new EV_BallPaddleCollide());
        else if (collidedObject == Strings.BorderTag)
            EventBus<EV_BallWallCollide>.Emit(this, new EV_BallWallCollide());
    }
}
