using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Event eventToExecute;

    public void Interact()
    {
        eventToExecute.Execute();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Interactable";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
