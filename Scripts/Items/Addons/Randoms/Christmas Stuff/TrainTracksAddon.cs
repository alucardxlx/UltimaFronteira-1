////////////////////////////////////////
//                                    //
//   Generated by CEO's YAAAG - V1.2  //
// (Yet Another Arya Addon Generator) //
//                                    //
////////////////////////////////////////

namespace Server.Items
{
    public class TrainTracksAddon : BaseAddon
    {
        public override BaseAddonDeed Deed { get { return new TrainTracksAddonDeed(); } }

        [Constructable]
        public TrainTracksAddon()
        {
            AddComplexComponent((BaseAddon)this, 4697, 1, -3, 0, 2101, -1, "train tracks", 1); // 1
            AddComplexComponent((BaseAddon)this, 4696, 0, -3, 0, 2101, -1, "train tracks", 1); // 2
            AddComplexComponent((BaseAddon)this, 4697, 1, 4, 0, 2101, -1, "train tracks", 1); // 3
            AddComplexComponent((BaseAddon)this, 4697, 1, 3, 0, 2101, -1, "train tracks", 1); // 4
            AddComplexComponent((BaseAddon)this, 4697, 1, 2, 0, 2101, -1, "train tracks", 1); // 5
            AddComplexComponent((BaseAddon)this, 4697, 1, 1, 0, 2101, -1, "train tracks", 1); // 6
            AddComplexComponent((BaseAddon)this, 4697, 1, 0, 0, 2101, -1, "train tracks", 1); // 7
            AddComplexComponent((BaseAddon)this, 4697, 1, -1, 0, 2101, -1, "train tracks", 1); // 8
            AddComplexComponent((BaseAddon)this, 4697, 1, -2, 0, 2101, -1, "train tracks", 1); // 9
            AddComplexComponent((BaseAddon)this, 4696, 0, 4, 0, 2101, -1, "train tracks", 1); // 10
            AddComplexComponent((BaseAddon)this, 4696, 0, 3, 0, 2101, -1, "train tracks", 1); // 11
            AddComplexComponent((BaseAddon)this, 4696, 0, 2, 0, 2101, -1, "train tracks", 1); // 12
            AddComplexComponent((BaseAddon)this, 4696, 0, 1, 0, 2101, -1, "train tracks", 1); // 13
            AddComplexComponent((BaseAddon)this, 4696, 0, 0, 0, 2101, -1, "train tracks", 1); // 14
            AddComplexComponent((BaseAddon)this, 4696, 0, -1, 0, 2101, -1, "train tracks", 1); // 15
            AddComplexComponent((BaseAddon)this, 4696, 0, -2, 0, 2101, -1, "train tracks", 1); // 16
        }

        public TrainTracksAddon(Serial serial)
            : base(serial)
        { }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset,
            int hue, int lightsource)
        {
            AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null, 1);
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset,
            int hue, int lightsource, string name, int amount)
        {
            AddonComponent ac;
            ac = new AddonComponent(item);
            if (name != null && name.Length > 0)
            {
                ac.Name = name;
            }
            if (hue != 0)
            {
                ac.Hue = hue;
            }
            if (amount > 1)
            {
                ac.Stackable = true;
                ac.Amount = amount;
            }
            if (lightsource != -1)
            {
                ac.Light = (LightType)lightsource;
            }
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TrainTracksAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new TrainTracksAddon(); } }

        [Constructable]
        public TrainTracksAddonDeed()
        {
            Name = "TrainTracks";
        }

        public TrainTracksAddonDeed(Serial serial)
            : base(serial)
        { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}