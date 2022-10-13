using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioClip m_AudioClip = null;
    [SerializeField] AudioSource m_AudioSource = null;

    [SerializeField] bool m_PlayOnAwake = false;
    [SerializeField] bool m_Looping = false;

    private void Awake()
    {
        m_AudioSource.playOnAwake = m_PlayOnAwake;
        m_AudioSource.loop = m_Looping;
    }
    public void PlayAudioClip()
    {
        m_AudioSource.clip = m_AudioClip;
        m_AudioSource.Play();
    }

    public void PlayAudioClipOneShot()
    {
        m_AudioSource.PlayOneShot(m_AudioClip);
    }
}
