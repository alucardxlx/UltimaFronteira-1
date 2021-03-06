using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Fronteira.Talentos;
using Server.Mobiles;

namespace Server.Items
{
    public class Bladeweave : Habilidade
    {
        private class BladeWeaveRedirect
        {
            public Habilidade NewAbility;
            public int ClilocEntry;

            public BladeWeaveRedirect(Habilidade ability, int cliloc)
            {
                NewAbility = ability;
                ClilocEntry = cliloc;
            }
        }

        private static Dictionary<Mobile, BladeWeaveRedirect> m_NewAttack = new Dictionary<Mobile, BladeWeaveRedirect>();

        public static bool BladeWeaving(Mobile attacker, out Habilidade a)
        {
            BladeWeaveRedirect bwr;
            bool success = m_NewAttack.TryGetValue(attacker, out bwr);
            if (success)
                a = bwr.NewAbility;
            else
                a = null;

            return success;
        }

        public Bladeweave()
        {
        }

        public override int BaseMana { get { return 30; } }

        public override Talento TalentoParaUsar { get { return Talento.Hab_Bladeweave; } }

        public override bool OnBeforeSwing(Mobile attacker, Mobile defender)
        {
            if (!Validate(attacker) || !CheckMana(attacker, false))
                return false;

            int ran = -1;

            if (attacker is BaseCreature && PetTrainingHelper.CheckSecondarySkill((BaseCreature)attacker, SkillName.Bushido))
            {
                ran = Utility.Random(9);
            }
            else
            {
                bool canfeint = attacker.Skills[Habilidade.Feint.GetSecondarySkill(attacker)].Value >= Habilidade.Feint.GetRequiredSecondarySkill(attacker);
                bool canblock = attacker.Skills[Habilidade.Block.GetSecondarySkill(attacker)].Value >= Habilidade.Block.GetRequiredSecondarySkill(attacker);

                if (canfeint && canblock)
                {
                    ran = Utility.Random(9);
                }
                else if (canblock)
                {
                    ran = Utility.Random(8);
                }
                else
                {
                    ran = Utility.RandomList(0, 1, 2, 3, 4, 5, 6, 8);
                }
            }

            switch (ran)
            {
                case 0:
                    m_NewAttack[attacker] = new BladeWeaveRedirect(Habilidade.ArmorIgnore, 1028838);
                    break;
                case 1:
                    m_NewAttack[attacker] = new BladeWeaveRedirect(Habilidade.BleedAttack, 1028839);
                    break;
                case 2:
                    m_NewAttack[attacker] = new BladeWeaveRedirect(Habilidade.ConcussionBlow, 1028840);
                    break;
                case 3:
                    m_NewAttack[attacker] = new BladeWeaveRedirect(Habilidade.CrushingBlow, 1028841);
                    break;
                case 4:
                    m_NewAttack[attacker] = new BladeWeaveRedirect(Habilidade.DoubleStrike, 1028844);
                    break;
                case 5:
                    m_NewAttack[attacker] = new BladeWeaveRedirect(Habilidade.MortalStrike, 1028846);
                    break;
                case 6:
                    m_NewAttack[attacker] = new BladeWeaveRedirect(Habilidade.ParalyzingBlow, 1028848);
                    break;
                case 7:
                    m_NewAttack[attacker] = new BladeWeaveRedirect(Habilidade.Block, 1028853);
                    break;
                case 8:
                    m_NewAttack[attacker] = new BladeWeaveRedirect(Habilidade.Feint, 1028857);
                    break;
                default:
                    // should never happen
                    return false;
            }


            return ((BladeWeaveRedirect)m_NewAttack[attacker]).NewAbility.OnBeforeSwing(attacker, defender);
        }

        public override bool OnBeforeDamage(Mobile attacker, Mobile defender)
        {
            BladeWeaveRedirect bwr;
            if (m_NewAttack.TryGetValue(attacker, out bwr))
                return bwr.NewAbility.OnBeforeDamage(attacker, defender);
            else
                return base.OnBeforeDamage(attacker, defender);
        }

        public override void OnHit(Mobile attacker, Mobile defender, int damage)
        {
            if (CheckMana(attacker, false))
            {
                BladeWeaveRedirect bwr;
                if (m_NewAttack.TryGetValue(attacker, out bwr))
                {
                    attacker.SendLocalizedMessage(1072841, "#" + bwr.ClilocEntry.ToString());
                    bwr.NewAbility.OnHit(attacker, defender, damage);
                }
                else
                    base.OnHit(attacker, defender, damage);

                m_NewAttack.Remove(attacker);
                ClearCurrentAbility(attacker);
            }
        }

        public override void OnMiss(Mobile attacker, Mobile defender)
        {
            BladeWeaveRedirect bwr;
            if (m_NewAttack.TryGetValue(attacker, out bwr))
                bwr.NewAbility.OnMiss(attacker, defender);
            else
                base.OnMiss(attacker, defender);

            m_NewAttack.Remove(attacker);
        }
    }
}
