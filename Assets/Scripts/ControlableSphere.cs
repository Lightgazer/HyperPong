using UnityEngine;

public class ControlableSphere : MonoBehaviour
{
    [SerializeField, Range(0f, 30f)] float maxSpeed = 5f;
    [SerializeField, Range(0f, 30f)] float maxAcceleration = 10f;
    Vector3 velocity;
    Vector3 desiredVelocity;
    Rigidbody body;
    IAbility ability;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        ability = GetComponent<IAbility>();
    }
    void Update()
    {
        Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;

        if (Input.GetKeyDown(KeyCode.Space)) ability.TurnOn();
        if (Input.GetKeyUp(KeyCode.Space)) ability.TurnOff();
    }

    void FixedUpdate()
    {
        var maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity = body.velocity;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
        body.velocity = velocity;
    }
}

interface IAbility
{
    void TurnOn();
    void TurnOff();
}

class GravityPullAbility : MonoBehaviour, IAbility
{
    [SerializeField] Material activeMaterial;
    Material defMaterial;
    MeshRenderer mesh;
    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        defMaterial = mesh.material;
    }

    public void TurnOn()
    {
        mesh.material = activeMaterial;
    }

    public void TurnOff()
    {
        mesh.material = defMaterial;
    }

    void OnDisable()
    {
        mesh.material = defMaterial;
    }
}