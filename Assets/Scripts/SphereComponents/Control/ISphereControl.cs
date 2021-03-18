using UnityEngine;

interface ISphereControl {
    Vector2 GetDesiredDirection();
    bool IsAbilityActive();
}