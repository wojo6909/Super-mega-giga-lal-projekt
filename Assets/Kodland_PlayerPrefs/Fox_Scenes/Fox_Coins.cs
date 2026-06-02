using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_Coins : MonoBehaviour
{
    //imię obiektu
public string objectName;
//czy obiekt jest zajęty?
public bool isTaken;
    // Start is called before the first frame update
Fox_Logic foxLogic;

private void Start()
{
    foxLogic = FindObjectOfType<Fox_Logic>();      
    // Jeśli mamy gniazdo zapisu o takiej nazwie
if (PlayerPrefs.HasKey(objectName))
{
    // Porównywanie wartości w tym gnieździe z 1, przechowywanie wyniku sprawdzenia w zmiennej isTaken
    // Jeśli takie gniazdo istnieje, nieuchronnie porównamy 1 z 1, co zawsze zwróci True
    isTaken = PlayerPrefs.GetInt(objectName) == 1;
    // Ustawianie stanu obiektu na Włączony/Wyłączony w zależności od wartości zmiennej isTaken
    gameObject.SetActive(!isTaken);
}  
}
private void OnTriggerEnter(Collider other)
{
    //Jeśli obiekt, który dotknął monety, ma tag "Player", to...
    if (other.CompareTag("Player"))
    {
        // Ustawianie zmiennej
        isTaken = true;
// Tworzenie gniazda zapisu z nazwą obiektu, przechowywanie w nim wartości "1"
        PlayerPrefs.SetInt(objectName, 1);
// Wyłączanie monety
        gameObject.SetActive(false);
        // Pobieranie liczby monet z gniazda zapisu i przechowywanie jej w tymczasowej zmiennej
        // Jeśli takie gniazdo nie istnieje, ustawiamy wartość na 0
        var value = PlayerPrefs.GetInt("Coins", 0);
        // Zapisywanie zaktualizowanej liczby zebranych monet w gnieździe "Coins"
        // W tym celu musimy wziąć bieżącą zmienną i dodać do niej jedną
        PlayerPrefs.SetInt("Coins", value + 1);
        // Wywołanie metody aktualizacji interfejsu użytkownika (nie martw się błędem; po prostu jeszcze nie napisaliśmy tej metody)
        foxLogic.GetCoin();
    }
}
}
