using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GridPos { public int row, col; }

public enum Izbor { SKRAT, SKRATZENSKO, ZIR }

public class Board
{
    Izbor[][] izbori;
    List<GridPos> indexList;

    public Board()
    {
        izbori = new Izbor[5][];
        indexList = new List<GridPos>();
        for (int i = 0; i < 5; i++)
        {
            izbori[i] = new Izbor[5];
            for (int j = 0; j < izbori[i].Length; j++)
            {
                izbori[i][j] = Izbor.SKRAT;
                indexList.Add(new GridPos { row = i, col = j });
            }
        }

        AAddSkratiZir();
    }

    GridPos GetRandomFromList()
    {
        GridPos temp;
        int index = Random.Range(0, indexList.Count);
        temp = new GridPos { row = indexList[index].row, col = indexList[index].col };
        indexList.RemoveAt(index);
        return temp;
    }

    void AAddSkratiZir()
    {
        GridPos temp;
        for (int i = 0; i < 2; i++)
        {
            temp = GetRandomFromList();
            izbori[temp.row][temp.col] = Izbor.ZIR;
        }
        for (int i = 0; i < 3; i++)
        {
            temp = GetRandomFromList();
            izbori[temp.row][temp.col] = Izbor.SKRATZENSKO;
        }
    }

    public Izbor GetChoice(int row, int col)
    {
        return izbori[row][col];
    }
}

