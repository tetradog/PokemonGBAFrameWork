/*
 * Usuario: Pikachu240
 * Licencia GNU GPL V3
 */
using System;

namespace PokemonGBAFrameWork.ComandosScript
{
 /// <summary>
 /// Description of CheckItemType.
 /// </summary>
 public class CheckItemType:Comando
 {
  public const byte ID=0x48;
  public const int SIZE=3;
  short objeto;
 
  public CheckItemType(short objeto) 
  {
   Objeto=objeto;
 
  }
   
  public CheckItemType(RomGba rom,int offset):base(rom,offset)
  {
  }
  public CheckItemType(byte[] bytesScript,int offset):base(bytesScript,offset)
  {}
  public unsafe CheckItemType(byte* ptRom,int offset):base(ptRom,offset)
  {}
  public override string Descripcion {
   get {
    return "Comprueba el tipo del objeto, el resultado se guarda en LASTRESULT";
   }
  }

  public override byte IdComando {
   get {
    return ID;
   }
  }
  public override string Nombre {
   get {
    return "CheckItemType";
   }
  }
  public override int Size {
   get {
    return SIZE;
   }
  }
                         public short Objeto
{
get{ return objeto;}
set{objeto=value;}
}
 
  protected override System.Collections.Generic.IList<object> GetParams()
  {
   return new Object[]{objeto};
  }
  protected unsafe override void CargarCamando(byte* ptrRom, int offsetComando)
  {
   objeto=Word.GetWord(ptrRom,offsetComando);
 offsetComando+=Word.LENGTH;
 
  }
  protected unsafe override void SetComando(byte* ptrRomPosicionado, params int[] parametrosExtra)
  {
    base.SetComando(ptrRomPosicionado,parametrosExtra);
   Word.SetWord(ptrRomPosicionado,Objeto);
 ptrRomPosicionado+=Word.LENGTH;
 
  }
 }
}