using UnityEngine;

namespace Dialogues
{
    public class Dialogue2 : BaseDialogue
    {
        public GameObject playerCamera;
        public GameObject commanderJohn;
        public GameObject player;
        public GameObject monster1;
        public GameObject monster2;
        
   

        protected override void OnStart()
        {
            monster1.GetComponent<AiFollow>().freeze = false;
            monster2.GetComponent<AiFollow>().freeze = false;
            playerCamera.transform.LookAt(commanderJohn.transform);
        }

        protected override void OnEnd()
        {
            player.gameObject.tag = "PlayerStage6";
            monster1.GetComponent<AiFollow>().freeze = true;
            monster2.GetComponent<AiFollow>().freeze = true;            
            
        }
    }
}
