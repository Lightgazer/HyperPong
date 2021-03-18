using UnityEngine;
using TMPro;

class GravityPullAbility : MonoBehaviour, IAbility
{
    [SerializeField] public GameObject energyLabel;
    public bool IsTurnOn { get; private set; }
    [SerializeField, Range(0, 10)] float gravForce = 1;
    TextMeshProUGUI energyText;
    float energy = 100;
    float maxEnergy = 100;
    float minEnergyToEnable = 20;
    float maxDuration = 2;

    [SerializeField] Material activeMaterial;
    Material defMaterial;
    MeshRenderer mesh;
    GameObject ball;

    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        defMaterial = mesh.material;
        ball = GameObject.Find("Ball");
        if(energyLabel != null) energyText = energyLabel.GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        if (IsTurnOn)
        {
            var dist = Vector3.Distance(transform.position, ball.transform.position);
            var pullForce = gravForce / dist;
            var ballBody = ball.GetComponent<Rigidbody>();
            var direction = transform.position - ball.transform.position;
            ballBody.AddForce(pullForce * direction);
        }
    }

    void Update()
    {
        ManageEnergy();
        ShowEnergy();
    }

    private void ManageEnergy()
    {
        var consumption = maxEnergy / maxDuration * Time.deltaTime;
        if (IsTurnOn)
        {
            energy = Mathf.MoveTowards(energy, 0, consumption);
            if (energy == 0) TurnOff();
        }
        else
        {
            energy = Mathf.MoveTowards(energy, maxEnergy, consumption);
        }
    }

    private void ShowEnergy()
    {
        if(energyText != null) energyText.text = Mathf.Round(energy).ToString() + "%";
    }

    public void TurnOn()
    {
        if (energy > minEnergyToEnable)
        {
            mesh.material = activeMaterial;
            IsTurnOn = true;
        }
    }

    public void TurnOff()
    {
        mesh.material = defMaterial;
        IsTurnOn = false;
    }
}