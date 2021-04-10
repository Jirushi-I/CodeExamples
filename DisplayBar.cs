using DG.Tweening;
using UnityEngine;

public class DisplayBar : MonoBehaviour
 {

     public void Display(float length)
     {
         transform.DOScaleX(length, 0.2f);
     }
 }