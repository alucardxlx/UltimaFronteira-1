using System;

namespace Server.Items
{
    public class TownTrashBarrel : Container
    {
        [Constructable]
        public TownTrashBarrel()
            : base(0xE77)
        {
            this.Movable = true;
            this.Name = "Lixeira";
        }

        public TownTrashBarrel(Serial serial)
            : base(serial)
        {
        }

        private static string[] msg = new string[] {
            "om nom nom", "que delicia", "quero mais", "tem um salzinho ?", "adoro lixo", "opa", "boa", "que otimo",
            "mais mais", "tem mais ai ?", "muito bom"
        };

        public override int LabelNumber
        {
            get
            {
                return 1041064;
            }
        }// a trash barrel
        public override int DefaultMaxWeight
        {
            get
            {
                return 0;
            }
        }// A value of 0 signals unlimited weight
        public override bool IsDecoContainer
        {
            get
            {
                return false;
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
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            if(this.RootParent is Mobile)
            {
                return false;
            }

            if (!base.OnDragDrop(from, dropped))
                return false;


            if(dropped is PotionKeg)
            {
                var keg = dropped as PotionKeg;
                if(keg.Held > 0)
                {
                    from.SendMessage("Voce esvaziou o barril");
                    keg.Held = 0;
                    return false;
                }
            
            }

            this.PublicOverheadMessage(Network.MessageType.Regular, 0x3B2, false, msg[Utility.Random(msg.Length)]);
            dropped.Delete();

            return true;
        }

        public override bool OnDragDropInto(Mobile from, Item item, Point3D p)
        {
            if (this.RootParent is Mobile)
            {
                return false;
            }

            if (!base.OnDragDropInto(from, item, p))
                return false;

            this.PublicOverheadMessage(Network.MessageType.Regular, 0x3B2, false, msg[Utility.Random(msg.Length)]);
            item.Delete();

            return true;
        }
    }
}
