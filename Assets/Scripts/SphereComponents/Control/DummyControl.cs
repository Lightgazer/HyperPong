using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyControl : MonoBehaviour, ISphereControl
{
    Vector2 direction = new Vector2(0, 0);

    public Vector2 GetDesiredDirection() {
        return direction;
    }

    public bool IsAbilityActive() {
        return false;
    }
}
