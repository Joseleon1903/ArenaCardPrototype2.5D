using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerUtilConstant
    {

        public enum Estatus
        {
            [StringValue("ONLINE")]  // el jugador se encuentra conectado al juego 
            Online,

            [StringValue("OFLINE")] // el jugador no se encuentra connectado al juego
            Ofline,

            [StringValue("INGAME")] // el jugador se encuentra en una partida
            InGame,

            [StringValue("OCUPADE")] // el jugador se encuentra ocupado esto previene bloquea peticiones de otros jugadores
            Ocupade
      
        }

        public enum Platform
        {
            [StringValue("ANDROID")]  // el jugador se encuentra conectado al juego 
            Android,

            [StringValue("WINDOWS")] // el jugador no se encuentra connectado al juego
            Windows,

            [StringValue("WEBBROWSER")] // el jugador se encuentra en una partida
            WebBrowser,

        }


        public class StringValueAttribute : Attribute
        {
            public string Value { get; }

            public StringValueAttribute(string value)
            {
                Value = value;
            }
        }

    }
}