using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateText{

    public static TextMesh CreateTextInWorld(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor)
    {
        GameObject gameobject = new GameObject("Text", typeof(TextMesh));
        Transform transform = gameobject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameobject.GetComponent<TextMesh>();
        textMesh.fontSize = fontSize;
        textMesh.anchor = textAnchor;
        textMesh.text = text;
        textMesh.color = color;
        return textMesh;
    }

}
