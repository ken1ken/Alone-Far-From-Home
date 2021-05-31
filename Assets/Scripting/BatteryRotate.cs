using UnityEngine;

/**
 * Rotates an object continuously. Used for floating batteries.
 */
// ORIGINAL CODE
public class BatteryRotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(10, 30, 10) * Time.deltaTime);
    }
}
