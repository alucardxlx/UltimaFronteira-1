using Server.Items;
using System;

namespace Server.Mobiles
{
    [CorpseName("a wolf corpse")]
    [TypeAlias("Server.Mobiles.SavagePackwolf")]
    public class SavagePackWolfy : BaseCreature
    {
        [Constructable]
        public SavagePackWolfy()
            : base(AIType.AI_Melee, FightMode.Weakest, 10, 1, 0.2, 0.4)
        {
            Name = "lobo selvagem";
            Body = 0xE1;
            BaseSoundID = 0xE5;

            SetStr(100, 116);
            SetDex(51, 61);
            SetInt(11, 21);

            SetHits(100, 200);
            SetMana(0);

            SetDamage(9, 12);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 50, 60);
            SetResistance(ResistanceType.Fire, 50, 60);
            SetResistance(ResistanceType.Cold, 60, 70);
            SetResistance(ResistanceType.Poison, 50, 60);
            SetResistance(ResistanceType.Energy, 50, 60);

            SetSkill(SkillName.MagicResist, 60.7, 74.0);
            SetSkill(SkillName.Tactics, 80.9, 94.4);
            SetSkill(SkillName.Wrestling, 89.0, 97.1);

            Fame = 450;
            Karma = -450;

            VirtualArmor = 26;
            Tamable = false;

            SetWeaponAbility(Habilidade.BleedAttack);
        }

        public SavagePackWolfy(Serial serial)
            : base(serial)
        {
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override int Meat { get { return 1; } }
        public override int Hides { get { return 5; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }

        public override void Serialize(GenericWriter writer)
        {
            /*
            writer.Write((int)0);
            base.Serialize(writer);
           */
        }

        public override void Deserialize(GenericReader reader)
        {
            /*
            base.Deserialize(reader);
            int version = reader.ReadInt();
            Timer.DelayCall(TimeSpan.FromSeconds(5), () =>
            {
                this.Delete();
            });
            */
        }
    }
}
