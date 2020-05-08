﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonGBAFramework.Core.Mapa.Basic
{
	public class TilesetCache
	{
		private static SortedList<int, Tileset> cache = new SortedList<int, Tileset>();

		private TilesetCache() { }

		public static bool Contains(int offset)
		{
			return cache.ContainsKey(offset);
		}

		/**
		 * Pulls a tileset from the tileset cache. Create a new tileset if one is not cached.
		 * @param offset Tileset data offset
		 * @return
		 */
		public static Tileset Get(RomGba rom,int offset,int mainTSHeight, int localTSHeight)
		{
			Tileset tile;
			if (cache.ContainsKey(offset))
			{
				tile = cache[offset];
				if (tile.Modified)
				{
					tile.loadData(offset);
					tile.renderTiles(mainTSHeight,localTSHeight);
					tile.Modified = false;
				}
			
			}
			else
			{
				 tile = new Tileset(rom, offset,mainTSHeight,localTSHeight);
				cache.Add(offset, tile);

			}
			return tile;
		}

		public static void Clear()
		{
			cache.Clear();
		}

		public static void switchTileset(RomGba rom,Map loadedMap,int mainTSPalCount, int mainTSHeight, int localTSHeight)
		{
			Get(rom, loadedMap.getMapData().GlobalTileSetPtr,mainTSHeight,localTSHeight).RestaurarPaletas();
			Get(rom, loadedMap.getMapData().LocalTileSetPtr, mainTSHeight, localTSHeight).RestaurarPaletas();
			for (int j = 1; j < 5; j++)
				for (int i = mainTSPalCount - 1; i < 13; i++)
					Get(rom, loadedMap.getMapData().GlobalTileSetPtr, mainTSHeight, localTSHeight).GetPaletas(j - 1)[i] = Get(rom, loadedMap.getMapData().LocalTileSetPtr, mainTSHeight, localTSHeight).GetTodasLasPaletas()[j - 1,i];
			for (int j = 0; j < 4; j++)
				Get(rom, loadedMap.getMapData().LocalTileSetPtr, mainTSHeight, localTSHeight).SetPaletas(j, Get(rom, loadedMap.getMapData().GlobalTileSetPtr, mainTSHeight, localTSHeight).GetPaletas(j));
			Get(rom, loadedMap.getMapData().LocalTileSetPtr, mainTSHeight, localTSHeight).Refresh();
			Get(rom, loadedMap.getMapData().GlobalTileSetPtr, mainTSHeight, localTSHeight).Refresh();
			//Get(rom, loadedMap.getMapData().LocalTileSetPtr).startTileThreads();
			//Get(rom, loadedMap.getMapData().GlobalTileSetPtr).startTileThreads();
		}
	}

}