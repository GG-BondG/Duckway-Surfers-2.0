using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceMeasurer : MonoBehaviour
{
    float StartingDistance;
    float CurrentDistance;
    public Text distanceText;
    // Start is called before the first frame update
    void Start()
    {
        StartingDistance = transform.position.z;
    }
    public Text finalDistanceDisplay;
    // Update is called once per frame
    void Update()
    {
        CurrentDistance = transform.position.z;
        CurrentDistance -= StartingDistance;
        CurrentDistance /= 2;
        distanceText.text = CurrentDistance.ToString("F1") + "M";
        finalDistanceDisplay.text = CurrentDistance.ToString("F1") + "M";
    }
}
