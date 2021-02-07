using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CubeManager : MonoBehaviour
{
    public ARRaycastManager aRRaycastManager;
    public GameObject cubePrefab;

    private List<ARRaycastHit> aRRaycastHits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    // AR Raycast Planes
                    if (aRRaycastManager.Raycast(touch.position, aRRaycastHits))
                    {
                         var pose = aRRaycastHits[0].pose;
                         CreateCube(pose.position);
                         return;
                    }

                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.collider.tag == "cube")
                        {
                            DeleteCube(hit.collider.gameObject);
                        }
                    }

                }
            }
        }
    }

    /*
     * Method to put an AR cube into the scene
     */
    private void CreateCube(Vector3 posotion)
    {
        Instantiate(cubePrefab, posotion, Quaternion.identity);
    }

    /*
     * Method to delete the AR cube from sceen when you touch it afte your placement
     */
    private void DeleteCube(GameObject cubeObject)
    {
        Destroy(cubeObject);
    }


}
