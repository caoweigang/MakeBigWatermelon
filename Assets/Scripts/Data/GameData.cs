using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    private static GameData instance;
    /// <summary>
    /// 它的继承类不需在写得到单例的方法
    /// </summary>
    /// <returns></returns>
    public static GameData GetInstance()
    {
        if (instance == null)
        {
            instance = new GameData();
        }
        return instance;
    }
    /// <summary>
    /// 在继承类中重写此方法可以将继承类的实例清空
    /// </summary>
    public virtual void Dispose()
    {
        instance = default(GameData);
    }


    public FRUIT_TYPE[] allFruits = { FRUIT_TYPE.chengzi, FRUIT_TYPE.ningmeng, FRUIT_TYPE.mihoutao, FRUIT_TYPE.xihongsi, FRUIT_TYPE.taozi, FRUIT_TYPE.hamigua, FRUIT_TYPE.xigua };

}
