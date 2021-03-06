using System;
using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishMaul))]
    [FlipableAttribute(0x143B, 0x143A)]
    public class Maul : BaseBashing
    {
        [Constructable]
        public Maul()
            : base(0x143B)
        {
            this.Weight = 10.0;
            Name = "Maca Longa";
        }

        public Maul(Serial serial)
            : base(serial)
        {
        }

        public override Habilidade PrimaryAbility
        {
            get
            {
                return Habilidade.DoubleStrike;
            }
        }
        public override Habilidade SecondaryAbility
        {
            get
            {
                return Habilidade.ConcussionBlow;
            }
        }
        public override int AosStrengthReq
        {
            get
            {
                return 45;
            }
        }
        public override int AosMinDamage
        {
            get
            {
                return 14;
            }
        }
        public override int AosMaxDamage
        {
            get
            {
                return 18;
            }
        }
        public override int AosSpeed
        {
            get
            {
                return 32;
            }
        }
        public override float MlSpeed
        {
            get
            {
                return 3.50f;
            }
        }
        public override int OldStrengthReq
        {
            get
            {
                return 20;
            }
        }
        public override int OldMinDamage
        {
            get
            {
                return 15;
            }
        }
        public override int OldMaxDamage
        {
            get
            {
                return 34;
            }
        }
        public override int OldSpeed
        {
            get
            {
                return 30;
            }
        }
        public override int InitMinHits
        {
            get
            {
                return 31;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 70;
            }
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (this.Weight == 14.0)
                this.Weight = 10.0;
        }
    }
}
