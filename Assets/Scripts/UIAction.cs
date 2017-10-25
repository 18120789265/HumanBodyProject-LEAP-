using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAction : MonoBehaviour {

    /// <summary>
    /// 皮肤层显示与否
    /// </summary>
    /// <param name="flag">true：显示；false：隐藏</param>
    public void DoBtnDissoloveIntegumentary(bool flag) {
        if (!flag)
        {
            GameManager.Instance.DissoloveIntegumentarySystems();
        }
        else {
            GameManager.Instance.UnDissoloveIntegumentarySystems();
        }
    }

}
