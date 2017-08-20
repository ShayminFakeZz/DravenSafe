﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EloBuddy;
using EloBuddy.Sandbox;
using EloBuddy.SDK.Events;
using SharpDX;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;


namespace DravenSafe
{
    class Program
    {

        private static Spell.Active Q, W;
        private static Spell.Skillshot E, R;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Spells()
        {
            Q = new Spell.Active(SpellSlot.Q);
            W = new Spell.Active(SpellSlot.W);
            E = new Spell.Skillshot(SpellSlot.E, 950, SkillShotType.Linear, 250, 1400, 130)
            {
                AllowedCollisionCount = -1
            };
            R = new Spell.Skillshot(SpellSlot.R, 30000, SkillShotType.Linear, 500, 2000, 160)
            {
                AllowedCollisionCount = int.MaxValue
            };

        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            //Return, falls der Champion nicht Draven ist.
            if (Player.Instance.ChampionName != "Draven")
            {
                Console.WriteLine(Player.Instance.ChampionName + " ist nicht Draven");
                return;
            }
            Chat.Print("Willkommen " + SandboxConfig.Username);
            Drawing.OnDraw += Drawing_OnDraw;
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            string playerName = "::";
            //Loopt durch alle Spieler im Team
            foreach (var hero in EntityManager.Heroes.Allies)
            {
                if (hero.ChampionName == "Draven")
                {
                    //playerName = summoner name
                    playerName = hero.Name;
                }
            }
            Drawing.DrawText(Drawing.Width - 200, Drawing.Height - 1000, System.Drawing.Color.OrangeRed, "|-- Draven by Ole & Julian --|\n" +
                "EB: " + SandboxConfig.Username + "\n" +
                "Buddy: " + SandboxConfig.IsBuddy + "\n" +
                "Summoner: " + playerName);


            Text buffActive = new Text();
            /*
            buffActive.Color = System.Drawing.Color.Orange;
            buffActive.Position = Drawing.WorldToScreen(new Vector3(Player.Instance.Position.X + 50, Player.Instance.Position.Y, Player.Instance.Position.Z));
            buffActive.TextValue = "LLLLLLLLLL";
            buffActive.Draw();
            */

            if (Player.HasBuff("dravenspinningattack"))
            {

                float buffEndTime = Player.GetBuff("dravenspinningattack").EndTime;
                var timeLeft = Math.Max(0, buffEndTime - Game.Time);
            }

        }


        private static void CreateMenu()
        {
        }

        private static void CastQ()
        {

        }

        private static void CastW()
        {

        }

        private static void CastE()
        {

        }

    }
}