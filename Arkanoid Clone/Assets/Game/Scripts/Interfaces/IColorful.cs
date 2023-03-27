using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events.Features;

public interface IColorful
{
    public Material _Color { get;}
    void SetColor(object sender,EV_SetColor @event);
}
