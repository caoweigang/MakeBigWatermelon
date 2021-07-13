using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class XiguaGo : MonoBehaviour,IDragHandler
{
    public GameObject fruit;
    public Transform fruitInitPos;

    GameObject m_currentGob;
    Transform m_currengGobPos;
    Sprite[] m_allFruits;
    // Start is called before the first frame update
    private void Awake() {
        InitFruit();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mousePos = Input.mousePosition;
            m_currengGobPos.position = new Vector3(mousePos.x, m_currengGobPos.position.y, 0);
        }
        if (Input.GetMouseButtonUp(0))
        { 
            print("up");
            m_currentGob.GetComponent<Rigidbody2D>().gravityScale = 66;
            RandomFruit();
        }

    }

    /// <summary>
    /// 初始化一个水果
    /// </summary>
    void InitFruit()
    {
        CreatFruit(FRUIT_TYPE.chengzi);
    }

    /// <summary>
    /// 根据水果类型给水果赋值, 生成水果
    /// </summary>
    void CreatFruit(FRUIT_TYPE randomFruit)
    {
        m_currentGob = Instantiate<GameObject>(fruit,fruitInitPos.position,Quaternion.identity,transform);
        string name = m_currentGob.name;
        m_currentGob.name = name.Replace("(Clone)", "");
        Image myImage = m_currentGob.GetComponent<Image>();

        string randomFruitName = Enum.GetName(typeof(FRUIT_TYPE), randomFruit);
        m_allFruits = Resources.LoadAll<Sprite>("Img/game/fruitsPackge");
        Sprite initFruit = m_allFruits[0];
        Sprite randomSprit = initFruit;

        for (int i = 0; i < m_allFruits.Length; i++)
        {
            Sprite ss = m_allFruits[i];
            print(ss.name);
            if (ss.name == randomFruitName)
            {
                randomSprit = m_allFruits[i];
                break;
            }
        }
        myImage.sprite = randomSprit;
        myImage.SetNativeSize();
        //设置碰撞体大小
        float radius = m_currentGob.GetComponent<RectTransform>().sizeDelta.x/2;
        print(radius);
        CircleCollider2D collider = m_currentGob.GetComponent<CircleCollider2D>();
        collider.radius = radius;
        m_currentGob.GetComponent<Rigidbody2D>().gravityScale = 0;//(松开鼠标后赋值为50)
        m_currengGobPos = m_currentGob.transform;
    }

    /// <summary>
    /// 随机一个水果类型
    /// </summary>
    /// <returns></returns>
    FRUIT_TYPE RandomNum()
    {
        int i = UnityEngine.Random.Range(0, 7);
        return GameData.Instance.allFruits[i];

    }

    /// <summary>
    /// 随机一个水果
    /// </summary>
    void RandomFruit()
    {
        FRUIT_TYPE randomFruit = RandomNum();
        CreatFruit(randomFruit);
    }



    /// <summary>
    /// 检测水果碰撞消失加分
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        
    }

    /// <summary>
    /// 拖拽水果位移
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Input.mousePosition;
        m_currengGobPos.position = new Vector3(mousePos.x, m_currengGobPos.position.y, 0);
    }
}

//bug  : 水果会穿过碰撞体掉下去

