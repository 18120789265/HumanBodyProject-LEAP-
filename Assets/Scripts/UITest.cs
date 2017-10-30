using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour {

    public Text TestText;

    public void DoBtnTest(string msg) {
        TestText.text = msg;
    }

}
