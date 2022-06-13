using System;
using System.Collections.Generic;
using UnityEngine;

public class CreepController : MonoBehaviour
{
    private GameObject _target;
    private GameObject _aggro;

    private LineCharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<LineCharacterController>();

        _target = GameObject.FindGameObjectWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        CalculateAggro();

        //if (_aggro != null && _characterController.IsInRange(_aggro.transform.position, attackRadius))
        if (_aggro != null) // Add leash range behaviour
        {
            AttackEnemy();
        }
        else
        {
            MoveUnit();
        }
    }

    /**
     * Attacks enemy.
     */
    private void AttackEnemy()
    {
        /*if (!agent.isStopped)
        {
            agent.isStopped = true;
        }*/
    }

    /**
     * Called when creep reaches target. DIsable instead of destroy, put creeps in object pool.
     * 
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Destroy(this.gameObject);
        }
    }

    /**
     * Aggroes Closest enemy. If aggroed, checks
     * if enemy is still in range, if not it will
     * lose aggro.
     */
    private void CalculateAggro()
    {
        List<GameObject> enemyTeamObjects = _characterController.GetEnemiesInRange();

        if (_aggro == null)
        {
            _aggro = _characterController.GetClosestEnemy(enemyTeamObjects);
        }
        else if (!enemyTeamObjects.Contains(_aggro))
        {
            _aggro = null;
        }
    }

    /**
     * Sets the unit destination.
     */
    private void MoveUnit()
    {
        Vector3 destination;

        if (_aggro == null)
        {
            destination = _target.transform.position;
        }
        else
        {
            destination = _aggro.transform.position;
        }

        _characterController.Move(destination);
    }
}
