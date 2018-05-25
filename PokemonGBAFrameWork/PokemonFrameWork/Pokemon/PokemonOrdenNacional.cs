﻿using Gabriel.Cat.S.Binaris;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonGBAFrameWork.Pokemon
{
    public class OrdenNacional:IElementoBinarioComplejo
    {
        public static readonly Zona ZonaOrdenNacional;
        public static readonly ElementoBinario Serializador = ElementoBinarioNullable.GetElementoBinario(typeof(OrdenNacional));

        public Word Orden { get; set; }

        ElementoBinario IElementoBinarioComplejo.Serialitzer => Serializador;

        static OrdenNacional()
        {
            ZonaOrdenNacional = new Zona("Orden Nacional");

            //orden nacional
            ZonaOrdenNacional.Add(0x3FA08, EdicionPokemon.RubiEsp, EdicionPokemon.ZafiroEsp);
            ZonaOrdenNacional.Add(0x3F83C, EdicionPokemon.RubiUsa, EdicionPokemon.ZafiroUsa);
            ZonaOrdenNacional.Add(0x43128, EdicionPokemon.RojoFuegoEsp, EdicionPokemon.VerdeHojaEsp);
            ZonaOrdenNacional.Add(EdicionPokemon.RojoFuegoUsa, 0x4323C, 0x43250);
            ZonaOrdenNacional.Add(EdicionPokemon.VerdeHojaUsa, 0x4323C, 0x43250);
            ZonaOrdenNacional.Add(0x6D448, EdicionPokemon.EsmeraldaUsa, EdicionPokemon.EsmeraldaEsp);


        }

        public static OrdenNacional GetOrdenNacional(RomGba rom,int posicion)
        {
            OrdenNacional ordenNacional = new OrdenNacional();
            try
            {
                ordenNacional.Orden = new Word(rom, Zona.GetOffsetRom(ZonaOrdenNacional, rom).Offset + (posicion- 1) * 2);
            }
            catch {
                ordenNacional.Orden = null;
            }
            return ordenNacional;
        }
        public static OrdenNacional[] GetOrdenNacional(RomGba rom)
        {
            OrdenNacional[] oredenesNacional = new OrdenNacional[Huella.GetTotal(rom)];
            for (int i = 0; i < oredenesNacional.Length; i++)
                oredenesNacional[i] = GetOrdenNacional(rom, i);
            return oredenesNacional;
        }
        public static void SetOrdenNacional(RomGba rom,int posicion,OrdenNacional orden)
        {
            Word.SetData(rom, Zona.GetOffsetRom(ZonaOrdenNacional, rom).Offset + posicion * Word.LENGTH, orden.Orden==null?new Word(0):orden.Orden);

        }
        public static void SetOrdenNacional(RomGba rom,IList<OrdenNacional> ordenes)
        {
            rom.Data.Remove(Zona.GetOffsetRom(ZonaOrdenNacional, rom).Offset, Huella.GetTotal(rom) * Word.LENGTH);
            OffsetRom.SetOffset(rom, Zona.GetOffsetRom(ZonaOrdenNacional, rom), rom.Data.SearchEmptyBytes(ordenes.Count * Word.LENGTH));
            for (int i = 0; i < ordenes.Count; i++)
                SetOrdenNacional(rom, i, ordenes[i]);
        }
    }
}