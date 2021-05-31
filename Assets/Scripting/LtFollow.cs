using UnityEngine;
using UnityEngine.AI;

// ORIGINAL CODE
public class LtFollow : MonoBehaviour
{

    private NavMeshAgent self;
    public GameObject Player;
    public bool healed;
    

    public float MobDistanceRun = 10.0f; 

    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healed) // once Dan has been healed, he will begin to follow the player.
        {

            float distance = Vector3.Distance(transform.position, Player.transform.position);

            if (distance >= MobDistanceRun) // once dan is further than 10f, he will follow the player.
            {
                Vector3 dirToPlayer = transform.position - Player.transform.position;

                Vector3 newPos = transform.position - dirToPlayer;

                GetComponent<NavMeshAgent>().speed = 20;

                self.SetDestination(newPos);
                GetComponent<Animator>().SetBool("moving", true); // When he is moving, the animation for moving will commence.
            }
            else
            {
                self.SetDestination(transform.position);
                GetComponent<Animator>().SetBool("moving", false); // when he is not moving, he will use his idle animation.
            }
        }
    }
}
