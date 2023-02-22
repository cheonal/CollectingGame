using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueParser : MonoBehaviour
{
    //�� ����ǥ ó�� ��� ��� �ؾߵ�
    /*���۽��������Ʈ�� �ƴ϶� ���� Ȥ�� ���극���ǽ� ���� ���α׷��� �̿��Ͽ� CSV ������ ������� ���, 
CSV������ ����� ��Ʃ����� ��� CSV������ �� ���� Ȯ�����ּ���.
���� 7��° �ٿ��� ���� �����µ�, �� ���� 8��° �ٱ��� �̾����ִٸ� ���� ���� ������ ���� ũ�⸦ �����ּ���. 
CSV ���� ���� ���� �ѹ��� �� ���� �ٶ��� �� ���� �� �ִ°ɷ� �ν��Ͽ� �������� �о�����ϱ� ������,
�� for (int i = 1; i < data.Length - 1; i++) << �� �κ��� data.Length�� �ǵ��� 7���� �ƴ϶� CSV ������ ��ü ���� 8�ٷ� �ν��ϰ� �Ǿ
IndexOutOfRangeException ������ �߻��ϰ� �Ǵ� ���Դϴ�.*/
    [SerializeField] Text tset;
    public Dialogue[] Parse(string _CsvFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); //��� ����Ʈ ����
        TextAsset csvData = Resources.Load<TextAsset>(_CsvFileName); //csv ���� ������

        string[] data = csvData.text.Split(new char[] { '\n' }); //���� �������� �ɰ� 1��° �� 2��° ��
        for(int i=1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' }); //�̸�, ��� ������ �ɰ�

            Dialogue dialogue = new Dialogue(); //��� ����Ʈ ����

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
