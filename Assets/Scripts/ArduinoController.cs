using UnityEngine;
using System.IO.Ports;

public class ArduinoController : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM6", 9600); // Arduino'nun baðlý olduðu seri portu ve baud rate'i ayarlayýn

    void Start()
    {
        serialPort.Open(); // Seri portu aç
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string serialData = serialPort.ReadLine(); // Arduino'dan gelen veriyi oku
                Debug.Log(serialData); // Veriyi Unity konsolunda göster
            }
            catch (System.Exception)
            {
                // Hata durumunda bir þey yapabilirsiniz
            }
        }
    }

    void OnDestroy()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Close(); // Uygulama kapatýldýðýnda seri portu kapat
        }
    }
}