using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject bunker;
    public GameObject invader;
    public GameObject laser;
    private GameObject activeLaser;
    public int rows = 8, cols = 5;

    private Dictionary<GameObject,int[]> invaders;
    private Dictionary<int,int> lowestRowForColumn;
    private float[] bunkersPos = {-1.45f,-0.5f,0.5f,1.45f};

    float hSpace = 0.35f;
    float hCenterOffset;
    void Start()
    {
        invaders = new Dictionary<GameObject, int[]>();
        lowestRowForColumn = new Dictionary<int, int>();

        foreach(float pos in bunkersPos) {
            Instantiate(bunker, new Vector3(pos,-1.125f,0f),Quaternion.identity);
        }

        hCenterOffset = -(0.175f * (cols-1));
        
        for (int c = 0; c < cols; c++) {
            for (int r = 0; r < rows; r++) {
                invaders.Add(Instantiate(invader,new Vector3(hCenterOffset + (c * hSpace),1.3f - r * 0.2f,0),Quaternion.identity),new int[]{r,c});
            }

            lowestRowForColumn.Add(c,rows);
        }
    }

    void Update() {
        foreach(GameObject inv in invaders.Keys) {
            if (!inv) {
                int col = invaders[inv][1];
                lowestRowForColumn[col]--;
                
                if (lowestRowForColumn[col] <= 0) {
                    lowestRowForColumn.Remove(col);
                }
                
                invaders.Remove(inv);
                return;
            }
        }

        if (activeLaser) return;
        var randomColumn = Random.Range(0,lowestRowForColumn.Count);
        var x = lowestRowForColumn.ElementAt(randomColumn).Key;
        var y = lowestRowForColumn.ElementAt(randomColumn).Value;

        var pos = new Vector3(hCenterOffset + (x * hSpace),1.35f - y * 0.2f,0);

        activeLaser = Instantiate(laser,pos,Quaternion.identity);
        activeLaser.GetComponent<Laser>().direction = Vector3.down;
        
    }
}
