﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]

public class  AudioPeer : MonoBehaviour {

    public GameObject playerm;
    public GameObject Audiooff;

    AudioSource audioSource;
    public static   float[] _samples = new float[512];
    public static float[] _freqBand = new float[8];
    public static float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];

   // float[] _freqBandHeighest = new float[8];
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];

   

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        GetSpectrumAudioSource();
        MakeFrequencyBand();
        BandBuffer();
        stopmusic();
        //CreateAudioBand();
    }
    /*
    void CreateAudioBand()
    {
        for (int i= 0; i < 8; i++)
        {
            if(_freqBand [i] > _freqBandHeighest [i])
            {
                _freqBandHeighest[i] = _freqBand[i];
            }
            _audioBand[i] = (_freqBand[i] / _freqBandHeighest[i]);
           _audioBandBuffer[i] = (_bandBuffer [i] / _freqBandHeighest[i]);
        }
    }*/

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(_samples,0,FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; ++g)
        {
            if( _freqBand [g] > _bandBuffer [g])
            {
                _bandBuffer[g] = _freqBand[g];
                _bufferDecrease[g] = 0.005f;
            }

            if (_freqBand[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBand()
    {
        int count = 0;
        for (int i =0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2 ;
            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j= 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }
            average /= count;
            _freqBand[i] = average * 10;

        }
    }

    public void stopmusic()
    {
        if (playerm.activeInHierarchy == false)
        {
            Audiooff.SetActive(false);
        }
    }
}