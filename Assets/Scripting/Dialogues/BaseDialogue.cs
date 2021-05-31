using System.Collections;
using TMPro;
using UnityEngine;

namespace Dialogues
{
    /**
     * This abstract class allows the dialogue-type cutscenes to share most of the code.
     * To add a new dialogue, create a new subclass and then implement abstract methods. They can be empty.
     * Dialogue classes can even be reused!
     */
    public abstract class BaseDialogue : MonoBehaviour
    {
        /** The object in which text will be displayed. */
        public TextMeshProUGUI textDisplay;
        /** The object in which continue prompt will be displayed. */
        public TextMeshProUGUI continueText;
        /** The dialogue text. */
        public string[] sentences;
        /* The speed with which letters will appear on the screen. */
        public float typingSpeed = 0.02f;
        
        /* Current sentence index. */
        private int _index;
        private PlayerCameraMovement _playerCameraMovement;
        
        /* The objective to be finished at the beginning of the cutscene. */
        public Objective startObjective;
        /* The objective to be started at the beginning of the cutscene. */
        public TextMeshProUGUI endObjective;
        
        /**
         * Set up the cutscene and call OnStart for things run per-cutscene.
         */
        private void Start()
        {
            _playerCameraMovement = FindObjectOfType<PlayerCameraMovement>();
            StartCoroutine(Type());
            

            startObjective.StartCrossOut();

            OnStart();
        }

        /**
         * Used to add extra things to happen at the start of the dialogue cutscene.
         */
        protected abstract void OnStart();
        
        /**
         * Used to add extra things to happen at the end of the dialogue cutscene.
         */
        protected abstract void OnEnd();

        /**
         * If the sentence is fully displayed (i.e. Type() has finished) wait for E to be pressed
         * and then start a new sentence.
         */
        private void Update()
        {
            _playerCameraMovement.cutscene = true;
            if (textDisplay.text == sentences[_index])
                if (Input.GetKeyUp(KeyCode.E))
                    NextSentence();
            
        }
        
        /**
         * Add new letter to a sentence, then wait for prescribed time, and so on until the end of the sentence.
         */
        private IEnumerator Type()
        {
            foreach (char letter in sentences[_index])
            {
                textDisplay.text += letter;
            
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        /** Start a new sentence. */
        private void NextSentence()
        {
            if (_index < sentences.Length - 1)
            {
                _index++;
            
                textDisplay.text = "";
                StartCoroutine(Type());
            }
            else
            {
                // The crossing out might not have finished
                // Disable it here in such a case.
                startObjective.gameObject.SetActive(false);
                
                textDisplay.text = "";
                textDisplay.gameObject.SetActive(false);
                _playerCameraMovement.cutscene = false;

                continueText.gameObject.SetActive(false);
                endObjective.gameObject.SetActive(true);
                
                OnEnd();

                
                gameObject.SetActive(false);
            }
        }
    }
}