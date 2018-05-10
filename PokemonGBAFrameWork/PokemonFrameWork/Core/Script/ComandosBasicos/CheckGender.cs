/*
 * Usuario: Pikachu240
 * Licencia GNU GPL V3
 */
using System;

namespace PokemonGBAFrameWork.ComandosScript
{
	/// <summary>
	/// Description of CheckGender.
	/// </summary>
	public class CheckGender:Comando
	{
		public const byte ID = 0xA0;
		public const int SIZE = 1;
		public const string NOMBRE="CheckGender";
		public const string DESCRIPCION="Comprueba si el jugador es chico o chica y lo guarda en LASTRESULT.";
  
		public CheckGender()
		{
   
		}
   
		public CheckGender(RomGba rom, int offset)
			: base(rom, offset)
		{
		}
		public CheckGender(byte[] bytesScript, int offset)
			: base(bytesScript, offset)
		{
		}
		public unsafe CheckGender(byte* ptRom, int offset)
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
                         
		protected override System.Collections.Generic.IList<object> GetParams()
		{
			return new Object[]{ };
		}

	}
}