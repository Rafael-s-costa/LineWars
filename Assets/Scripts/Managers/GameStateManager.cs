using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private List<Team> teams;

    // Start is called before the first frame update
    void Start()
    {
        initCreepPool();
        InvokeRepeating("AwardPassiveIncome", 30.0f, 15.0f);
    }

    /**
     * TODO: Called by matchmaker, or lobby
     */
    private void InitTeams()
    {

    }

    void AwardGold(Character character, int gold)
    {
        character._gold += gold;
    }

    /**
     * Award passive gold to every player on both teams, based on their shop level;
     */
    private void AwardPassiveIncome()
    {
        foreach (Team team in teams)
        {
            team.players.ForEach(player => AwardGold(player, player._passiveIncome));
        }
    }

    /*
     * Calculate damage done to defending target, if killed award attacking player with gold based on its bounty.
     */
    public void DealDamage(Character attacking)
    {
        Character defending = attacking.enemyTarget.gameObject.GetComponent<Character>();

        int critDamage = Random.value > attacking.critChange ? 0 : attacking.critDamage;
        int damage = attacking.damage * critDamage;

        defending.hp = System.Math.Max(0, defending.hp - (defending.armor - (damage * attacking.armorPen))); // Call function in Character to take damage

        if (defending.hp == 0)
        {
            AwardGold(attacking, defending._bounty);
        }
    }

    private void initCreepPool()
    {

    }
}
