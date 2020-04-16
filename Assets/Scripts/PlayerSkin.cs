using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] int skinNum = 0;
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator outlineAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    public int GetSkinNum()
    {
        return skinNum;
    }

    public void LoadPlayerSkin()
    {
        SaveData data = SaveSystem.LoadPlayerSkin();
        skinNum = data.skinNum;
    }

    public void Refresh()
    {
        //load from save
        LoadPlayerSkin();

        //handle skin
        if (skinNum == 0)//Male1
        {
            playerAnimator.runtimeAnimatorController = Resources.Load("Animations/Characters/Male1/Male1Controller", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        }
        else if (skinNum == 1)//Male2
        {
            playerAnimator.runtimeAnimatorController = Resources.Load("Animations/Characters/Male2/Male2Controller", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        }
        else if (skinNum == 2)//Male3
        {
            playerAnimator.runtimeAnimatorController = Resources.Load("Animations/Characters/Male3/Male3Controller", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        }
        else if (skinNum == 3)//Male4
        {
            playerAnimator.runtimeAnimatorController = Resources.Load("Animations/Characters/Male4/Male4Controller", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        }
        else if (skinNum == 4)//Female1
        {
            playerAnimator.runtimeAnimatorController = Resources.Load("Animations/Characters/Female1/Female1Controller", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        }
        else if (skinNum == 5)//Female2
        {
            playerAnimator.runtimeAnimatorController = Resources.Load("Animations/Characters/Female2/Female2Controller", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        }
        else if (skinNum == 6)//Female3
        {
            playerAnimator.runtimeAnimatorController = Resources.Load("Animations/Characters/Female3/Female3Controller", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        }
        else if (skinNum == 7)//Female4
        {
            playerAnimator.runtimeAnimatorController = Resources.Load("Animations/Characters/Female4/Female4Controller", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        }

        //handle outline
        if (skinNum < 4) //male outline
        {
            outlineAnimator.runtimeAnimatorController = Resources.Load("Animations/Characters/Outlines/MaleOutlineController", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        }
        else //female outline
        {
            outlineAnimator.runtimeAnimatorController = Resources.Load("Animations/Characters/Outlines/FemaleOutlineController", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        }
    }

    public void EquipSkin(int skinNum)
    {
        this.skinNum = skinNum; //set new skinNum
        SaveSystem.SavePlayerSkin(this); //save new PlayerSkin
        Refresh(); //refresh
    }
}
