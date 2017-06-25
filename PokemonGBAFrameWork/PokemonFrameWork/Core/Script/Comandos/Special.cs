﻿/*
 * Creado por SharpDevelop.
 * Usuario: Pikachu240
 * Fecha: 02/06/2017
 * Hora: 12:49
 * Licencia GNU GPL V3
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace PokemonGBAFrameWork.Script
{
	/// <summary>
	/// Description of Special.
	/// </summary>
	public class Special:Comando
	{
		public const byte ID=0x25;
		public const int SIZE=1+Word.LENGTH;
		
		short eventoALlamar;
		public Special(short eventoALlamar)
		{
			EventoALlamar=eventoALlamar;
		}
		public Special(RomGba rom,int offset):base(rom,offset)
		{
		}
		public Special(byte[] bytesScript,int offset):base(bytesScript,offset)
		{}
		public unsafe Special(byte* ptRom,int offset):base(ptRom,offset)
		{}
		public override string Descripcion {
			get {
				return "Llama al evento especial";
			}
		}

		public override byte IdComando {
			get {
				return ID;
			}
		}

		public override string Nombre {
			get {
				return "Special";
			}
		}

		public override int Size {
			get {
				return SIZE;
			}
		}

		public short EventoALlamar {
			get {
				return eventoALlamar;
			}
			set {
				eventoALlamar = value;
			}
		}
		protected unsafe override void CargarCamando(byte* ptrRom, int offsetComando)
		{
			eventoALlamar=Word.GetWord(ptrRom,offsetComando);
		}
		protected unsafe override void SetComando(byte* ptrRomPosicionado, params int[] parametrosExtra)
		{
			base.SetComando(ptrRomPosicionado, parametrosExtra);
			ptrRomPosicionado++;
			Word.SetWord(ptrRomPosicionado,eventoALlamar);
		}
	}

}