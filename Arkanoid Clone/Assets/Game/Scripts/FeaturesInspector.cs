using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Features;

public class FeaturesInspector : MonoBehaviour
{


    public void SetColorEvent()
    {
        EventBus<EV_SetColor>.Emit(this, new EV_SetColor());
    }
}
