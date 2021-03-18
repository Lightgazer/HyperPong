using UnityEngine;

public class ControlableSphere : MonoBehaviour
{
    [SerializeField, Range(0f, 30f)] float maxSpeed = 5f;
    [SerializeField, Range(0f, 30f)] float maxAcceleration = 10f;
    Vector3 velocity;
    Vector3 desiredVelocity;
    Rigidbody body;
    IAbility ability;
    ISphereControl controler;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        ability = GetComponent<IAbility>();
        controler = GetComponent<ISphereControl>();
    }

    void FixedUpdate()
    {
        ManageVelocity();
        ManageAbility();
    }

    private void ManageAbility()
    {
        var desire = controler.IsAbilityActive();
        if (ability.IsTurnOn == true && desire == false)
        {
            ability.TurnOff();
        }
        else if (ability.IsTurnOn == false && desire == true)
        {
            ability.TurnOn();
        }
    }

    private void ManageVelocity()
    {
        var direction = controler.GetDesiredDirection();
        direction = Vector2.ClampMagnitude(direction, 1f);
        desiredVelocity = new Vector3(direction.x, 0f, direction.y) * maxSpeed;

        var maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity = body.velocity;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
        body.velocity = velocity;
    }
}
