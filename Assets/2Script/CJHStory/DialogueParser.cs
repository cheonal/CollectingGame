using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueParser : MonoBehaviour
{
    //쌍 따옴표 처리 방법 고민 해야돼
    /*구글스프레드시트가 아니라 엑셀 혹은 리브레오피스 등의 프로그램을 이용하여 CSV 파일을 만들었을 경우, 
CSV파일을 비쥬얼 스튜디오로 열어서 CSV파일의 줄 수를 확인해주세요.
만약 7번째 줄에서 글이 끝나는데, 줄 수는 8번째 줄까지 이어져있다면 끝의 줄을 지워서 줄의 크기를 맞춰주세요. 
CSV 파일 끝에 엔터 한번이 더 들어가는 바람에 한 줄이 더 있는걸로 인식하여 다음줄을 읽어오려하기 때문에,
즉 for (int i = 1; i < data.Length - 1; i++) << 이 부분의 data.Length가 의도한 7줄이 아니라 CSV 파일의 전체 줄인 8줄로 인식하게 되어서
IndexOutOfRangeException 오류가 발생하게 되는 것입니다.*/
    [SerializeField] Text tset;
    public Dialogue[] Parse(string _CsvFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); //대사 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>(_CsvFileName); //csv 파일 가져옴

        string[] data = csvData.text.Split(new char[] { '\n' }); //엔터 기준으로 쪼갬 1번째 줄 2번째 줄
        for(int i=1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' }); //이름, 대사 순으로 쪼갬

            Dialogue dialogue = new Dialogue(); //대사 리스트 생성

            dialogue.Name = row[1];
            Debug.Log(row[1]);
              List<string> contextList = new List<string>();
            do{
                tset.text = row[2];
                Debug.Log(row[2]);
                contextList.Add(row[2]);
                if (++i < data.Length){
                    row = data[i].Split(new char[] { ',' });
                }
                else{
                    break;
                }

            } while (row[0].ToString() == "");

            dialogue.Contexts = contextList.ToArray();

            dialogueList.Add(dialogue);
        }
        return dialogueList.ToArray();
    }
}
