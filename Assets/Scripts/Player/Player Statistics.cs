using UnityEngine;
using Image = UnityEngine.UI.Image;
using TMPro;




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
    public bool Celcjusze;

    
    //Additional Stat
    private float AddHealth, AddStamina, AddFood, AddWater, AddOxygen, AddVirus, AddWeight, AddRadiation;

    //Max Stat
    private float MxHealth, MxStamina, MxFood, MxWater, MxOxygen, MxTemp, MxRadiation, MxPollution, MxVirus, MxWeight;

    // Type of Statistics
    private GameObject S_Health, S_Food, S_Water, S_Virus, S_Temperature, S_Oxygen, S_Radiation, S_Weight, S_Stamina;
    private Image F_Weight, F_Stamina, F_Oxygen, F_Radiation, F_Health, F_Food, F_Water, F_Virus, F_Temperature;
    private TextMeshProUGUI T_Temperature, T_Weight;



    

    void Start()
    {
        AsignVariable();
        StatisticUpdate();

    }

    void Update()
    {
        StatisticUpdate();

        if (Input.GetKey(KeyCode.LeftAlt)){S_Health.SetActive(true);S_Food.SetActive(true);S_Water.SetActive(true);S_Virus.SetActive(true);}else{S_Health.SetActive(false);S_Food.SetActive(false);S_Water.SetActive(false);S_Virus.SetActive(false);}

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

        F_Weight = GameObject.Find("Canvas/Statistics/S_Weight/F_Weight")?.GetComponent<Image>();
        F_Stamina = GameObject.Find("Canvas/Statistics/S_Stamina/F_Stamina")?.GetComponent<Image>();
        F_Oxygen = GameObject.Find("Canvas/Statistics/S_Oxygen/F_Oxygen")?.GetComponent<Image>();
        F_Radiation = GameObject.Find("Canvas/Statistics/S_Radiation/F_Radiation")?.GetComponent<Image>();
        F_Health = GameObject.Find("Canvas/Statistics/S_Health/F_Health")?.GetComponent<Image>();
        F_Food = GameObject.Find("Canvas/Statistics/S_Food/F_Food")?.GetComponent<Image>();
        F_Water = GameObject.Find("Canvas/Statistics/S_Water/F_Water")?.GetComponent<Image>();
        F_Virus = GameObject.Find("Canvas/Statistics/S_Virus/F_Virus")?.GetComponent<Image>();
        F_Temperature = GameObject.Find("Canvas/Statistics/S_Temperature/F_Temperature")?.GetComponent<Image>();

        T_Temperature = GameObject.Find("Canvas/Statistics/S_Temperature/T_Temperature")?.GetComponent<TextMeshProUGUI>();
        T_Weight = GameObject.Find("Canvas/Statistics/S_Weight/T_Weight")?.GetComponent<TextMeshProUGUI>();
    }


    void StatisticUpdate()
    {
        MxHealth = 100 + AddHealth;
        MxStamina = 100 + AddStamina;
        MxFood = 100 + AddFood;
        MxWater = 100 + AddWater;
        MxOxygen = 100 + AddOxygen;
        MxVirus = 100 + AddVirus;
        MxRadiation = 100 + AddRadiation;
        MxWeight = 100 + AddWeight;
        MxTemp = 122;

        F_Weight.fillAmount = Weight / MxWeight;
        F_Stamina.fillAmount = Stamina / MxStamina;
        F_Oxygen.fillAmount = Oxygen / MxOxygen;
        F_Radiation.fillAmount = Radiation / MxRadiation;
        F_Health.fillAmount = Health / MxHealth;
        F_Food.fillAmount = Food / MxFood;
        F_Water.fillAmount = Water / MxWater;
        F_Virus.fillAmount = Virus / MxVirus;



        float displayTemperature = Temperature;
        string unit = "°F";

        int weightPercentage = Mathf.RoundToInt(F_Weight.fillAmount * 100);
        T_Weight.text = $"{weightPercentage}";


        if (Celcjusze)
        {
            displayTemperature = (Temperature - 32) * 5 / 9; // Konwersja na Celsjusza
            unit = "°C";
        }

        // Logika dla temperatury
        if (Temperature >= 0) // Temperatura powyżej 0°F
        {
            F_Temperature.fillAmount = Temperature / MxTemp;
            F_Temperature.color = new Color(1f, 0.65f, 0f, 1f); // Kolor czerwony dla wysokich temperatur
            T_Temperature.text = $"{displayTemperature:F1}{unit}";
        }
        else // Temperatura poniżej 0°F
        {
            float normalizedTemp = Mathf.Clamp(Temperature, -58, 0); // Ograniczenie od -58°F do 0°F
            F_Temperature.fillAmount = Mathf.Abs(normalizedTemp) / 58; // Normalizacja do zakresu -58°F -> 0°F
            F_Temperature.color = Color.cyan; // Kolor aqua dla niskich temperatur
            T_Temperature.text = $"{displayTemperature:F1}{unit}";
        }




        if (F_Weight.fillAmount >= 0.5f){if(F_Weight.fillAmount >= 0.75f){F_Weight.color = new Color(1f, 0f, 0f);}else{F_Weight.color = new Color(1f, 0.5f, 0f);}}else{F_Weight.color = Color.white;}
        if (F_Oxygen.fillAmount >= 1f) { S_Oxygen.SetActive(false); } else { S_Oxygen.SetActive(true);}
        if (F_Radiation.fillAmount <= 0f) { S_Radiation.SetActive(false); } else { S_Radiation.SetActive(true);}
        


    }

}
