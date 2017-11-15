/*
 * Usuario: Pikachu240
 * Licencia GNU GPL V3
 */
using System;

namespace PokemonGBAFrameWork.ComandosScript
{
	/// <summary>
	/// Description of BufferStd.
	/// </summary>
	public class BufferStd:Comando
	{
		public const byte ID = 0x84;
		public const int SIZE = 4;
		public const string NOMBRE="BufferStd";
		public const string DESCRIPCION="Guarda una string estandar en el buffer especificado.";
		Byte buffer;
		Word standarString;
 
		public BufferStd(Byte buffer, Word standarString)
		{
			Buffer = buffer;
			StandarString = standarString;
 
		}
   
		public BufferStd(RomGba rom, int offset)
			: base(rom, offset)
		{
		}
		public BufferStd(byte[] bytesScript, int offset)
			: base(bytesScript, offset)
		{
		}
		public unsafe BufferStd(byte* ptRom, int offset)
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
		public Byte Buffer {
			get{ return buffer; }
			set{ buffer = value; }
		}
		public Word StandarString {
			get{ return standarString; }
			set{ standarString = value; }
		}
 
		protected override System.Collections.Generic.IList<object> GetParams()
		{
			return new Object[]{ buffer, standarString };
		}
		protected unsafe override void CargarCamando(byte* ptrRom, int offsetComando)
		{
			buffer = *(ptrRom + offsetComando);
			offsetComando++;
			standarString = new Word(ptrRom, offsetComando);
		}
		protected unsafe override void SetComando(byte* ptrRomPosicionado, params int[] parametrosExtra)
		{
			base.SetComando(ptrRomPosicionado, parametrosExtra);
			ptrRomPosicionado++;
			*ptrRomPosicionado = buffer;
			++ptrRomPosicionado; 
			Word.SetWord(ptrRomPosicionado, StandarString);
 
		}
	}
}
