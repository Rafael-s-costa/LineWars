using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroData", menuName = "Custom Data/HeroData")]
public class Hero : ScriptableObject
{
    public GameObject model;

    public string heroName;
    public string heroDescription;

    public int maxHp;
    public int hp;

    public int maxMp;
    public int mp;

    public int damage;

    public float critChange;
    public float critDamage;

    public int moveSpeed;
    public int attackSpeed;

    public float attackRange;
}
