using Server.Gumps;

namespace Server.Items
{
    public class PedraStatus : Item
    {
        [Constructable]
        public PedraStatus()
            : base(0xED4)
        {
            this.Name = "Pedra de Status";
            this.Movable = false;
            this.Weight = 0;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.InRange(this, 8))
            {
                from.SendGump(new PedraStatusGump(from));
            }
            else
            {
                from.SendMessage(0x00FE, "Você está muito longe.");
            }
        }

        public PedraStatus(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
