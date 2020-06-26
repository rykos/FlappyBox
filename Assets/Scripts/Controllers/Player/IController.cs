using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    /// <summary>
    /// User just tapped
    /// </summary>
    void Tap();
    /// <summary>
    /// User just released 
    /// </summary>
    void Release();
    /// <summary>
    /// User is holding
    /// </summary>
    void Hold();
    /// <summary>
    /// Physics tick (every frame)
    /// </summary>
    void Tick();
}
