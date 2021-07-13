using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private ManagerVars m_Vrs;
    /// <summary>
    /// 声音管理
    /// </summary>
    private AudioSource m_Source;
    private void Awake()
    {
        m_Vrs = ManagerVars.GetManagerVars();
        //m_Vrs.InitSound();
        m_Source = GetComponent<AudioSource>();
        EventCenter.AddListener<SOUND_TYPE>(SOUND_EVENT.PLAY, this.onPlaySound);
        EventCenter.AddListener(SOUND_EVENT.PAUSE, this.onPauseSound);
        EventCenter.AddListener(SOUND_EVENT.STOP, this.onStopSound);
    }
    private void onPlaySound(SOUND_TYPE type)
    {
        //this.m_Source.clip = this.m_Vrs.SoundDic[type.ToString()];
        this.m_Source.clip = this.m_Vrs.SoundList[(int)type];
        this.m_Source.Play();
    }
    /// <summary>
    /// 暂停声音
    /// </summary>
    private void onPauseSound()
    {
        this.m_Source.Pause();
    }
    /// <summary>
    /// 停止声音
    /// </summary>
    private void onStopSound()
    {
        this.m_Source.Stop();
    }
    /// <summary>
    /// test 测试用
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EventCenter.Broadcast(SOUND_EVENT.PLAY, SOUND_TYPE.欢呼);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            m_Source.Stop();
        }
    }
}
