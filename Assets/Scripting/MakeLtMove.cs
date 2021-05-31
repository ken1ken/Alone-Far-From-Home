using UnityEngine;
// ORIGINAL CODE
public class MakeLtMove : MonoBehaviour
{
    public GameObject Lt;
    // This causes dan to be healed, this making him follow the player.
    void Start()
    {
        Lt.GetComponent<LtFollow>().healed = true;
    }
}
