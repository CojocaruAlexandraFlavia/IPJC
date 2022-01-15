using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanelController : MonoBehaviour
{
    public Animator panelAnim;
    public Animator endGameAnim;
    public Animator startGameAnim;

    public void OK()
    {
        if (panelAnim != null && startGameAnim != null)
        {
            
            panelAnim.SetBool("Out", true);
            startGameAnim.SetBool("Out", true);
        }
    }

    public void GameOver()
    {
        panelAnim.SetBool("Out", false);
        //endGameAnim.SetBool("Out", false);
        panelAnim.SetBool("Game Over", true);
    }

}
