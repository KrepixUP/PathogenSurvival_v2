using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;



public class PlayerStat : MonoBehaviour
{
    [Header("Player Statistic")]
    public float Health = 100;
    public float Stamina = 100;
    public float Food = 100;
    public float Water = 100;
    public float Oxygen = 100;
    public float Temperature = 22;
    public float Radiation = 0;
    public float Pollution = 0;
    public float Virus = 0;
    public float Weight = 0;

    
    //Additional Stat
    private float AddHealth, AddStamina, AddFood, AddWater, AddOxygen, AddVirus, AddWeight;

    //Max Stat
    private float MxHealth, MxStamina, MxFood, MxWater, MxOxygen, MxTemp, MxRadiation, MxPollution, MxVirus, MxWeight;

    // Type of Statistics
    private GameObject S_Health, S_Food, S_Water, S_Virus, S_Temperature, S_Oxygen, S_Radiation, S_Weight, S_Stamina;
    private Image F_Weight;




    

    void Start()
    {
        AsignVariable();
        StatisticUpdate();

    }

    void Update()
    {
        StatisticUpdate();



    }








    void StatisticUpdate()
    {
        MxHealth = 100 + AddHealth;
        MxStamina = 100 + AddStamina;
        MxFood = 100 + AddFood;
        MxWater = 100 + AddWater;
        MxOxygen = 100 + AddOxygen;
        MxVirus = 0 + AddVirus;
        MxWeight = 100 + AddWeight;
        Debug.Log($"Weight: {Weight}, MxWeight: {MxWeight}, FillAmount: {Weight / MxWeight}");
        F_Weight.fillAmount = Mathf.Clamp01(Weight / MxWeight);

    }




    void AsignVariable()
    {
        S_Health = GameObject.Find("Canvas/Statistics/S_Health");
        S_Food = GameObject.Find("Canvas/Statistics/S_Food");
        S_Water = GameObject.Find("Canvas/Statistics/S_Water");
        S_Virus = GameObject.Find("Canvas/Statistics/S_Virus");
        S_Temperature = GameObject.Find("Canvas/Statistics/S_Temperature");
        S_Oxygen = GameObject.Find("Canvas/Statistics/S_Oxygen");
        S_Radiation = GameObject.Find("Canvas/Statistics/S_Radiation");
        S_Weight = GameObject.Find("Canvas/Statistics/S_Weight");
        S_Stamina = GameObject.Find("Canvas/Statistics/S_Stamina");

        F_Weight = GameObject.Find("Canvas/Statistics/F_Weight")?.GetComponent<Image>();



    }
}
