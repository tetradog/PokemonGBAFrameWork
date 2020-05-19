/*
 * Usuario: Pikachu240
 * Licencia GNU GPL V3
 */
using System;

namespace PokemonGBAFramework.Core.ComandosScript
{
	/// <summary>
	/// Description of FedeScreen.
	/// </summary>
	public class FadeScreen:Comando
	{
		public enum EfectoFedeScreen:byte{
			Entrar=0x0,
			Salir=0x1
				
		}
		public const byte ID=0x97;
		public new const int SIZE=Comando.SIZE+1;
        public const string NOMBRE = "FedeScreen";
        public const string DESCRIPCION = "Desavanece la pantalla entrando o saliendo";
        public FadeScreen(Byte efectoDeDesvanecimiento)
		{
			EfectoDeDesvanecimiento=efectoDeDesvanecimiento;
			
		}
		
		public FadeScreen(ScriptManager scriptManager,RomGba rom,int offset):base(scriptManager,rom,offset)
		{
		}
		public FadeScreen(ScriptManager scriptManager,byte[] bytesScript,int offset):base(scriptManager,bytesScript,offset)
		{}
		public unsafe FadeScreen(ScriptManager scriptManager,byte* ptRom,int offset):base(scriptManager,ptRom,offset)
		{}
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
        public Byte EfectoDeDesvanecimiento { get; set; }
        public EfectoFedeScreen Efecto
		{
			get{return (EfectoFedeScreen)EfectoDeDesvanecimiento;}
			set{EfectoDeDesvanecimiento=(byte)value;}
			
		}
		protected override System.Collections.Generic.IList<object> GetParams()
		{
			return new Object[]{EfectoDeDesvanecimiento};
		}
		protected unsafe override void CargarCamando(ScriptManager scriptManager,byte* ptrRom, int offsetComando)
		{
			EfectoDeDesvanecimiento=*(ptrRom+offsetComando);			
		}
		public override byte[] GetBytesTemp()
		{
			byte[] data=new byte[Size];
			ptrRomPosicionado+=base.Size;
			*ptrRomPosicionado=EfectoDeDesvanecimiento;
		}
	}
}
