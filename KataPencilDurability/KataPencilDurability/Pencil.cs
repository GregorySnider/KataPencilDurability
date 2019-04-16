using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPencilDurability
{
    public class Pencil
    {
        public int Durability { get; set; }


        public string Write(string input)
        {
            StringBuilder sb = new StringBuilder();
            var letters = input.ToCharArray();

            letters.ToList().ForEach(l => WriteToBuilder(l, sb));
            

            return sb.ToString();
        }

        private void WriteToBuilder(char letter, StringBuilder stringBuilder )
        {
            char outOfInkChar = ' ';
            if (Char.IsUpper(letter))
            {
                Durability = Durability - 2;
            } else
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
