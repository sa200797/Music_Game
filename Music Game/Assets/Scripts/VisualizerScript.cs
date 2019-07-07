using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizerScript : MonoBehaviour {

   


    public float minHeight = 15.0f;
	public float maxHeight = 425.0f;
	public float updateSentivity = 10.0f;
	//public Color visualizerColor = Color.gray;
	[Space (15)]
	public AudioClip audioClip;
	public bool loop = true;
	[Space (15), Range (64, 8192)]
	public int visualizerSimples = 64;
    public RectTransform[] rect;

	VisualizerObjectScript[] visualizerObjects;
	public  AudioSource audioSource;

    

    // Use this for initialization
    public void Start () {
		visualizerObjects = GetComponentsInChildren<VisualizerObjectScript> ();

        

		if (!audioClip)
			return;

		audioSource = new GameObject ("_AudioSource").AddComponent <AudioSource> ();
		audioSource.loop = loop;
		audioSource.clip = audioClip;
		audioSource.Play ();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float[] spectrumData = audioSource.GetSpectrumData (visualizerSimples, 0, FFTWindow.Rectangular);

		for (int i = 0; i < visualizerObjects.Length; i++) {
			Vector2 newSize = visualizerObjects [i].GetComponent<RectTransform> ().rect.size;

            newSize.y = Mathf.Lerp(newSize.y, minHeight + (spectrumData[i] * (maxHeight - minHeight) * 5.0f), updateSentivity * 0.5f);
			visualizerObjects [i].GetComponent<RectTransform> ().sizeDelta = newSize;



            for (int j = 0; j < visualizerObjects.Length; j++)//visualizerObjects.Length
            {
                Vector2 newColliderSize = new Vector2(this.GetComponentInChildren<BoxCollider2D>().size.x, rect[j].rect.height);



                Vector2 newOffsetPosition = new Vector2(this.GetComponentInChildren<BoxCollider2D>().offset.x, (rect[j].rect.height / 2));

                visualizerObjects[j].GetComponentInChildren<BoxCollider2D>().size = newColliderSize;
                visualizerObjects[j].GetComponentInChildren<BoxCollider2D>().offset = newOffsetPosition;
               // Debug.Log("Visualizer name is " + visualizerObjects[j].name);


            }


            /* newSize.y = Mathf.Clamp(Mathf.Lerp(newSize.y, minHeight + (spectrumData[i] * (maxHeight - minHeight) * 5.0f), updateSentivity * 0.5f), minHeight, maxHeight);
             visualizerObjects[i].GetComponent<RectTransform>().sizeDelta = newSize;
             */

            //  visualizerObjects[i].GetComponent<Image> ().color = visualizerColor;
        }
	}
}

namespace Assets
{
    class PlayerManager
    {
    }
}