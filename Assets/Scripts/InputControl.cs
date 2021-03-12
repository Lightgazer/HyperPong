using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour, ISphereControl
{
    Vector2 playerInput;

    public Vector2 getDesiredDirection() {
        return playerInput;
    }

    public bool isAbilityActive() {
        return Input.GetKey(KeyCode.Space);
    }

    void Update()
    {
        playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
