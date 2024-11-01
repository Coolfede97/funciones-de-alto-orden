using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Script : MonoBehaviour
{
    public int clave;
    public string palabraACifrar;
    public string palabraCifrada;
    public string palabraDescifrada;
    
    private char[] abecedario = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    void Start()
    {
        //foreach (char letra in letras)
        //{
        //    Debug.Log(letra);
        //}
        palabraACifrar=palabraACifrar.ToLower();
        palabraCifrada = new string(palabraACifrar.Select(c => cifrar(c, clave)).ToArray());
        // palabraDescifrada = new string(palabraCifrada.Select(c => descifrar(c, clave)).ToArray());
    }

    private char cifrar(char letra, int clavePar)
    {
        List<char> list = abecedario.ToList();
        if (abecedario.Contains(letra))
        {
            clavePar%=27;
            int indiceNuevo = (clavePar+list.IndexOf(letra))%26;
            return list[indiceNuevo];
        }
        return ' ';
    }
    private char descifrar(char letra, int clavePar)
    {
        List<char> list = abecedario.ToList();
        if (abecedario.Contains(letra))
        {
            clavePar%=27;
            int indiceNuevo = (clavePar+list.IndexOf(letra))%26;
            return list[indiceNuevo];
        }
        return ' ';
    }
}
