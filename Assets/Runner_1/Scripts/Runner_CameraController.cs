using UnityEngine;

public class Runner_CameraController : MonoBehaviour 
{
    public GameObject mainCharacter;
    private Vector3 offset; 
	
    void Start()
    {
        offset = new Vector3(transform.position.x, transform.position.y, mainCharacter.transform.position.z -12f);
    }

    void LateUpdate()
    {
        transform.position = mainCharacter.transform.position + offset;
    }
}
