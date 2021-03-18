using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour, ISphereControl
{
    Vector2 playerInput;

    public Vector2 GetDesiredDirection() {
        return playerInput;
    }

    public bool IsAbilityActive() {
        return Input.GetKey(KeyCode.Space);
    }

    void Update()
    {
        playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
