using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [HideInInspector]
    public GameManager gameManager;
    public Event next;

    void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        OnAwake();
    }
    public void Execute()
    {
        OnExecute();
    }
    // Start is called before the first frame update
    public void Terminate()
    {
        OnTerminate();
        if (next != null)
        {
            next.Execute();
        }
    }

    public virtual void OnAwake()
    {

    }

    public virtual void OnExecute()
    {

    }

    public virtual void OnTerminate()
    {

    }
}
