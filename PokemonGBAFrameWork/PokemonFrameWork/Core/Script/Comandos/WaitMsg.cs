/*
 * Usuario: Pikachu240
 * Licencia GNU GPL V3
 */
using System;

namespace PokemonGBAFrameWork.ComandosScript
{
 /// <summary>
 /// Description of WaitMsg.
 /// </summary>
 public class WaitMsg:Comando
 {
  public const byte ID=0x66;
  public const int SIZE=1;
  
  public WaitMsg() 
  {
   
  }
   
  public WaitMsg(RomGba rom,int offset):base(rom,offset)
  {
  }
  public WaitMsg(byte[] bytesScript,int offset):base(bytesScript,offset)
  {}
  public unsafe WaitMsg(byte* ptRom,int offset):base(ptRom,offset)
  {}
  public override string Descripcion {
   get {
    return "Espera a que preparemsg acabe";
   }
  }

  public override byte IdComando {
   get {
    return ID;
   }
  }
  public override string Nombre {
   get {
    return "WaitMsg";
   }
  }
  public override int Size {
   get {
    return SIZE;
   }
  }
                         
  protected override System.Collections.Generic.IList<object> GetParams()
  {
   return new Object[]{};
  }
  protected unsafe override void CargarCamando(byte* ptrRom, int offsetComando)
  {
   
  }
  protected unsafe override void SetComando(byte* ptrRomPosicionado, params int[] parametrosExtra)
  {
    base.SetComando(ptrRomPosicionado,parametrosExtra);
   
  }
 }
}
