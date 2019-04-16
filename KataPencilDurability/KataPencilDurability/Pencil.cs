using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPencilDurability
{
    public class Pencil
    {
        //todo - review .net coding standard for naming conventions, probably shouldn't duplicate
        //constructor input with property names
        //todo - remove default value for EraserDurability
        public Pencil(int Durability, int Length, int EraserDurability = 1)
        {
            this.Durability = Durability;
            this.OriginalDurability = Durability;
            this.Length = Length;
            this.EraserDurability = EraserDurability;
        }


        public int OriginalDurability { get; private set; }
        public int Durability {  get; private set; }
        public int EraserDurability { get; private set; }

        public int Length { get; set; }

        public void Sharpen()
        {
            if (Length == 0)
            {
                return;
            }
            if (Length >= 1)
            {
                Length = Length - 1;
                Durability = OriginalDurability;
            }
            return;
        }

        public string Write(string input)
        {
            StringBuilder sb = new StringBuilder();
            var letters = input.ToCharArray();

            letters.ToList().ForEach(l => WriteToBuilder(l, sb));
            

            return sb.ToString();
        }

        public string Erase(string paper, string textToErase)
        {
            //todo - guard/verify/test against null/empty strings

            string spaces = new string(' ', textToErase.Length);
            int lastIdx = paper.LastIndexOf(textToErase);
            return paper.Substring(0, lastIdx) + spaces + paper.Substring(lastIdx + textToErase.Length, (paper.Length - (lastIdx + textToErase.Length)));
        }

        private void WriteToBuilder(char letter, StringBuilder stringBuilder )
        {
            char outOfInkChar = ' ';
            if (Char.IsUpper(letter))
            {
                Durability = Durability - 2;

            } else if(letter != ' ') 
                //TODO - implement handling newlines
                // && letter != '\r' && letter != '\n')
            {
                Durability = Durability - 1;
            }
            if (Durability >= 0)
            {
                stringBuilder.Append(letter);
            }
            else
            {
                stringBuilder.Append(outOfInkChar);
            }
        }
    }
}
