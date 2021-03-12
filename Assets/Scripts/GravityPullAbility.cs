using UnityEngine;

class GravityPullAbility : MonoBehaviour, IAbility
{
    [SerializeField] Material activeMaterial;
    Material defMaterial;
    MeshRenderer mesh;
    GameObject ball;
    bool isTurnOn = false;
    [SerializeField, Range(0, 10)] float gravForce = 1; 

    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        defMaterial = mesh.material;
        ball = GameObject.Find("Ball");
    }

    void FixedUpdate()
    {
        if (isTurnOn)
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
        isTurnOn = true;
    }

    public void TurnOff()
    {
        mesh.material = defMaterial;
        isTurnOn = false;
    }
}