using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum AudioType
{
    Master,
    SoundFX,
    Music
}

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioMixer m_Master = null;
    [SerializeField] List<AudioSource> m_Sources = new List<AudioSource> ();

    public void SetVolume(AudioType type, float volume)
    {
        switch (type)
        {
            case AudioType.Master:
                m_Master.SetFloat("MasterVol", volume);
                break;

            case AudioType.SoundFX:
                m_Master.SetFloat("SoundFXVol", volume);
                break;

            case AudioType.Music:
                m_Master.SetFloat("MusicVol", volume);
                break;
        }
    }
}
    