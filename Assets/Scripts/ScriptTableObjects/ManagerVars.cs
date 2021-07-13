using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "CreatManagerVarsController")]
public class ManagerVars : ScriptableObject
{
    /// <summary>
    /// 获取资源
    /// </summary>
    /// <returns></returns>
    public static ManagerVars GetManagerVars()
    {
        return Resources.Load<ManagerVars>("ManagerVarsController");
    }
    /// <summary>
    /// 声音列表
    /// </summary>
    [SerializeField]
    private List<AudioClip> m_SoundList = new List<AudioClip>();
    /// <summary>
    /// 声音列表
    /// </summary>
    public List<AudioClip> SoundList
    {
        get
        {
            return m_SoundList;
        }
    }


    #region
    /// <summary>
    /// 先暂时不用
    /// </summary>
    public Dictionary<string, AudioClip> SoundDic = new Dictionary<string, AudioClip>();
    /// <summary>
    /// 初始化音频系统
    /// </summary>
    public void InitSound()
    {
        for (int i = 0; i < this.m_SoundList.Count; i++)
        {
            AudioClip clip = m_SoundList[i];
            this.SoundDic.Add(clip.name, clip);
        }
    }
    #endregion
}
