using UnityEngine;
using UnityEngine.UI;
public class AudioOptions : MonoBehaviour
{
	private static readonly string FirstPlay = "FirstPlay";
	private int firstPlayInt;
	
	public Slider backgroundSlider;
	private float backgroundFloat;
	
	
	
	
    void Start()
    {
		//checks if its the first play through, if it is we are going to set it to
		//default value and every other play through we are going to pull the saved volume 
		firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
		
		if(firstPlayInt ==0) //this the default as its the first time the user opened the app
		{
			
		}
        else
        {

        }
    }

}
