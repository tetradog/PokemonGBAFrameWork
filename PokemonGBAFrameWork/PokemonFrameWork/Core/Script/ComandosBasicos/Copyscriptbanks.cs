﻿/*
 * Creado por SharpDevelop.
 * Usuario: Pikachu240
 * Fecha: 01/06/2017
 * Hora: 2:59
 * Licencia GNU GPL V3
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace PokemonGBAFrameWork.ComandosScript
{
	/// <summary>
	/// Description of Copyscriptbanks.
	/// </summary>
	public class Copyscriptbanks:Comando
	{
		public const byte ID=0x14;
		public const int SIZE=0x3;
        public const string NOMBRE = "Copyscriptbanks";
        byte bankDestination;
		byte bankSource;
		
		public Copyscriptbanks(byte bankDestination,byte bankSource)
		{
			BankDestination=bankDestination;
			BankSource=bankSource;
		}
		public Copyscriptbanks(RomGba rom,int offset):base(rom,offset)
		{}
		public Copyscriptbanks(byte[] bytesScript,int offset):base(bytesScript,offset)
		{}
		public unsafe Copyscriptbanks(byte* ptRom,int offset):base(ptRom,offset)
		{}
		
		#region implemented abstract members of Comando
		public override string Descripcion {
			get {
				return "Copia un bank script a otro";
			}
		}
		public override byte IdComando {
			get {
				return ID;
			}
		}
		public override string Nombre {
			get {
				return NOMBRE;
			}
		}
		public override int Size {
			get {
				return SIZE;
			}
		}
		#endregion

		public byte BankDestination {
			get {
				return bankDestination;
			}
			set {
				bankDestination = value;
			}
		}

		public byte BankSource {
			get {
				return bankSource;
			}
			set {
				bankSource = value;
			}
		}
		protected override System.Collections.Generic.IList<object> GetParams()
		{
			return new Object[]{BankDestination,BankSource};
		}
		protected unsafe override void CargarCamando(byte* ptrRom, int offsetComando)
		{
			bankDestination=ptrRom[offsetComando];
			bankSource=ptrRom[offsetComando+1];
		}
		protected unsafe override void SetComando(byte* ptrRomPosicionado, params int[] parametrosExtra)
		{
			base.SetComando(ptrRomPosicionado, parametrosExtra);
			ptrRomPosicionado++;
			*ptrRomPosicionado=bankDestination;
			ptrRomPosicionado++;
			*ptrRomPosicionado=bankSource;
		}
	}
}
