using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    public Texture2D image;
    int hauteur, largeur;

    void Start()
    {
        // Obtenir la largeur et la hauteur de l'image
         largeur = image.width;
         hauteur = image.height;
        //Création d'un tableau pour stockage des données
        int[] valeursPixels = new int[largeur * hauteur];

        int compteur = 0;

        // Obtenir les pixels de l'image
      
        Color[] pixels = image.GetPixels();

        //Définir taille max des vecteurs !!!!!!
        for (int i = 0; i < pixels.Length; i++)
        {
            // Convertir la couleur en valeur en noir et blanc (0 ou 1)
            //float valeurPixel = pixels[i].grayscale;
            float valeurPixel = pixels[i].r;
            int valeurNoirBlanc = (valeurPixel > 0.5f) ? 1 : 0;

            // Stocker la valeur du pixel dans le tableau
            valeursPixels[i] = valeurNoirBlanc;

            // Afficher la valeur du pixel dans la console
            //Debug.Log("Pixel " + i + " : " + valeurNoirBlanc);
        }
            Debug.Log(valeursPixels[1080]);
        Debug.Log(valeursPixels[50000]);
        Debug.Log(valeursPixels[56320]);
    


    // Afficher la dimension de l'image dans la console
    Debug.Log("Dimension de l'image : " + largeur + "x" + hauteur);
    }

    void Update()
    {
        //Si l'image est trop grande
        if (hauteur >= 1080)
        {
            hauteur = 1080;
        }
        if (largeur >= 1920)
        {
            largeur = 1920;
        }
    }
}
