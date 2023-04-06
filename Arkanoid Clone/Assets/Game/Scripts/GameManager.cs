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
        Instantiate(_Ball);
    }
}
