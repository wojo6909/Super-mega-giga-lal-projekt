using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
// Referencja do przycisku Wczytaj Grę
[SerializeField] Button przyciskWczytaj;
private void Start()
{
    Cursor.lockState = CursorLockMode.None;
    // Sprawdzanie, czy mamy gniazdo zapisu. Jeśli tak, aktywujemy przycisk Wczytaj
    if (PlayerPrefs.HasKey("posX"))
    {
        przyciskWczytaj.interactable = true;
    }
}
// Funkcja nowej gry
public void RozpocznijNowaGre()
{
    // Sprawdzanie, czy mamy gniazdo zapisu. Jeśli tak, czyścimy wszystkie gniazda zapisu i rozpoczynamy nową grę
    if(PlayerPrefs.HasKey("posX"))
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Game");
    }
    // W przeciwnym razie po prostu rozpoczynamy grę
    else
    {
        SceneManager.LoadScene("Game");
    }
}
// Funkcja, która uruchamia grę z uwzględnieniem wszystkich zapisanych danych
public void WczytajGre()
{
    // Uruchamiamy grę, jeśli mamy jakiekolwiek gniazda zapisu
    if (PlayerPrefs.HasKey("posX"))
    {
        SceneManager.LoadScene("Game");
    }
}
}
