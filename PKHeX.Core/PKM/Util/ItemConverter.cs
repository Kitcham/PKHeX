﻿using System;
using System.Collections.Generic;

namespace PKHeX.Core
{
    /// <summary>
    /// Logic for converting Item IDs between the generation specific value sets.
    /// </summary>
    internal static class ItemConverter
    {
        /// <summary>Unused item ID, placeholder for item/sprite finding</summary>
        private const ushort NaN = 128;

        /// <summary>
        /// Checks if the item can be kept during 3->4 conversion.
        /// </summary>
        /// <param name="item">Generation 3 Item ID.</param>
        /// <returns>True if transferrable, False if not transferrable.</returns>
        public static bool IsItemTransferrable34(ushort item) => item != NaN && item > 0;

        /// <summary>
        /// Converts a Generation 3 Item ID to Generation 4+ Item ID.
        /// </summary>
        /// <param name="g3val">Generation 3 Item ID.</param>
        /// <returns>Generation 4+ Item ID.</returns>
        public static ushort GetG4Item(ushort g3val) => g3val > arr3.Length ? NaN : arr3[g3val];

        /// <summary>
        /// Converts a Generation 2 Item ID to Generation 4+ Item ID.
        /// </summary>
        /// <param name="g2val">Generation 2 Item ID.</param>
        /// <returns>Generation 4+ Item ID.</returns>
        public static ushort GetG4Item(byte g2val) => g2val > arr2.Length ? NaN : arr2[g2val];

        /// <summary>
        /// Converts a Generation 4+ Item ID to Generation 3 Item ID.
        /// </summary>
        /// <param name="g4val">Generation 4+ Item ID.</param>
        /// <returns>Generation 3 Item ID.</returns>
        public static ushort GetG3Item(ushort g4val)
        {
            if (g4val == NaN)
                return 0;
            int index = Array.IndexOf(arr3, g4val);
            return (ushort)Math.Max(0, index);
        }

        /// <summary>
        /// Converts a Generation 4+ Item ID to Generation 2 Item ID.
        /// </summary>
        /// <param name="g4val">Generation 4+ Item ID.</param>
        /// <returns>Generation 2 Item ID.</returns>
        public static byte GetG2Item(ushort g4val)
        {
            if (g4val == NaN)
                return 0;
            int index = Array.IndexOf(arr2, g4val);
            return (byte)Math.Max(0, index);
        }

        #region Item Mapping Tables
        /// <summary> Gen2 items (index) and their corresponding Gen4 item ID (value) </summary>
        private static readonly ushort[] arr2 =
        {
            000, 001, 002, 213, 003, 004, NaN, 450, 081, 018, // 0
            019, 020, 021, 022, 023, 024, 025, 026, 017, 078, // 1
            079, 041, 082, 083, 084, NaN, 045, 046, 047, 048, // 2
            256, 049, 050, 060, 085, 257, 092, 063, 027, 028, // 3
            029, 055, 076, 077, 056, NaN, 030, 031, 032, 057, // 4
            NaN, 058, 059, 061, 444, NaN, NaN, 216, 445, 446, // 5
            NaN, 447, 051, 038, 039, 040, 478, 464, 456, 484, // 6
            NaN, 482, 033, 217, 151, NaN, 237, 244, 149, 153, // 7
            152, 245, 221, 156, 150, 485, 086, 087, 222, 487, // 8
            NaN, 223, 486, 488, 224, 243, 248, 490, 241, 491, // 9
            NaN, 489, 240, 473, NaN, 259, 228, 246, 242, 157, // 10
            088, 089, 229, 247, 504, NaN, NaN, 239, 258, 230, // 11
            NaN, 034, 035, 036, 037, 238, 231, 475, 481, NaN, // 12
            NaN, 090, 091, 476, 480, NaN, NaN, NaN, 249, 043, // 13
            232, NaN, NaN, 233, 250, NaN, 234, NaN, NaN, NaN, // 14
            154, 235, NaN, NaN, NaN, NaN, 044, 495, NaN, 493, // 15
            NaN, 492, NaN, 236, 497, 498, 496, NaN, NaN, 080, // 16
            NaN, NaN, 252, 155, 158, 477, NaN, 500, 483, NaN, // 17
            NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, // 18
            NaN, 328, 329, 330, 331, 331, 332, 333, 334, 335, // 19
            336, 337, 338, 339, 340, 341, 342, 343, 344, 345, // 20
            346, 347, 348, 349, 350, 351, 352, 353, 354, 355, // 21
            355, 356, 357, 358, 359, 360, 361, 362, 363, 364, // 22
            365, 366, 367, 368, 369, 370, 371, 372, 373, 374, // 23
            375, 376, 377, 420, 421, 422, 423, 424, 425, 426, // 24
            427, NaN, NaN, NaN, NaN, NaN,
        };

        /// <summary> Gen3 items (index) and their corresponding Gen4 item ID (value) </summary>
        private static readonly ushort[] arr3 =
        {
            000, 001, 002, 003, 004, 005, 006, 007, 008, 009,
            010, 011, 012, 017, 018, 019, 020, 021, 022, 023,
            024, 025, 026, 027, 028, 029, 030, 031, 032, 033,
            034, 035, 036, 037, 038, 039, 040, 041, 042, 065,
            066, 067, 068, 069, 043, 044, 070, 071, 072, 073,
            074, 075, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN,
            NaN, NaN, NaN, 045, 046, 047, 048, 049, 050, 051,
            052, 053, NaN, 055, 056, 057, 058, 059, 060, 061,
            063, 064, NaN, 076, 077, 078, 079, NaN, NaN, NaN,
            NaN, NaN, NaN, 080, 081, 082, 083, 084, 085, NaN,
            NaN, NaN, NaN, 086, 087, NaN, 088, 089, 090, 091,
            092, 093, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN,
            NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN,
            NaN, NaN, NaN, 149, 150, 151, 152, 153, 154, 155,
            156, 157, 158, 159, 160, 161, 162, 163, 164, 165,
            166, 167, 168, 169, 170, 171, 172, 173, 174, 175,
            176, 177, 178, 179, 180, 181, 182, 183, 201, 202,
            203, 204, 205, 206, 207, 208, NaN, NaN, NaN, 213,
            214, 215, 216, 217, 218, 219, 220, 221, 222, 223,
            224, 225, 226, 227, 228, 229, 230, 231, 232, 233,
            234, 235, 236, 237, 238, 239, 240, 241, 242, 243,
            244, 245, 246, 247, 248, 249, 250, 251, 252, 253,
            254, 255, 256, 257, 258, 259, NaN, NaN, NaN, NaN,
            NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN,
            NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN,
            NaN, NaN, NaN, NaN, 260, 261, 262, 263, 264,

            NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN,
            NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN,
            NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN, NaN,
            328, 329, 330, 331, 332, 333, 334, 335, 336, 337,
            338, 339, 340, 341, 342, 343, 344, 345, 346, 347,
            348, 349, 350, 351, 352, 353, 354, 355, 356, 357,
            358, 359, 360, 361, 362, 363, 364, 365, 366, 367,
            368, 369, 370, 371, 372, 373, 374, 375, 376, 377,
        };
        #endregion

        /// <summary>
        /// Converts a Generation 1 (Teru-sama) Item ID to Generation 2 Item ID.
        /// </summary>
        /// <param name="g1val">Gen1 Item ID</param>
        /// <returns>Gen2 Item ID</returns>
        /// <remarks>https://github.com/pret/pokecrystal/blob/edb624c20ceb50eef9d73a5df0ac041cc156dd32/engine/link/link.asm#L1093-L1115</remarks>
        private static int GetTeruSamaItem(int g1val)
        {
            switch (g1val)
            {
                case 0x19: return 0x92; // Leftovers
                case 0x2D: return 0x53; // Bitter Berry
                case 0x32: return 0xAE; // Leftovers

                case 0x5A:
                case 0x64:
                case 0x78:
                case 0x87:
                case 0xBE:
                case 0xC3:
                case 0xDC:
                case 0xFA:
                case 0xFF:
                    return 0xAD; // Berry

                default: return g1val;
            }
        }

        public static int GetG2ItemTransfer(int g1val)
        {
            if (!IsItemTransferrable12((ushort) g1val))
                return GetTeruSamaItem(g1val);
            return g1val;
        }

        public static bool IsItemTransferrable12(ushort item) => ((IList<ushort>) Legal.HeldItems_GSC).Contains(item);

        /// <summary>
        /// Gets a format specific <see cref="PKM.HeldItem"/> value depending on the desired format and the provided item index &amp; origin format.
        /// </summary>
        /// <param name="item">Held Item to apply</param>
        /// <param name="srcFormat">Format from importing</param>
        /// <param name="destFormat">Format required for holder</param>
        public static int GetFormatHeldItemID(int item, int srcFormat, int destFormat)
        {
            if (item <= 0)
                return 0;

            if (destFormat != srcFormat && srcFormat <= 3) // past gen items
            {
                if (destFormat > 3) // try remapping
                    return item = srcFormat == 2 ? GetG4Item((byte)item) : GetG4Item((ushort)item);

                if (destFormat > srcFormat) // can't set past gen items
                    return 0;

                // ShowdownSet checks gen3 then gen2. For gen2 collisions (if any?) remap 3->4->2.
                item = GetG4Item((ushort)item);
                item = GetG2Item((ushort)item);
                if (item <= 0)
                    return 0;
            }

            switch (destFormat)
            {
                case 3: return GetG3Item((ushort)item);
                case 2: return (byte)item;
                case 1: return 0;
                default: return item;
            }
        }
    }
}
