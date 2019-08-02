using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gps : MonoBehaviour {

    public static gps Instance { set; get; }
    public float latitude;
    public float longitude;
    public Text mesg;
    
    private void Start()
    {
        Debug.Log("Private void start() başlatıldı");
        mesg.text = "Private void start() başlatıldı";
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationServices());
    }

    private IEnumerator StartLocationServices()
    {
        
        yield return new WaitForSeconds(10);
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Konum Bilgisi Açılamadı.");
            mesg.text = "Konum Bilgisi Açılamadı.";
            yield break;
        }
        Input.location.Start(1,0);
        int maxwait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxwait > 0) 
        { yield return new WaitForSeconds(1);
            maxwait--;
        }
        if (maxwait<=0)
        {
            Debug.Log("Süre bitti.Tekrar başlatın");
            mesg.text = "Süre bitti.Tekrar başlatın.";
            yield break;
        }
        if (Input.location.status==LocationServiceStatus.Failed)
        {
            Debug.Log("Konum bilgisi alınamadı");
            mesg.text = "Konum bilgisi alınamadı.";
            yield break;
        }
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        
        mesg.text = "";
    }
}
