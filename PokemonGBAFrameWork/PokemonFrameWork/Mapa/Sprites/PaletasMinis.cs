﻿/*
 * Creado por SharpDevelop.
 * Usuario: pikachu240
 * Fecha: 24/05/2017
 * Hora: 2:46
 * Licencia GNU GPL V3
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 *
 */
using System;
using Gabriel.Cat.S.Utilitats;

using Gabriel.Cat.S.Extension;
using Gabriel.Cat.S.Binaris;

namespace PokemonGBAFrameWork.Mini
{
	/// <summary>
	/// Description of PaletasMinis.
	/// </summary>
	public class Paletas:IElementoBinarioComplejo
	{
        public const byte ID = 0x13;
        public static readonly ElementoBinario Serializador = ElementoBinario.GetSerializador<Paleta>();

        public static readonly Zona ZonaMiniSpritesPaleta;
		Llista<Paleta> paletas;
		static Paletas()
		{
			ZonaMiniSpritesPaleta=new Zona("Mini sprites OverWorld-Paleta");
			//Esmeralda
			ZonaMiniSpritesPaleta.Add(EdicionPokemon.EsmeraldaUsa10,0x8E8BC);
			ZonaMiniSpritesPaleta.Add(EdicionPokemon.EsmeraldaEsp10,0x8E8D0);
			//Rojo y Verde
			ZonaMiniSpritesPaleta.Add(EdicionPokemon.RojoFuegoUsa10,0x5F4D8,0x5F4EC);
			ZonaMiniSpritesPaleta.Add(EdicionPokemon.VerdeHojaUsa10,0x5F4D8,0x5F4EC);
			ZonaMiniSpritesPaleta.Add(EdicionPokemon.RojoFuegoEsp10,0x5F5AC);
			ZonaMiniSpritesPaleta.Add(EdicionPokemon.VerdeHojaEsp10,0x5F5AC);
			//Rubi y Zafiro
			ZonaMiniSpritesPaleta.Add(EdicionPokemon.RubiUsa10,0x5BE20,0x5BE40);
			ZonaMiniSpritesPaleta.Add(EdicionPokemon.ZafiroUsa10,0x5BE24,0x5BE44);
			ZonaMiniSpritesPaleta.Add(EdicionPokemon.RubiEsp10,0x5C25C);
			ZonaMiniSpritesPaleta.Add(EdicionPokemon.ZafiroEsp10,0x5C260);
			
			
		}
		public Paletas()
		{
			paletas=new Llista<Paleta>();
		}

		public Llista<Paleta> PaletasMinis {
			get {
				return paletas;
			}
		}

        ElementoBinario IElementoBinarioComplejo.Serialitzer => Serializador;

        public Paleta this[byte idPaleta]
		{
			get{
				return paletas.Filtra((p)=>p.SortID==idPaleta)[0];
			}
		}

		public static Paletas GetPaletasMinis(RomGba rom)
		{
			Paletas paletas=new Paletas();
			//obtengo la paleta
			int	offsetTablaPaleta=Zona.GetOffsetRom(ZonaMiniSpritesPaleta, rom).Offset;
			try{
				while(true)
					paletas.PaletasMinis.Add(GetPaletaMinis(rom,paletas.paletas.Count,offsetTablaPaleta));
			}catch{}
			paletas.PaletasMinis.SortByQuickSort();
			return paletas;
		}
        public static Paleta GetPaletaMinis(RomGba rom,int posicion,int offsetTablaPaleta = -1)
        {
            if(offsetTablaPaleta<0)
                offsetTablaPaleta= Zona.GetOffsetRom(ZonaMiniSpritesPaleta, rom).Offset;
            return Paleta.GetPaleta(rom, offsetTablaPaleta + posicion * Paleta.LENGTHHEADERCOMPLETO);
        }
        //falta set
	}
}
