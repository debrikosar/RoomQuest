using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractRaycast : MonoBehaviour
{
    [SerializeField]
    Camera Camera;

    [SerializeField]
    float rayMaxDistance;

    //[SerializeField]
    //Canvas hintCanvas;

    void Update()
    {
        var ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayMaxDistance))
        {
            var selectedItem = hit.transform.GetComponent<IInteract>();

            if (selectedItem != null)
            {
                //hintCanvas.enabled = true;
                //hintCanvas.GetComponentInChildren<Text>().text = selectedItem.ShowHint();

                if (Input.GetKeyDown(KeyCode.E))
                    selectedItem.ToInteract();
            }
            //else hintCanvas.enabled = false;
        }
        //else hintCanvas.enabled = false;

        Debug.DrawLine(ray.origin, hit.point, Color.red);
    }
}
