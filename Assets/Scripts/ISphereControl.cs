using UnityEngine;

interface ISphereControl {
    Vector2 getDesiredDirection();
    bool isAbilityActive();
}