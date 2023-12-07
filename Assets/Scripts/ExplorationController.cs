using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class ExplorationController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI explorationText;
    public int score;
    [SerializeField] float fillSpeed = 0.5f;
    private float targetProgress = 0;
    private bool scoreAdded;

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
        score =+ furnitureFound * 5;
        slider.value = furnitureFound;
        
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
        float percentage = ConvertToPercentage(furnitureFound);
        explorationText.text = (int)percentage + "%";
        Debug.Log(percentage.ToString());

        if (percentage == 100 && !scoreAdded)
        {
            score = score + 500;
            StartCoroutine(GetComponent<TriggerController>().EventText("Explored everything. (+500 score)"));
            scoreAdded = true;
        }
    }
    float ConvertToPercentage(int value)
    {
        value = Mathf.Clamp(value, 0, furnitureCount);

        float percentage = ((float)value / furnitureCount) * 100;

        return percentage;
    }
}
