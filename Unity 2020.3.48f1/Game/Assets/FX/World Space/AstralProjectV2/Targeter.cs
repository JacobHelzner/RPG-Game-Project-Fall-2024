using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public Transform target;
    public GameObject quad;
    public GameObject renderCam;
    public Transform positionTarget;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.position = positionTarget.position;
    }
}
