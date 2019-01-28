using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class Simulator : MonoBehaviour 
{
    float yRotation, xRotation, zRotation;
    bool skateIt = false;
    public Animator animator;
    public Dropdown dropdown;
    public Text text;
    public GameObject botaoSimulator;


    public void FuncClick(){
        string manobra = dropdown.options[dropdown.value].text;
        skateIt = true;
        text.text = "";
        ExecutarManobra(manobra);
    }

    public void TrocarCena(int cena)
    {
        SceneManager.LoadScene(cena);
    }

    private void Awake()
    {
        botaoSimulator = GameObject.Find("Simulator");

        animator = GetComponent<Animator>();
        text = GameObject.Find("fraseManobra").GetComponent<Text>();
        Screen.orientation = ScreenOrientation.Portrait;

        List<string> manobras = new List<string>()
        { "Ollie", "Varial", "Flip", "Varial Flip", "Kick Flip", "Double Varial", "Double Flip", "Gravity"};
        dropdown.AddOptions(manobras);

        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.1f;
    }

    void Start()
    {
        botaoSimulator.SetActive(false);
    }

    public void ListenToGyroQuaternion()
    {
        if(skateIt)
        {
            text.text = "Movimente o dispositivo";
            xRotation += -Input.gyro.rotationRateUnbiased.x;
            yRotation += -Input.gyro.rotationRateUnbiased.y;
            zRotation += -Input.gyro.rotationRateUnbiased.z;
            transform.rotation = Quaternion.Euler(xRotation, zRotation, yRotation * 2);
        }
    }

    public void ExecutarManobra(string manobra)
    {
        if (skateIt)
        {
            skateIt = false;
            text.text = manobra + " realizado!";
            animator.SetTrigger(manobra);
        }
    }
}
