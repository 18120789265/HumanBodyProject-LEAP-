using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataReadHelp{

    /// <summary>
    /// 解析处理人体模型数据
    /// </summary>
    /// <param name="asset"></param>
    public static Dictionary<string, string> AnaLysisFromTextAsset(TextAsset  asset) {
        Dictionary<string, string> HumanBodyDatas = new Dictionary<string, string>();

        //读取每一行的内容
        string[] lineArray = asset.text.Split("\r"[0]);

        //把csv中的数据储存在二位数组中
        for (int i = 0; i < lineArray.Length; i++)
        {
            string[] strs = lineArray[i].Split(","[0]);
            if (!HumanBodyDatas.ContainsKey(strs[0]))
            {
                HumanBodyDatas.Add(strs[0], strs[1]);
            }
        }

        return HumanBodyDatas;
    }

}
