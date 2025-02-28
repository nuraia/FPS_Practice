using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using Cysharp.Threading.Tasks;

public class LoadingBarVisualizer : MonoBehaviour
{
   
    public Slider loadingBarFill;
    public float minimumLoadTime = 2f;

    public void StartLoadingScene(int sceneId)
    {
        LoadSceneAsync(sceneId);
    }
    private async UniTask LoadSceneAsync(int sceneId)
    {
        
        float elapsedTime = 0f;


        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        operation.allowSceneActivation = false;

        float currentProgress = 0f;

        while (!operation.isDone)
        {

            float targetProgress = Mathf.Clamp01(operation.progress / 0.9f);
            currentProgress = Mathf.MoveTowards(currentProgress, targetProgress, Time.deltaTime / minimumLoadTime);
            loadingBarFill.value = currentProgress;

            if (operation.progress >= 0.9f)
            {

                if (elapsedTime < minimumLoadTime)
                {
                    elapsedTime += Time.deltaTime;
                }
                else
                {
                    operation.allowSceneActivation = true;
                }
            }

            await UniTask.Yield();
        }
    }
}
