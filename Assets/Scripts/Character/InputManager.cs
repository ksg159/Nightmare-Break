using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
<<<<<<< HEAD
=======
    private static InputManager instance = null;
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindWithTag("InputManager").GetComponent<InputManager>();
            }

            return instance;
        }
    }

>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    public float vertical = 0;
    public float horizontal = 0;

    public CharacterManager characterManager;
    
    public void InitializeManager()
    {
        characterManager = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterManager>();
    }

    public IEnumerator GetKeyInput()
    {
        Debug.Log("Input Key Start");

        while (true)
        {
            yield return null;

            vertical = Input.GetAxisRaw("Vertical");
            horizontal = Input.GetAxisRaw("Horizontal");
            characterManager.Move(vertical, horizontal);


            if (Input.GetKeyDown(KeyCode.T))
            {
                characterManager.UsingPotion();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                characterManager.NormalAttack();
            }
            if (Input.GetButtonDown("Skill1"))
            {
                characterManager.Skill1();
                //Maelstrom ();
            }
            else if (Input.GetButtonDown("Skill2"))
            {
                characterManager.skill2();
            }
            else if (Input.GetButtonDown("Skill3"))
            {
                characterManager.skill3();
            }
            else if (Input.GetButtonDown("Skill4"))
            {
                characterManager.Skill4();
            }
        }
    }
}