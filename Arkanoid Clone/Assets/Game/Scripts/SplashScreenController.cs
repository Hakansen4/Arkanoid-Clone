using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Scenes;

public class SplashScreenController : MonoBehaviour
{
    public void EndSplashScreen()
    {
        EventBus<EV_OpenMainMenu>.Emit(this, new EV_OpenMainMenu());
    }
}
