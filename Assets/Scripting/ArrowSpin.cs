using UnityEngine;

/**
 * Spins an object around z-axis. Used for objective arrows.
 */
// ORIGINAL CODE
public class ArrowSpin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }
}
