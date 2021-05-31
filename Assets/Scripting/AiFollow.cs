using UnityEngine;
using UnityEngine.AI;

/**
 * The brain of the mobs. Simple but effective. And scary.
 */

// THIS IS ORIGINAL CODE
public class AiFollow : MonoBehaviour
{
    private NavMeshAgent Mob;

    public GameObject Player;

    public float MobDistanceRun = 20.0f;

    public PlayerCameraMovement cutscene1;
    public GameObject head;
    public GameObject fadein;
    public GameObject chaseSound;
    public GameObject deathSound;
    public GameObject radar;

    public GameObject patrolPoint0;
    public GameObject patrolPoint1;
    public GameObject patrolPoint2;
    public GameObject patrolPoint3;
    public GameObject patrolPoint4;
    public GameObject patrolPoint5;
    public GameObject patrolPoint6;
    public GameObject patrolPoint7;
    public GameObject patrolPoint8;
    public GameObject patrolPoint9;
    public GameObject patrolPoint10;
    public GameObject patrolPoint11;
    public GameObject patrolPoint12;
    public GameObject patrolPoint13;
    public GameObject patrolPoint14;
    public GameObject patrolPoint15;
    public GameObject patrolPoint16;
    public GameObject patrolPoint17;
    public GameObject patrolPoint18;

    private GameObject patrolSpot;


    public GameObject[] patrolSpots = new GameObject[19]; // list of patrol points, where the monsters will go to.

    public bool freeze = true;

    public GameObject exitGame;

    private float targetTime;
    private int roamingSpeed;
    public bool inSafeRoom;



    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
        patrolSpots[0] = patrolPoint0;
        patrolSpots[1] = patrolPoint1;
        patrolSpots[2] = patrolPoint2;
        patrolSpots[3] = patrolPoint3;
        patrolSpots[4] = patrolPoint4;
        patrolSpots[5] = patrolPoint5;
        patrolSpots[6] = patrolPoint6;
        patrolSpots[7] = patrolPoint7;
        patrolSpots[8] = patrolPoint8;
        patrolSpots[9] = patrolPoint9;
        patrolSpots[10] = patrolPoint10;
        patrolSpots[11] = patrolPoint11;
        patrolSpots[12] = patrolPoint12;
        patrolSpots[13] = patrolPoint13;
        patrolSpots[14] = patrolPoint14;
        patrolSpots[15] = patrolPoint15;
        patrolSpots[16] = patrolPoint16;
        patrolSpots[17] = patrolPoint17;
        patrolSpots[18] = patrolPoint18;

        targetTime = 10;
        roamingSpeed = 13;
        inSafeRoom = false;
        
        
        patrolSpot = patrolSpots[Random.Range(0, patrolSpots.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
        targetTime -= Time.deltaTime; //Changes monsters speed, 10 seconds slow, 10 seconds fast.
        if(targetTime <= 0f)
        {
            if (roamingSpeed == 13)
            {
                roamingSpeed = 10;
            }
            else if(roamingSpeed == 10)
            {
                roamingSpeed = 13;
            }
            targetTime = Random.Range(5,20);
        }

        if (freeze) // when in a cutscene, the monsters will stay in position.
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);
            if (inSafeRoom)
            {             
                    Vector3 dirToSpot = transform.position - patrolSpot.transform.position;

                    Vector3 newPosSpot = transform.position - dirToSpot;

                    GetComponent<NavMeshAgent>().speed = roamingSpeed;
                    if (roamingSpeed == 10)
                    {
                        GetComponent<Animator>().SetBool("run", false);
                    }
                    else
                    {
                        GetComponent<Animator>().SetBool("run", true);
                    }
                    chaseSound.gameObject.SetActive(false);

                    Mob.SetDestination(newPosSpot);
            }
            else if (distance < 5) //Monster is too close, player is dead.
            {
                cutscene1 = FindObjectOfType<PlayerCameraMovement>();
                cutscene1.cutscene = true;
                radar.SetActive(false);
                Player.transform.LookAt(head.transform); // Player will look towards monster
                Mob.SetDestination(transform.position);

                Mob.GetComponent<Animator>().SetBool("death", true);
                transform.LookAt(Player.transform);
                fadein.gameObject.SetActive(true);
                chaseSound.gameObject.SetActive(false);
                deathSound.gameObject.SetActive(true);
                exitGame.SetActive(true); // Game will exit

            }


            
            // Running towards player
            
            




            else if (distance < MobDistanceRun) // The monster is chasing the player
            {
                Vector3 dirToPlayer = transform.position - Player.transform.position;

                Vector3 newPos = transform.position - dirToPlayer;

                GetComponent<NavMeshAgent>().speed = 13;
                GetComponent<Animator>().SetBool("run", true);
                Mob.SetDestination(newPos);
                chaseSound.gameObject.SetActive(true);
            }
            else  // if distance is too far from the player, monster will go to patrol points.
            {
                Vector3 dirToSpot = transform.position - patrolSpot.transform.position;

                Vector3 newPosSpot = transform.position - dirToSpot;

                GetComponent<NavMeshAgent>().speed = roamingSpeed;
                if(roamingSpeed == 10)
                {
                    GetComponent<Animator>().SetBool("run", false);
                }
                else
                {
                    GetComponent<Animator>().SetBool("run", true);
                }
                chaseSound.gameObject.SetActive(false);

                Mob.SetDestination(newPosSpot);
            }




            float distanceSpot = Vector3.Distance(transform.position, patrolSpot.transform.position); // once monster arives at patrol point, it will find another position

            if (distanceSpot < 10.0)
            {
                patrolSpot = patrolSpots[Random.Range(0, patrolSpots.Length)];

            }
        }
        else
        {
            Mob.SetDestination(transform.position); // this makes the monster stay in position at cutscenes.
        }
    }
}
