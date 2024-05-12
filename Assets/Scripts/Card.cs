using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public bool hasClicked;

    [SerializeField]
    int row, col;

    [SerializeField]
    Sprite zir, skrat, skratzena, unrevealed;

    SpriteRenderer renderer;

    Animator animator;

    public Choice mychoice;

    private void Start()
    {
        hasClicked = false;
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        mychoice = Control.instance.myboard.GetChoice(row, col);
        renderer.sprite = unrevealed;
    }

    public void PlayTurn()
    {
        animator.Play("Reveal");
        hasClicked = true;
    }

    public void ChangeImage()
    {
        Sprite current = mychoice == Choice.SKRAT ? skrat
            : mychoice == Choice.ZIR ? zir
            : skratzena;
        renderer.sprite = current;

    }

}
