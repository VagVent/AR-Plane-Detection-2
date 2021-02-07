using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneAreaManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Chech if the user touches the screen
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            // Chech if the user ends to touch the screen
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    // Debug.Log("Tap detected");
                    Ray raycast = Camera.main.ScreenPointToRay(touch.position);

                    // If the ray hits anything Physics.Raycast will return true.
                    if (Physics.Raycast(raycast, out RaycastHit raycastHit))
                    {
                        // Debug.Log("Something Hit : " + raycastHit.collider.gameObject.name);
                        var planeAreaBehaviour = raycastHit.collider.gameObject.GetComponent<PlaneAreaBehaviour>();

                        if (planeAreaBehaviour != null)
                        {
                            planeAreaBehaviour.ToogleAreaView();
                        }
                    }
                }
            }
        }
    }
}
