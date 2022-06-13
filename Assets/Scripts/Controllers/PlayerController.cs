using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private LineCharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<LineCharacterController>();
        GetComponent<Team>().id = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Character" && hit.collider.gameObject.GetComponent<Team>().id != GetComponent<Team>().id)
                {
                    _characterController.setEnemyTarget(hit.collider);
                    return;
                }

                _characterController.setEnemyTarget(null);
                _characterController.Move(hit.point);
            }
        }
    }
}
