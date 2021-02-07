using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneAreaBehaviour : MonoBehaviour
{
    public TextMeshPro areaText;
    public ARPlane arPlane;

    private void OnEnable()
    {
        arPlane.boundaryChanged += ArPlane_BoundaryChanged;
    }

    private void OnDisable()
    {
        arPlane.boundaryChanged -= ArPlane_BoundaryChanged;
    }

    // Update is called once per frame
    void Update()
    {
        areaText.transform.rotation = Quaternion.LookRotation(areaText.transform.position - Camera.main.transform.position);
    }

    /*
     * 
     */
    private void ArPlane_BoundaryChanged(ARPlaneBoundaryChangedEventArgs obj)
    {
        areaText.text = CalculatePlaneArea(arPlane).ToString();
    }

    /*
     * Calculate the squer meters of the palne.
     */
    private float CalculatePlaneArea(ARPlane plane)
    {
        return plane.size.x * plane.size.y;
    }

    /*
     * Enable and disable our areaText component based on its current state.
     */
    public void ToogleAreaView()
    {
        if (areaText.enabled)
        {
            areaText.enabled = false;
        }
        else
        {
            areaText.enabled = true;
        }
    }
}
