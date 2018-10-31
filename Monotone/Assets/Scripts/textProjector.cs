using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class textData
{
    public Text text;
    public Transform target;
}

public class textProjector : MonoBehaviour {

    public textData[] data;

    void LateUpdate()
    {
        foreach (textData d in data)
            Project(d.text, d.target);
    }

    public void Project(Text text, Transform target)
    {
        if(target != null)
            text.rectTransform.position = Camera.main.WorldToScreenPoint(target.position);
    }

}