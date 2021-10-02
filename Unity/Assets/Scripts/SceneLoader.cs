using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string _sceneName = "";
    
    [SerializeField]
    private float _secondsUntilLoad = 1.0f;

    private void Start()
    {
        StartCoroutine(Routine());
    }

    private IEnumerator Routine()
    {
        yield return new WaitForSeconds(_secondsUntilLoad);
        
        SceneManager.LoadScene(_sceneName);
    }
}
