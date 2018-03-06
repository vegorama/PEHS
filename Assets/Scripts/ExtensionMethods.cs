using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Extensions
{

    public static List<T> GetComponentsInChildrenNoParent<T>(this GameObject parent) where T : Component
    {

        Transform tr = parent.transform;
        int count = tr.childCount;
        List<T> list = new List<T>();
        for (int i = 0; i < count; i++)
        {
            var child = tr.GetChild(i);
            list.AddRange(child.GetComponentsInChildren<T>());
        }

        return list;
    }
}
