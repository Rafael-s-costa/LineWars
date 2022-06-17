using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : ScriptableObject
{
    public GameObject model;

    public string characterName;
    public string characterDescription;

    public int maxHp;
    public int hp;

    public int maxMp;
    public int mp;

    public int armor { get; set; }

    public int damage { get; set; }
    public int armorPen { get; set; }

    public float critChange;
    public int critDamage;

    public int moveSpeed;
    public int attackSpeed { get; set; }
    public float attackInterval { get; set; }

    public Collider enemyTarget { get; set; }

    public float attackRange;
    public float aggroRadius;

    public int _gold { get; set; }
    public int _passiveIncome { get; set; }
    public int _bounty { get; set; }
}
