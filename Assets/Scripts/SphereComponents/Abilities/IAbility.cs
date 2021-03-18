using UnityEngine;

interface IAbility
{
    void TurnOn();
    void TurnOff();
    bool IsTurnOn { get; }
}