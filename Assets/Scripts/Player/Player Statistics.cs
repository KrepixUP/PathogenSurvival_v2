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
    [Range(0, 200)]public float Health = 100;
    [Range(0, 200)]public float Stamina = 100;
    [Range(0, 200)]public float Food = 100;
    [Range(0, 200)]public float Water = 100;
    [Range(0, 200)]public float Oxygen = 100;
    [Range(-50, 80)]public float Temperature = 22;
    [Range(0, 100)]public float Radiation = 0;
    [Range(0, 100)]public float Pollution = 0;
    [Range(0, 100)]public float Virus = 0;
    
    [Header("Max Player Statistic")]
    public float M_Health = 100;
    public float M_Stamina = 100;
    public float M_Food = 100;
    public float M_Water = 100;
    public float M_Oxygen = 100;
    public float M_Temperature = 100;


    [Header("Connect Bar")]
    public Image HealthBar;
    public Image StaminaBar;
    public Image FoodBar;
    public Image WaterBar;

    

    void Start()
    {

    }

    void Update()
    {
        Stamina = Mathf.Clamp(Stamina, 0 ,M_Stamina);

        HealthBar.fillAmount = Health / M_Health;
        StaminaBar.fillAmount = Stamina / M_Stamina;
        FoodBar.fillAmount = Food / M_Food;
        WaterBar.fillAmount = Water / M_Water;

        Food -= 0.05f * Time.deltaTime;


        // Obniżanie zdrowa, gdy jedzenie spada do zera
        if(Food == 0 )
        {
            Health -= 0.5f * Time.deltaTime;
        }



    }
}
