using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    #region 单例
    public static DataManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    public TextAsset BodyDataAsset;

    Dictionary<string, string> HumanBodyDatas = new Dictionary<string, string>();

	// Use this for initialization
	void Start () {
        HumanBodyDatas = DataReadHelp.AnaLysisFromTextAsset(BodyDataAsset);
        Debug.Log(HumanBodyDatas.Count);
    }

    /// <summary>
    /// 查找中文描述
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public string SearchData(string name) {
        string res = "";
        if (HumanBodyDatas.Count <= 0)
            return res;
        if (HumanBodyDatas.ContainsKey(name)) {
            res = HumanBodyDatas[name];
        }
        return res;
    }

	
}
