﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PokemonGBAFrameWork {
	using System;
	
	
	/// <summary>
	///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
	/// </summary>
	// StronglyTypedResourceBuilder generó automáticamente esta clase
	// a través de una herramienta como ResGen o Visual Studio.
	// Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
	// con la opción /str o recompile su proyecto de VS.
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	internal class Resources {
		
		private static global::System.Resources.ResourceManager resourceMan;
		
		private static global::System.Globalization.CultureInfo resourceCulture;
		
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Resources() {
		}
		
		/// <summary>
		///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
		/// </summary>
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Resources.ResourceManager ResourceManager {
			get {
				if (object.ReferenceEquals(resourceMan, null)) {
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PokemonGBAFrameWork.Resources", typeof(Resources).Assembly);
					resourceMan = temp;
				}
				return resourceMan;
			}
		}
		
		/// <summary>
		///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
		///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
		/// </summary>
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Globalization.CultureInfo Culture {
			get {
				return resourceCulture;
			}
			set {
				resourceCulture = value;
			}
		}
		
		/// <summary>
		///   Busca una cadena traducida similar a .text
		///.align 2
		///.thumb
		///.thumb_func
		///
		///main:
		///cmp r5, #0x0
		///bne end
		///ldr r3, =(0x8OFFSET2 +1)
		///bx r3
		///
		///end:
		///mov r0, r7
		///mov r1, #0x8
		///mov r2, r4
		///ldr r6, =(0x8OFFSET1+1)
		///bl link
		///ldr r3, =(0x8OFFSET2+1)
		///bx r3
		///
		///link:
		///bx r6
		///
		///.align 2
		///
		///.
		/// </summary>
		internal static string ASMMTBW {
			get {
				return ResourceManager.GetString("ASMMTBW", resourceCulture);
			}
		}
		
		/// <summary>
		///   Busca un recurso adaptado de tipo System.Byte[].
		/// </summary>
		internal static byte[] ASMMugshotsFR {
			get {
				object obj = ResourceManager.GetObject("ASMMugshotsFR", resourceCulture);
				return ((byte[])(obj));
			}
		}
		
		/// <summary>
		///   Busca una cadena traducida similar a .text
		///.align 2
		///.thumb
		///.thumb_func
		///
		///main:
		/// ldr r0, =(0x2022B4C)
		/// ldr r1, [r0]
		/// ldr r2, .VAR
		/// ldrb r2, [r2]
		/// cmp r2, #0x1
		/// beq uncatchable
		/// ldr r0, = (0x802D490 +1)
		/// bx r0
		///
		///uncatchable:
		/// ldr r0, = (0x802D460 +1)
		/// bx r0
		/// 
		/// 
		///
		///.align 2
		///.VAR:
		/// .word 0x020270B8 + (0xVARIABLE * 2).
		/// </summary>
		internal static string ASMPokemonInCapturable {
			get {
				return ResourceManager.GetString("ASMPokemonInCapturable", resourceCulture);
			}
		}
		
		/// <summary>
		///   Busca una cadena traducida similar a .text
		///.align 2
		///.thumb
		///.thumb_func
		///
		///shiny_hack_main:
		/// lsr r0, r4, #0x18
		/// cmp r0, #0x3
		/// bne return
		/// ldr r0, .SHINY_COUNTER
		/// ldrb r0, [r0]
		/// cmp r0, #0x0
		/// bne shiny_hack
		///
		///return:
		/// bx lr
		///
		///shiny_hack:
		/// push {r2-r5, lr}
		/// sub r3, r0, #0x1
		/// ldr r0, .SHINY_COUNTER
		/// strb r3, [r0]
		/// ldrb r4, [r0, #0x1]
		/// cmp r4, #0x0
		/// bne is_trainer
		/// add r4, r1, #0x0
		///
		///no_trainer:
		/// ldr r2, .RANDOM
		/// bl branch_r2
		/// mov r3, #0x7
		/// and r0, r3
		/// add r3, r0, #0x0
		/// ldr r2, .RANDOM
		/// bl branch_r2
		/// lsl r5, r0, #0x10		/// [resto de la cadena truncado]&quot;;.
		/// </summary>
		internal static string ASMShinyzer {
			get {
				return ResourceManager.GetString("ASMShinyzer", resourceCulture);
			}
		}
	}
}
