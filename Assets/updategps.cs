using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class updategps : MonoBehaviour {

    public Text coordin;
    public Text mgs;
    public GameObject referans;

    public Camera FirstPersonCamera;
    public float xx = 40.9143062f;
    public float yy = 1f;
    public float zz = 38.3228113f;
    public GameObject AndyPointPrefab;
    private const float k_ModelRotation = 90.0f;
    public double alat;
    public double blon;
    public int say = 1;
    //matematiksel
    private double refex;
    private double refez;
    private double kulx;
    private double kulz;
    private double hedx = 40.9120;
    private double hedz = 38.3385;
   // private double hedx = 40.9903;
   // private double hedz =29.0205;
   
    private void Update()
    {
       new WaitForSeconds(2);
        gps.Instance.latitude = Input.location.lastData.latitude;
        gps.Instance.longitude = Input.location.lastData.longitude;
        coordin.text = "Lat: " + gps.Instance.latitude.ToString() + "Long: " + gps.Instance.longitude.ToString();
        //-----------------------
        //alat = int.Parse(gps.Instance.latitude.ToString());
        //blon = int.Parse(gps.Instance.longitude.ToString());
       alat = gps.Instance.latitude;
        blon = gps.Instance.longitude;
        kulx = alat;
        kulz = blon;
        refex = alat - 0.300000;
        refez = blon;


        Debug.Log(alat.ToString());
        Debug.Log(blon.ToString());
        GameObject prefab;
        prefab = AndyPointPrefab;
        mgs.text = "lat =" + alat.ToString() + " ----long = " + blon.ToString();
        // spawn karakter 1
       //kuzeye göre döndür transform.rotation = Quaternion.Euler(0, -Input.compass.magneticHeading, 0);
       //quaternion.identity
        //if (alat > 40.9143082 & alat <
        //    40.9147042 & blon > 38.3224133 & blon < 38.3229083 & say == 1)
        //{
        //    say++;
        //    var andyObject = Instantiate(prefab, new Vector3(xx, yy, zz), Quaternion.Euler(0, -Input.compass.magneticHeading, 0)) as GameObject;
        //    andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);
        //    coordin.text = "İf başarılı " + alat.ToString() + "  -  " + blon.ToString() + " Lat: " + gps.Instance.latitude.ToString() + "Long: " + gps.Instance.longitude.ToString();
        //    mgs.text = "monster spawned";
        //}
        //else {
        //    //karakter 1 kaldır
        //    Destroy(AndyPointPrefab);
        //    mgs.text = "monster removed";
        //}
        //matematiksel-------------------
        //-------hedefi kodlama
        //c^2=a^2+b^2-2ab.cosy
        //uzunluk hesapla
        //kul-ref=a ref-hed=b reff-kul=c
        //double theta = kulx - refex;
        //double dist = Math.Sin(kulx * Math.PI / 180.0) * Math.Sin(refex * Math.PI / 180.0) + Math.Cos(kulz * Math.PI / 180.0) * Math.Cos(refez * Math.PI / 180.0) * Math.Cos(theta * Math.PI / 180.0);
        //dist = Math.Acos(dist);
        //dist = dist * 60 * 1.1515;
        //a = dist * 1.609344;
        //msg1.text = "kul-ref" + Convert.ToInt64(a);
        ////------------
        //double theta2 = refex - hedx;
        //double dist2 = Math.Sin(refex * Math.PI / 180.0) * Math.Sin(hedx * Math.PI / 180.0) + Math.Cos(refez * Math.PI / 180.0) * Math.Cos(hedz * Math.PI / 180.0) * Math.Cos(theta2 * Math.PI / 180.0);
        //dist2 = Math.Acos(dist2);
        //dist2 = dist2 * 60 * 1.1515;
        //b = dist2 * 1.609344;
        //msg2.text = "ref-hed" + Convert.ToInt64(b);
        ////---------------
        //double theta3 = kulx - hedx;
        //double dist3 = Math.Sin(kulx * Math.PI / 180.0) * Math.Sin(hedx * Math.PI / 180.0) + Math.Cos(kulz * Math.PI / 180.0) * Math.Cos(hedz * Math.PI / 180.0) * Math.Cos(theta3 * Math.PI / 180.0);
        //dist3 = Math.Acos(dist3);
        //dist3 = dist3 * 60 * 1.1515;
        //c = dist3 * 1.609344;
        //msg3.text = "kul-hed" + Convert.ToInt64(c);
        ////-----------------açı bulma
        //akare = a * a;
        //akare2 = akare - 0.000030;
        //akare = akare + 0.000030;

        //for (double i = 0; i > -1; i++)
        //{
        //    if (akare > (b * b) + (c * c) - 2 * a * b * Math.Cos(i) || akare2 < (b * b) + (c * c) - 2 * a * b * Math.Cos(i))
        //    {
        //        ac = i;
        //        msg4.text = "açı" + Convert.ToInt64(ac);
        //        break;
        //    }
        //}
        //-----------------

        //    var degre = Math.PI / 180;
        //        var earthRadiusKm = 6371;
        //        var dLat = degre * (kulx - hedx);
        //        var dLon = degre * (kulz - hedz);

        //        kulx = degre * (kulx);
        //        hedx = degre * (hedx);

        //        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
        //                Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(kulx) * Math.Cos(hedx);
        //        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        //        ac=earthRadiusKm * c;
        //    msg3.text = "kul-hed" + Convert.ToInt64(ac);
        //-----------------------------
        
      c= distance(kulx,kulz,hedx,hedz,'K');
       a= distance(kulx, kulz, refex, refez, 'K');
        b=distance(refex, refez, hedx, hedz, 'K');
        msg3.text = "kul-hed = " + Convert.ToInt64(c);
        msg2.text = "ref-hed = " + Convert.ToInt64(b);
        msg1.text = "kul-ref = " + Convert.ToInt64(a);
        akare = a * a;
        akare2 = akare - 0.0020;
        akare = akare + 0.0020;
        for (double i = 0; i > 360; i=i+0.0020)
        {
            if (akare > (b * b) + (c * c) - 2 * c * b * Math.Cos(i) && akare2 < (b * b) + (c * c) - 2 * c * b * Math.Cos(i))
            {
                ac = i;
                msg4.text = "açı" + Convert.ToInt64(ac);
               // var andyObject = Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;                
               // andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);
                break;
            }
        }
        //--------------------------
        
           deg1= Vector3.Distance(Camera.main.transform.position,referans.transform.position);
        unirefx = referans.transform.position.x;
        unirefz = referans.transform.position.z;
        refdeg1 = (float)unirefx;
        refdeg2 = (float)unirefz;
        //-------------------------------------------------sorun
        StartCoroutine(hes(AndyPointPrefab, prefab));
       var andyObject = Instantiate(prefab, omega, Quaternion.identity) as GameObject;
        andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);
        //if (hedx < hedz)
        //{
        //    say1 = 0;
        //    for (double i = 0; i > -1; i = i + 0.0100)
        //    {
        //        alfa = (float)i;
        //        for (double y = 0; y > -1; y = y + 0.0100)
        //        {
        //            beta = (float)y;
        //            hesap1 = distance(y, i, 0f, 0f, 'K');
        //            hesap2 = distance(unirefx, unirefz, y, i, 'K');

        //            //var andyObject = Instantiate(prefab, new Vector3(alfa, 0f, beta), Quaternion.identity) as GameObject;
        //            //andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);
        //            //deg2 = Vector3.Distance(referans.transform.position, andyObject.transform.position);
        //            //andyObject.SetActive(false);

        //            if (hesap1 < (c + 0.0050) && hesap1 > (c - 0.0050))
        //            {
        //                if (((deg1 * deg1) + 0.0050) > (hesap1 * hesap1) + (hesap2 * hesap2) - 2 * hesap1 * hesap1 * Math.Cos(ac) && ((deg1 * deg1) - 0.0050) < (hesap1 * hesap1) + (hesap2 * hesap2) - 2 * hesap1 * hesap1 * Math.Cos(ac))
        //                {
        //                    var andyObject = Instantiate(prefab, new Vector3(alfa, 0f, beta), Quaternion.identity) as GameObject;
        //                    andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);
        //                    say1 = 1;
        //                }

        //                unhedx = i;
        //                unhedz = y;
        //                break;
        //            }
        //            if (y > 90)
        //            {
        //                break;

        //            }
        //        }
        //        if (say1 == 1)
        //        {
        //            break;
        //        }
        //        if (i > 180)
        //        {
        //            break;
        //        }

        //    }
        //}

    }
    private IEnumerator hes(GameObject andyObject,GameObject prefab)
    {
        if (hedx > hedz)
        {
            msgmes.text = "canavara uzaklı = " + hesap1;

            say1 = 0;
            for (double i = 0; i <90; i = i + 0.0100)
            {
                alfa = (float)i;
                for (double y = 0; y <180; y = y + 0.0100)
                {
                    beta = (float)y;
                    omega = new Vector3(alfa, 0f, beta);
                    hesap1 = distance(i, y, 0, 0, 'K');
                    hesap2 = distance(unirefx, unirefz, i, y, 'K');
                    msgmes.text = "kullanıcı-hedef mesa= " + hesap1;
                    msgmes1.text = "referans-hedef mesa= " + hesap2;
                    //say1++;

                    //if (say1 > 20)
                    //{
                    //    say1 = 0;
                    //    break;
                    //}


                    andyObject = Instantiate(prefab, new Vector3(alfa, 0f, beta), Quaternion.identity) as GameObject;
                    andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);
                    deg2 = Vector3.Distance(referans.transform.position, andyObject.transform.position);
                    andyObject.SetActive(false);

                    if (hesap1 < (c + 0.0150) && hesap1 > (c - 0.0150))
                    {
                        if (((deg1 * deg1) + 0.0150) > (hesap1 * hesap1) + (hesap2 * hesap2) - 2 * hesap1 * hesap1 * Math.Cos(ac) && ((deg1 * deg1) - 0.0150) < (hesap1 * hesap1) + (hesap2 * hesap2) - 2 * hesap1 * hesap1 * Math.Cos(ac))
                        {
                            andyObject = Instantiate(prefab, new Vector3(alfa, 0f, beta), Quaternion.identity) as GameObject;
                            andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);
                            msgmes.text = "canavar doğdu";
                            say1 = 1;
                            unhedx = y;
                            unhedz = i;

                            break;
                        }


                    }
                    if (y > 90)
                    {
                        break;

                    }
                   
                    yield return new WaitForSeconds(5);
                   
                }
                
                if (i > 180)
                {
                    break;
                }


            }
        }
    }
    private double distance(double lat1, double lon1, double lat2, double lon2, char unit)
    {
        if ((lat1 == lat2) && (lon1 == lon2))
        {
            return 0;
        }
        else
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
               // dist = dist * 1000;
                msg3.text = Convert.ToString(dist);
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }
    }

    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    //::  This function converts decimal degrees to radians             :::
    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    private double deg2rad(double deg)
    {
        return (deg * Math.PI / 180.0);
    }

    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    //::  This function converts radians to decimal degrees             :::
    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    private double rad2deg(double rad)
    {
        return (rad / Math.PI * 180.0);
    }
    private float alfa;
    private float beta;
    private double a;
    private double akare;
    private double akare2;
    private double b;
    private double c;
    private double ac;
    private double ac2;
    public Text msg1;
    public Text msg2;
    public Text msg3;
    public Text msg4;
    public Text msgmes,msgmes1;
    private float deg1,deg2,refdeg1,refdeg2;
    private double hesap1, hesap2, hesap3, hesap4, hesap5, hesap6,unhedx,unhedz, unirefx, unirefz;
    private int say1, say2,say3,say4,say5;
    private Vector3 omega;
}
