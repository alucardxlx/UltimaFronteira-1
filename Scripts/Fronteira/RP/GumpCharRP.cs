
//////////////////////////////////////////////////////////////////////
// Automatically generated by Bradley's GumpStudio and roadmaster's 
// exporter.dll,  Special thanks goes to Daegon whose work the exporter
// was based off of, and Shadow wolf for his Template Idea.
//////////////////////////////////////////////////////////////////////
#define RunUo2_0

using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Mobiles;
using Server.Accounting;

namespace Server.Gumps
{
    public class GumpCharRP : Gump
    {
        Mobile caller;

        public GumpCharRP(Mobile from) : this()
        {
            caller = from;
        }

        public GumpCharRP() : base(0, 0)
        {
            this.Closable = false;
            this.Disposable = false;
            this.Dragable = true;
            this.Resizable = false;

            AddPage(0);
            AddBackground(210, 220, 507, 392, 9200);
            AddHtml(366, 234, 200, 23, @"Criar Personagem RP ?", (bool)false, (bool)false);
            AddBackground(223, 275, 476, 250, 5150);
            AddHtml(250, 306, 422, 24, @"- Perma Death (Zerar pontos de vida, personagem deletado)", (bool)false, (bool)false);
            AddHtml(251, 334, 422, 24, @"- Nao tem .pvm ou .login", (bool)false, (bool)false);
            AddHtml(251, 361, 422, 24, @"- RP Obrigatorio", (bool)false, (bool)false);
            AddHtml(251, 388, 432, 24, @"- So pode ser PKlizado ou Looteado por Personagem RP", (bool)false, (bool)false);
            AddHtml(252, 415, 432, 24, @"- Nao tem a tag de (Novato)", (bool)false, (bool)false);
            AddHtml(252, 442, 432, 24, @"- Nao pode alterar template", (bool)false, (bool)false);
            AddHtml(252, 469, 432, 24, @"- Nao pode usar 'Estou Preso'", (bool)false, (bool)false);
            AddHtml(414, 278, 77, 25, @"Contrato", (bool)false, (bool)false);
            AddButton(241, 572, 1154, 1154, (int)Buttons.RP, GumpButtonType.Reply, 0);
            AddHtml(242, 525, 440, 24, @"Ver Regras em www.ultimafronteirashard.com.br/wiki", (bool)true, (bool)false);
            AddHtml(273, 570, 182, 24, @"Personagem RP", (bool)false, (bool)false);
            AddButton(499, 572, 1151, 1151, (int)Buttons.NORMAL, GumpButtonType.Reply, 0);
            AddHtml(530, 571, 182, 24, @"Personagem NORMAL", (bool)false, (bool)false);
        }

        public enum Buttons
        {
            Nada,
            RP,
            NORMAL,
        }

        public static Point3D CharRP = new Point3D(1769, 1128, 1);

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            var from = sender.Mobile as PlayerMobile;

            switch (info.ButtonID)
            {
                case (int)Buttons.RP:
                    {
                        from.MoveToWorld(CharRP, Map.Felucca);
                        from.SendMessage("Voce criou um personagem RP");
                        from.RP = true;
                        from.PatenteRP = Fronteira.RP.PatenteRP.Aspirante;
                        from.Young = false;
                        //var acc = from.Account as Account;
                        //acc.RP = false;
                        from.SendGump(new GumpLore(from));
                        break;
                    }
                case (int)Buttons.Nada:
                case (int)Buttons.NORMAL:
                    {
                        from.SendMessage("Voce criou um personagem NORMAL");
                        from.RP = false;
                        from.SendGump(new GumpLore(from));
                        break;
                    }

            }
        }
    }
}
