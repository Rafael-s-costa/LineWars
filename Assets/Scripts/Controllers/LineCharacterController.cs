using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LineCharacterController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameStateManager _gameState;

    [SerializeField]
    private Character _characterData;

    // Start is called before the first frame update
    void Start()
    {
        _gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameStateManager>();

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
            _gameState.DealDamage();
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

    /**
     * Gets a list of all enemies in the range of the creep.
     */
    public List<GameObject> GetEnemiesInRange()
    {
        Team[] teamObjects = FindObjectsOfType<Team>();
        List<GameObject> objectsInRange = new List<GameObject>();
        int creepTeam = GetComponent<Team>().id;

        foreach (Team teamObject in teamObjects)
        {
            GameObject objectFound = teamObject.gameObject;
            if (teamObject.id != creepTeam && IsInRange(objectFound.transform.position, _characterData.aggroRadius))
            {
                objectsInRange.Add(objectFound);
            }
        }

        return objectsInRange;
    }

    /**
     * Gets the closest enemy object to the creep, out of a list
     * of possible objects.
     */
    public GameObject GetClosestEnemy(List<GameObject> enemies)
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;
            }
        }

        return closest;
    }
}
