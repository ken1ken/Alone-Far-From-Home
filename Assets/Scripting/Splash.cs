using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Splash : MonoBehaviour
{
    [Serializable]
    public enum Position
    {
        TopRight,
        BottomRight,
        TopLeft,
        BottomLeft
    }
    
    [Serializable]
    public struct Background
    {
        public Texture texture;
        public Position loadingTextPosition;
        public Position storyTextPosition;
    }

    
    public List<Background> backgrounds;
    public List<Texture> alien;

    public TextMeshProUGUI loadingText, storyText;
    public string[] sentences;
    public float typingSpeed = 0.02f;

    public static String NextScene = "Menu";

    private AsyncOperation _sceneLoading;
    private IEnumerator _typingCoroutine;

    /** Run coroutine HeadHurts on this sentence. Disabled by default. */
    public int whenHeadHurts = -1;
    public bool outro = false;

    private RawImage _background;
    private AudioSource _audio;
    public List<AudioClip> noiseClips;

    /** Sets the text position. Used so we can have different positions for different loading backgrounds. */
    private void _setTextPosition(TextMeshProUGUI text, Position position)
    {
        RectTransform textTransform = text.GetComponent<RectTransform>();
        
        switch (position)
        {
            case Position.TopRight:
                textTransform.anchorMin = new Vector2(1, 1);
                textTransform.anchorMax = new Vector2(1, 1);
                textTransform.pivot = new Vector2(1, 1);
                textTransform.anchoredPosition = new Vector2(200, -20);
                break;
            case Position.BottomRight:
                textTransform.anchorMin = new Vector2(1, 0);
                textTransform.anchorMax = new Vector2(1, 0);
                textTransform.pivot = new Vector2(1, 0);
                textTransform.anchoredPosition = new Vector2(200, 50);
                break;
            case Position.BottomLeft:
                textTransform.anchorMin = new Vector2(0, 0);
                textTransform.anchorMax = new Vector2(0, 0);
                textTransform.pivot = new Vector2(0, 1);
                textTransform.anchoredPosition = new Vector2(50, 150);
                break;
            case Position.TopLeft:
                textTransform.anchorMin = new Vector2(0, 1);
                textTransform.anchorMax = new Vector2(0, 1);
                textTransform.pivot = new Vector2(0, 0);
                textTransform.anchoredPosition = new Vector2(50, -70);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    /**
     * Choose a random loading screen background.
     * Place the text on the top or bottom depending on the background.
     * Then start loading the next scene.
     */
    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
        _background = gameObject.GetComponent<RawImage>();
        StopAllCoroutines();
        
        int index = Random.Range(0, backgrounds.Count);

        _background.texture = backgrounds[index].texture;
        _setTextPosition(loadingText, backgrounds[index].loadingTextPosition);
        _setTextPosition(storyText, backgrounds[index].storyTextPosition);

        if (NextScene == "SpaceStationGame")
        {
            _sceneLoading = SceneManager.LoadSceneAsync("SpaceStationGame");
            _sceneLoading.allowSceneActivation = false;
            _typingCoroutine = TypeStory();
            StartCoroutine(_typingCoroutine);
        }
        else if (outro)
        {
            _typingCoroutine = TypeStory();
            StartCoroutine(_typingCoroutine);
        }
        else {
            _sceneLoading = SceneManager.LoadSceneAsync(NextScene);
            storyText.text = "";
        }
    }

    private void Update()
    {
        if (!outro && NextScene == "SpaceStationGame")
        {
            // https://docs.unity3d.com/ScriptReference/AsyncOperation-allowSceneActivation.html
            if (_sceneLoading.progress >= 0.9f)
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    StopCoroutine(_typingCoroutine);
                    _sceneLoading.allowSceneActivation = true;
                }

                loadingText.text = "Press E to start.";
            }
            else
            {
                loadingText.text = "Now Loading... " + (int) (_sceneLoading.progress * 100) + "%";
            }
        }
    }

    private IEnumerator TypeStory()
    {
        int sentenceIndex = 0;
        foreach (string sentence in sentences)
        {
            if (sentenceIndex == whenHeadHurts)
                StartCoroutine(HeadHurts());
            sentenceIndex++;
            
            storyText.text = "";
            foreach (char letter in sentence)
            {
                storyText.text += letter;

                yield return new WaitForSeconds(typingSpeed);
            }
            
            yield return new WaitForSeconds(typingSpeed * 150);
        }

        if (outro)
        {
            SceneManager.LoadSceneAsync("Menu");
        }
    }

    /** A special effect used in the outro. */
    private IEnumerator HeadHurts()
    {
        Texture oldTexture = _background.texture;

        for (int i = 0; i < 20; i++)
        {
            int audioIndex = Random.Range(0, noiseClips.Count);
            _audio.clip = noiseClips[audioIndex];
            _audio.Play();
            
            int index = Random.Range(0, alien.Count);
            _background.texture = alien[index];
            
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

            _background.texture = oldTexture;
            
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            if (_audio.isPlaying)
                _audio.Stop();
        }
    }
}
