using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevelTrigger2 : MonoBehaviour
{
    public string scene;

    private void OnTriggerEnter(Collider collider)
    { 
        SceneManager.LoadScene(scene);
    }
}
