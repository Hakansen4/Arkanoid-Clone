using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Others;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController _Player;
    [SerializeField] GameObject _Ball;
    private ObjectPool<BallControler> BallPool;
    private BallControler activeBall;
    private void Awake()
    {
        BallPool = new ObjectPool<BallControler>(4, _Ball);
    }
    private void OnEnable()
    {
        EventBus<EV_StartGame>.AddListener(StartGame);
    }
    private void OnDisable()
    {
        EventBus<EV_StartGame>.RemoveListener(StartGame);
    }

    private void StartGame(object sender, EV_StartGame @event)
    {
        _Player.StartGame();
        activeBall = BallPool.GetPooledObject();
    }
}
