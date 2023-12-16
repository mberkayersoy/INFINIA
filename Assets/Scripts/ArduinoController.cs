using UnityEngine;
using System.IO.Ports;

public class ArduinoController : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM6", 9600); // Arduino'nun ba�l� oldu�u seri portu ve baud rate'i ayarlay�n

    void Start()
    {
        serialPort.Open(); // Seri portu a�
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string serialData = serialPort.ReadLine(); // Arduino'dan gelen veriyi oku
                Debug.Log(serialData); // Veriyi Unity konsolunda g�ster
            }
            catch (System.Exception)
            {
                // Hata durumunda bir �ey yapabilirsiniz
            }
        }
    }

    void OnDestroy()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Close(); // Uygulama kapat�ld���nda seri portu kapat
 �������}
    }
}