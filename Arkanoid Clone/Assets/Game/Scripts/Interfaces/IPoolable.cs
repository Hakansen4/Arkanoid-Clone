using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    public void Activate();
    public void DeActivate();
}
