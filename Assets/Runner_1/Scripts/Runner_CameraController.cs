using UnityEngine;

public class Runner_CameraController : MonoBehaviour 
{
    public GameObject mainCharacter;
    private Vector3 offset; 
	
    void Start()
    {
        offset = new Vector3(transform.position.x, transform.position.y +0.5f, mainCharacter.transform.position.z - 9f);
    }

    void LateUpdate()
    {
        var temp = mainCharacter.transform.position + offset;
        transform.position = new Vector3(transform.position.x, temp.y, temp.z);
    }
}
