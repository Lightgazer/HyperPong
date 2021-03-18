using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teams : MonoBehaviour
{
    [SerializeField] GameObject blueMemberPrefab;
    [SerializeField] GameObject yellowMemberPrefab;
    [SerializeField] GameObject blueTarget;
    [SerializeField] GameObject yellowTarget;
    float blueTeamLine = -4f;
    float yellowTeamLine = 4f;
    float minZ = -4.5f;
    float maxZ = 4.5f;


    void Awake()
    {
        CreateBlueTeam();
        CreateYellowTeam();
    }

    void CreateBlueTeam()
    {
        for (int index = 0; index < TeamSettings.teamSize; index++)
        {
            var position = CalculatePosition(index, blueTeamLine);
            var member = Instantiate(blueMemberPrefab, position, Quaternion.identity);
            if (index == 0 && TeamSettings.withPlayer)
            {
                member.AddComponent<InputControl>();
                SetupAbility(member, "Player Energy");
            }
            else
            {
                member.AddComponent<AIControl>();
                var control = member.GetComponent<AIControl>();
                control.ballTarget = blueTarget;
            }
            member.SetActive(true);
        }
    }

    void CreateYellowTeam()
    {
        for (int index = 0; index < TeamSettings.teamSize; index++)
        {
            var position = CalculatePosition(index, yellowTeamLine);
            var member = Instantiate(yellowMemberPrefab, position, Quaternion.identity);
            member.AddComponent<AIControl>();
            var control = member.GetComponent<AIControl>();
            control.ballTarget = yellowTarget;
            if (TeamSettings.teamSize == 1)
            {
                SetupAbility(member, "Enemy Energy");
            }
            member.SetActive(true);
        }
    }

    private Vector3 CalculatePosition(int index, float x)
    {
        var rangeZ = maxZ - minZ;
        var stepZ = rangeZ / (TeamSettings.teamSize + 1f);
        var z = minZ + (index + 1) * stepZ;
        var position = new Vector3(x, 0.5f, z);
        return position;
    }

    private static void SetupAbility(GameObject member, string labelName)
    {
        var ability = member.GetComponent<IAbility>();
        //нужно переделать отображение энергии по SOLID
        if (ability is GravityPullAbility)
        {
            var gravPull = (GravityPullAbility)ability;
            gravPull.energyLabel = GameObject.Find(labelName);
            gravPull.energyLabel.SetActive(true);
        }
    }
}
