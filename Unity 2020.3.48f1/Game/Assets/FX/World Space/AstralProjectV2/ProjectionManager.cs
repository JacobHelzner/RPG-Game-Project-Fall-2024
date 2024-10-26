using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionManager : MonoBehaviour
{
    public int projection_start_layer = 5;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] projections = GameObject.FindGameObjectsWithTag("Astral Projection");
        for (int i = 0; i < projections.Length; i++)
        {
            projections[i].GetComponent<AstralProjectV2>().SetLayer(projection_start_layer + i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
