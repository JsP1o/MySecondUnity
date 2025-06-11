using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RenPy : MonoBehaviour
{
    [SerializeField] Image Img_BG; // ���
    [SerializeField] Image[] Img_Character; // ĳ���� [] �迭

    [SerializeField] TextMeshProUGUI Txt_Name; // ĳ���� �̸�: ī��ī
    [SerializeField] TextMeshProUGUI Txt_NameTitle; // ĳ���� Ÿ��Ʋ: ���ڶ�� ����
    [SerializeField] TextMeshProUGUI Txt_Dialogue; // ���: �� ���.

    int id = 1; // ��� ID
    private void Start()
    {
        RefreshUI();
    }

    public void OnClickButton()
    {
        //if (SData.GetDialogueData(id + 1) == null)
        //{
        //    Debug.Log("�� �̻� ��簡 �����ϴ�.");
        //    return;
        //}

        id++;
        RefreshUI();
    }

    void RefreshUI()
    {
        int CharacterID = SData.GetDialogueData(id).Characterid;
        Txt_Name.text = SData.GetCharacterData(CharacterID).Name;
        Txt_NameTitle.text = SData.GetCharacterData(CharacterID).Title;

        Txt_Dialogue.text = SData.GetDialogueData(id).Dialogue;

        Img_BG.sprite = Resources.Load<Sprite>("Img/Starrail/" + SData.GetDialogueData(id).BG);

        for (int i = 0; i < Img_Character.Length; i++)
        {
            if(i == SData.GetDialogueData(id).Position)
            {
                Img_Character[i].sprite = Resources.Load<Sprite>("Img/Starrail/" + SData.GetCharacterData(CharacterID).Image); // ĳ���� �̹��� �ε�
                Img_Character[i].gameObject.SetActive(true);
            }
            else
            {
                Img_Character[i].gameObject.SetActive(false);
            }
        }
    }
}
