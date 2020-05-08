/*
 * Usuario: Pikachu240
 * Licencia GNU GPL V3
 */
using System;

namespace PokemonGBAFramework.Core.ComandosScript
{
	/// <summary>
	/// Description of CheckPcItem.
	/// </summary>
	public class CheckPcItem:Comando
	{
		public const byte ID = 0x4A;
		public new const int SIZE = Comando.SIZE+Word.LENGTH+Word.LENGTH;
		public const string NOMBRE="CheckPcItem";
		public const string DESCRIPCION="Mira si el player posee en su pc la cantidad del objeto especificado";

        public CheckPcItem(Word objeto, Word cantidad)
		{
			Objeto = objeto;
			Cantidad = cantidad;
 
		}
   
		public CheckPcItem(RomGba rom, int offset)
			: base(rom, offset)
		{
		}
		public CheckPcItem(byte[] bytesScript, int offset)
			: base(bytesScript, offset)
		{
		}
		public unsafe CheckPcItem(byte* ptRom, int offset)
			: base(ptRom, offset)
		{
		}
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
        public Word Objeto { get; set; }
        public Word Cantidad { get; set; }

        protected override System.Collections.Generic.IList<object> GetParams()
		{
			return new Object[]{ Objeto, Cantidad };
		}
		protected unsafe override void CargarCamando(byte* ptrRom, int offsetComando)
		{
			Objeto = new Word(ptrRom, offsetComando);
			offsetComando += Word.LENGTH;
			Cantidad = new Word(ptrRom, offsetComando);
		}
		protected unsafe override void SetComando(byte* ptrRomPosicionado, params int[] parametrosExtra)
		{
			base.SetComando(ptrRomPosicionado, parametrosExtra);
			ptrRomPosicionado+=base.Size;
			Word.SetData(ptrRomPosicionado, Objeto);
			ptrRomPosicionado += Word.LENGTH;
			Word.SetData(ptrRomPosicionado, Cantidad);
		}
	}
}