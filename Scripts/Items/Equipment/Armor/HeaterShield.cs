using System;
using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(LargePlateShield))]
    public class HeaterShield : BaseShield
    {
        [Constructable]
        public HeaterShield()
            : base(0x1B76)
        {
            this.Weight = 20.0;
            this.Name = "Escudo Grande";
        }

        public HeaterShield(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance
        {
            get
            {
                return 0;
            }
        }

        public override int BaseFireResistance
        {
            get
            {
                return 1;
            }
        }

        public override int BaseColdResistance
        {
            get
            {
                return 0;
            }
        }

        public override int BasePoisonResistance
        {
            get
            {
                return 0;
            }
        }

        public override int BaseEnergyResistance
        {
            get
            {
                return 0;
            }
        }

        public override int InitMinHits
        {
            get
            {
                return 50;
            }
        }

        public override int InitMaxHits
        {
            get
            {
                return 65;
            }
        }

        public override int AosStrReq
        {
            get
            {
                return 90;
            }
        }

        public override int OldStrReq
        {
            get
            {
                return 90;
            }
        }

        public override int ArmorBase
        {
            get
            {
                return 20;
            }
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version
        }
    }
}
