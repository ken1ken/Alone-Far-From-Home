using UnityEngine;

namespace Dialogues
{
    /** The first dialogue in the game - the talk with hurt Commander John. */
    public class Dialogue : BaseDialogue
    {
        public GameObject monster;
        public GameObject PlayerCamera;
        public GameObject CommanderJohn;
        public GameObject Monster1;
        public GameObject Monster2;

 

        public GameObject MainCamera;
        public GameObject CutSceneCamera1;
        public GameObject hud;
        public GameObject radar;
        public GameObject playerBody;

        public GameObject hydropack1;
        public GameObject hydropack2;
        public GameObject hydropack3;
        public GameObject hydropack4;
        public GameObject hydropack5;
        public GameObject hydropack6;
        public GameObject hydropack7;
        public GameObject hydropack8;
        public GameObject hydropack9;
        public GameObject hydropack10;


        protected override void OnStart()
        {
            PlayerCamera.transform.LookAt(CommanderJohn.transform);
            
        }

        protected override void OnEnd()
        {
            monster.SetActive(true);
        
            Monster1.SetActive(true);
            if (!DIFFICULTY.easyMode)
            {
                Monster2.SetActive(true);
            }
            
            
            CutSceneCamera1.SetActive(false);
            MainCamera.SetActive(true);
            hud.SetActive(true);
            radar.SetActive(true);
            playerBody.SetActive(false);
            hydropack1.SetActive(true);
            hydropack2.SetActive(true);
            hydropack3.SetActive(true);
            hydropack4.SetActive(true);
            hydropack5.SetActive(true);
            hydropack6.SetActive(true);
            hydropack7.SetActive(true);
            hydropack8.SetActive(true);
            hydropack9.SetActive(true);
            hydropack10.SetActive(true);
        }
    }
}
