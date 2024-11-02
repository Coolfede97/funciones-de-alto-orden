﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScrtipsSinFuncionesDeAltoOrden : MonoBehaviour
{
    public TMP_InputField palabraInput;
    public TMP_InputField claveInput;
    public TextMeshProUGUI palabraFinal;
    private char[] abecedario = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

    public void CifrarPalabra()
    {
        string palabraACifrar = palabraInput.text;
        int clave = int.Parse(claveInput.text);
        claveInput.text = "";
        palabraInput.text = "";
        palabraACifrar = palabraACifrar.ToLower();
        string palabraCifrada = "";
        foreach (char c in palabraACifrar)
        {
            palabraCifrada += cifrar(c,clave);
            Debug.Log(palabraCifrada);
            Debug.Log(c);
        }
        palabraFinal.text = palabraCifrada;
    }
    public void DescifrarPalabra()
    {
        string palabraADescifrar = palabraInput.text;
        int clave = int.Parse(claveInput.text);
        claveInput.text = "";
        palabraInput.text = "";
        palabraADescifrar = palabraADescifrar.ToLower();
        string palabraDescifrada = "";
        foreach (char c in palabraADescifrar)
        {
            palabraDescifrada += descifrar(c,clave);
        }
        palabraFinal.text = palabraDescifrada;
    }
    private char cifrar(char letra, int clavePar)
    {
        if (clavePar < 0) return descifrar(letra, -clavePar);
        List<char> list = abecedario.ToList();
        if (abecedario.Contains(letra))
        {
            clavePar %= 27;
            int indiceNuevo = (clavePar + list.IndexOf(letra)) % 26;
            return list[indiceNuevo];
        }
        return ' ';
    }
    private char descifrar(char letra, int clavePar)
    {
        if (clavePar < 0) return cifrar(letra, -clavePar);
        List<char> list = abecedario.ToList();
        if (abecedario.Contains(letra))
        {
            clavePar %= 27;
            int indiceNuevo;
            if (list.IndexOf(letra) - clavePar < 0) indiceNuevo = list.IndexOf(letra) - clavePar + 26;
            else indiceNuevo = (list.IndexOf(letra) - clavePar);
            return list[indiceNuevo];
        }
        return ' ';
    }
}