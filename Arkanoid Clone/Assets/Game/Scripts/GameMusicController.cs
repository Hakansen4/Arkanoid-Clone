using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Features;
using System;

public class GameMusicController : MonoBehaviour
{
    public void OnEnable()
    {
        EventBus<EV_MusicSound>.AddListener(PlayMusic);
    }
    public void OnDisable()
    {
        EventBus<EV_MusicSound>.RemoveListener(PlayMusic);
    }

    private void PlayMusic(object sender, EV_MusicSound @event)
    {
        AudioManager.instance.ChangeActivity(Strings.JuicyMusic);
        AudioManager.instance.PlayMusic(Strings.JuicyMusic);
    }
}
