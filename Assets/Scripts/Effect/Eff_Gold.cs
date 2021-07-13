using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Eff_Gold : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("金币飞行", GUILayout.MaxWidth(366), GUILayout.MaxHeight(184)))
        {
            this.onClick();
        }
        if (GUILayout.Button("画个圆", GUILayout.MaxWidth(366), GUILayout.MaxHeight(184)))
        {
            this.onShow();
        }
    }

    public Image img;
    private List<Image> prefabPool = new List<Image>();
    Image GetPrefab()
    {
        for (int i = 0; i < prefabPool.Count; i++)
        {
            if (prefabPool[i].gameObject.activeSelf == false)
            {
                return prefabPool[i];
            }
        }
        return Instantiate(img);
    }
    void onClick()
    {
        for (int i = 0; i < 10; i++)
        {
            var distanceScale = 1 + 10 / 30;
            Image im = GetPrefab();
            im.transform.SetParent(transform);
            im.rectTransform.anchoredPosition = Vector2.zero;

            var dic = UnityEngine.Random.Range(100, 200) * distanceScale;
            //Debug.Log("dic  " + dic);

            var random_angle = UnityEngine.Random.Range(0, 361);//随机一个角度
            //Debug.Log("random_angle  " + random_angle);

            var x = dic * Mathf.Cos(random_angle);
            var y = dic * Mathf.Sin(random_angle);

            var offset = new Vector2(x, y);

            //Debug.Log("x " + x);
            //Debug.Log("y " + y);
            //Debug.Log(offset);
            im.transform.gameObject.SetActive(true);
            im.rectTransform.DOAnchorPos(im.rectTransform.anchoredPosition + offset, 0.5f).OnComplete(() =>
            {
                y = Screen.height / 2;
                x = Screen.width / 2;
                im.rectTransform.DOAnchorPos(new Vector2(-x, y), 1).OnComplete(() =>
                {
                    im.gameObject.SetActive(false);
                });
            });
        }
    }
    [Tooltip("需要显示的个数"), Range(0, 360)] public int use_show_number = 0;
    [Tooltip("间距"), Range(0, 200)] public int use_show_dic = 0;
    void onShow()
    {
        List<GameObject> temp = new List<GameObject>();
        for (int i = 0; i < use_show_number; i++)
        {
            var angle = 360 / use_show_number;
            Image im = GetPrefab();
            im.transform.SetParent(transform);
            im.rectTransform.anchoredPosition = Vector2.zero;

            var x = use_show_dic * Mathf.Cos(angle + i);
            var y = use_show_dic * Mathf.Sin(angle + i);

            im.rectTransform.anchoredPosition = new Vector2(x, y);
            im.gameObject.SetActive(true);
            temp.Add(im.gameObject);
        }
        asyncFunc(5, temp);
    }

    async void asyncFunc(int timer, List<GameObject> temp)
    {
        await Task.Delay(timer * 1000);
        for (int i = 0; i < temp.Count; i++)
        {
            temp[i].SetActive(false);
        }
    }
}
