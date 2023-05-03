using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Others;

public static class ManuelCollision
{
    private static Transform BallTransform;

    public static void SetBallTransform(Transform transform)
    {
        BallTransform = transform;
    }

    public static bool CheckBallCollision(Transform transform)
    {
        if (BallTransform == null)
        {
            return false;
        }
        if (CalculateCollision(BallTransform, transform))
            return true;
        return false;
    }
        
    private static bool CalculateCollision(Transform Ball, Transform rectangle)
    {
        var xBound_1 = Ball.position.x + Ball.localScale.x / 2;
        var xBound_2 = Ball.position.x - Ball.localScale.x / 2;
        var yBound_1 = Ball.position.y + Ball.localScale.y / 2;
        var yBound_2 = Ball.position.y - Ball.localScale.y / 2;

        var xBoundRectangle_1 = rectangle.position.x + rectangle.localScale.x / 2;
        var xBoundRectangle_2 = rectangle.position.x - rectangle.localScale.x / 2;
        var yBoundRectangle_1 = rectangle.position.y + rectangle.localScale.y / 2;
        var yBoundRectangle_2 = rectangle.position.y - rectangle.localScale.y / 2;

        if(((xBound_1 <= xBoundRectangle_1 && xBound_1 >= xBoundRectangle_2) || (xBound_2 >= xBoundRectangle_2 && xBound_2 <= xBoundRectangle_1))
                && ((yBound_1 <= yBoundRectangle_1 && yBound_1 >= yBoundRectangle_2) || (yBound_2 >= yBoundRectangle_2 && yBound_2 <= yBoundRectangle_1)))
        {
            if(rectangle.position.y+0.1f >= Ball.position.y + Ball.localScale.y/2 + rectangle.localScale.y/2)
                EventBus<EV_BallCollide>.Emit(rectangle.gameObject, new EV_BallCollide(BallCollisionSide.Top));
            else if(rectangle.position.y - 0.1f <= Ball.position.y - Ball.localScale.y / 2 - rectangle.localScale.y / 2)
                EventBus<EV_BallCollide>.Emit(rectangle.gameObject, new EV_BallCollide(BallCollisionSide.Bottom));
            else if(rectangle.position.x > Ball.position.x)
                EventBus<EV_BallCollide>.Emit(rectangle.gameObject, new EV_BallCollide(BallCollisionSide.Right));
            else
                EventBus<EV_BallCollide>.Emit(rectangle.gameObject, new EV_BallCollide(BallCollisionSide.Left));
            return true;
        }
        return false;
    }
}
public enum BallCollisionSide
{
    Left, Right, Bottom,Top
}
