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

    public int damage;

    public float critChange;
    public float critDamage;

    public int moveSpeed;
    public int attackSpeed { get; set; }
    public float attackInterval { get; set; }

    public Collider enemyTarget { get; set; }

    public float attackRange;
    public float aggroRadius;
}
