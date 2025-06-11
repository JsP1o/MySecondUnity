using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RenPy : MonoBehaviour
{
    [SerializeField] Image Img_BG; // 배경
    [SerializeField] Image[] Img_Character; // 캐릭터 [] 배열

    [SerializeField] TextMeshProUGUI Txt_Name; // 캐릭터 이름: 카프카
    [SerializeField] TextMeshProUGUI Txt_NameTitle; // 캐릭터 타이틀: 스텔라론 헌터
    [SerializeField] TextMeshProUGUI Txt_Dialogue; // 대사: 잘 들어.

    int id = 1; // 대사 ID
    private void Start()
    {
        RefreshUI();
    }

    public void OnClickButton()
    {
        //if (SData.GetDialogueData(id + 1) == null)
        //{
        //    Debug.Log("더 이상 대사가 없습니다.");
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
                Img_Character[i].sprite = Resources.Load<Sprite>("Img/Starrail/" + SData.GetCharacterData(CharacterID).Image); // 캐릭터 이미지 로드
                Img_Character[i].gameObject.SetActive(true);
            }
            else
            {
                Img_Character[i].gameObject.SetActive(false);
            }
        }
    }
}
