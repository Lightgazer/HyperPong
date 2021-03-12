using UnityEngine;

class GravityPullAbility : MonoBehaviour, IAbility
{
    [SerializeField] Material activeMaterial;
    Material defMaterial;
    MeshRenderer mesh;
    GameObject ball;

    public bool IsTurnOn { get; private set; }

    [SerializeField, Range(0, 10)] float gravForce = 1; 

    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        defMaterial = mesh.material;
        ball = GameObject.Find("Ball");
    }

    void FixedUpdate()
    {
        if (IsTurnOn)
        {
            var dist = Vector3.Distance(transform.position, ball.transform.position); //4~5
            var pullForce = gravForce / dist;
            var ballBody = ball.GetComponent<Rigidbody>();
            var direction = transform.position - ball.transform.position;
            ballBody.AddForce(pullForce * direction);
        }
    }

    public void TurnOn()
    {
        mesh.material = activeMaterial;
        IsTurnOn = true;
    }

    public void TurnOff()
    {
        mesh.material = defMaterial;
        IsTurnOn = false;
    }
}