using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelLoader : MonoBehaviour
{   
    public GameObject waste, waste3;
    public GameObject waste1, waste2;
    public bool LoadGame = false;
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
         operation.allowSceneActivation = false; 
        //float progress = Mathf.Clamp01(operation.progress / .9f);   
        while (operation.progress < 0.9f)
        { yield return null;
        } 
        operation.allowSceneActivation = true;   
        Time.timeScale = 1f;
    }

    public void Destroywaste(){
        AudioListener.pause=true;
        Destroy(waste2);
        Destroy(waste);
        Destroy(waste1);
        Destroy(waste3);
    }
    
}
