using UnityEngine;
using UnityEngine.SceneManagement;

public class Runner_EnemyCollision : MonoBehaviour 
{
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //TODO PLAY KILL FX
            //TODO FADE TO BLACK
            //TODO WAIT 1 second
            //TODO FADE TO SCENE
            collision.gameObject.transform.position = new Vector3(0, 0, 6);
        }

    }
}
