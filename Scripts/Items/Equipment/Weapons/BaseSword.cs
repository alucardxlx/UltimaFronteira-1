using System;
using Server.Targets;

namespace Server.Items
{
    public abstract class BaseSword : BaseMeleeWeapon
    {
        public BaseSword(int itemID)
            : base(itemID)
        {
        }

        public BaseSword(Serial serial)
            : base(serial)
        {
        }

        public override SkillName DefSkill
        {
            get
            {
                return SkillName.Swords;
            }
        }
        public override WeaponType DefType
        {
            get
            {
                return WeaponType.Slashing;
            }
        }
        public override WeaponAnimation DefAnimation
        {
            get
            {
                return WeaponAnimation.Slash1H;
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

        public override void OnDoubleClick(Mobile from)
        {
            from.SendLocalizedMessage(1010018); // What do you want to use this item on?

            from.Target = new BladedItemTarget(this);
        }

        public override void OnHit(Mobile attacker, IDamageable defender, double damageBonus)
        {
            base.OnHit(attacker, defender, damageBonus);

            if (Habilidade.GetCurrentAbility(attacker) is InfectiousStrike)
                return;

            if (!Core.AOS && defender is Mobile && this.Poison != null && this.PoisonCharges > 0)
            {
                if (Utility.RandomDouble() <= 0.1)
                {
                    --this.PoisonCharges;
                    ((Mobile)defender).ApplyPoison(attacker, this.Poison);
                }
            }
        }
    }
}
