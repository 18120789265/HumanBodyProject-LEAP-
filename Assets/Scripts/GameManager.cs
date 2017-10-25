using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

/// <summary>
/// 人体模型层次类型
/// </summary>
public enum BodySystemType {
    IntegumentarySystem, //皮肤系统
    MuscularSystem,      //肌肉系统
    SkeletalSystem,      //骨骼系统
    LymphaticSystem,     //淋巴系统
    CirculatorySystem,   //循环系统
    NervousSystem,       //神经系统
    RespiratorySystem,   //呼吸系统
    DigestiveSystem,     //消化系统
    UrinarySystem        //泌尿系统
}

public class GameManager : MonoBehaviour {

    //是否处于动画播放状态
    public static bool IsOnAnimation = false;

    #region 单例
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    #region 公开变量
    [Header("皮肤层")]
    public GameObject[] IntegumentarySystems;
    [Header("溶解时间")]
    public float DessoloveTime = 2.0f;
    #endregion

    #region 私有变量
    #endregion

    #region 开放方法
    /// <summary>
    /// 溶解隐藏皮肤层
    /// </summary>
    public void DissoloveIntegumentarySystems() {
        IsOnAnimation = true;
        Dissolove(IntegumentarySystems[0], delegate
        {
            Dissolove(IntegumentarySystems[1], delegate {
                IsOnAnimation = false;
                IntegumentarySystems[0].SetActive(false);
                IntegumentarySystems[1].SetActive(false);
                //隐藏眼睛
                IntegumentarySystems[2].SetActive(false);
            });
        });
    }

    /// <summary>
    /// 显示皮肤层
    /// </summary>
    public void UnDissoloveIntegumentarySystems()
    {
        IsOnAnimation = true;
        IntegumentarySystems[0].SetActive(true);
        IntegumentarySystems[1].SetActive(true);
        UnDissolove(IntegumentarySystems[1],delegate {
            UnDissolove(IntegumentarySystems[0],delegate {
                IsOnAnimation = false;
                IntegumentarySystems[2].SetActive(true);
            });
        });
    }
    #endregion

    #region 内部方法
    /// <summary>
    /// 延迟溶解
    /// </summary>
    /// <param name="ac"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator DissoloveWaitTime(GameObject go,Action ac,float time) {
        yield return new WaitForSeconds(time);
        Dissolove(go, ac);
    }

    /// <summary>
    /// 立即溶解
    /// </summary>
    /// <param name="go"></param>
    /// <param name="ac"></param>
    void Dissolove(GameObject go,Action ac = null) {
        Material[] mas = go.GetComponent<MeshRenderer>().materials;
        float value = 0.55f;
        DOTween.To(() => value, x => value = x, 0.3f, DessoloveTime).OnUpdate(delegate {
            foreach (Material ma in mas)
            {
                ma.SetFloat("_Progress", value);
            }
        }).OnComplete(delegate {
            if (ac != null)
                ac();
        });
    }

    /// <summary>
    /// 反溶解
    /// </summary>
    /// <param name="go"></param>
    /// <param name="ac"></param>
    void UnDissolove(GameObject go, Action ac = null) {
        Material[] mas = go.GetComponent<MeshRenderer>().materials;
        float value = 0.3f;
        DOTween.To(() => value, x => value = x, 0.55f, DessoloveTime).OnUpdate(delegate {
            foreach (Material ma in mas)
            {
                ma.SetFloat("_Progress", value);
            }
        }).OnComplete(delegate {
            if (ac != null)
                ac();
        });
    }
    #endregion
}
