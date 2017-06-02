﻿/*
 * Creado por SharpDevelop.
 * Usuario: Pikachu240
 * Fecha: 02/06/2017
 * Hora: 13:38
 * Licencia GNU GPL V3
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace PokemonGBAFrameWork.Script
{
	/// <summary>
	/// Description of CheckSound.
	/// </summary>
	public class CheckSound:Comando
	{
		public const byte ID=0x30;

		public CheckSound(RomGba rom,int offset):base(rom,offset)
		{
		}
		public CheckSound(byte[] bytesScript,int offset):base(bytesScript,offset)
		{}
		public unsafe CheckSound(byte* ptRom,int offset):base(ptRom,offset)
		{}
		public override string Descripcion {
			get {
				return "Comprueba si esta reproduciendose el sonido,fanfare o canción";
			}
		}

		public override byte IdComando {
			get {
				return ID;
			}
		}
		public override string Nombre {
			get {
				return "CheckSound";
			}
		}
	}
}
