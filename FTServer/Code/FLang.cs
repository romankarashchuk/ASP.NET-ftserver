using System;
using System.Collections.Generic;

namespace FTServer
{
    //Language
    public class Lang
    {
        public static Lang Instance = new Lang();

        HashSet<Char> set;

        private Lang()
        {

            String s = "!\"@$%&'()*+,./:;<=>?[\\]^_`{|}~\r\n"; //@-
            s += "， 　，《。》、？；：‘’“”【｛】｝——=+、｜·～！￥%……&*（）"; //@-#
            s += "｀～！＠￥％……—×（）——＋－＝【】｛｝：；’＇”＂，．／＜＞？’‘”“";//＃
            s += "� ★☆,。？,　！";
            s += "©»¥「」";
            s += "[¡, !, \", ', (, ), -, °, :, ;, ?]-\"#";

            set = new HashSet<Char>();
            foreach (char c in s.toCharArray())
            {
                if (isWord(c))
                {
                    continue;
                }
                set.add(c);
            }

            set.add(' ');
            set.add('　');

            set.add((char)0);
            set.add((char)0x09);
            set.add((char)8203);
            // http://www.unicode-symbol.com/block/Punctuation.html
            for (int i = 0x2000; i <= 0x206F; i++)
            {
                set.add((char)i);
            }
            set.add((char)0x0E00);//Thai

            //https://unicode-table.com/en/blocks/arabic/
            //Punctuation Arabic
            set.add((char)0x0609);
            set.add((char)0x060A);
            set.add((char)0x060B);
            set.add((char)0x060C);
            set.add((char)0x060D);

            set.add((char)0x061B);
            set.add((char)0x061E);
            set.add((char)0x061F);

            set.add((char)0x066A);
            set.add((char)0x066B);
            set.add((char)0x066C);
            set.add((char)0x066D);

            set.add((char)0x06D4);

            //https://unicode-table.com/en/blocks/hebrew/
            set.add((char)0x05BE);
            set.add((char)0x05C0);
            set.add((char)0x05C3);

            set.add((char)0x05C6);

            set.add((char)0x05F3);
            set.add((char)0x05F4);

            //Devanagari
            set.add((char)0x0964);
            set.add((char)0x0965);

            //Katakana
            set.add((char)0x30A0);
            set.add((char)0x30FB);
            set.add((char)0x30FC);
        }

        public bool isPunctuation(char c)
        {
            return set.contains(c);
        }
        public bool isWord(char c)
        {
            // https://unicode-table.com/en/blocks/basic-latin/
            // 0-9
            if (c >= 0x30 && c <= 0x39)
            {
                return true;
            }
            // A - Z
            if (c >= 0x41 && c <= 0x5A)
            {
                return true;
            }
            // a - z
            if (c >= 0x61 && c <= 0x7A)
            {
                return true;
            }

            // https://unicode-table.com/en/blocks/latin-1-supplement/
            if (c >= 0xC0 && c <= 0xFF)
            {
                return true;
            }

            // https://unicode-table.com/en/blocks/latin-extended-a/
            if (c >= 0x0100 && c <= 0x017F)
            {
                return true;
            }

            // https://unicode-table.com/en/blocks/latin-extended-b/
            if (c >= 0x0180 && c <= 0x024F)
            {
                return true;
            }

            // https://unicode-table.com/en/blocks/ipa-extensions/
            if (c >= 0x0250 && c <= 0x02AF)
            {
                return true;
            }

            // https://unicode-table.com/en/blocks/combining-diacritical-marks/
            if (c >= 0x0300 && c <= 0x036F)
            {
                return true;
            }

            // https://unicode-table.com/en/blocks/greek-coptic/
            if (c >= 0x0370 && c <= 0x03FF)
            {
                return true;
            }

            //Russian
            // https://unicode-table.com/en/blocks/cyrillic/
            // https://unicode-table.com/en/blocks/cyrillic-supplement/
            if (c >= 0x0400 && c <= 0x052F)
            {
                return true;
            }

            // https://unicode-table.com/en/blocks/armenian/
            if (c >= 0x0530 && c <= 0x058F)
            {
                return true;
            }

            if (isWordRight2Left(c))
            {
                return true;
            }

            // https://unicode-table.com/en/blocks/devanagari/
            // India
            if (c >= 0x0900 && c <= 0x097F)
            {
                return true;
            }

            //Korean
            // https://unicode-table.com/en/blocks/hangul-jamo/
            if (c >= 0x1100 && c <= 0x11FF)
            {
                return true;
            }
            //https://unicode-table.com/en/blocks/hangul-jamo-extended-b/
            if (c >= 0xD7B0 && c <= 0xD7FF)
            {
                return true;
            }
            //https://unicode-table.com/en/blocks/hangul-syllables/        
            if (c >= 0xAC00 && c <= 0xD7AF)
            {
                return true;
            }

            //Japanese
            /*
            if (c >= 0x3040 && c <= 0x312F)
            {
                return true;
            }
            */


            // https://unicode-table.com/en/blocks/latin-extended-additional/
            if (c >= 0x1E00 && c <= 0x1EFF)
            {
                return true;
            }
            // https://unicode-table.com/en/blocks/greek-extended/
            if (c >= 0x1F00 && c <= 0x1FFF)
            {
                return true;
            }

            //special
            return c == '-' || c == '#';
        }

        private bool isWordRight2Left(char c)
        {
            // https://unicode-table.com/en/blocks/hebrew/
            // https://www.compart.com/en/unicode/block/U+0590
            if (c >= 0x0590 && c <= 0x05FF)
            {
                return true;
            }
            // https://unicode-table.com/en/blocks/arabic/
            // https://www.compart.com/en/unicode/bidiclass/AL
            if (c >= 0x0600 && c <= 0x06FF)
            {
                return true;
            }

            // https://unicode-table.com/en/blocks/arabic-supplement/
            if (c >= 0x0750 && c <= 0x077F)
            {
                return true;
            }
            // https://unicode-table.com/en/blocks/arabic-extended-a/
            if (c >= 0x08A0 && c <= 0x08FF)
            {
                return true;
            }

            return false;
        }


    }
}