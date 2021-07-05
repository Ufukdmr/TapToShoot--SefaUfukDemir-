using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_ShootableCubes : Sc_ShootableSurface
{
    private int totalBrick;
    public override void Start()
    {
        
        if ((columnCount * rowCount) <= shootableObjCount)
        {
            shootableObjCount = columnCount * rowCount;
        }
        totalBrick = columnCount * rowCount;
        
        base.Start();
    }

    public override void BuildWall()
    {

        for (int k = 0; k < rowCount; k++)
        {

            for (int j = 0; j < columnCount; j++)
            {
                GameObject brick = Instantiate(pre_Brick, BrickPos(k, j), Quaternion.identity);
                if (shootableObjCount != 0)
                {
                    if (totalBrick <= shootableObjCount)
                    {
                        brick.GetComponent<Sc_Brick>().Walling(1);
                        shootableObjCount--;
                    }
                    else
                    {
                        int a = Random.Range(0, 5);
                        if (a == 1)
                        {
                            shootableObjCount--;
                            totalBrick--;

                        }
                        else
                        {
                            totalBrick--;
                        }
                        brick.GetComponent<Sc_Brick>().Walling(a);
                    }

                }
                else
                {
                    brick.GetComponent<Sc_Brick>().Walling(0);
                    totalBrick--;
                }



            }
        }
    }
    public override Vector3 BrickPos(int k, int j)
    {
        float x = 0 - ((columnCount / 2f) - (pre_Brick.transform.localScale.x / 2f)) + (j * pre_Brick.transform.localScale.x);
        float y = 0.5f + (k * pre_Brick.transform.localScale.y);
        float z = 4.5f;
        Vector3 brickPos = new Vector3(x, y, z);

        return brickPos;
    }


}
