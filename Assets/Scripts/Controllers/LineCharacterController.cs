using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LineCharacterController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Character _characterData;

    public LineCharacterController(Character character)
    {
        _characterData = character;
    }

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_characterData.enemyTarget != null && !IsInRange(_characterData.enemyTarget.transform.position, _characterData.attackRange) && !_agent.isStopped)
        {
            _agent.SetDestination(_characterData.enemyTarget.transform.position);
        }

        if (_characterData.attackInterval > 0)
        {
            _characterData.attackInterval -= Time.deltaTime;
        }
        else if (_characterData.enemyTarget == null)
        {
            Attack();
        }
    }

    public void Move(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }

    public void Attack()
    {
        if (_characterData.enemyTarget == null)
        {
            return;
        }

        if (_characterData.attackInterval <= 0L && IsInRange(_characterData.enemyTarget.transform.position, _characterData.attackRange))
        {
            _agent.isStopped = true;
            _characterData.attackInterval = _characterData.attackSpeed;
            //DealDamage();
            //Deal damage
            //Play animation

            _agent.isStopped = false;
            Debug.Log("Attacked");
        }
        else
        {
            Debug.Log("Not yet");
        }
    }

    /**
     * Checks if target unit is inside the defined radius.
     */
    public bool IsInRange(Vector3 objectPosition, float radius)
    {
        return Vector3.Distance(transform.position, objectPosition) < radius;
    }

    public void setEnemyTarget(Collider target)
    {
        _characterData.enemyTarget = target;
    }
}
