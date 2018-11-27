using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movimentacao : MonoBehaviour {
    
    public int xx;
    public int yy;
    public int Id;
    public GameObject select;
    public GameObject setaPosition;
    public Text[] pontos;
    public int Pontosp1;
    public int Pontosp2;

    public int VezJogador;

    public GameObject[] jogadores;

    public GameObject pai;
    
    public static GameObject objSelect;
    public static int posXClick;
    public static int posYClick;
    public static int idClick;
    


    private Vector3 x,y;
    private int contRows=0;
    
    [System.Serializable]
    public struct rowDate
    {
        public GameObject[] row;
    }
    public  rowDate[] mapPos = new rowDate[8];


    [System.Serializable]
    public struct matrizbinaria
    {
        public int[] coluna;
    }
    public matrizbinaria[] mapBinario = new matrizbinaria[8];



    float delay=0;
    int tempx;
    int tempy;
    int tempId;
    GameObject tempObg;

    objSelect scriptSelect = new objSelect();

    // Use this for initialization
    void Start () {
        Pontosp1 = 0;
        Pontosp2 = 0;
        VezJogador = 1;
        setaPosition.GetComponent<Light>().enabled = false;
        for (int i = 0; i < 8; i++)
        {
            for (int y = 0; y < 8; y++)
            {
                mapPos[i].row[y] = pai.gameObject.transform.GetChild(contRows).gameObject;
                contRows++;
                //mapPos[i].row[y].GetComponent<BoxCollider>().enabled=false;
                mapPos[i].row[y].GetComponent<objSelect>().x = i;//dar a position na matriz
                mapPos[i].row[y].GetComponent<objSelect>().y = y;

            }
            
        }

        PrepandoMap();


 
        
        
    }
	
	// Update is called once per frame
	void Update () {
        pontos[0].text = Pontosp1.ToString();
        pontos[1].text = Pontosp2.ToString();
        pontos[2].text = "Jogador : "+VezJogador.ToString(); 
        if (Input.GetMouseButtonDown(0))
        {
            xx = posXClick;
            yy = posYClick;
            Id = idClick;
            select = objSelect;

        }

        if (Id > 0)
        {
            //Debug.Log("PEÇA SELECIONADA");
            //CHAMA A MOVIMENTAÇÃO
            ChamaAMovimentacao();

        }
        else
        {
            if (Id == 0)
            {
                Debug.Log("chamou");
                Movimenta();
                Id = -5;
            }
        }

        
    }

    void PrepandoMap()
    {
       for (int i = 0; i < 8; i++)
        {
            
            x = new Vector3(mapPos[1].row[i].transform.position.x, -0.75f, mapPos[1].row[i].transform.position.z);
            y = new Vector3(mapPos[0].row[i].transform.position.x, -0.75f, mapPos[0].row[i].transform.position.z);
            
            Instantiate(jogadores[0], x, Quaternion.identity);//peao
            mapBinario[1].coluna[i] = 1;

            switch (i)
            {
                case 0:
                    Instantiate(jogadores[5], y, Quaternion.identity);
                    mapBinario[0].coluna[i] = 6;
                    break;
                case 1:
                    Instantiate(jogadores[1], y, Quaternion.identity);
                    mapBinario[0].coluna[i] = 5;
                    break;
                case 2:
                    Instantiate(jogadores[4], y, Quaternion.identity);
                    mapBinario[0].coluna[i] = 4;
                    break;
                case 3:
                    Instantiate(jogadores[2], y, Quaternion.identity);
                    mapBinario[0].coluna[i] = 3;
                    break;
                case 4:
                    Instantiate(jogadores[3], y, Quaternion.identity);
                    mapBinario[0].coluna[i] = 2;
                    break;
                case 5:
                    Instantiate(jogadores[4], y, Quaternion.identity);
                    mapBinario[0].coluna[i] = 4;
                    break;
                case 6:
                    Instantiate(jogadores[1], y, Quaternion.identity);
                    mapBinario[0].coluna[i] = 5;
                    break;
                case 7:
                    Instantiate(jogadores[5], y, Quaternion.identity);
                    mapBinario[0].coluna[i] = 6;
                    break;

            }
        }
       //inimigo
        for (int i = 0; i < 8; i++)
        {

            x = new Vector3(mapPos[6].row[i].transform.position.x, -0.75f, mapPos[6].row[i].transform.position.z);
            y = new Vector3(mapPos[7].row[i].transform.position.x, -0.75f, mapPos[7].row[i].transform.position.z);

            Instantiate(jogadores[6], x, Quaternion.identity);//peao
            mapBinario[6].coluna[i] = 11;

            switch (i)
            {
                case 0:
                    Instantiate(jogadores[11], y, Quaternion.identity);
                    mapBinario[7].coluna[i] = 16;
                    break;
                case 1:
                    Instantiate(jogadores[7], y, Quaternion.Euler(0, 180, 0));
                    mapBinario[7].coluna[i] = 15;
                    break;
                case 2:
                    Instantiate(jogadores[10], y, Quaternion.identity);
                    mapBinario[7].coluna[i] = 14;
                    break;
                case 3:
                    Instantiate(jogadores[8], y, Quaternion.identity);
                    mapBinario[7].coluna[i] = 13;
                    break;
                case 4:
                    Instantiate(jogadores[9], y, Quaternion.identity);
                    mapBinario[7].coluna[i] = 12;
                    break;
                case 5:
                    Instantiate(jogadores[10], y, Quaternion.identity);
                    mapBinario[7].coluna[i] = 14;
                    break;
                case 6:
                    Instantiate(jogadores[7], y,  Quaternion.Euler(0,180,0));
                    mapBinario[7].coluna[i] = 15;
                    break;
                case 7:
                    Instantiate(jogadores[11], y, Quaternion.identity);
                    mapBinario[7].coluna[i] = 16;
                    break;

            }
        }

    }
    void ChamaAMovimentacao()
    {
        if (VezJogador == 1)
        {

            switch (Id)
            {
                case 1://peao
                    CAM();
                    break;
                case 2://rainha
                    CAM();
                    break;
                case 3://rei
                    CAM();
                    break;
                case 4://bispo
                    CAM();
                    break;
                case 5://cavalo
                    CAM();
                    break;
                case 6://torre
                    CAM();
                    break;

            }


        }
        if (VezJogador == 2)
        {

            switch (Id)
            {
                case 11://peao
                    CAM();
                    break;
                case 12://rainha
                    CAM();
                    break;
                case 13://rei
                    CAM();
                    break;
                case 14://bispo
                    CAM();
                    break;
                case 15://cavalo
                    CAM();
                    break;
                case 16://torre
                    CAM();
                    break;

            }

        }
    }
    void Movimenta() {
        if (VezJogador == 1)
        {
            
            switch (tempId)
            {
                case 1://peao
                    Peao(1);
                    break;
                case 2://rainha
                    Rainha(1);
                    break;
                case 3://rei
                    Rei(1);
                    break;
                case 4://bispo
                    Bispo(1);
                    break;
                case 5://cavalo
                    Cavalo(1);
                    break;
                case 6://torre
                    Torre(1);
                    break;

            }

        }
        if (VezJogador == 2)
        {
            
            switch (tempId)
            {
                case 11://peao
                    Peao(2);
                    break;
                case 12://rainha
                    Rainha(2);
                    break;
                case 13://rei
                    Rei(2);
                    break;
                case 14://bispo
                    Bispo(2);
                    break;
                case 15://cavalo
                    Cavalo(2);
                    break;
                case 16://torre
                    Torre(2);
                    break;

            }
            

        }
    }

    void /*ok*/Peao(int j)
    {
        if (j == 1) {//jogador 1
            if (posXClick == tempx + 1 && posYClick == tempy && mapBinario[posXClick].coluna[posYClick] == 0)
            {
				Mover (1);
            }
            //verifica possivel ataq n as diagonais
            if (posXClick == tempx + 1 && posYClick == tempy + 1 && mapBinario[posXClick].coluna[posYClick] > 10)//esquerda
            {
                Pontuacao(1);
            }
            if (posXClick == tempx + 1 && posYClick == tempy - 1 && mapBinario[posXClick].coluna[posYClick] >10)//direita
            {
                Pontuacao(1);

            }
        }
        else//jogador2 
        {
            if (posXClick == tempx - 1 && posYClick == tempy && mapBinario[posXClick].coluna[posYClick] == 0)
            {
                Mover(2);
            }
            //verifica possivel ataq n as diagonais
            if (posXClick == tempx - 1 && posYClick == tempy + 1 && mapBinario[posXClick].coluna[posYClick] != 0 && mapBinario[posXClick].coluna[posYClick] < 10)//esquerda
            {
                Pontuacao(2);
            }
            if (posXClick == tempx - 1 && posYClick == tempy - 1 && mapBinario[posXClick].coluna[posYClick] != 0 && mapBinario[posXClick].coluna[posYClick] < 10)//direita
            {
                Pontuacao(2);

            }
        }
    }
    void /*ok*/Torre(int j)
    {

        if (j == 1) {
            int maxdir = 0, maxfrente = 0, maxesq = 0, maxtras = 0;
            int badir = 0, bafrente = 0, baesq = 0, batras = 0;
            for (int x = 0; x < 8; x++){
                for (int y = 0; y < 8; y++){
                    if(x > tempx && y == tempy)//para frente
                    {
                        if(mapBinario[x].coluna[tempy] == 0)
                        {
                            if (bafrente == 0)
                            {
                                maxfrente++;
                            }
                            
                        }
                        else
                        {
                            bafrente = 1;
                        }
                    }
                    if(x == tempx)//dir esq
                    {
                        if(y < tempy)//dir
                        {
                            if (mapBinario[x].coluna[(tempy-1)-y] == 0)
                            {
                                if (badir == 0) {
                                    maxdir++;
                                }
                            }
                            else
                            {
                                badir = 1;
                            }
                        }
                        else if(y > tempy) // esq
                        {
                            if (mapBinario[x].coluna[y] == 0)
                            {
                                if (baesq == 0)
                                {
                                    maxesq++;
                                }
                            }
                            else
                            {
                                baesq = 1;
                            }
                        }
                    }
                    if (x< tempx && y == tempy)//tras
                    {
                        if (mapBinario[(tempx-1)-x].coluna[tempy] == 0)
                        {
                            if (batras == 0)
                            {
                                maxtras++;
                            }
                        }
                        else
                        {
                            batras = 1;
                        }
                    }
                }
            }
            
			if (posXClick > tempx && (posXClick-tempx) <= maxfrente && posYClick == tempy) //frente
            {
				Debug.Log("frente");
				Mover (1);
              
            }
			if (posYClick < tempy && posYClick >=(tempy- maxdir)&& posXClick == tempx)//direita
			{ 
				Debug.Log("direita");
				Mover (1);

			}
			if (posYClick> tempy && (posYClick-tempy) <= maxesq && posXClick == tempx)//esquerda
            {
				Debug.Log("esquerda");
				Mover (1);
			}
			if (posXClick < tempx && posXClick >= (tempx -maxtras) && posYClick == tempy)//tras
            {
				Debug.Log("trasS");
				Mover (1);
            }
            //ataq
            if(mapBinario[posXClick].coluna[posYClick] > 10 && posYClick == tempy)
            {
                if (posXClick == tempx - maxtras - 1)//tras
                {
                    Pontuacao(1);
                }
                if (posXClick == tempx + maxfrente + 1) //frente
                {

                    Pontuacao(1);

                }
            }
            if (mapBinario[posXClick].coluna[posYClick] > 10 && posXClick == tempx)
            {
                if (posYClick == tempy - maxdir - 1 )//direita
                {
                    Pontuacao(1);
                }
                if (posYClick == tempy + maxesq + 1 )//esquerda
                {

                    Pontuacao(1);
                }
            }
        }
        else
        {
            int maxdir = 0, maxfrente = 0, maxesq = 0, maxtras = 0;
            int badir = 0, bafrente = 0, baesq = 0, batras = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (x > tempx && y == tempy)//para frente
                    {
                        if (mapBinario[x].coluna[tempy] == 0)
                        {
                            if (bafrente == 0)
                            {
                                maxfrente++;
                            }

                        }
                        else
                        {
                            bafrente = 1;
                        }
                    }
                    if (x == tempx)//dir esq
                    {
                        if (y < tempy)//dir
                        {
                            if (mapBinario[x].coluna[(tempy - 1) - y] == 0)
                            {
                                if (badir == 0)
                                {
                                    maxdir++;
                                }
                            }
                            else
                            {
                                badir = 1;
                            }
                        }
                        else if (y > tempy) // esq
                        {
                            if (mapBinario[x].coluna[y] == 0)
                            {
                                if (baesq == 0)
                                {
                                    maxesq++;
                                }
                            }
                            else
                            {
                                baesq = 1;
                            }
                        }
                    }
                    if (x < tempx && y == tempy)//tras
                    {
                        if (mapBinario[(tempx - 1) - x].coluna[tempy] == 0)
                        {
                            if (batras == 0)
                            {
                                maxtras++;
                            }
                        }
                        else
                        {
                            batras = 1;
                        }
                    }
                }
            }

            if (posXClick > tempx && (posXClick - tempx) <= maxfrente && posYClick == tempy) //frente
            {
                Debug.Log("frente");
                Mover(2);

            }
            if (posYClick < tempy && posYClick >= (tempy - maxdir) && posXClick == tempx)//direita
            {
                Debug.Log("direita");
                Mover(2);

            }
            if (posYClick > tempy && (posYClick - tempy) <= maxesq && posXClick == tempx)//esquerda
            {
                Debug.Log("esquerda");
                Mover(2);
            }
            if (posXClick < tempx && posXClick >= (tempx - maxtras) && posYClick == tempy)//tras
            {
                Debug.Log("trasS");
                Mover(2);
            }
            //ataq
            if (mapBinario[posXClick].coluna[posYClick] < 10 && mapBinario[posXClick].coluna[posYClick] > 0  && posYClick == tempy)
            {
                if (posXClick == tempx - maxtras - 1)//tras
                {
                    Pontuacao(2);
                }
                if (posXClick == tempx + maxfrente + 1) //frente
                {
                    Pontuacao(2);
                }
            }
            if (mapBinario[posXClick].coluna[posYClick] < 10 && mapBinario[posXClick].coluna[posYClick] > 0 && posXClick == tempx)
            {
                if (posYClick == tempy - maxdir - 1)//direita
                {
                    Pontuacao(2);
                }
                if (posYClick == tempy + maxesq + 1)//esquerda
                {
                    Pontuacao(2);
                }
            }
        }
    }
    void /*ok*/Cavalo(int j)
    {
        if (j == 1)
        {
            
            //casa cima esquerda
            if (posXClick == tempx+2 && posYClick == tempy+1 )
            {
                
                if (mapBinario[tempx + 2].coluna[tempy + 1] == 0)
                {
                    Mover(1);
                }
                else if (mapBinario[tempx + 2].coluna[tempy + 1] > 10)
                {
                    Pontuacao(1);
                }
            }
            if (posXClick == tempx + 1 && posYClick == tempy + 2 )
            {
                if (mapBinario[tempx + 1].coluna[tempy + 2] == 0)
                {
                    Mover(1);
                }
                else if (mapBinario[tempx + 1].coluna[tempy + 2] > 10)
                {
                    Pontuacao(1);
                }
            }
            //baixo baixo direita
            if (posXClick == tempx - 2 && posYClick == tempy - 1)
            {
                if (mapBinario[tempx - 2].coluna[tempy - 1] == 0)
                {
                    Mover(1);
                }
                else if (mapBinario[tempx - 2].coluna[tempy - 1] > 10)
                {
                    Pontuacao(1);
                }
            }
            if (posXClick == tempx - 1 && posYClick == tempy - 2)
            {
                if (mapBinario[tempx - 1].coluna[tempy - 2] == 0)
                {
                    Mover(1);
                }
                else if (mapBinario[tempx - 1].coluna[tempy - 2] > 10)
                {
                    Pontuacao(1);
                }
            }
            //casa cima direita
            if (posXClick == tempx -1 && posYClick == tempy +1)
            {
                if (mapBinario[tempx - 1].coluna[tempy + 2] == 0)
                {
                    Mover(1);
                }
                else if (mapBinario[tempx - 1].coluna[tempy + 2] > 10)
                {
                    Pontuacao(1);
                }
            }
            if (posXClick == tempx-2 && posYClick == tempy + 1 )
            {
                if (mapBinario[tempx - 2].coluna[tempy + 1] == 0)
                {
                    Mover(1);
                }
                else if (mapBinario[tempx - 2].coluna[tempy + 1] > 10)
                {
                    Pontuacao(1);
                }
            }
            //baixo baixo esquerda
            if (posXClick == tempx + 2 && posYClick == tempy - 1)
            {
                if (mapBinario[tempx + 2].coluna[tempy - 1] == 0)
                {
                    Mover(1);
                }
                else if (mapBinario[tempx + 2].coluna[tempy - 1] > 10)
                {
                    Pontuacao(1);
                }
            }
            if (posXClick == tempx +1 && posYClick == tempy -2 )
            {
                if (mapBinario[tempx + 1].coluna[tempy - 2] == 0)
                {
                    Mover(1);
                }
                else if (mapBinario[tempx + 1].coluna[tempy - 2] >10)
                {
                    Pontuacao(1);
                }
            }

        }
        else
        {
            //casa cima esquerda
            if (posXClick == tempx + 2 && posYClick == tempy + 1)
            {

                if (mapBinario[tempx + 2].coluna[tempy + 1] == 0)
                {
                    Mover(2);
                }
                else if (mapBinario[tempx + 2].coluna[tempy + 1] < 10 && mapBinario[tempx + 2].coluna[tempy + 1] > 0)
                {
                    Pontuacao(2);
                }
            }
            if (posXClick == tempx + 1 && posYClick == tempy + 2)
            {
                if (mapBinario[tempx + 1].coluna[tempy + 2] == 0)
                {
                    Mover(2);
                }
                else if (mapBinario[tempx + 1].coluna[tempy + 2] < 10 && mapBinario[tempx + 1].coluna[tempy + 2] > 0)
                {
                    Pontuacao(2);
                }
            }
            //baixo baixo direita
            if (posXClick == tempx - 2 && posYClick == tempy - 1)
            {
                if (mapBinario[tempx - 2].coluna[tempy - 1] == 0)
                {
                    Mover(2);
                }
                else if (mapBinario[tempx - 2].coluna[tempy - 1] < 10 && mapBinario[tempx - 2].coluna[tempy - 1] > 0)
                {
                    Pontuacao(2);
                }
            }
            if (posXClick == tempx - 1 && posYClick == tempy - 2)
            {
                if (mapBinario[tempx - 1].coluna[tempy - 2] == 0)
                {
                    Mover(2);
                }
                else if (mapBinario[tempx - 1].coluna[tempy - 2] < 10 && mapBinario[tempx - 1].coluna[tempy - 2] > 0)
                {
                    Pontuacao(2);
                }
            }
            //casa cima direita
            if (posXClick == tempx - 1 && posYClick == tempy + 1)
            {
                if (mapBinario[tempx - 1].coluna[tempy + 2] == 0)
                {
                    Mover(2);
                }
                else if (mapBinario[tempx - 1].coluna[tempy + 2] < 10 && mapBinario[tempx - 1].coluna[tempy + 2] > 0)
                {
                    Pontuacao(2);
                }
            }
            if (posXClick == tempx - 2 && posYClick == tempy + 1)
            {
                if (mapBinario[tempx - 2].coluna[tempy + 1] == 0)
                {
                    Mover(2);
                }
                else if (mapBinario[tempx - 2].coluna[tempy + 1] < 10 && mapBinario[tempx - 2].coluna[tempy + 1] > 0)
                {
                    Pontuacao(2);
                }
            }
            //baixo baixo esquerda
            if (posXClick == tempx + 2 && posYClick == tempy - 1)
            {
                if (mapBinario[tempx + 2].coluna[tempy - 1] == 0)
                {
                    Mover(2);
                }
                else if (mapBinario[tempx + 2].coluna[tempy - 1] < 10 && mapBinario[tempx + 2].coluna[tempy - 1] > 0)
                {
                    Pontuacao(2);
                }
            }
            if (posXClick == tempx + 1 && posYClick == tempy - 2)
            {
                if (mapBinario[tempx + 1].coluna[tempy - 2] == 0)
                {
                    Mover(2);
                }
                else if (mapBinario[tempx + 1].coluna[tempy - 2] < 10 && mapBinario[tempx + 1].coluna[tempy - 2] > 0)
                {
                    Pontuacao(2);
                }
            }
        }
    }
    void /*ok*/Bispo(int j)
    { 
        if(j== 1)
        {
            int maxDdirC = 0, maxDdirB = 0, maxDesqC = 0, maxDesqB = 0;
            int DdirC = 0, DdirB = 0, DesqC = 0, DesqB = 0;
            int cont = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {

                    if (x > tempx)
                    {
                        //diagonal secundaria dirC
                        if (tempx + tempy == x + y)
                        {
                            if (mapBinario[x].coluna[y] == 0)
                            {
                                if (DdirC == 0)
                                {
                                    maxDdirC++;
                                }
                            }
                            else
                            {
                                DdirC = 1;
                            }
                        }
                        //diagonal primaria esqC
                        if (Mathf.Abs(tempx - tempy) == Mathf.Abs(x - y))
                        {
                            if (mapBinario[x].coluna[y] == 0)
                            {
                                if (DesqC == 0)
                                {
                                    maxDesqC++;
                                }
                            }
                            else
                            {
                                DesqC = 1;
                            }
                        }

                    }
                   
                        if (x < tempx)
                        {
                            //diagonal secundaria
                            if (tempx + tempy == x + y)
                            {
                                if (mapBinario[y - 1].coluna[x + 1] == 0)
                                {
                                    if (DesqB == 0)
                                    {
                                        maxDesqB++;
                                    }
                                }
                                else
                                {
                                    DesqB = 1;
                                }
                            }
                            //diagonal principal
                            if (Mathf.Abs(tempx - tempy) == Mathf.Abs(x - y))
                            {//
                                cont++;
                                if (mapBinario[Mathf.Abs(tempx - cont)].coluna[Mathf.Abs(tempy - cont)] == 0)
                                {
                                    if (DdirB == 0)
                                    {
                                        maxDdirB++;
                                    }
                                }
                                else
                                {
                                    DdirB = 1;
                                }
                            }
                        }
                    }
                
            }

            if (posXClick > tempx && posYClick < tempy && posXClick <= (tempx + maxDdirC))// para cima e para direita
            {
                if (posXClick + posYClick == tempx + tempy && mapBinario[posXClick].coluna[posYClick] == 0)
                {
                    Debug.Log("D direita Cima");
                    Mover(1);
                }

            }
            if (posXClick > tempx && posYClick > tempy && posXClick <= (tempx + maxDesqC))// para cima e para esquerda
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy) && mapBinario[posXClick].coluna[posYClick] == 0)
                {
                    Debug.Log("D esquerda Cima");
                    Mover(1);
                }

            }
            if (posXClick < tempx && posYClick > tempy && posXClick >= (tempx - maxDesqB))// para baixo e para esquerda
            {
                if (posXClick + posYClick == tempx + tempy && mapBinario[posXClick].coluna[posYClick] == 0)
                {
                    Debug.Log("D esquerda baixo");
                    Mover(1);
                }

            }
            if (posXClick < tempx && posYClick < tempy && posXClick >= (tempx - maxDdirB))// para baixo e para direita
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy) && mapBinario[posXClick].coluna[posYClick] == 0)
                {
                    Debug.Log("D direita baixo");
                    Mover(1);
                }

            }
			//////////////////
			if(mapBinario[posXClick].coluna[posYClick] > 10){
			if (posXClick > tempx && posYClick < tempy && posXClick <= (tempx + maxDdirC+1))// para cima e para direita
            {
                if (posXClick + posYClick == tempx + tempy)
                {
                    Pontuacao(1); 
                }

            }
            if (posXClick > tempx && posYClick > tempy && posXClick <= (tempx + maxDesqC+1))// para cima e para esquerda
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy) )
                {
                   Pontuacao(1); 
                }

            }
            if (posXClick < tempx && posYClick > tempy && posXClick >= (tempx - maxDesqB-1))// para baixo e para esquerda
            {
                if (posXClick + posYClick == tempx + tempy )
                {
                  Pontuacao(1); 
                }

            }
            if (posXClick < tempx && posYClick < tempy && posXClick >= (tempx - maxDdirB-1))// para baixo e para direita
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy) )
                {
                   Pontuacao(1); 
                }

            }
			}
        }
        else
        {
            int maxDdirC = 0, maxDdirB = 0, maxDesqC = 0, maxDesqB = 0;
            int DdirC = 0, DdirB = 0, DesqC = 0, DesqB = 0;
            int cont = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {

                    if (x > tempx)
                    {
                        //diagonal secundaria dirC
                        if (tempx + tempy == x + y)
                        {
                            if (mapBinario[x].coluna[y] == 0)
                            {
                                if (DdirC == 0)
                                {
                                    maxDdirC++;
                                }
                            }
                            else
                            {
                                DdirC = 1;
                            }
                        }
                        //diagonal primaria esqC
                        if (Mathf.Abs(tempx - tempy) == Mathf.Abs(x - y))
                        {
                            if (mapBinario[x].coluna[y] == 0)
                            {
                                if (DesqC == 0)
                                {
                                    maxDesqC++;
                                }
                            }
                            else
                            {
                                DesqC = 1;
                            }
                        }

                    }
                 

                        if (x < tempx)
                        {
                            //diagonal secundaria
                            if (tempx + tempy == x + y)
                            {
                                if (mapBinario[y - 1].coluna[x + 1] == 0)
                                {
                                    if (DesqB == 0)
                                    {
                                        maxDesqB++;
                                    }
                                }
                                else
                                {
                                    DesqB = 1;
                                }
                            }
                            //diagonal principal
                            if (Mathf.Abs(tempx - tempy) == Mathf.Abs(x - y))
                            {//
                                cont++;
                                if (mapBinario[Mathf.Abs(tempx - cont)].coluna[Mathf.Abs(tempy - cont)] == 0)
                                {
                                    if (DdirB == 0)
                                    {
                                        maxDdirB++;
                                    }
                                }
                                else
                                {
                                    DdirB = 1;
                                }
                            }
                        }
                    }
                
            }

            if (posXClick > tempx && posYClick < tempy && posXClick <= (tempx + maxDdirC))// para cima e para direita
            {
                if (posXClick + posYClick == tempx + tempy && mapBinario[posXClick].coluna[posYClick] == 0)
                {
                    Debug.Log("D direita Cima");
                    Mover(2);
                }

            }
            if (posXClick > tempx && posYClick > tempy && posXClick <= (tempx + maxDesqC))// para cima e para esquerda
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy) && mapBinario[posXClick].coluna[posYClick] == 0)
                {
                    Debug.Log("D esquerda Cima");
                    Mover(2);
                }

            }
            if (posXClick < tempx && posYClick > tempy && posXClick >= (tempx - maxDesqB))// para baixo e para esquerda
            {
                if (posXClick + posYClick == tempx + tempy && mapBinario[posXClick].coluna[posYClick] == 0)
                {
                    Debug.Log("D esquerda baixo");
                    Mover(2);
                }

            }
            if (posXClick < tempx && posYClick < tempy && posXClick >= (tempx - maxDdirB))// para baixo e para direita
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy) && mapBinario[posXClick].coluna[posYClick] == 0)
                {
                    Debug.Log("D direita baixo");
                    Mover(2);
                }

            }
			////////////////////////////
			if(mapBinario[posXClick].coluna[posYClick] < 10 && mapBinario[posXClick].coluna[posYClick] > 0 ){
				   if (posXClick > tempx && posYClick < tempy && posXClick <= (tempx + maxDdirC+1))// para cima e para direita
            {
                if (posXClick + posYClick == tempx + tempy )
                {
                     Pontuacao(2); 
                }

            }
            if (posXClick > tempx && posYClick > tempy && posXClick <= (tempx + maxDesqC+1))// para cima e para esquerda
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy) )
                {
                    Pontuacao(2); 
                }

            }
            if (posXClick < tempx && posYClick > tempy && posXClick >= (tempx - maxDesqB-1))// para baixo e para esquerda
            {
                if (posXClick + posYClick == tempx + tempy )
                {
                     Pontuacao(2); 
                }

            }
            if (posXClick < tempx && posYClick < tempy && posXClick >= (tempx - maxDdirB-1))// para baixo e para direita
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy) )
                {
                    Pontuacao(2); 
                }

            }
				
			}
        }
        

    }
    void /*ok*/Rainha(int j)
    {
        if (j == 1)
        {
            int maxdir = 0, maxfrente = 0, maxesq = 0, maxtras = 0;
            int maxDdirC = 0, maxDdirB = 0, maxDesqC = 0, maxDesqB = 0;
            int badir = 0, bafrente = 0, baesq = 0, batras = 0;
            int DdirC= 0, DdirB = 0,DesqC = 0, DesqB = 0;
            int cont=0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    //Diagonal primeira
                    
                    if (x > tempx ) //para frente
                    {
                        //frente
                        if (y == tempy)//somente para frente
                        {
                            if (mapBinario[x].coluna[tempy] == 0)
                            {
                                if (bafrente == 0)
                                {
                                    maxfrente++;
                                }

                            }
                            else
                            {
                                bafrente = 1;
                            }
                        }
                        //diagonal secundaria dirC
                        if (tempx + tempy == x + y)
                        {
                            if (mapBinario[x].coluna[y] == 0)
                            {
                                if (DdirC == 0)
                                {
                                    maxDdirC++;
                                }
                            }
                            else
                            {
                                DdirC = 1;
                            }
                        }
                        //diagonal primaria esqC
                        if (Mathf.Abs(tempx - tempy) == Mathf.Abs(x - y))
                        {
                            if (mapBinario[x].coluna[y] == 0)
                            {
                                if (DesqC == 0)
                                {
                                    maxDesqC++;
                                }
                            }
                            else
                            {
                                DesqC = 1;
                            }
                        }
         
                    }
                    if (x == tempx)//dir esq
                    {
                        if (y < tempy)//dir
                        {
                            if (mapBinario[x].coluna[(tempy - 1) - y] == 0)
                            {
                                if (badir == 0)
                                {
                                    maxdir++;
                                }
                            }
                            else
                            {
                                badir = 1;
                            }
                        }
                        else if (y > tempy) // esq
                        {
                            if (mapBinario[x].coluna[y] == 0)
                            {
                                if (baesq == 0)
                                {
                                    maxesq++;
                                }
                            }
                            else
                            {
                                baesq = 1;
                            }
                        }
                    }
                    if (x < tempx)//tras
                    {
                        //tras
                        if (y == tempy)
                        {
                            if (mapBinario[(tempx - 1) - x].coluna[tempy] == 0)
                            {
                                if (batras == 0)
                                {
                                    maxtras++;
                                }
                            }
                            else
                            {
                                batras = 1;
                            }
                        }
                        //diagonal secundaria
                        if (tempx + tempy == x + y)
                        {
                            if (mapBinario[y-1].coluna[x+1] == 0)
                            {
                                if (DesqB == 0)
                                {
                                    maxDesqB++;
                                }
                            }
                            else
                            {
                                DesqB = 1;
                            }
                        }
                        //diagonal principal
                        if (Mathf.Abs(tempx-tempy) == Mathf.Abs(x-y))
                        {//
                            cont++;
                            if (mapBinario[Mathf.Abs(tempx-cont)].coluna[Mathf.Abs(tempy-cont)] == 0)
                            {
                                if (DdirB == 0)
                                {
                                    maxDdirB++;
                                }
                            }
                            else
                            {
                                DdirB = 1;
                            }
                        }
                    }
                }
            }
            if(posXClick > tempx && posYClick == tempy && posXClick <=(tempx+maxfrente)&&mapBinario[posXClick].coluna[posYClick] ==0)// para cima e para frente
            {
                Debug.Log("frente");
                Mover(1);
            }
            if (posXClick > tempx && posYClick < tempy && posXClick <= (tempx + maxDdirC) &&mapBinario[posXClick].coluna[posYClick] ==0)// para cima e para direita
            {
                if(posXClick+posYClick == tempx + tempy)
                {
                    Debug.Log("D direita Cima");
                    Mover(1);
                }
                
            }
            if (posXClick > tempx && posYClick > tempy && posXClick <= (tempx + maxDesqC) &&mapBinario[posXClick].coluna[posYClick] ==0)// para cima e para esquerda
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs (tempx - tempy))
                {
                    Debug.Log("D esquerda Cima");
                    Mover(1);
                }

            }
            if (posXClick < tempx && posYClick > tempy && posXClick >= (tempx - maxDesqB) &&mapBinario[posXClick].coluna[posYClick] ==0)// para baixo e para esquerda
            {
                if (posXClick + posYClick == tempx + tempy)
                {
                    Debug.Log("D esquerda baixo");
                    Mover(1);
                }

            }
            if (posXClick < tempx && posYClick == tempy && posXClick >= (tempx - maxtras)&&mapBinario[posXClick].coluna[posYClick] ==0)// para baixo 
            {
                
                 Debug.Log("baixo");
                 Mover(1);


            }
            if (posXClick < tempx && posYClick < tempy && posXClick >= (tempx - maxDdirB)&&mapBinario[posXClick].coluna[posYClick] ==0)// para baixo e para direita
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy))
                {
                    Debug.Log("D direita baixo");
                    Mover(1);
                }

            }
            if (posXClick == tempx && posYClick < tempy && posYClick >= (tempy - maxdir)&&mapBinario[posXClick].coluna[posYClick] ==0)// para direita
            {                            
                    Debug.Log("direita ");
                    Mover(1);              
            }
            if (posXClick == tempx && posYClick > tempy && posYClick <= (tempy + maxesq)&&mapBinario[posXClick].coluna[posYClick] ==0)// para esquerda
            {
                Debug.Log("esquerda ");
                Mover(1);
            }
			//////////////////////////////
			if(mapBinario[posXClick].coluna[posYClick] > 10){
			if(posXClick > tempx && posYClick == tempy && posXClick <=(tempx+maxfrente+1))// para cima e para frente
            {
                Pontuacao(1);
            }
            if (posXClick > tempx && posYClick < tempy && posXClick <= (tempx + maxDdirC+1))// para cima e para direita
            {
                if(posXClick+posYClick == tempx + tempy)
                {
                    Pontuacao(1);
                }
                
            }
            if (posXClick > tempx && posYClick > tempy && posXClick <= (tempx + maxDesqC+1))// para cima e para esquerda
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs (tempx - tempy))
                {
                  Pontuacao(1);
                }

            }
            if (posXClick < tempx && posYClick > tempy && posXClick >= (tempx - maxDesqB-1))// para baixo e para esquerda
            {
                if (posXClick + posYClick == tempx + tempy)
                {
                		Pontuacao(1);
                }

            }
            if (posXClick < tempx && posYClick == tempy && posXClick >= (tempx - maxtras-1))// para baixo 
            {
                Pontuacao(1);


            }
            if (posXClick < tempx && posYClick < tempy && posXClick >= (tempx - maxDdirB-1))// para baixo e para direita
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy))
                {
                  Pontuacao(1);
                }

            }
            if (posXClick == tempx && posYClick < tempy && posYClick >= (tempy - maxdir-1))// para direita
            {            
				Pontuacao(1);     
            }
            if (posXClick == tempx && posYClick > tempy && posYClick <= (tempy + maxesq+1))// para esquerda
            {
                Pontuacao(1);
            }
			}
			
        }
        else
        {
            int maxdir = 0, maxfrente = 0, maxesq = 0, maxtras = 0;
            int maxDdirC = 0, maxDdirB = 0, maxDesqC = 0, maxDesqB = 0;
            int badir = 0, bafrente = 0, baesq = 0, batras = 0;
            int DdirC = 0, DdirB = 0, DesqC = 0, DesqB = 0;
            int cont = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    //Diagonal primeira

                    if (x > tempx) //para frente
                    {
                        //frente
                        if (y == tempy)//somente para frente
                        {
                            if (mapBinario[x].coluna[tempy] == 0)
                            {
                                if (bafrente == 0)
                                {
                                    maxfrente++;
                                }

                            }
                            else
                            {
                                bafrente = 1;
                            }
                        }
                        //diagonal secundaria dirC
                        if (tempx + tempy == x + y)
                        {
                            if (mapBinario[x].coluna[y] == 0)
                            {
                                if (DdirC == 0)
                                {
                                    maxDdirC++;
                                }
                            }
                            else
                            {
                                DdirC = 1;
                            }
                        }
                        //diagonal primaria esqC
                        if (Mathf.Abs(tempx - tempy) == Mathf.Abs(x - y))
                        {
                            if (mapBinario[x].coluna[y] == 0)
                            {
                                if (DesqC == 0)
                                {
                                    maxDesqC++;
                                }
                            }
                            else
                            {
                                DesqC = 1;
                            }
                        }

                    }
                    if (x == tempx)//dir esq
                    {
                        if (y < tempy)//dir
                        {
                            if (mapBinario[x].coluna[(tempy - 1) - y] == 0)
                            {
                                if (badir == 0)
                                {
                                    maxdir++;
                                }
                            }
                            else
                            {
                                badir = 1;
                            }
                        }
                        else if (y > tempy) // esq
                        {
                            if (mapBinario[x].coluna[y] == 0)
                            {
                                if (baesq == 0)
                                {
                                    maxesq++;
                                }
                            }
                            else
                            {
                                baesq = 1;
                            }
                        }
                    }
                    if (x < tempx)//tras
                    {
                        //tras
                        if (y == tempy)
                        {
                            if (mapBinario[(tempx - 1) - x].coluna[tempy] == 0)
                            {
                                if (batras == 0)
                                {
                                    maxtras++;
                                }
                            }
                            else
                            {
                                batras = 1;
                            }
                        }
                        //diagonal secundaria
                        if (tempx + tempy == x + y)
                        {
                            if (mapBinario[y - 1].coluna[x + 1] == 0)
                            {
                                if (DesqB == 0)
                                {
                                    maxDesqB++;
                                }
                            }
                            else
                            {
                                DesqB = 1;
                            }
                        }
                        //diagonal principal
                        if (Mathf.Abs(tempx - tempy) == Mathf.Abs(x - y))
                        {//
                            cont++;
                            if (mapBinario[Mathf.Abs(tempx - cont)].coluna[Mathf.Abs(tempy - cont)] == 0)
                            {
                                if (DdirB == 0)
                                {
                                    maxDdirB++;
                                }
                            }
                            else
                            {
                                DdirB = 1;
                            }
                        }
                    }
                }
            }
            if (posXClick > tempx && posYClick == tempy && posXClick <= (tempx + maxfrente)&&mapBinario[posXClick].coluna[posYClick] ==0)// para cima e para frente
            {
                Debug.Log("frente");
                Mover(2);
            }
            if (posXClick > tempx && posYClick < tempy && posXClick <= (tempx + maxDdirC)&&mapBinario[posXClick].coluna[posYClick] ==0)// para cima e para direita
            {
                if (posXClick + posYClick == tempx + tempy)
                {
                    Debug.Log("D direita Cima");
                    Mover(2);
                }

            }
            if (posXClick > tempx && posYClick > tempy && posXClick <= (tempx + maxDesqC)&&mapBinario[posXClick].coluna[posYClick] ==0)// para cima e para esquerda
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy))
                {
                    Debug.Log("D esquerda Cima");
                    Mover(2);
                }

            }
            if (posXClick < tempx && posYClick > tempy && posXClick >= (tempx - maxDesqB)&&mapBinario[posXClick].coluna[posYClick] ==0)// para baixo e para esquerda
            {
                if (posXClick + posYClick == tempx + tempy)
                {
                    Debug.Log("D esquerda baixo");
                    Mover(2);
                }

            }
            if (posXClick < tempx && posYClick == tempy && posXClick >= (tempx - maxtras)&&mapBinario[posXClick].coluna[posYClick] ==0)// para baixo 
            {

                Debug.Log("baixo");
                Mover(2);


            }
            if (posXClick < tempx && posYClick < tempy && posXClick >= (tempx - maxDdirB)&&mapBinario[posXClick].coluna[posYClick] ==0)// para baixo e para direita
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy))
                {
                    Debug.Log("D direita baixo");
                    Mover(2);
                }

            }
            if (posXClick == tempx && posYClick < tempy && posYClick >= (tempy - maxdir)&&mapBinario[posXClick].coluna[posYClick] ==0)// para direita
            {
                Debug.Log("direita ");
                Mover(2);
            }
            if (posXClick == tempx && posYClick > tempy && posYClick <= (tempy + maxesq)&&mapBinario[posXClick].coluna[posYClick] ==0)// para esquerda
            {
                Debug.Log("esquerda ");
                Mover(2);
            }
			///////////////////////////////
			if(mapBinario[posXClick].coluna[posYClick] <10 && mapBinario[posXClick].coluna[posYClick] >0){
				
			if (posXClick > tempx && posYClick == tempy && posXClick <= (tempx + maxfrente+1))// para cima e para frente
            {
                Pontuacao(2);
            }
            if (posXClick > tempx && posYClick < tempy && posXClick <= (tempx + maxDdirC+1))// para cima e para direita
            {
                if (posXClick + posYClick == tempx + tempy)
                {
                    Pontuacao(2);
                }

            }
            if (posXClick > tempx && posYClick > tempy && posXClick <= (tempx + maxDesqC+1))// para cima e para esquerda
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy))
                {
                   Pontuacao(2);
                }

            }
            if (posXClick < tempx && posYClick > tempy && posXClick >= (tempx - maxDesqB-1))// para baixo e para esquerda
            {
                if (posXClick + posYClick == tempx + tempy)
                {
                    Pontuacao(2);
                }

            }
            if (posXClick < tempx && posYClick == tempy && posXClick >= (tempx - maxtras-1))// para baixo 
            {
				Pontuacao(2);
            }
            if (posXClick < tempx && posYClick < tempy && posXClick >= (tempx - maxDdirB-1))// para baixo e para direita
            {
                if (Mathf.Abs(posXClick - posYClick) == Mathf.Abs(tempx - tempy))
                {
					Pontuacao(2);
                }

            }
            if (posXClick == tempx && posYClick < tempy && posYClick >= (tempy - maxdir-1))// para direita
            {
				Pontuacao(2);
            }
            if (posXClick == tempx && posYClick > tempy && posYClick <= (tempy + maxesq+1))// para esquerda
            {
				Pontuacao(2);
            }
			}
        }
    }
    void /*ok*/Rei(int j)
    {
        if (j==1)
        {
            
            if (posXClick >= tempx-1 && posXClick <= tempx+1 && posYClick >= tempy - 1 && posYClick <= tempy + 1)
            {
                if (mapBinario[posXClick].coluna[posYClick]== 0)
                {
                    Debug.Log("Quadrado");
                    Mover(1);
                }
                else if(mapBinario[posXClick].coluna[posYClick] > 10)
                {
                    Pontuacao(1);
                }


            }
        }
        else
        {
            if (posXClick >= tempx - 1 && posXClick <= tempx + 1 && posYClick >= tempy - 1 && posYClick <= tempy + 1)
            {
                if (mapBinario[posXClick].coluna[posYClick] == 0)
                {
                    Debug.Log("Quadrado");
                    Mover(2);
                }
                else if(mapBinario[posXClick].coluna[posYClick] < 10 && mapBinario[posXClick].coluna[posYClick] > 0)
                {
                    Pontuacao(2);
                }


            }
        }
    }
	void Mover(int j){
		if (j == 1) {
			tempObg.transform.position = new Vector3(mapPos[posXClick].row[posYClick].transform.position.x, -0.75f, mapPos[posXClick].row[posYClick].transform.position.z);
			setaPosition.GetComponent<Light>().enabled = false;
			mapBinario[posXClick].coluna[posYClick] = tempId;
			mapBinario[tempx].coluna[tempy] = 0;
			tempx = 0;
			tempy = 0;
			tempId = 0;
			VezJogador = 2;

		} else {
            tempObg.transform.position = new Vector3(mapPos[posXClick].row[posYClick].transform.position.x, -0.75f, mapPos[posXClick].row[posYClick].transform.position.z);
            setaPosition.GetComponent<Light>().enabled = false;
            mapBinario[posXClick].coluna[posYClick] = tempId;
            mapBinario[tempx].coluna[tempy] = 0;
            tempx = 0;
            tempy = 0;
            tempId = 0;
            VezJogador = 1;
        }
	}
    void CAM()
    {
       
        setaPosition.transform.position = new Vector3(mapPos[posXClick].row[posYClick].transform.position.x, 5, mapPos[posXClick].row[posYClick].transform.position.z);
        setaPosition.GetComponent<Light>().enabled = true;
        //grava a posicao da peça
        tempx = posXClick;
        tempy = posYClick;
        tempId = Id;
        tempObg = select;
        
        
      
    }
    void Pontuacao(int j)
    {
        if (j == 1)
        {
            if (scriptSelect.MataPeca(mapPos[posXClick].row[posYClick]))
            {
                Pontosp1++;
                Mover(1);
            }
        }
        else
        {
            if (scriptSelect.MataPeca(mapPos[posXClick].row[posYClick]))
            {
                Pontosp2++;
                Mover(2);
            }

        }
    }
}