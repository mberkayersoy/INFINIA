using UnityEngine;
using System.IO.Ports;

public class InputTest : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM5", 9600);

    void Start()
    {
        serialPort.Open();
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string serialData = serialPort.ReadLine();
                Debug.Log(serialData); // Send data
            }
            catch (System.Exception)
            {
              
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