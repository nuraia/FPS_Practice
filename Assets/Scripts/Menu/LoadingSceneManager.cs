using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingSceneManager : MonoBehaviour
{
    public async UniTask LoadScene(int sceneId)
    {
       await SceneManager.LoadSceneAsync(sceneId);
    }
}
