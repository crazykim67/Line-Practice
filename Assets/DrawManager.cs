using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    private Camera cam;

    [Header("Line")]
    [SerializeField]
    private GameObject linePrefab;

    [Header("LineController")]
    [SerializeField]
    private LineController currentLine;

    private Ray ray;
    private RaycastHit hit;

    public static float LIMIT = 0.25f;

    private void Start() => cam = Camera.main;

    private void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
            currentLine = Instantiate(linePrefab).GetComponent<LineController>();

        if (Input.GetMouseButton(0))
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 mousePos = new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z);
                currentLine.SetPosition(mousePos);
            }

        if (Input.GetMouseButtonUp(0))
            currentLine = null;
    }
}
