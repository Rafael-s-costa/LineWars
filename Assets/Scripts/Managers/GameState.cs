using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private List<Team> teams;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AwardPassiveIncome", 30.0f, 15.0f);
    }

    void AwardGold()
    {

    }

    private void AwardPassiveIncome()
    {

    }

    private void InitTeams()
    {

    }
}
