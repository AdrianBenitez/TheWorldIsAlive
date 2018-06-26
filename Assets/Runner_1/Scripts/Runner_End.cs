using UnityEngine;

public class Runner_End : MonoBehaviour 
{
    public GameObject MainCharacter;
    void OnCollisionEnter(Collision collision)
    {
        MainCharacter.transform.position = new Vector3(0,0,6);
    }
}
