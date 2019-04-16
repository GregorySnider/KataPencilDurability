using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPencilDurability
{
    public class Pencil
    {
        //todo - remove default value for EraserDurability
        public Pencil(int durability, int length, int eraserDurability = 1)
        {
            this.Durability = durability;
            this.OriginalDurability = durability;
            this.Length = length;
            this.EraserDurability = eraserDurability;
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
            string spaces = "";
            if ((EraserDurability - textToErase.Length) > 0)
            {
                spaces = new string(' ', textToErase.Length);

            } else
            {
                spaces = new string(' ', EraserDurability);
                textToErase = textToErase.Substring(textToErase.Length - EraserDurability);
                EraserDurability = 0;
            }
            int lastIdx = paper.LastIndexOf(textToErase);
            if (lastIdx > 0)
            {
                return paper.Substring(0, lastIdx) + spaces + paper.Substring(lastIdx + textToErase.Length, (paper.Length - (lastIdx + textToErase.Length)));
            }
            else {
                return paper;
            }
        }

        private void WriteToBuilder(char letter, StringBuilder stringBuilder )
        {
            char outOfInkChar = ' ';
            if (Char.IsUpper(letter))
            {
                Durability = Durability - 2;

            } else if(letter != ' ') 
                //TODO - implement handling newlines
                //Research - will I need to detect the '\' character and interpret the next letter myself
                //Or is there a better way to handle special characters like this?
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
