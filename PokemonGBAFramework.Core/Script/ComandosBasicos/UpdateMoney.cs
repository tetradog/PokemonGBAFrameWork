/*
 * Usuario: Pikachu240
 * Licencia GNU GPL V3
 */
using System;

namespace PokemonGBAFramework.Core.ComandosScript
{
	/// <summary>
	/// Description of UpdateMoney.
	/// </summary>
	public class UpdateMoney:Comando
	{
		public const byte ID = 0x95;
		public const int SIZE = 4;
		Byte coordenadaX;
		Byte coordenadaY;
		Byte comprobarEjecucionComando;
 
		public UpdateMoney(Byte coordenadaX, Byte coordenadaY, Byte comprobarEjecucionComando)
		{
			CoordenadaX = coordenadaX;
			CoordenadaY = coordenadaY;
			ComprobarEjecucionComando = comprobarEjecucionComando;
 
		}
   
		public UpdateMoney(ScriptManager scriptManager,RomGba rom, int offset)
			 : base(scriptManager,rom, offset)
		{
		}
		public UpdateMoney(ScriptManager scriptManager,byte[] bytesScript, int offset)
			: base(scriptManager,bytesScript, offset)
		{
		}
		public unsafe UpdateMoney(ScriptManager scriptManager,byte* ptRom, int offset)
			: base(scriptManager,ptRom, offset)
		{
		}
		public override string Descripcion {
			get {
				return "Actualiza el dinero mostrado.";
			}
		}

		public override byte IdComando {
			get {
				return ID;
			}
		}
		public override string Nombre {
			get {
				return "UpdateMoney";
			}
		}
		public override int Size {
			get {
				return SIZE;
			}
		}
		public Byte CoordenadaX {
			get{ return coordenadaX; }
			set{ coordenadaX = value; }
		}
		public Byte CoordenadaY {
			get{ return coordenadaY; }
			set{ coordenadaY = value; }
		}
		public Byte ComprobarEjecucionComando {
			get{ return comprobarEjecucionComando; }
			set{ comprobarEjecucionComando = value; }
		}
 
		protected override System.Collections.Generic.IList<object> GetParams()
		{
			return new Object[]{ coordenadaX, coordenadaY, comprobarEjecucionComando };
		}
		protected unsafe override void CargarCamando(ScriptManager scriptManager,byte* ptrRom, int offsetComando)
		{
			coordenadaX = ptrRom[offsetComando];
			offsetComando++;
			coordenadaY = ptrRom[offsetComando];
			offsetComando++;
			comprobarEjecucionComando = ptrRom[offsetComando];
		}
		public override byte[] GetBytesTemp()
		{
			byte[] data=new byte[Size];
			ptrRomPosicionado++;
			*ptrRomPosicionado = coordenadaX;
			++ptrRomPosicionado; 
			*ptrRomPosicionado = coordenadaY;
			++ptrRomPosicionado; 
			*ptrRomPosicionado = comprobarEjecucionComando;
		}
	}
}
