using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuadTest : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    float offset;
    public float speed;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
         
    }
    void OnMouseDrag()
    {
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

      //  transform.position = objPos;
        meshRenderer.material.mainTextureOffset = new Vector2((float)-objPos.x /100, 0);
        //   offset += speed;
    }

    private void Update()
    {
      //  meshRenderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
