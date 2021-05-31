using UnityEngine;
using TMPro;

//This script controls the players movements, camera position, hydrogen pack counts, saving and loading.
//ONLY player movement and camera inspired by Acacia Developer. https://www.youtube.com/watch?v=n-KX8AeGK7E&ab_channel=AcaciaDeveloper


public class PlayerCameraMovement : MonoBehaviour
{

    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 6.0f;


    public bool lockedCursor = true;
    CharacterController controller = null;
    [SerializeField] float gravity = -13.0f;

    float velocityY = 0.0f;
    float cameraPitch = 0.0f;

    public bool cutscene = false;
    int count = 0;

    public TextMeshProUGUI countText;
    public TextMeshProUGUI Objective2;
    public TextMeshProUGUI Objective3;
    public GameObject arrow2;

    public GameObject objective0;
    public GameObject objective1;
    public GameObject objective2;
    public GameObject objective3;
    public GameObject objective4;
    public GameObject objective5;
    public GameObject objective7;
    public GameObject objective8;
    public GameObject objective9;
    public GameObject objective10;
    public GameObject objective11;
    public GameObject objective12;
    public GameObject objective13;
    public GameObject objective14;

    public GameObject monster1;
    public GameObject monster2;
    public GameObject dan;
    public GameObject john;

    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;
    public GameObject HP4;
    public GameObject HP5;
    public GameObject HP6;
    public GameObject HP7;
    public GameObject HP8;
    public GameObject HP9;
    public GameObject HP10;

    public GameObject MainLights;
    public GameObject BedRoomDoor;
    public GameObject medicalBox;
    public AudioSource StepsSound;
    public GameObject planeCamera;
    public GameObject plane;

    public GameObject arrow0;
    public GameObject arrow1;
    public GameObject arrow4;
    public GameObject arrow5;
    public GameObject arrow6;
    public GameObject arrow6h;
    public GameObject arrow7;
    public GameObject arrow7h;
    public GameObject arrow8;

    public GameObject itemPickUp;
  

    void Start() // At start, cursor is locked and invisible. Game will load only if gameSave is true.
    {
        controller = GetComponent<CharacterController>();
        if (lockedCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (LoadGameOnStart.gameSave)
        {
            LoadPlayer();
        }
    }
    void Update() // Cutscene varible allows for player movement and camera to not be functional.
    {
        if (cutscene)
        {
            if (StepsSound.isPlaying)
                StepsSound.Pause();
        }
        else
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            UpdateMouseLook(mouseDelta);
            
            Vector2 inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            UpdateMovement(inputDir);
        }
    }

    void UpdateMouseLook(Vector2 mouseDelta) // Camera controller
    {
        cameraPitch -= mouseDelta.y * mouseSensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement(Vector2 inputDir) //Player input controller
    {
        inputDir.Normalize();

        if (controller.isGrounded)
        {
            velocityY = 0.0f;
        }
        velocityY += gravity * Time.deltaTime;

        Vector3 velocityX = (transform.forward * inputDir.y + transform.right * inputDir.x) * walkSpeed;
        Vector3 velocity = velocityX + Vector3.up * velocityY;
        
        controller.Move(velocity * Time.deltaTime);

        if (velocityX.magnitude > 0)
        {
            if (!StepsSound.isPlaying)
                StepsSound.Play();
        } else if (StepsSound.isPlaying)
            StepsSound.Pause();
    }

    void OnTriggerEnter(Collider other)
    {
        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("HydrogenPack"))
        {
            itemPickUp.SetActive(true);
            other.gameObject.SetActive(false);
            itemPickUp.SetActive(true);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText();
        }
    }

    void SetCountText() // This displays the amount of Hyodren packs the player has. 
    {
        countText.text = "Hydrogen Packs: " + count.ToString();

        if (count >= 10)
        {
            Objective2.gameObject.SetActive(false);
            Objective3.gameObject.SetActive(true);
            arrow2.SetActive(true);
            countText.text = "";
            gameObject.tag = "PlayerStage4";

        }
    }

    public void SavePlayer() // This function will save the game.
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() // This will change the players, monster(s) and dans position depending on the save.
    {
        PlayerData data = SaveSystem.LoadPlayer();   //loading save file

        tag = data.playerStage;

        arrow0.SetActive(false);
        arrow1.SetActive(false);
        
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        position.z = data.playerPosition[2];

        Vector3 monster1Position;
        monster1Position.x = data.monster1Position[0];
        monster1Position.y = data.monster1Position[1];
        monster1Position.z = data.monster1Position[2];

        Vector3 monster2Position;
        monster2Position.x = data.monster2Position[0];
        monster2Position.y = data.monster2Position[1];
        monster2Position.z = data.monster2Position[2];

        Vector3 danPosition;
        danPosition.x = data.danPosition[0];
        danPosition.y = data.danPosition[1];
        danPosition.z = data.danPosition[2];

        transform.position = position;



        objective0.SetActive(false);
      // ------------------------------------------Depending on the stage of the player, different objects will be loaded-------------------
     
        if (tag.Equals("PlayerStage1"))
        {
            objective0.SetActive(true);
            arrow0.SetActive(true);
            arrow1.SetActive(true);
        }
        else if (tag.Equals("PlayerStage2"))
        {
            objective1.SetActive(true);
            arrow1.SetActive(true);
            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);

        }
        else if (tag.Equals("PlayerStage3"))
        {
            objective2.SetActive(true);
            spawnMonsters();

            if (data.HP1)
            {
                HP1.SetActive(true);
            }
            else
            {
                count = count + 1;
                SetCountText();
            }

            if (data.HP2)
            {
                HP2.SetActive(true);
            }
            else
            {
                count = count + 1;
                SetCountText();
            }

            if (data.HP3)
            {
                HP3.SetActive(true);
            }
            else
            {
                count = count + 1;
                SetCountText();
            }

            if (data.HP4)
            {
                HP4.SetActive(true);
            }
            else
            {
                count = count + 1;
                SetCountText();
            }

            if (data.HP5)
            {
                HP5.SetActive(true);
            }
            else
            {
                count = count + 1;
                SetCountText();
            }

            if (data.HP6)
            {
                HP6.SetActive(true);
            }
            else
            {
                count = count + 1;
                SetCountText();
            }

            if (data.HP7)
            {
                HP7.SetActive(true);
            }
            else
            {
                count = count + 1;
                SetCountText();
            }

            if (data.HP8)
            {
                HP8.SetActive(true);
            }
            else
            {
                count = count + 1;
                SetCountText();
            }

            if (data.HP9)
            {
                HP9.SetActive(true);
            }
            else
            {
                count = count + 1;
                SetCountText();
            }

            if (data.HP10)
            {
                HP10.SetActive(true);
            }
            else
            {
                count = count + 1;
                SetCountText();
            }

            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);
        }
        else if (tag.Equals("PlayerStage4"))
        {
            arrow2.SetActive(true);
            objective3.SetActive(true);
            spawnMonsters();
            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);
        }
        else if (tag.Equals("PlayerStage5"))
        {
            arrow1.SetActive(true);
            objective4.SetActive(true);
            spawnMonsters();
            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);
        }
        else if (tag.Equals("PlayerStage7"))
        {
            arrow2.SetActive(true);
            objective5.SetActive(true);
            spawnMonsters();
            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);
        }
        else if (tag.Equals("PlayerStage9"))
        {
            objective7.SetActive(true);
            spawnMonsters();
            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);
        }
        else if (tag.Equals("PlayerStage10"))
        {
            arrow4.SetActive(true);
            objective8.SetActive(true);
            spawnMonsters();
            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);
        }
        else if (tag.Equals("PlayerStage11"))
        {
            arrow5.SetActive(true);
            objective9.SetActive(true);
            spawnMonsters();
            MainLights.gameObject.SetActive(true);
            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);
        }
        else if (tag.Equals("PlayerStage12"))
        {
            objective10.SetActive(true);
            monster1.SetActive(true);
            spawnMonsters();
            MainLights.gameObject.SetActive(true);
            medicalBox.SetActive(false);
            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);
        }
        else if (tag.Equals("PlayerStage13"))
        {
            arrow6.SetActive(true);
            arrow6h.SetActive(true);
            objective11.SetActive(true);
            spawnMonsters();
            dan.transform.position = danPosition;
            dan.GetComponent<LtFollow>().healed = true;
            dan.GetComponent<Animator>().SetBool("healed", true);
            medicalBox.SetActive(false);
            MainLights.gameObject.SetActive(true);
            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);
        }
        else if (tag.Equals("PlayerStage14"))
        {
            arrow7.SetActive(true);
            arrow7h.SetActive(true);
            objective12.SetActive(true);
            spawnMonsters();
            dan.transform.position = danPosition;
            dan.GetComponent<LtFollow>().healed = true;
            dan.GetComponent<Animator>().SetBool("healed", true);
            MainLights.gameObject.SetActive(true);
            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);

        }
        else if (tag.Equals("PlayerStage15"))
        {
            objective13.SetActive(true);
            spawnMonsters();
            dan.transform.position = danPosition;
            dan.GetComponent<LtFollow>().healed = true;
            dan.GetComponent<Animator>().SetBool("healed", true);
            MainLights.gameObject.SetActive(true);
            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);
            john.SetActive(false);
        }
        else if (tag.Equals("PlayerStage16"))
        {
            arrow8.SetActive(true);
            objective14.SetActive(true);
            spawnMonsters();
            dan.transform.position = danPosition;
            dan.GetComponent<LtFollow>().healed = true;
            dan.GetComponent<Animator>().SetBool("healed", true);
            MainLights.gameObject.SetActive(true);
            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);
            john.SetActive(false);
            
        }
        else
        {
            tag = "PlayerStage16";
            arrow8.SetActive(true);
            objective14.SetActive(true);
            spawnMonsters();
            dan.transform.position = danPosition;
            dan.GetComponent<LtFollow>().healed = true;
            dan.GetComponent<Animator>().SetBool("healed", true);
            MainLights.gameObject.SetActive(true);
            BedRoomDoor.GetComponent<Animator>().SetBool("DoorSwitch", true);
            john.SetActive(false);
        }
        

        void spawnMonsters() // Spawn 2 monsters if the game is on hard mode, else spawn 1 on easy mode.
        {
            monster1.SetActive(true);
            monster1.transform.position = monster1Position;
            if (!data.easyMode)
            {
                monster2.SetActive(true);
                medicalBox.SetActive(false);
                monster2.transform.position = monster2Position;
            }
        }
    }
}
