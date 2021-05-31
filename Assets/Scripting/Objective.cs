using System.Collections;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

/**
 * Various effects and mechanisms associated with objectives.
 */
public class Objective : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    public float typingSpeed = 0.08f;
    
    /** Sound played on a complete objective. */
    public AudioSource objectiveCompletedSound;

    /** Start CrossOutObjective coroutine. */
    public void StartCrossOut([CanBeNull] GameObject nextObjective = null)
    {
        StartCoroutine(CrossOutObjective(nextObjective));
    }
    
    /**
     * Do objective done effect and deactivate itself.
     * Activate nextObjective if not null.
     */
    private IEnumerator CrossOutObjective([CanBeNull] GameObject nextObjective = null) {
        objectiveCompletedSound.Play();
        text.color = new Color(0.9f, 0.1f, 0.1f, 1.0f);
        
        yield return new WaitForSeconds(1);
        
        string startText = text.text;
        for (int i = 0; i < startText.Length; i++)
        {
            text.text = "<s>" + startText.Substring(0, i) + "</s>" +
                                startText.Substring(i);
            
            yield return new WaitForSeconds(typingSpeed);
        }
        
        if (nextObjective is null) {
            yield return new WaitForSeconds(5);
            gameObject.SetActive(false);
        } else {
            yield return new WaitForSeconds(1);
            gameObject.SetActive(false);
            nextObjective.SetActive(true);
        }
    }
}