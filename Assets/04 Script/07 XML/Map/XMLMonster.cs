using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLMonster : Singleton<XMLMonster>
{
    public Sprite[] MonsterSprites;

    public List<XMLMonsterData> Monsters;

    string filePath = "./Assets/Resources/MonsterList.xml";

    private void Awake()
    {
        //CreateXml();
        LoadXml();

        MonsterSelectListManager.Instance.Init();
    }

    public void CreateXml() // 기본 틀을 만들기 위해서 제작한 함수
    {
        Monsters = new List<XMLMonsterData>();

        for (int i = 0; i < 2; i++)
        {
            XMLMonsterData Monster = new XMLMonsterData
            {
                fNumber = i,
                sName = "몬스터이름",
                sDescription = "몬스터 설명",
                fHp = 100,
                fLevel = 1,
                fAttack = 10,
                fAttackSpeed = 1,
                eAttackType = (AttackType)1,
                fCritical = 1,
                fDefence = 1,
                eDefenceType = (DefenceType)1,
                fGold = 100,
                fSoul = 0
            };
            Monsters.Add(Monster);
        }

        XmlDocument Document = new XmlDocument();
        XmlElement MonsterListElement = Document.CreateElement("MonsterList");
        Document.AppendChild(MonsterListElement);

        foreach (XMLMonsterData Monster in Monsters)
        {
            XmlElement MonsterElement = Document.CreateElement("Monster");
            MonsterElement.SetAttribute("fNumber", Monster.fNumber.ToString());
            MonsterElement.SetAttribute("sName", Monster.sName.ToString());
            MonsterElement.SetAttribute("sDescription", Monster.sDescription.ToString());
            MonsterElement.SetAttribute("fHp", Monster.fHp.ToString());
            MonsterElement.SetAttribute("fLevel", Monster.fLevel.ToString());
            MonsterElement.SetAttribute("fAttack", Monster.fAttack.ToString());
            MonsterElement.SetAttribute("fAttackSpeed", Monster.fAttackSpeed.ToString());
            MonsterElement.SetAttribute("eAttackType", Monster.eAttackType.ToString());
            MonsterElement.SetAttribute("fCritical", Monster.fCritical.ToString());
            MonsterElement.SetAttribute("fDefence", Monster.fDefence.ToString());
            MonsterElement.SetAttribute("eDefenceType", Monster.eDefenceType.ToString());
            MonsterElement.SetAttribute("fGold", Monster.fGold.ToString());
            MonsterElement.SetAttribute("fSoul", Monster.fSoul.ToString());

            MonsterListElement.AppendChild(MonsterElement);
        }

        Document.Save(filePath);
    }

    public void LoadXml()
    {
        Monsters = new List<XMLMonsterData>();
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement MonsterListElement = Document["MonsterList"];        

        foreach (XmlElement MonsterElement in MonsterListElement.ChildNodes)
        {
            XMLMonsterData Monster = new XMLMonsterData
            {
                fNumber = System.Convert.ToSingle(MonsterElement.GetAttribute("fNumber")),
                sName = MonsterElement.GetAttribute("sName"),
                sDescription = MonsterElement.GetAttribute("sDescription"),
                fHp = System.Convert.ToSingle(MonsterElement.GetAttribute("fHp")),
                fLevel = System.Convert.ToSingle(MonsterElement.GetAttribute("fLevel")),
                fAttack = System.Convert.ToSingle(MonsterElement.GetAttribute("fAttack")),
                fAttackSpeed = System.Convert.ToSingle(MonsterElement.GetAttribute("fAttackSpeed")),
                eAttackType = (AttackType)System.Convert.ToInt32(MonsterElement.GetAttribute("eAttackType")),
                fCritical = System.Convert.ToSingle(MonsterElement.GetAttribute("fCritical")),
                fDefence = System.Convert.ToSingle(MonsterElement.GetAttribute("fDefence")),
                eDefenceType = (DefenceType)System.Convert.ToInt32(MonsterElement.GetAttribute("eDefenceType")),
                fGold = System.Convert.ToSingle(MonsterElement.GetAttribute("fGold")),
                fSoul = System.Convert.ToSingle(MonsterElement.GetAttribute("fSoul")),
            };
            Monsters.Add(Monster);
        }
    }

    public XMLMonsterData GetMonsterData(int _num)
    {
        for (int i = 0; i < Monsters.Count; i++)
        {
            if(Monsters[i].fNumber == _num)
            {
                return Monsters[_num];
            }
        }
        return null;
    }

    public int MonsterLegth()
    {
        return Monsters.Count;
    }
}
