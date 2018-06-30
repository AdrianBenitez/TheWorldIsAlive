using UnityEngine;

public class StreetLightController : MonoBehaviour
{
    public float reachDistance;
    public GameObject Player;

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = Vector3.Distance(Player.transform.position, transform.position);
        if (playerDistance < reachDistance)
        {
            animator.Play("Armature|AttackGood");
            //Debug.Log(reachDistance);
        }
    }
}