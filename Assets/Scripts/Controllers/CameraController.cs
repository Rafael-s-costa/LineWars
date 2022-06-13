using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Pan")]
    private const float PanSpeed = 20f;
    private const float PanBorderThickness = 20f;
    private Vector2 _panLimit;

    [Header("Scroll")]
    private const float ScrollSpeed = 10f;
    private const float ScrollMin = 10f;
    private const float ScrollMax = 30f;

    void Start()
    {
        _panLimit = new Vector2(10f, 10f);
        this.transform.rotation = new Quaternion(0.6f, 0, 0, 1);
        this.transform.position = new Vector3(0, 15, -6);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - PanBorderThickness)
        {
            pos.z += PanSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= PanBorderThickness)
        {
            pos.z -= PanSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= PanBorderThickness)
        {
            pos.x -= PanSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - PanBorderThickness)
        {
            pos.x += PanSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * ScrollSpeed * 100f * Time.deltaTime;

        // Limit Panning
        pos.x = Mathf.Clamp(pos.x, -_panLimit.x, _panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -_panLimit.y, _panLimit.y);

        // Limit Scroll
        pos.y = Mathf.Clamp(pos.y, ScrollMin, ScrollMax);

        transform.position = pos;
    }
}
