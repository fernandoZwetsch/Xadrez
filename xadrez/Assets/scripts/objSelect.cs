using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objSelect : MonoBehaviour {

    public int x;
    public int y;
    public int id;

    public static RaycastHit ray;
    

    //primeiro click selecao segundo posicao
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }
    void OnMouseDown()
    {

       

        if (id > 0)
        {
            if (Physics.Raycast(this.gameObject.transform.position, -Vector3.up, out ray))
            {
                if (ray.collider.gameObject)
                {
                    x = ray.collider.gameObject.GetComponent<objSelect>().x;
                    y = ray.collider.gameObject.GetComponent<objSelect>().y;
                }
                
            }
        }
        else
        {
            if (Physics.Raycast(this.gameObject.transform.position, Vector3.up, out ray))
            {
                if (ray.collider.tag == "Player")
                {
                    Debug.Log("Player");
                    
                }


                
            }
        }
        //selecionar pesa
        Movimentacao.objSelect = gameObject;
        Movimentacao.posXClick = x;
        Movimentacao.posYClick = y;
        Movimentacao.idClick = id;
 


    }
    public bool MataPeca(GameObject z)
    {
        //Movimentacao.mapPos[x].row[y]
        
        if (Physics.Raycast(z.transform.position, Vector3.up, out ray))
        {
            if (ray.collider.gameObject)
            {
                Destroy(ray.collider.gameObject);      
            }
            
        }
        
        return true;
    }
}
