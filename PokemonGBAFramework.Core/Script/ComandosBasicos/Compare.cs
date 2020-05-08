﻿/*
 * Creado por SharpDevelop.
 * Usuario: Pikachu240
 * Fecha: 02/06/2017
 * Hora: 8:09
 * Licencia GNU GPL V3
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace PokemonGBAFramework.Core.ComandosScript
{
	/// <summary>
	/// Description of Compare.
	/// </summary>
	public class Compare:Comando
	{
		public const int ID=0x21;
		public new const int SIZE=Comando.SIZE+Word.LENGTH+Word.LENGTH;
        public const string NOMBRE = "Compare";
        public const string DESCRIPCION= "Compara el valor de la variable con el valor pasado como parametro";

        public Compare(Word variable,Word valorAComparar)
		{
			Variable=variable;
			ValorAComparar=valorAComparar;
		}
		public Compare(RomGba rom,int offset):base(rom,offset)
		{}
		public Compare(byte[] bytesScript,int offset):base(bytesScript,offset)
		{}
		public unsafe Compare(byte* ptRom,int offset):base(ptRom,offset)
		{}

		#region implemented abstract members of Comando

		public override string Descripcion {
			get {
                return DESCRIPCION;
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

        public Word Variable { get; set; }
        public Word ValorAComparar { get; set; }
        #endregion
        protected override System.Collections.Generic.IList<object> GetParams()
		{
			return new Object[]{Variable,ValorAComparar};
		}
		protected unsafe override void CargarCamando(byte* ptrRom, int offsetComando)
		{
			Variable=new Word(ptrRom,offsetComando);
			ValorAComparar=new Word(ptrRom,offsetComando+Word.LENGTH);
		}
		protected unsafe override void SetComando(byte* ptrRomPosicionado, params int[] parametrosExtra)
		{
			base.SetComando(ptrRomPosicionado, parametrosExtra);
			ptrRomPosicionado+=base.Size;
			Word.SetData(ptrRomPosicionado,Variable);
			ptrRomPosicionado+=Word.LENGTH;
			Word.SetData(ptrRomPosicionado,ValorAComparar);
		}
	}
}