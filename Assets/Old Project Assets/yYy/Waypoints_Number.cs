using System.Collections.Generic;
using UnityEngine;

public class Waypoints_Number : MonoBehaviour
{
    public int wp_num;
    public List<Transform> Waypoints = new List<Transform>();
    Index indexScript;

    void Start()
    {
        Waypoints.Clear();
        foreach (Transform child in transform)
        {
            indexScript = child.GetComponent<Index>();
            if (indexScript == null)
            {
                indexScript = child.gameObject.AddComponent<Index>();
            }
            indexScript.index = wp_num;
            Waypoints.Add(child);
            wp_num = wp_num + 1;
        }
    }
}