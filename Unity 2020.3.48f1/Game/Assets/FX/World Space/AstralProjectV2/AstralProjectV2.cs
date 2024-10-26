using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstralProjectV2 : MonoBehaviour
{
    public GameObject targeterRoot;
    GameObject myTargeterRoot;
    public RenderTexture renderTexture;

    public void SetLayer(int layer)
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            GameObject Go = this.gameObject.transform.GetChild(i).gameObject;
            Go.layer = layer;
        }
        this.gameObject.layer = layer;
        Targeter myTargeter = myTargeterRoot.GetComponent<Targeter>();
        myTargeter.renderCam.GetComponent<Camera>().cullingMask = (int)Mathf.Pow(10f, layer);
    }
    // Start is called before the first frame update
    void Awake()
    {
        this.tag = "Astral Projection";
        myTargeterRoot = Instantiate(targeterRoot);
        Targeter myTargeter = myTargeterRoot.GetComponent<Targeter>();
        myTargeter.positionTarget = this.transform;
        RenderTexture renderTexInst = new RenderTexture(renderTexture);
        renderTexInst.filterMode = FilterMode.Point;
        myTargeter.renderCam.GetComponent<Camera>().targetTexture = renderTexInst;
        myTargeter.quad.GetComponent<Renderer>().material.mainTexture = renderTexInst;

        Transform gameCam = Camera.main.transform;
        myTargeterRoot.GetComponent<Targeter>().target = gameCam;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
