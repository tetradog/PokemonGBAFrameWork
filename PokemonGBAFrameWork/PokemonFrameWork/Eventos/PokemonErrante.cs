﻿/*
 * Created by SharpDevelop.
 * User: Pikachu240
 * Date: 14/03/2017
 * Time: 17:11
 * 
 * Código bajo licencia GNU
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Gabriel.Cat.S.Binaris;
using Gabriel.Cat.S.Extension;
using Gabriel.Cat.S.Utilitats;
using Poke;
using PokemonGBAFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonGBAFrameWork
{
    /// <summary>
    /// Description of PokemonErrante.
    /// </summary>
    public static class PokemonErrante
    {
        public class Ruta
        {
            public const byte ID = 0x10;
            public const int MAXLENGTH = 7;
            public const byte MAXIMODERUTAS = byte.MaxValue - 1;
            public static readonly ElementoBinario Serializador = ElementoBinario.GetSerializador<Ruta>();

            public static readonly Variable VariableBancoMapaRutaValido;
            public static readonly Variable VariableColumnasFilaRuta;
            public static readonly Variable VariableOffsetTablaFilasRuta;
            public static readonly Variable VariableOffSetRutina1;
            public static readonly Variable VariableOffSetRutina2;
            public static readonly Variable VariableOffSetRutina3;

            static Ruta()
            {
                VariableBancoMapaRutaValido = new Variable("Pokemon Errante Banco Mapa Ruta Valido");
                VariableColumnasFilaRuta = new Variable("Pokemon Errante Columnas Fila Ruta");
                VariableOffsetTablaFilasRuta = new Variable("Pokemon Errante Offset Tabla Filas Ruta");
                VariableOffSetRutina1 = new Variable("Pokemon Errante OffSet Rutina 1");
                VariableOffSetRutina2 = new Variable("Pokemon Errante OffSet Rutina 2");
                VariableOffSetRutina3 = new Variable("Pokemon Errante OffSet Rutina 3");

                VariableBancoMapaRutaValido.Add(0, EdicionPokemon.EsmeraldaUsa10, EdicionPokemon.EsmeraldaEsp10);
                VariableBancoMapaRutaValido.Add(3, EdicionPokemon.RojoFuegoUsa10, EdicionPokemon.VerdeHojaUsa10, EdicionPokemon.RojoFuegoEsp10, EdicionPokemon.VerdeHojaEsp10);

                //creo...no se donde se mira...
                VariableBancoMapaRutaValido.Add(0, EdicionPokemon.ZafiroEsp10, EdicionPokemon.ZafiroUsa10, EdicionPokemon.ZafiroUsa11, EdicionPokemon.ZafiroUsa12);
                VariableBancoMapaRutaValido.Add(0, EdicionPokemon.RubiEsp10, EdicionPokemon.RubiUsa10, EdicionPokemon.RubiUsa11, EdicionPokemon.RubiUsa12);


                VariableColumnasFilaRuta.Add(6, EdicionPokemon.EsmeraldaUsa10, EdicionPokemon.EsmeraldaEsp10);
                VariableColumnasFilaRuta.Add(7, EdicionPokemon.RojoFuegoUsa10, EdicionPokemon.VerdeHojaUsa10, EdicionPokemon.RojoFuegoEsp10, EdicionPokemon.VerdeHojaEsp10);
                //sacado de pokeruby :D
                VariableColumnasFilaRuta.Add(6, EdicionPokemon.ZafiroEsp10, EdicionPokemon.ZafiroUsa10, EdicionPokemon.ZafiroUsa11, EdicionPokemon.ZafiroUsa12);
                VariableColumnasFilaRuta.Add(6, EdicionPokemon.RubiEsp10, EdicionPokemon.RubiUsa10, EdicionPokemon.RubiUsa11, EdicionPokemon.RubiUsa12);

                VariableOffsetTablaFilasRuta.Add(EdicionPokemon.EsmeraldaEsp10, 0xD5A140);
                VariableOffsetTablaFilasRuta.Add(EdicionPokemon.RojoFuegoEsp10, 0x64C685);

                //investigando zonaOffsetTablaFilasRuta
                VariableOffsetTablaFilasRuta.Add(EdicionPokemon.EsmeraldaUsa10, 0xD5A144);
                VariableOffsetTablaFilasRuta.Add(EdicionPokemon.VerdeHojaEsp10, 0x64BD7D);
                VariableOffsetTablaFilasRuta.Add(EdicionPokemon.VerdeHojaUsa10, 0x655665, 0x6556D5);
                VariableOffsetTablaFilasRuta.Add(EdicionPokemon.RojoFuegoUsa10, 0x655D89, 0x655DE9);
                //investigando con la info de pokeruby
                VariableOffsetTablaFilasRuta.Add(EdicionPokemon.RubiEsp10, 0x406D90);
                VariableOffsetTablaFilasRuta.Add(EdicionPokemon.ZafiroEsp10, 0x406ACC);
                VariableOffsetTablaFilasRuta.Add(EdicionPokemon.RubiUsa10, 0x402E80, 0x402E9C);
                VariableOffsetTablaFilasRuta.Add(EdicionPokemon.ZafiroUsa10, 0x402ED8, 0x402EF8);

                //esta parte en pokeruby no se donde se mira...
                VariableOffSetRutina1.Add(EdicionPokemon.EsmeraldaEsp10, 0x161928);
                VariableOffSetRutina1.Add(EdicionPokemon.RojoFuegoEsp10, 0x141D6E);

                //investigacion a ciegas
                VariableOffSetRutina1.Add(EdicionPokemon.EsmeraldaUsa10, 0x161C84);
                VariableOffSetRutina1.Add(EdicionPokemon.VerdeHojaEsp10, 0x141D46);
                VariableOffSetRutina1.Add(EdicionPokemon.VerdeHojaUsa10, 0x141B6A, 0x141BE2);
                VariableOffSetRutina1.Add(EdicionPokemon.RojoFuegoUsa10, 0x141B92, 0x141C0A);

                VariableOffSetRutina2.Add(EdicionPokemon.EsmeraldaEsp10, 0x1619c6);
                VariableOffSetRutina2.Add(EdicionPokemon.RojoFuegoEsp10, 0x141df6);

                //investigacion a ciegas
                VariableOffSetRutina2.Add(EdicionPokemon.EsmeraldaUsa10, 0x161D22);
                VariableOffSetRutina2.Add(EdicionPokemon.VerdeHojaEsp10, 0x141D88);
                VariableOffSetRutina2.Add(EdicionPokemon.VerdeHojaUsa10, 0x141BAC, 0x141C24);
                VariableOffSetRutina2.Add(EdicionPokemon.RojoFuegoUsa10, 0x141BD4, 0x141C4C);

                VariableOffSetRutina3.Add(EdicionPokemon.EsmeraldaEsp10, 0x161A82);
                VariableOffSetRutina3.Add(EdicionPokemon.RojoFuegoEsp10, 0x141EAE);

                //investigacion a ciegas
                VariableOffSetRutina3.Add(EdicionPokemon.EsmeraldaUsa10, 0x161DDE);
                VariableOffSetRutina3.Add(EdicionPokemon.VerdeHojaEsp10, 0x141E86);
                VariableOffSetRutina3.Add(EdicionPokemon.VerdeHojaUsa10, 0x141CAA, 0x141D22);
                VariableOffSetRutina3.Add(EdicionPokemon.RojoFuegoUsa10, 0x141CD2, 0x141D4A);


            }

            public byte[] Rutas { get; set; }


            public Ruta()
            {
                Rutas = new byte[MAXLENGTH];
            }

            public static Paquete GetRutas(RomGba rom)
            {
                return rom.GetPaquete("Rutas pokemon errante", (r, i) => GetRuta(r, i), rom.Data[Variable.GetVariable(VariableOffSetRutina1, rom.Edicion)]);

            }

            public static PokemonGBAFramework.Eventos.PokemonErrante.Ruta GetRuta(RomGba rom, int posicion)
            {
                int columnas = Variable.GetVariable(VariableColumnasFilaRuta, rom.Edicion);
                Ruta ruta = new Ruta();
                BloqueBytes bloqueDatos = BloqueBytes.GetBytes(rom.Data, Variable.GetVariable(VariableOffsetTablaFilasRuta, rom.Edicion), columnas * rom.Data[Variable.GetVariable(VariableOffSetRutina1, rom.Edicion)]);

                for (int j = 0; j < columnas; j++)
                    ruta.Rutas[j] = bloqueDatos.Bytes[posicion * columnas + j];
                return new PokemonGBAFramework.Eventos.PokemonErrante.Ruta() { Rutas = ruta.Rutas.Casting<int>() };

            }

        }
        public class Pokemon
        {


            public const byte ID = 0x11;
            public static readonly ElementoBinario Serializador = ElementoBinario.GetSerializador<Pokemon>();

            public static readonly Variable VariableSpecialPokemonErrante;
            public static readonly Variable VariablePokemonErranteVar;
            public static readonly Variable VariableVitalidadVar;
            public static readonly Variable VariableNivelYEstadoVar;
            public static readonly Variable VariableDisponibleVar;

            public const int MAXTURNOSDORMIDO = 7;



            //falta Rubi y Zafiro esp y usa
            static Pokemon()
            {
                VariableSpecialPokemonErrante = new Variable("Pokemon Errante Special");
                VariablePokemonErranteVar = new Variable("Pokemon Errante Var");
                VariableVitalidadVar = new Variable("Pokemon Errante Vitalidad Var");
                VariableNivelYEstadoVar = new Variable("Pokemon Errante Nivel Y Estado Var");
                VariableDisponibleVar = new Variable("Pokemon Errante Disponible Var");

                //pongo los datos encontrados


                VariableSpecialPokemonErrante.Add(0x12B, EdicionPokemon.EsmeraldaUsa10, EdicionPokemon.EsmeraldaEsp10);
                VariableSpecialPokemonErrante.Add(0x129, EdicionPokemon.RojoFuegoUsa10, EdicionPokemon.VerdeHojaUsa10, EdicionPokemon.RojoFuegoEsp10, EdicionPokemon.VerdeHojaEsp10);

                //creo mirar como se asigna el numero def_special InitRoamer /data/specials.inc mirar esto	clear flag FLAG_SYS_TV_LATI	setflag FLAG_LATIOS_OR_LATIAS_ROAMING
                VariableSpecialPokemonErrante.Add(0x12B, EdicionPokemon.ZafiroEsp10, EdicionPokemon.ZafiroUsa10, EdicionPokemon.ZafiroUsa11, EdicionPokemon.ZafiroUsa12);
                VariableSpecialPokemonErrante.Add(0x12B, EdicionPokemon.RubiEsp10, EdicionPokemon.RubiUsa10, EdicionPokemon.RubiUsa11, EdicionPokemon.RubiUsa12);

                //-4 en la var del pokemon para los datos encripatos :D
                VariablePokemonErranteVar.Add(0x4F24, EdicionPokemon.EsmeraldaUsa10, EdicionPokemon.EsmeraldaEsp10);
                VariablePokemonErranteVar.Add(0x506C, EdicionPokemon.RojoFuegoEsp10, EdicionPokemon.VerdeHojaEsp10);
                VariablePokemonErranteVar.Add(EdicionPokemon.VerdeHojaUsa10, 0x5100, 0x5114);
                VariablePokemonErranteVar.Add(EdicionPokemon.RojoFuegoUsa10, 0x5100, 0x5114);

                //investigacion mia :D
                VariablePokemonErranteVar.Add(0x4B54, EdicionPokemon.RubiEsp10);

                VariableVitalidadVar.Add(0x4F25, EdicionPokemon.EsmeraldaUsa10, EdicionPokemon.EsmeraldaEsp10);
                VariableVitalidadVar.Add(0x506D, EdicionPokemon.RojoFuegoEsp10, EdicionPokemon.VerdeHojaEsp10);
                VariableVitalidadVar.Add(EdicionPokemon.VerdeHojaUsa10, 0x5101, 0x5115);
                VariableVitalidadVar.Add(EdicionPokemon.RojoFuegoUsa10, 0x5101, 0x5115);//logica
                                                                                        //logica
                VariableVitalidadVar.Add(0x4B55, EdicionPokemon.RubiEsp10);

                VariableNivelYEstadoVar.Add(0x4F26, EdicionPokemon.EsmeraldaUsa10, EdicionPokemon.EsmeraldaEsp10);
                VariableNivelYEstadoVar.Add(0x506E, EdicionPokemon.RojoFuegoEsp10, EdicionPokemon.VerdeHojaEsp10);

                VariableNivelYEstadoVar.Add(EdicionPokemon.VerdeHojaUsa10, 0x5102, 0x5116);//logica
                VariableNivelYEstadoVar.Add(EdicionPokemon.RojoFuegoUsa10, 0x5102, 0x5116);//logica
                                                                                           //logica
                VariableNivelYEstadoVar.Add(0x4B56, EdicionPokemon.RubiEsp10);

                VariableDisponibleVar.Add(0x5F29, EdicionPokemon.EsmeraldaUsa10, EdicionPokemon.EsmeraldaEsp10);
                VariableDisponibleVar.Add(0x5071, EdicionPokemon.RojoFuegoEsp10, EdicionPokemon.VerdeHojaEsp10);

                VariableDisponibleVar.Add(EdicionPokemon.VerdeHojaUsa10, 0x5105, 0x5119);//logica
                VariableDisponibleVar.Add(EdicionPokemon.RojoFuegoUsa10, 0x5105, 0x5119);//logica
                                                                                         //logica
                VariableDisponibleVar.Add(0x4B59, EdicionPokemon.RubiEsp10);
            }


            public static Script GetScript(Edicion edicion, PokemonGBAFramework.Eventos.PokemonErrante pokemonErrante)
            {
                Hex nivelYEstado;
                string estado, nivel;
                ushort auxNivelYEstado;
                Script scriptPokemonErrante = new Script();
                scriptPokemonErrante.ComandosScript.Add(new ComandosScript.Special(new Word((ushort)Variable.GetVariable(VariableSpecialPokemonErrante, edicion))));
                scriptPokemonErrante.ComandosScript.Add(new ComandosScript.SetVar(new Word((ushort)Variable.GetVariable(VariablePokemonErranteVar, edicion)), pokemonErrante.Pokemon));
                scriptPokemonErrante.ComandosScript.Add(new ComandosScript.SetVar(new Word((ushort)Variable.GetVariable(VariableVitalidadVar, edicion)), pokemonErrante.Vida));
                estado = ((Hex)pokemonErrante.GetStats()).ToString().PadLeft(2, '0');
                nivel = ((Hex)((byte)pokemonErrante.Nivel)).ToString();
                nivelYEstado = (Hex)(estado + nivel);
                auxNivelYEstado = (ushort)(uint)nivelYEstado;
                scriptPokemonErrante.ComandosScript.Add(new ComandosScript.SetVar(new Word((ushort)Variable.GetVariable(VariableNivelYEstadoVar, edicion)), new Word(auxNivelYEstado)));//por mirar
                return scriptPokemonErrante;


            }

        }

        public static readonly Creditos Creditos;
        static PokemonErrante()
        {
            Creditos = new Creditos();
            Creditos.Add(Creditos.Comunidades[Creditos.WAHACKFORO], "Ratzhier", "Investigación");
        }
        public static bool EsCompatible(EdicionPokemon edicion, Compilacion compilacion)
        {
            return Ruta.VariableBancoMapaRutaValido.Diccionario.ContainsKey(compilacion) && Ruta.VariableBancoMapaRutaValido.Diccionario[compilacion].ContainsKey(edicion);
        }


    }
}
