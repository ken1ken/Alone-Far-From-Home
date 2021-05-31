using UnityEngine;

public class CommanderDeath : MonoBehaviour
    // ORIGINAL CODE
{
    public GameObject commander;
    void Start()
    {
        commander.GetComponent<Animator>().SetBool("death",true); //changes Commander John animation
    }


    
}
