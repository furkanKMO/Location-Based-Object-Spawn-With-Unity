using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pusula : MonoBehaviour {

    //gyro
    private Gyroscope gyro;
    private GameObject camertaContainer;
    private Quaternion rotation;
    //cam
   private WebCamTexture cam;
    public RawImage background;
    public AspectRatioFitter fit;

    private bool arready = false;

    private void Start()
    {//servis kontrolü
        //gyro
        if (!SystemInfo.supportsGyroscope)
        {
            Debug.Log("Gyroskop desteklenmiyor");
            return;
        }
        
        for (int i = 0; i < WebCamTexture.devices.Length; i++)
        {
            if (!WebCamTexture.devices[i].isFrontFacing)
            {
                cam = new WebCamTexture(WebCamTexture.devices[i].name, Screen.width, Screen.height);
                break;
            }
        }
        //kamera yoksa çık
        if (cam == null)
        {
            Debug.Log("kamera bulunamadı");
            return;
        }
        //Servisler destekleniyorsa
        camertaContainer = new GameObject("Camera Container");
        camertaContainer.transform.position = transform.position;
        transform.SetParent(camertaContainer.transform);

        gyro = Input.gyro;
        gyro.enabled = true;
        camertaContainer.transform.rotation = Quaternion.Euler(90f, 0, 0);
        rotation = new Quaternion(0, 0, 1, 0);
        //cam.Play();
        //background.texture = cam;
        arready = true;
    }

    private void Update()
    {
        if (arready)
        {//camera güncel
            float ratio = (float)cam.width / (float)cam.height;
            fit.aspectRatio = ratio;
            float scaleY = cam.videoVerticallyMirrored ? -1.0f : 1.0f;
            background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

            int orient = -cam.videoRotationAngle;
            background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
            //gyro güncel
            transform.localRotation = gyro.attitude * rotation;
        }
    }
    
}
