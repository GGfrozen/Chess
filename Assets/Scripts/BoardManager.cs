using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
   [SerializeField] private float tileSize = 1f;
   [SerializeField] private float tileOffset = 0.5f;
   [SerializeField] private int tileCount = 8;
   [SerializeField] private LayerMask layerMask;
   
   

   private int selection = -1;

   private void Update()
   {
      DrawChessboard();
   }

   

   private void UpdateSelection()
   {
       if (!Camera.main)
       {
           return;
       }

       RaycastHit hit;
       if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50f, layerMask))
       {
           var selectionX = (int) hit.point.x;
           var selectionY = (int) hit.point.z;
       }
       

   }

   private void DrawChessboard()
   {
       var widthLine = Vector3.right * tileCount;
       var heightLine = Vector3.forward * tileCount;

       for (int i = 0; i <= tileCount; i++)
       {
           var start = Vector3.forward * i;
           var start2 = Vector3.right * i;
           Debug.DrawLine(start, start + widthLine); 
           Debug.DrawLine(start2,start2 +heightLine);
       }
   }
}
