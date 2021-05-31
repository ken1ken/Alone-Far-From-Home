using UnityEngine;

namespace Dialogues
{
    public class Dialogue3 : BaseDialogue
    {
        public GameObject PlayerCamera;
        public GameObject Soldier;
        public GameObject Player;
        public GameObject Monster1;
        public GameObject Monster2;
        public GameObject arrow;

        public GameObject cutSceneCamera;
        public GameObject radar;
        public GameObject playbody;
        public GameObject hud;


        protected override void OnStart()
        {
            Monster1.GetComponent<AiFollow>().freeze = false;
            Monster2.GetComponent<AiFollow>().freeze = false;
        }

        protected override void OnEnd()
        {
            Player.gameObject.tag = "PlayerStage10";
            Monster1.GetComponent<AiFollow>().freeze = true;
            Monster2.GetComponent<AiFollow>().freeze = true;
            arrow.SetActive(true);

            PlayerCamera.SetActive(true);
            cutSceneCamera.SetActive(false);
            radar.SetActive(true);
            playbody.SetActive(false);
            hud.SetActive(true);
        }
    }
}
