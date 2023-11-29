using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ExplorationController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float fillSpeed = 0.5f;
    private float targetProgress = 0;

    public int furnitureFound = 0;
    public int furnitureCount = 24;

    private void Awake()
    {
        slider = slider.GetComponent<Slider>();
    }

    void Start()
    {
        slider.maxValue = furnitureCount;
    }
    public void collectOne()
    {
        furnitureFound++;
        slider.value = furnitureFound;
    }
    // Update is called once per frame
    //void Update()
    //{
    //    if (slider.value < targetProgress)
    //        slider.value += fillSpeed * Time.deltaTime;
    //}
    //public void IncrementProgress(int newProgress)
    //{
    //    targetProgress += slider.value + newProgress;
    //}
}
