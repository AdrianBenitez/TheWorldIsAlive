using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LampHeadController : MonoBehaviour {

    private void OnCollisionEnter(Collision col)
    {

        StartCoroutine(Respawn(1.5f));
    }

    IEnumerator Respawn(float respawnDelay)
    {
        yield return new WaitForSeconds(respawnDelay);

        string m_Scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(m_Scene);
    }
}
