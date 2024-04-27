using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct GridPos { public int row, col; }

public enum Choice { SKRAT, SKRATZENA, ZIR }

public class Board
{
    Choice[][] choices;
    List<GridPos> indexList;

    public Board()
    {
        choices = new Choice[5][];
        indexList = new List<GridPos>();
        for (int i = 0; i < 5; i++)
        {
            choices[i] = new Choice[5];
            for (int j = 0; j < choices[i].Length; j++)
            {
                choices[i][j] = Choice.SKRAT;
                indexList.Add(new GridPos { row = i, col = j });
            }
        }

        AddSkratandZir();
    }

    GridPos GetRandomFromList()
    {
        GridPos temp;
        int index = Random.Range(0, indexList.Count);
        temp = new GridPos { row = indexList[index].row, col = indexList[index].col };
        indexList.RemoveAt(index);
        return temp;
    }

    void AddSkratandZir()
    {
        GridPos temp;
        temp = GetRandomFromList();
        choices[temp.row][temp.col] = Choice.ZIR;
        temp = GetRandomFromList();
        choices[temp.row][temp.col] = Choice.ZIR;
        temp = GetRandomFromList();
        choices[temp.row][temp.col] = Choice.SKRAT;
        temp = GetRandomFromList();
        choices[temp.row][temp.col] = Choice.SKRAT;
        temp = GetRandomFromList();
        choices[temp.row][temp.col] = Choice.SKRAT;
    }

    public Choice GetChoice(int row, int col)
    {
        return choices[row][col];
    }
}