using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string groupName;

    private float volume;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        audioMixer.GetFloat(groupName , out volume );
        slider.value = Mathf.Pow(10, volume / 20);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat(groupName, Mathf.Log10(volume) * 20);
    }
}
