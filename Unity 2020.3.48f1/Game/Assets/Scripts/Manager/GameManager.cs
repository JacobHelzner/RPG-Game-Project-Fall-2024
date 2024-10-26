using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public Player player;
    public MainCamera mainCam;

    public void SetPlayerTransform(Vector3 startPosition, Quaternion startRotation)
    {
        player.cc.enabled = false;
        player.transform.position = startPosition;
        player.transform.rotation = startRotation;
        player.cc.enabled = true;
    }

    public void SetCameraTransform(Vector3 position)
    {
        mainCam.transform.position = position;
    }

    public void FreezePlayer()
    {
        player.Freeze();
    }

    public void UnfreezePlayer()
    {
        player.Unfreeze();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
