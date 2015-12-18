
using System;
using System.Collections.Generic;
using System.ComponentModel;
using YGOProDevelop;
using YGOProDevelop.Model;

namespace Builder {


    public class CardBuilder:INotifyPropertyChanged {

        public static datas CreateDefaultData(CardType type) {
            datas d = new datas();
            d.texts = new texts();
            d.texts.id = 0;
            d.texts.name = "新建卡片";
            d.texts.desc = "输入描述";
            switch (type) {
                case CardType.Monster:
                    d.id = 0;
                    d.type = 17;
                    d.race = 1;
                    d.attribute = 1;
                    return d;
                case CardType.Spell:
                    d.id = 0;
                    d.type = 2;
                    d.race = 0;
                    d.attribute = 0;
                    return d;
                case CardType.Trap:
                    d.id = 0;
                    d.type = 4;
                    d.race = 0;
                    d.attribute = 0;
                    return d;
                default:
                    d.id = 0;
                    d.type = 17;
                    d.race = 1;
                    d.attribute = 1;
                    return d;
            }
        }

        public enum CardType {
            Monster,
            Spell,
            Trap
        }

        public CardBuilder(datas data) {
            Load(data);
        }

        public CardBuilder() {
            Ot = new OtField(0);
            SetCode = new SetCodeField(0);
            Type = new TypeField(0);
            Category = new CategoryField(0);
            Race = new RaceField(0);
            Attribute = new AttributeField(0);
        }

      

        public void Load(datas data) {
            this.ID = data.id;
            this.Alias = data.alias ?? 0;
            this.Level = data.level ?? 0;
            this.Atk = data.atk ?? 0;
            this.Def = data.def ?? 0;
            this.Name = data.texts.name;
            this.Description = data.texts.desc;
            this.InfoStrings = new List<string>();
            this.InfoStrings.Add(data.texts.str1);
            this.InfoStrings.Add(data.texts.str2);
            this.InfoStrings.Add(data.texts.str3);
            this.InfoStrings.Add(data.texts.str4);
            this.InfoStrings.Add(data.texts.str5);
            this.InfoStrings.Add(data.texts.str6);
            this.InfoStrings.Add(data.texts.str7);
            this.InfoStrings.Add(data.texts.str8);
            this.InfoStrings.Add(data.texts.str9);
            this.InfoStrings.Add(data.texts.str10);
            this.InfoStrings.Add(data.texts.str11);
            this.InfoStrings.Add(data.texts.str12);
            this.InfoStrings.Add(data.texts.str13);
            this.InfoStrings.Add(data.texts.str14);
            this.InfoStrings.Add(data.texts.str15);
            this.InfoStrings.Add(data.texts.str16);

            //这里有个问题值可能是0,因此Field的VarITem可能为Null,WPF中要对VarItem为Null的情况选中一个默认值.
            this.Ot = new OtField(data.ot ?? 0);
            this.SetCode = new SetCodeField(data.setcode ?? 0);
            this.Type = new TypeField(data.type ?? 0);
            this.Category = new CategoryField(data.category ?? 0);
            this.Race = new RaceField(data.race ?? 0);
            this.Attribute = new AttributeField(data.attribute ?? 0);
        }

        public void CopyTo(datas data) {
            data.id = ID;
            data.alias = Alias;
            data.level = Level;
            data.atk = Atk;
            data.def = Def;
            data.texts.name = Name;
            data.texts.desc = Description;
            data.ot = Ot.Value;
            data.setcode = SetCode.Value;
            data.category = Category.Value;
            data.type = Type.Value;
            data.race = Race.Value;
            data.attribute = Attribute.Value;

            data.texts.str1 = InfoStrings[0];
            data.texts.str2 = InfoStrings[1];
            data.texts.str3 = InfoStrings[2];
            data.texts.str4 = InfoStrings[3];
            data.texts.str5 = InfoStrings[4];
            data.texts.str6 = InfoStrings[5];
            data.texts.str7 = InfoStrings[6];
            data.texts.str8 = InfoStrings[7];
            data.texts.str9 = InfoStrings[8];
            data.texts.str10 = InfoStrings[9];
            data.texts.str11 = InfoStrings[10];
            data.texts.str12 = InfoStrings[11];
            data.texts.str13 = InfoStrings[12];
            data.texts.str14 = InfoStrings[13];
            data.texts.str15 = InfoStrings[14];
            data.texts.str16 = InfoStrings[15];

        }

        //不需要Field包装的字段
        public Int64 ID { get; set; }

        public Int64 Alias { get; set; }

        public string Name { get; set; }

        public Int64 Level { get; set; }

        public Int64 Atk { get; set; }

        public Int64 Def { get; set; }

        public string Description { get; set; }

        public List<string> InfoStrings { get; set; }


        //需要Field包装的字段
        public OtField Ot { get; set; }

        public SetCodeField SetCode { get; set; }

        public TypeField Type { get; set; }

        public CategoryField Category { get; set; }

        public RaceField Race { get; set; }

        public AttributeField Attribute { get; set; }

        /// <summary>
        /// 转换成
        /// </summary>
        public datas ToDatas() {
            datas data = new datas();
            data.texts = new texts();
            data.id = this.ID;
            data.alias = this.Alias;
            data.texts.name = this.Name;
            data.level = this.Level;
            data.atk = this.Atk;
            data.def = this.Def;
            data.texts.desc = this.Description;
            data.texts.str1 = this.InfoStrings[0];
            data.texts.str2 = this.InfoStrings[1];
            data.texts.str3 = this.InfoStrings[2];
            data.texts.str4 = this.InfoStrings[3];
            data.texts.str5 = this.InfoStrings[4];
            data.texts.str6 = this.InfoStrings[5];
            data.texts.str7 = this.InfoStrings[6];
            data.texts.str8 = this.InfoStrings[7];
            data.texts.str9 = this.InfoStrings[8];
            data.texts.str10 = this.InfoStrings[9];
            data.texts.str11 = this.InfoStrings[10];
            data.texts.str12 = this.InfoStrings[11];
            data.texts.str13 = this.InfoStrings[12];
            data.texts.str14 = this.InfoStrings[13];
            data.texts.str15 = this.InfoStrings[14];
            data.texts.str16 = this.InfoStrings[15];

            data.ot = this.Ot.Value;
            data.setcode = this.SetCode.Value;
            data.type = this.Type.Value;
            data.category = this.Category.Value;
            data.race = this.Race.Value;
            data.attribute = this.Attribute.Value;

            return data;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
