using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Team>().id = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Character" && hit.collider.gameObject.GetComponent<Team>().id != GetComponent<Team>().id)
            {
                //Target = collider
                // return
            }

            //target = null
            //Move
        }
    }
}
