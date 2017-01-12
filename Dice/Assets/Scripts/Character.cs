using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SourceStat
{
    Str = 0,
    Dex = 1,
    Con = 2,
    Intel = 3,
    Wis = 4,
    Cha = 5
};

public enum SkillAsInt
{
    Acrobatics = 0,
    AnimalHandling = 1,
    Arcana = 2,
    Athletics = 3,
    Deception = 4,
    History = 5,
    Insight = 6,
    Intimidation = 7,
    Investigation = 8,
    Medicine = 9,
    Nature = 10,
    Perception = 11,
    Performance = 12,
    Persuasion = 13,
    Religion = 14,
    SleightOfHand = 15,
    Sealth = 16,
    Survival = 17,
    StrSave = 18,
    DexSave = 19,
    ConSave = 20,
    IntSave = 21,
    WisSave = 22,
    ChaSave = 23
}

public class Character
{
    public bool active;
    public string name;
    public int level;
    public int ac;
    public int hp;
    private int proficiencyBonus;
    public int strength;
    public int dexterity;
    public int constitution;
    public int intelligence;
    public int wisdom;
    public int charisma;

    public Skill[] skills =
    {
        new Skill("Acrobatics", false, 1),
        new Skill("Animal Handling", false, 4),
        new Skill("Arcana", false, 3),
        new Skill("Athletics", false, 0),
        new Skill("Deception", false, 5),
        new Skill("History", false, 3),
        new Skill("Insight", false, 4),
        new Skill("Intimidation", false, 5),
        new Skill("Investigation", false, 3),
        new Skill("Medicine", false, 4),
        new Skill("Nature", false, 3),
        new Skill("Perception", false, 4),
        new Skill("Performance", false, 5),
        new Skill("Persuasion", false, 5),
        new Skill("Religion", false, 3),
        new Skill("Sleight of Hand", false, 1),
        new Skill("Stealth", false, 1),
        new Skill("Survival", false, 4),
        new Skill("Str Save", false, 0),
        new Skill("Dex Save", false, 1),
        new Skill("Con Save", false, 2),
        new Skill("Int Save", false, 3),
        new Skill("Wis Save", false, 4),
        new Skill("Cha Save", false, 5)
    };

    public class Skill
    {
        public string name;
        private bool proficient;
        public SourceStat source;

        public Skill(string n, bool p, int s)
        {
            name = n;
            proficient = p;
            source = (SourceStat)s;
        }

        public bool IsProficient()
        {
            return proficient;
        }
    }

    public Character()
    {
        active = false;
    }

    public Character(string n, int l, int h, int a, int st, int de, int co, int intel, int wi, int ch)
    {
        name = n;
        level = l;
        ac = a;
        hp = h;

        if (level < 5)
        {
            proficiencyBonus = 2;
        }
        else if (level < 9)
        {
            proficiencyBonus = 3;
        }
        else if (level < 13)
        {
            proficiencyBonus = 4;
        }
        else if (level < 17)
        {
            proficiencyBonus = 5;
        }
        else
        {
            proficiencyBonus = 6;
        }

        strength = st;
        dexterity = de;
        constitution = co;
        intelligence = intel;
        wisdom = wi;
        charisma = ch;

    }

    //Returns the total value of the skill
    public int GetValue(Skill s)
    {
        switch (s.source)
        {
            case SourceStat.Str:
                if (s.IsProficient())
                {
                    return proficiencyBonus + strength;
                }
                else
                {
                    return strength;
                }
            case SourceStat.Dex:
                if (s.IsProficient())
                {
                    return proficiencyBonus + dexterity;
                }
                else
                {
                    return dexterity;
                }
            case SourceStat.Con:
                if (s.IsProficient())
                {
                    return proficiencyBonus + constitution;
                }
                else
                {
                    return constitution;
                }
            case SourceStat.Intel:
                if (s.IsProficient())
                {
                    return proficiencyBonus + intelligence;
                }
                else
                {
                    return intelligence;
                }
            case SourceStat.Wis:
                if (s.IsProficient())
                {
                    return proficiencyBonus + wisdom;
                }
                else
                {
                    return wisdom;
                }
            case SourceStat.Cha:
                if (s.IsProficient())
                {
                    return proficiencyBonus + charisma;
                }
                else
                {
                    return charisma;
                }
            default:
                return 0;
        }
    }
}

/*
    public string name;
    public string playerClass;
    public string race;
    public int level;
    public Stats primaryStats;
    public Skills secondaryStats;
    public int proficiencyBonus;

    //Done in class Skill so skills can be recalculated once pb is modified
    public void ModifyProficiencyBonus(int value)
    {
        proficiencyBonus = value;
        CalculateValues();   //Calculate new skill value
    }

    public void CalculateValues()
    {
        switch (source)
        {
            case Stat.Strength:
                value = GetModifier(str);
                break;
            case Stat.Dexterity:
                value = GetModifier(dex);
                break;
            case Stat.Constitution:
                value = GetModifier(con);
                break;
            case Stat.Intelligence:
                value = GetModifier(intelligence);
                break;
            case Stat.Wisdom:
                value = GetModifier(wis);
                break;
            case Stat.Charisma:
                value = GetModifier(cha);
                break;
        }

        if (proficient)
        {
            value += proficiencyBonus;
        }
    }
}

public class Stats
{
    public int str;
    public int dex;
    public int con;
    public int intelligence;
    public int wis;
    public int cha;
    public int proficiencyBonus;

    public Stats()
    {
        str = 10;
        dex = 10;
        con = 10;
        intelligence = 10;
        wis = 10;
        cha = 10;
        proficiencyBonus = 2;
    }

    public Stats(int s, int d, int c, int i, int w, int ch)
    {
        str = s;
        dex = d;
        con = c;
        intelligence = i;
        wis = w;
        cha = ch;
    }

    public Stats(int s, int d, int c, int i, int w, int ch, int pb)
    {
        str = s;
        dex = d;
        con = c;
        intelligence = i;
        wis = w;
        cha = ch;
        proficiencyBonus = pb;
    }

    public int GetModifier(int value)
    {
        return (value - 10)/2;
    }
}

/*
 * Skill
 * 
 * Refers to any stat associated with skill checks. Each skill has a value which is determined by the source stat
 * and proficiency bonus (if that player is proficient with the skill). 
 *
public class Skill
{
    public int value;
    public bool proficient;
    public Stat source;

    public Skill()
    {
        value = 0;
        proficient = false;
        source = Stat.Strength;
    }

    public Skill(int v, bool p, Stat s)
    {
        value = v;
        proficient = p;
        source = s;
    }

}

public class Skills
{
    public int proficiencyBonus;

    public Skill acrobatics;
    public Skill animalHandling;
    public Skill arcana;
    public Skill athletics;
    public Skill deception;
    public Skill history;
    public Skill insight;
    public Skill intimidation;
    public Skill investigation;
    public Skill medicine;
    public Skill nature;
    public Skill perception;
    public Skill performance;
    public Skill persuasion;
    public Skill religion;
    public Skill sleightOfHand;
    public Skill stealth;
    public Skill survival;

    List<Skill> GetOrderedList()
    {
        List<Skill> skillList = new List<Skill>();
        skillList.Add(acrobatics);
        skillList.Add(animalHandling);
        skillList.Add(arcana);
        skillList.Add(athletics);
        skillList.Add(deception);
        skillList.Add(history);
        skillList.Add(insight);
        skillList.Add(intimidation);
        skillList.Add(investigation);
        skillList.Add(medicine);
        skillList.Add(nature);
        skillList.Add(perception);
        skillList.Add(performance);
        skillList.Add(persuasion);
        skillList.Add(religion);
        skillList.Add(sleightOfHand);
        skillList.Add(stealth);
        skillList.Add(survival);

        return skillList;
    }

    void AssignFromList(List<Skill> l)
    {
        acrobatics;
        animalHandling;
        arcana;
        athletics;
        deception;
        history;
    public Skill insight;
    public Skill intimidation;
    public Skill investigation;
    public Skill medicine;
    public Skill nature;
    public Skill perception;
    public Skill performance;
    public Skill persuasion;
    public Skill religion;
    public Skill sleightOfHand;
    public Skill stealth;
    public Skill survival;
}
}

public enum Stat
{
    Strength,
    Dexterity,
    Constitution,
    Intelligence,
    Wisdom,
    Charisma
};
*/