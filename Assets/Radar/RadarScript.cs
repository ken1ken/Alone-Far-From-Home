using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//----------------------INSPIRED BY CODE MONKEY -----------------
public class RadarScript : MonoBehaviour
{
    [SerializeField] public GameObject allyping;
    [SerializeField] public GameObject itemping;
    [SerializeField] public GameObject dangerousping;

    public List<GameObject> hitSafeObjects = new List<GameObject>();
    public List<GameObject> hitDangerousObjects = new List<GameObject>();
    public List<GameObject> hitItemObjects = new List<GameObject>();
    private float fadeRange;
    private Color pulseColour;
    private SpriteRenderer pulseSpriteRenderer;

    private Transform pulseTransform;
    private float range;
    private float MAXrange;
    private List<Collider> pingedList;
    private float rangeSpeed = 0;



    private void Awake() 
    {
        pulseTransform = transform.Find("RPulse");
        MAXrange = 35f;
        pingedList = new List<Collider>();
        fadeRange = 31.5f;
        pulseSpriteRenderer = pulseTransform.GetComponent<SpriteRenderer>();
        pulseColour = pulseSpriteRenderer.color;
    }

    private void Update() // depending on difficulty, the speed of radar varies.
    {
        if (DIFFICULTY.easyMode)
        {
            rangeSpeed = 10f;
        }
        else
        {
            rangeSpeed = 5f;
        }
        
        range += rangeSpeed * Time.deltaTime; // every second, the radar will increase it's size
        if (range > MAXrange)
        {
            range = 0f;
            hitSafeObjects.Clear();
            hitDangerousObjects.Clear();
            hitItemObjects.Clear();


        }
        pulseTransform.localScale = new Vector3(range, range);

        
        // ----------------------------------------- ORIGINAL CODE BELOW ----------------------------------------
        RaycastHit[] raycastHitArray = Physics.SphereCastAll(transform.position, range*2, transform.forward); // Sphere raycast will spawn from the player locations, objects hit must contain the correct tag.
        foreach(RaycastHit raycastHit in raycastHitArray )
        {
            if (!hitSafeObjects.Contains(raycastHit.transform.gameObject)) // Objects must contain the tag RadarAlly, RadarDangerous or HydrogenPack to be stored into an array.
            { // The arry stops the same object from pinging multuple times per raycast cycle.
                if (raycastHit.transform.gameObject.CompareTag("RadarAlly") || raycastHit.transform.gameObject.CompareTag("CommanderJohnTrigger1"))
                {
                    hitSafeObjects.Add(raycastHit.transform.gameObject);
                    Instantiate(allyping, raycastHit.transform.position, transform.rotation);
                }
            }
            if (!hitDangerousObjects.Contains(raycastHit.transform.gameObject))
            {
                if (raycastHit.transform.gameObject.CompareTag("RadarDangerous"))
                {
                    hitDangerousObjects.Add(raycastHit.transform.gameObject);
                    Instantiate(dangerousping, raycastHit.transform.position, transform.rotation);
                }
            }
            if (!hitItemObjects.Contains(raycastHit.transform.gameObject))
            {
                if (raycastHit.transform.gameObject.CompareTag("HydrogenPack") || raycastHit.transform.gameObject.CompareTag("WayPoint"))
                {
                    hitItemObjects.Add(raycastHit.transform.gameObject);
                    Instantiate(itemping, raycastHit.transform.position, transform.rotation);
                }
            }
        }  
        //-----------------------------------------------------------------------------------------------------------------
        if (range > MAXrange - fadeRange) //This causes the radar ping to fade towards the end.
        {
            pulseColour.a = Mathf.Lerp(0f, 1f, (MAXrange - range) / fadeRange); //setting alpha, get lerp starting at 1 then goes to 0.
        }
        else
        {
            pulseColour.a = 1f;
        }
        pulseSpriteRenderer.color = pulseColour;
    }
}
