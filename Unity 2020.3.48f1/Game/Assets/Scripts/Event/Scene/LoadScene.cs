using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : Event
{
    public string sceneName;
    public string startTransformName;
    public override void OnExecute()
    {
        gameManager.FreezePlayer();
        var op = SceneManager.LoadSceneAsync(sceneName);
        op.completed += (x) => {
            Transform startTransform = GameObject.Find(startTransformName).transform;
            gameManager.SetPlayerTransform(startTransform.position, startTransform.rotation);
            gameManager.SetCameraTransform(startTransform.position);
            Terminate();
        };
    }

    public override void OnTerminate()
    {
        gameManager.UnfreezePlayer();
    }
}
