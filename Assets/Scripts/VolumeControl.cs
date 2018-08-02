using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {

    public Slider VolumeValue;
    public AudioSource musicSource;

    void Update()
    {
        musicSource.volume = VolumeValue.value;
    }
}
